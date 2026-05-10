using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

// All variants call into the same native function (`bench_fill` from the
// bench shared library). The native side is identical, so any difference
// in measured time is attributable to .NET's marshalling/transition layer.

[MemoryDiagnoser]
public partial class FillBenchmarks
{
    private const string Lib = "bench";

    [Params(0, 16, 256, 4096)]
    public int Size;

    private byte[] _buffer = Array.Empty<byte>();

    [GlobalSetup]
    public void Setup() => _buffer = new byte[Math.Max(Size, 1)];

    // ---------- V1: classic [DllImport] with byte[] parameter ----------
    // Runtime IL stub pins the array. No unsafe in user code.

    [DllImport(Lib, EntryPoint = "bench_fill", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_fill_arr([Out] byte[] buf, int len, byte value);

    [Benchmark(Baseline = true, Description = "DllImport byte[]")]
    public int V1_DllImport_ByteArray() => bench_fill_arr(_buffer, Size, 0);


    // ---------- V2: [DllImport] with byte* + fixed (the PR's pattern) ----------

    [DllImport(Lib, EntryPoint = "bench_fill", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_fill_ptr(byte* buf, int len, byte value);

    [Benchmark(Description = "DllImport byte* + fixed")]
    public unsafe int V2_DllImport_Fixed()
    {
        Span<byte> span = _buffer.AsSpan(0, Size);
        fixed (byte* p = span)
            return bench_fill_ptr(p, Size, 0);
    }


    // ---------- V3: [DllImport] with ref byte + MemoryMarshal.GetReference ----------
    // No unsafe in user code; runtime pins via the P/Invoke stub.

    [DllImport(Lib, EntryPoint = "bench_fill", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_fill_ref(ref byte buf, int len, byte value);

    [Benchmark(Description = "DllImport ref byte + GetReference")]
    public int V3_DllImport_RefByte()
    {
        Span<byte> span = _buffer.AsSpan(0, Size);
        return bench_fill_ref(ref MemoryMarshal.GetReference(span), Size, 0);
    }


#if NET7_0_OR_GREATER
    // ---------- V4: [LibraryImport] with Span<byte> ----------
    // Source-generated stub pins the span and calls the underlying P/Invoke.

    [LibraryImport(Lib, EntryPoint = "bench_fill")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_fill_li_span(Span<byte> buf, int len, byte value);

    [Benchmark(Description = "LibraryImport Span<byte>")]
    public int V4_LibraryImport_Span() => bench_fill_li_span(_buffer.AsSpan(0, Size), Size, 0);


    // ---------- V5: [LibraryImport] with ref byte ----------

    [LibraryImport(Lib, EntryPoint = "bench_fill")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_fill_li_ref(ref byte buf, int len, byte value);

    [Benchmark(Description = "LibraryImport ref byte")]
    public int V5_LibraryImport_RefByte()
    {
        Span<byte> span = _buffer.AsSpan(0, Size);
        return bench_fill_li_ref(ref MemoryMarshal.GetReference(span), Size, 0);
    }


    // ---------- V6: [LibraryImport] Span + [SuppressGCTransition] ----------
    // Skips the cooperative GC handshake. Only safe for short, non-blocking
    // native code (a memset qualifies; arbitrary plctag calls do not).

    [LibraryImport(Lib, EntryPoint = "bench_fill")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_fill_li_span_sgt(Span<byte> buf, int len, byte value);

    [Benchmark(Description = "LibraryImport Span + SuppressGC")]
    public int V6_LibraryImport_Span_SuppressGC()
        => bench_fill_li_span_sgt(_buffer.AsSpan(0, Size), Size, 0);


    // ---------- V7: [LibraryImport] ref byte + [SuppressGCTransition] ----------

    [LibraryImport(Lib, EntryPoint = "bench_fill")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_fill_li_ref_sgt(ref byte buf, int len, byte value);

    [Benchmark(Description = "LibraryImport ref byte + SuppressGC")]
    public int V7_LibraryImport_RefByte_SuppressGC()
    {
        Span<byte> span = _buffer.AsSpan(0, Size);
        return bench_fill_li_ref_sgt(ref MemoryMarshal.GetReference(span), Size, 0);
    }
#endif
}


// Pure transition cost - no buffer work on the native side.
// Useful for isolating "how much does the P/Invoke transition itself cost"
// from "how much does memset of N bytes cost".
[MemoryDiagnoser]
public partial class NoopBenchmarks
{
    private const string Lib = "bench";

    private byte[] _buffer = new byte[1];

    [DllImport(Lib, EntryPoint = "bench_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_noop_ptr(byte* buf, int len);

    [Benchmark(Baseline = true, Description = "DllImport byte* + fixed (noop)")]
    public unsafe int V2_Fixed()
    {
        fixed (byte* p = _buffer)
            return bench_noop_ptr(p, 0);
    }

    [DllImport(Lib, EntryPoint = "bench_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_noop_ref(ref byte buf, int len);

    [Benchmark(Description = "DllImport ref byte (noop)")]
    public int V3_RefByte()
        => bench_noop_ref(ref MemoryMarshal.GetReference(_buffer.AsSpan()), 0);

#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_noop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_noop_li_span(Span<byte> buf, int len);

    [Benchmark(Description = "LibraryImport Span (noop)")]
    public int V4_LibraryImport_Span()
        => bench_noop_li_span(_buffer.AsSpan(), 0);

    [LibraryImport(Lib, EntryPoint = "bench_noop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_noop_li_span_sgt(Span<byte> buf, int len);

    [Benchmark(Description = "LibraryImport Span + SuppressGC (noop)")]
    public int V6_LibraryImport_Span_SuppressGC()
        => bench_noop_li_span_sgt(_buffer.AsSpan(), 0);
#endif
}
