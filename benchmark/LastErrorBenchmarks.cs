using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

// SetLastError=true makes the marshaller capture GetLastError (Windows) or
// errno (POSIX) into a thread-local immediately after the native call so
// Marshal.GetLastWin32Error / GetLastPInvokeError can read it. The cost is
// per call — one extra TLS write — and shows up below the noise floor at
// small Sizes.
[MemoryDiagnoser]
public partial class LastErrorBenchmarks
{
    private const string Lib = "bench";

    private byte[] _buffer = new byte[1];

    [DllImport(Lib, EntryPoint = "bench_noop", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
    private static extern unsafe int bench_noop(byte* buf, int len);

    [Benchmark(Baseline = true)]
    public unsafe int DllImport_NoSetLastError()
    {
        fixed (byte* p = _buffer) return bench_noop(p, 0);
    }


    [DllImport(Lib, EntryPoint = "bench_noop", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
    private static extern unsafe int bench_noop_sle(byte* buf, int len);

    [Benchmark]
    public unsafe int DllImport_SetLastError()
    {
        fixed (byte* p = _buffer) return bench_noop_sle(p, 0);
    }


    [Benchmark]
    public unsafe int DllImport_SetLastError_AndRead()
    {
        fixed (byte* p = _buffer)
        {
            int r = bench_noop_sle(p, 0);
            _ = Marshal.GetLastWin32Error();
            return r;
        }
    }


#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_noop", SetLastError = false)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_noop_li(Span<byte> buf, int len);

    [Benchmark]
    public int LibraryImport_NoSetLastError() => bench_noop_li(_buffer.AsSpan(), 0);


    [LibraryImport(Lib, EntryPoint = "bench_noop", SetLastError = true)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_noop_li_sle(Span<byte> buf, int len);

    [Benchmark]
    public int LibraryImport_SetLastError() => bench_noop_li_sle(_buffer.AsSpan(), 0);


    [Benchmark]
    public int LibraryImport_SetLastError_AndRead()
    {
        int r = bench_noop_li_sle(_buffer.AsSpan(), 0);
        _ = Marshal.GetLastPInvokeError();
        return r;
    }
#endif
}
