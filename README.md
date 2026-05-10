# dotnet-pinvoke-bench

Benchmarks for comparing .NET P/Invoke marshalling strategies when passing
buffers (`byte[]`, `byte*` + `fixed`, `ref byte` + `MemoryMarshal.GetReference`,
`Span<byte>` via `[LibraryImport]`, with and without `[SuppressGCTransition]`)
to a native function.

The native side is a tiny Zig library that cross-compiles to Windows / Linux /
macOS without needing platform-specific toolchains.

## Layout

```
native/                 Zig sources + build script
  bench.zig             Two trivial export fns: bench_fill, bench_noop
  build.zig             Cross-compiles to all RIDs in one invocation
  build.zig.zon         Pins minimum_zig_version

benchmark/              BenchmarkDotNet project (net48;net8.0;net10.0)
  PInvokeBench.csproj
  Benchmarks.cs
  Program.cs

runtimes/<rid>/native/  Build output (gitignored)
                        bench.dll / libbench.so / libbench.dylib

run.ps1 / run.sh        One-shot orchestrator: zig build + dotnet run
```

## Prerequisites

- [Zig](https://ziglang.org/download/) 0.14+ on `PATH` (only for building the
  native shim; runtime doesn't need it).
- .NET SDK with workloads for the TFMs you want to benchmark — typically
  .NET 8 SDK is enough; install the .NET 10 SDK if you want net10.0 numbers.
- On Windows, .NET Framework 4.8 developer pack if benchmarking net48.

## Quickstart

```powershell
# Windows
.\run.ps1                          # net8.0 only (default)
.\run.ps1 net8.0 net10.0 net48     # one run per TFM, sequentially
```

```bash
# Linux / macOS
./run.sh                           # net8.0 only (default)
./run.sh net8.0 net10.0            # one run per TFM, sequentially
```

The orchestrator builds the native shim with `zig build -Doptimize=ReleaseFast`
(producing artefacts for win-x64, linux-x64, linux-arm64, osx-x64, osx-arm64
in one invocation), then runs BenchmarkDotNet for each requested TFM. Reports
land in `benchmark/BenchmarkDotNet.Artifacts/results/`.

To filter benchmarks or change BDN job mode:

```powershell
.\run.ps1 net8.0 -Filter '*Noop*'
.\run.ps1 net8.0 -Job Default       # full statistical run; ~30s/benchmark
```

```bash
FILTER='*Noop*' ./run.sh net8.0
JOB=Default     ./run.sh net8.0
```

## Manual workflow (without the orchestrator)

```bash
# 1. Build native artefacts for all RIDs
cd native && zig build -Doptimize=ReleaseFast && cd ..

# 2. Run benchmarks for the desired TFM
cd benchmark
dotnet run -c Release -f net8.0  -- --filter '*' --job Short
dotnet run -c Release -f net10.0 -- --filter '*' --job Short
dotnet run -c Release -f net48   -- --filter '*' --job Short    # Windows only
```

## Variants under test

`FillBenchmarks` (calls `bench_fill`, which is a `memset` on the native side):

| # | Pattern                                                   | net48 | net8 / net10 |
|---|-----------------------------------------------------------|:-----:|:------------:|
| 1 | `[DllImport]` + `byte[]`                                  |  ✅   |     ✅       |
| 2 | `[DllImport]` + `byte*` + `fixed`                         |  ✅   |     ✅       |
| 3 | `[DllImport]` + `ref byte` + `MemoryMarshal.GetReference` |  ✅   |     ✅       |
| 4 | `[LibraryImport]` + `Span<byte>`                          |  —    |     ✅       |
| 5 | `[LibraryImport]` + `ref byte`                            |  —    |     ✅       |
| 6 | `[LibraryImport]` + `Span<byte>` + `[SuppressGCTransition]` | —   |     ✅       |
| 7 | `[LibraryImport]` + `ref byte`  + `[SuppressGCTransition]`  | —   |     ✅       |

`NoopBenchmarks` (calls `bench_noop`, native side returns immediately) measures
pure call/transition overhead independent of buffer-fill cost.

## What you're likely to see

- For **blittable** parameters, V2 / V3 / V4 / V5 land within ±1–2 ns of each
  other on net8+. The compiler/runtime converges on the same generated call site.
- On **net48**, V2/V3 (`byte*`/`ref byte`) are noticeably slower than V1
  (`byte[]`) at small sizes — the legacy P/Invoke stub for `byte[]` is the
  best-optimised path; `ref` and pointer paths take a different route.
- `[SuppressGCTransition]` (V6/V7) is the **biggest lever**: at small sizes it
  drops the call to ~2 ns by skipping the cooperative GC handshake. Only safe
  when the native function is short, non-blocking, and doesn't call back into
  managed code (a `memset` qualifies; arbitrary library calls do not).
- At larger `Size` values (e.g. 4096 bytes), the actual `memset` work dominates
  and all variants converge — marshalling-strategy choice becomes invisible.

## License

MIT — see [LICENSE](LICENSE).
