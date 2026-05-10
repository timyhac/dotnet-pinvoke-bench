# dotnet-pinvoke-bench

Benchmarks for comparing .NET P/Invoke marshalling strategies when passing buffers to a native function.
The native side is a tiny Zig library that cross-compiles to Windows / Linux / macOS without needing platform-specific toolchains.

## Prerequisites

- .NET SDK with workloads for the TFMs you want to benchmark.
- [Zig](https://ziglang.org/download/) 0.14+ on `PATH`.

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

## What you're likely to see

- For **blittable** parameters, V2 / V3 / V4 / V5 land within ±1–2 ns of each other on net8+.
  The compiler/runtime converges on the same generated call site.
- On **net48**, V2/V3 (`byte*`/`ref byte`) are noticeably slower than V1 (`byte[]`) at small sizes — the legacy P/Invoke stub for `byte[]` is the best-optimised path; `ref` and pointer paths take a different route.
- `[SuppressGCTransition]` (V6/V7) is the **biggest lever**: at small sizes it drops the call to ~2 ns by skipping the cooperative GC handshake.
  Only safe when the native function is short, non-blocking, and doesn't call back into managed code (a `memset` qualifies; arbitrary library calls do not).
- At larger `Size` values (e.g. 4096 bytes), the actual `memset` work dominates and all variants converge — marshalling-strategy choice becomes invisible.
