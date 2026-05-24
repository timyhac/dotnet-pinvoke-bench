using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

[MemoryDiagnoser]
public partial class NoopBenchmarks
{
    private const string Lib = "bench";

    private byte[] _buffer = new byte[1];

    [DllImport(Lib, EntryPoint = "bench_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_noop_ptr(byte* buf, int len);

    [Benchmark(Baseline = true)]
    public unsafe int DllImport_BytePointer()
    {
        fixed (byte* p = _buffer)
            return bench_noop_ptr(p, 0);
    }

    [DllImport(Lib, EntryPoint = "bench_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_noop_ref(ref byte buf, int len);

    [Benchmark]
    public int DllImport_RefByte()
        => bench_noop_ref(ref MemoryMarshal.GetReference(_buffer.AsSpan()), 0);

#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_noop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_noop_li_span(Span<byte> buf, int len);

    [Benchmark]
    public int LibraryImport_Span()
        => bench_noop_li_span(_buffer.AsSpan(), 0);

    [LibraryImport(Lib, EntryPoint = "bench_noop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_noop_li_span_sgt(Span<byte> buf, int len);

    [Benchmark]
    public int LibraryImport_Span_SuppressGC()
        => bench_noop_li_span_sgt(_buffer.AsSpan(), 0);
#endif
}
