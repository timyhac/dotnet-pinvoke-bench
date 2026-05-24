# dotnet-pinvoke-bench

Benchmarks for every lever .NET exposes when calling native code via P/Invoke — marshalling strategies, calling conventions, struct/callback/handle shapes, transition costs.

The native side is a tiny Zig library that cross-compiles to Windows / Linux / macOS without needing platform-specific toolchains.

## Prerequisites

- .NET SDK with workloads for the TFMs you want to bench (`net481`, `net8.0`, `net10.0`).
- [Zig](https://ziglang.org/download/) 0.14+ on `PATH`.

## Quickstart

```sh
# Windows
.\run.ps1                          # net10.0 only (default)
.\run.ps1 net8.0 net10.0 net481     # one run per TFM, sequentially
.\run.ps1 -Short                   # BenchmarkDotNet Short job (fewer iterations, faster)

# Linux / macOS
./run.sh                           # net10.0 only (default)
./run.sh net8.0 net10.0            # one run per TFM, sequentially
./run.sh --short                   # Short job
```

The orchestrator builds the native shim with `zig build -Doptimize=ReleaseFast`, then runs BenchmarkDotNet for each requested TFM. Reports land in `benchmark/BenchmarkDotNet.Artifacts/results/`:

- `report.html` — single consolidated interactive report. Analysis + chart + table per class, all inline. Opens directly from `file://`; loads [Observable Plot](https://observablehq.com/plot/) from CDN. Analysis text lives in `benchmark/report.template.html` (an embedded resource in the benchmark assembly) — edit it to update the narrative.
- `*-report-github.md` — markdown table per class (renders in GitHub).
- `*-report.csv` — raw data for downstream tooling.

`report.html` is rebuilt from per-class JSON sidecars in `.report-data/` on every run, so running only one class still produces a complete report (other classes show prior data).

## Benchmark categories

Method names follow `{Source}_{Strategy}[_{Modifier}]`, e.g. `DllImport_RefByte`, `LibraryImport_Span_SuppressGC`.

| Class | What it measures |
| --- | --- |
| `FillBenchmarks` | Buffer-out: `byte[]`, `byte*`, `ref byte`, `Span<byte>`. ± `SuppressGCTransition`. |
| `NoopBenchmarks` | Same shapes pointed at a native no-op. Isolates the call / transition floor from the `memset` work. |
| `StringBenchmarks` | UTF-8 string marshalling — default/Ansi/`[LPStr]`/`[LPUTF8Str]`/`CharSet.Auto`, manual encode, pre-encoded `byte*`/`byte[]`, `StringBuilder`, `StringToCoTaskMemUTF8`, `StringMarshalling.Utf8`, `ReadOnlySpan<byte>`. |
| `StringNoopBenchmarks` | Same variants pointed at `_noop` entry point — subtract from `StringBenchmarks` to isolate encoding+transition from native walk. |
| `WideStringBenchmarks` | UTF-16 string marshalling — `CharSet.Unicode`, `[LPWStr]`, `char* + fixed` (zero-copy), `char[]`, `StringBuilder`, `StringMarshalling.Utf16`, `ReadOnlySpan<ushort>`. |
| `WideStringNoopBenchmarks` | UTF-16 transition-only counterpart. |
| `StructBenchmarks` | Small (8B) and large (16B) blittable structs — by-value / `in` / `ref` / pointer / array. Plus `ReadOnlySpan<Point>` via LibraryImport. |
| `CallbackBenchmarks` | Native-calls-managed — `delegate` parameter, cached `IntPtr` from `GetFunctionPointerForDelegate`, `GetFunctionPointerForDelegate` per call, `delegate* unmanaged<>` + `[UnmanagedCallersOnly]`. With and without a userdata pointer. |
| `PrimitiveBenchmarks` | `bool` widths (default `Bool`/`U1`/`I1`/`VariantBool`/raw `byte`) and scalar types (`int`/`long`/`float`/`double`). |
| `ReturnStringBenchmarks` | Library-owned static strings — `IntPtr` + `Marshal.PtrToStringAnsi`/`UTF8`/`Uni`. (Direct `return string` would call `CoTaskMemFree` on a static pointer → omitted.) |
| `OutRefBenchmarks` | `out`/`ref`/`int*`/stackalloc `Span<int>`/`IntPtr` + `AllocHGlobal`+`ReadInt32`. |
| `HandleBenchmarks` | `IntPtr` vs `SafeHandle` round-trip. `SafeHandle` is incompatible with `SuppressGCTransition`. |
| `LastErrorBenchmarks` | `SetLastError = true/false` and the cost of reading `Marshal.GetLastWin32Error`. |

## What you'll usually see

- **For blittable parameters**, modern net8+ converges: by-array / `byte*` / `ref byte` / `Span<byte>` land within ~1–2 ns of each other.
- **`[SuppressGCTransition]`** is the biggest single lever: at small payloads it drops the call to ~2 ns by skipping the cooperative GC handshake. Only safe when the native side is short, non-blocking, and never calls back to managed.
- **`delegate* unmanaged<>` + `[UnmanagedCallersOnly]`** is the cheapest callback shape — no delegate object, no reverse stub, no GC handle.
- **String marshalling** is dominated by encoding: pre-encoded `byte*`/`byte[]` or `ReadOnlySpan<byte>` is a large win over runtime encode (`[LPUTF8Str]`, `StringMarshalling.Utf8`) at every payload size.
- **UTF-16 paths** are often cheaper than UTF-8 because .NET strings are already UTF-16 internally — `char* + fixed` is a true zero-copy pin.
- **Large structs** on Windows x64 cross the "fits in a register" threshold and start to cost noticeably more by-value than by-ref. SysV (Linux/macOS x64) handles up to 16 bytes in registers.
- **On net481**, the legacy P/Invoke stub for `byte[]` is the best-optimised path; `ref` and `byte*` variants are slower at small payloads (different IL stub path).
