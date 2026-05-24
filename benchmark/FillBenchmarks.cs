using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

[MemoryDiagnoser]
public partial class FillBenchmarks
{
    private const string Lib = "bench";

    [Params(0, 16, 256, 4096)]
    public int Size;

    private byte[] _buffer = Array.Empty<byte>();

    [GlobalSetup]
    public void Setup() => _buffer = new byte[Math.Max(Size, 1)];

    [DllImport(Lib, EntryPoint = "bench_fill", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_fill_arr([Out] byte[] buf, int len, byte value);

    [Benchmark(Baseline = true)]
    public int DllImport_ByteArray() => bench_fill_arr(_buffer, Size, 0);


    [DllImport(Lib, EntryPoint = "bench_fill", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_fill_ptr(byte* buf, int len, byte value);

    [Benchmark]
    public unsafe int DllImport_BytePointer()
    {
        Span<byte> span = _buffer.AsSpan(0, Size);
        fixed (byte* p = span)
            return bench_fill_ptr(p, Size, 0);
    }


    [DllImport(Lib, EntryPoint = "bench_fill", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_fill_ref(ref byte buf, int len, byte value);

    [Benchmark]
    public int DllImport_RefByte()
    {
        Span<byte> span = _buffer.AsSpan(0, Size);
        return bench_fill_ref(ref MemoryMarshal.GetReference(span), Size, 0);
    }


#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_fill")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_fill_li_span(Span<byte> buf, int len, byte value);

    [Benchmark]
    public int LibraryImport_Span() => bench_fill_li_span(_buffer.AsSpan(0, Size), Size, 0);


    [LibraryImport(Lib, EntryPoint = "bench_fill")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_fill_li_ref(ref byte buf, int len, byte value);

    [Benchmark]
    public int LibraryImport_RefByte()
    {
        Span<byte> span = _buffer.AsSpan(0, Size);
        return bench_fill_li_ref(ref MemoryMarshal.GetReference(span), Size, 0);
    }


    // SuppressGCTransition skips the cooperative GC handshake. Safe only when
    // the native side is short, non-blocking, and never calls back to managed.
    [LibraryImport(Lib, EntryPoint = "bench_fill")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_fill_li_span_sgt(Span<byte> buf, int len, byte value);

    [Benchmark]
    public int LibraryImport_Span_SuppressGC()
        => bench_fill_li_span_sgt(_buffer.AsSpan(0, Size), Size, 0);


    [LibraryImport(Lib, EntryPoint = "bench_fill")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_fill_li_ref_sgt(ref byte buf, int len, byte value);

    [Benchmark]
    public int LibraryImport_RefByte_SuppressGC()
    {
        Span<byte> span = _buffer.AsSpan(0, Size);
        return bench_fill_li_ref_sgt(ref MemoryMarshal.GetReference(span), Size, 0);
    }
#endif
}
