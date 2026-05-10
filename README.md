# dotnet-pinvoke-bench

Benchmarks for comparing .NET P/Invoke marshalling strategies when passing buffers to a native function.

(`byte[]`, `byte*` + `fixed`, `ref byte` + `MemoryMarshal.GetReference`,
`Span<byte>` via `[LibraryImport]`, with and without `[SuppressGCTransition]`)
to a native function.

The native side is a tiny Zig library that cross-compiles to Windows / Linux / macOS without needing platform-specific toolchains.

## Prerequisites

- [Zig](https://ziglang.org/download/) 0.14+ on `PATH`.
- .NET SDK with workloads for the TFMs you want to benchmark.

## Quickstart

```sh
# Windows
.\run.ps1                          # net8.0 only (default)
.\run.ps1 net8.0 net10.0 net48     # one run per TFM, sequentially

# Linux / macOS
./run.sh                           # net8.0 only (default)
./run.sh net8.0 net10.0            # one run per TFM, sequentially
```

The orchestrator builds the native shim with `zig build -Doptimize=ReleaseFast` then runs BenchmarkDotNet for each requested TFM.
Reports land in `benchmark/BenchmarkDotNet.Artifacts/results/`.

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
