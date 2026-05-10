using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
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


// String marshalling strategies. Each variant calls the same native
// `bench_strlen` (walks a null-terminated UTF-8 string), so all timing
// differences are .NET-side encoding + transition cost.
//
// The interesting cost shows up at small sizes where transition / per-call
// allocation dominate. At Length=4096 the native walk starts to matter and
// the strategies converge.
[MemoryDiagnoser]
public partial class StringBenchmarks
{
    private const string Lib = "bench";

    // Stackalloc threshold for the manual-encode variant. 1024 is the
    // conventional cutoff (Span<T>.Slice patterns, System.Buffers, etc.)
    // beyond which a stack frame becomes uncomfortably large.
    private const int StackallocLimit = 1024;

    [Params(0, 16, 256, 4096)]
    public int Length;

    private string _input = string.Empty;
    private byte[] _preEncoded = Array.Empty<byte>();

    [GlobalSetup]
    public void Setup()
    {
        _input = new string('x', Length);
        // ASCII payload, so encoded byte count == char count. +1 for NUL.
        _preEncoded = new byte[Length + 1];
        if (Length > 0)
        {
            Encoding.UTF8.GetBytes(_input, 0, Length, _preEncoded, 0);
        }
        // _preEncoded[Length] is already 0 from `new byte[]`.
    }

    // ---------- S1: DllImport string with default marshalling (LPStr/ANSI) ----------
    // Common but lossy on non-ASCII. Runtime allocates a temp ANSI buffer
    // on every call, copies bytes via the system codepage, and pins it.

    [DllImport(Lib, EntryPoint = "bench_strlen", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_strlen_default(string s);

    [Benchmark(Baseline = true, Description = "DllImport string (default LPStr/ANSI)")]
    public int S1_DllImport_Default() => bench_strlen_default(_input);


    // ---------- S2: DllImport [LPUTF8Str] string ----------
    // Runtime allocates a temp UTF-8 buffer per call. Correct for non-ASCII
    // but still pays an allocation each invocation.

    [DllImport(Lib, EntryPoint = "bench_strlen", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_strlen_utf8([MarshalAs(UnmanagedType.LPUTF8Str)] string s);

    [Benchmark(Description = "DllImport [LPUTF8Str] string")]
    public int S2_DllImport_LPUTF8Str() => bench_strlen_utf8(_input);


    // ---------- S3: DllImport byte* + manual UTF-8 encode (stackalloc/pool) ----------
    // What you'd write for a hot path: stack buffer for short strings,
    // pooled buffer above the threshold. Avoids the runtime marshaller
    // and removes the per-call managed allocation.

    [DllImport(Lib, EntryPoint = "bench_strlen", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_strlen_ptr(byte* s);

    [Benchmark(Description = "DllImport byte* + manual UTF-8 (stackalloc/pool)")]
    public unsafe int S3_DllImport_ManualUtf8()
    {
        fixed (char* c = _input)
        {
            int len = _input.Length;
            int byteCount = Encoding.UTF8.GetByteCount(c, len);
            if (byteCount + 1 <= StackallocLimit)
            {
                byte* p = stackalloc byte[byteCount + 1];
                if (len > 0) Encoding.UTF8.GetBytes(c, len, p, byteCount);
                p[byteCount] = 0;
                return bench_strlen_ptr(p);
            }
            else
            {
                byte[] rented = ArrayPool<byte>.Shared.Rent(byteCount + 1);
                try
                {
                    fixed (byte* h = rented)
                    {
                        Encoding.UTF8.GetBytes(c, len, h, byteCount);
                        h[byteCount] = 0;
                        return bench_strlen_ptr(h);
                    }
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(rented);
                }
            }
        }
    }


    // ---------- S6: DllImport byte* + pre-encoded buffer ----------
    // Lower-bound baseline: the encoded bytes are produced once at setup,
    // each call just pins the buffer. Anything slower than this is paying
    // per-call encoding cost.

    [Benchmark(Description = "DllImport byte* + pre-encoded buffer")]
    public unsafe int S6_DllImport_PreEncoded()
    {
        fixed (byte* p = _preEncoded)
            return bench_strlen_ptr(p);
    }


#if NET7_0_OR_GREATER
    // ---------- S4: LibraryImport with StringMarshalling.Utf8 ----------
    // Source-generated UTF-8 marshalling. Same shape as S2 but the stub
    // is generated at compile time rather than synthesised by the runtime.

    [LibraryImport(Lib, EntryPoint = "bench_strlen", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_strlen_li_utf8(string s);

    [Benchmark(Description = "LibraryImport string Utf8")]
    public int S4_LibraryImport_Utf8() => bench_strlen_li_utf8(_input);


    // ---------- S5: LibraryImport Utf8 + SuppressGCTransition ----------
    // Same encoding cost as S4, but skips the cooperative GC handshake.
    // Safe here because bench_strlen is short, non-blocking, and never
    // calls back into managed code.

    [LibraryImport(Lib, EntryPoint = "bench_strlen", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_strlen_li_utf8_sgt(string s);

    [Benchmark(Description = "LibraryImport string Utf8 + SuppressGC")]
    public int S5_LibraryImport_Utf8_SuppressGC() => bench_strlen_li_utf8_sgt(_input);
#endif
}


// String marshalling cost with the native walk removed. Same six variants
// as StringBenchmarks, but pointed at `bench_strlen_noop` (returns 0
// immediately). Subtracting the corresponding row in StringBenchmarks
// gives the "encoding + transition" contribution of each strategy.
[MemoryDiagnoser]
public partial class StringNoopBenchmarks
{
    private const string Lib = "bench";
    private const int StackallocLimit = 1024;

    [Params(0, 16, 256, 4096)]
    public int Length;

    private string _input = string.Empty;
    private byte[] _preEncoded = Array.Empty<byte>();

    [GlobalSetup]
    public void Setup()
    {
        _input = new string('x', Length);
        _preEncoded = new byte[Length + 1];
        if (Length > 0)
        {
            Encoding.UTF8.GetBytes(_input, 0, Length, _preEncoded, 0);
        }
    }

    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_strlen_noop_default(string s);

    [Benchmark(Baseline = true, Description = "DllImport string default (noop)")]
    public int N1_DllImport_Default() => bench_strlen_noop_default(_input);


    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_strlen_noop_utf8([MarshalAs(UnmanagedType.LPUTF8Str)] string s);

    [Benchmark(Description = "DllImport [LPUTF8Str] string (noop)")]
    public int N2_DllImport_LPUTF8Str() => bench_strlen_noop_utf8(_input);


    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_strlen_noop_ptr(byte* s);

    [Benchmark(Description = "DllImport byte* + manual UTF-8 (noop)")]
    public unsafe int N3_DllImport_ManualUtf8()
    {
        fixed (char* c = _input)
        {
            int len = _input.Length;
            int byteCount = Encoding.UTF8.GetByteCount(c, len);
            if (byteCount + 1 <= StackallocLimit)
            {
                byte* p = stackalloc byte[byteCount + 1];
                if (len > 0) Encoding.UTF8.GetBytes(c, len, p, byteCount);
                p[byteCount] = 0;
                return bench_strlen_noop_ptr(p);
            }
            else
            {
                byte[] rented = ArrayPool<byte>.Shared.Rent(byteCount + 1);
                try
                {
                    fixed (byte* h = rented)
                    {
                        Encoding.UTF8.GetBytes(c, len, h, byteCount);
                        h[byteCount] = 0;
                        return bench_strlen_noop_ptr(h);
                    }
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(rented);
                }
            }
        }
    }


    [Benchmark(Description = "DllImport byte* + pre-encoded buffer (noop)")]
    public unsafe int N6_DllImport_PreEncoded()
    {
        fixed (byte* p = _preEncoded)
            return bench_strlen_noop_ptr(p);
    }


#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_strlen_noop", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_strlen_noop_li_utf8(string s);

    [Benchmark(Description = "LibraryImport string Utf8 (noop)")]
    public int N4_LibraryImport_Utf8() => bench_strlen_noop_li_utf8(_input);


    [LibraryImport(Lib, EntryPoint = "bench_strlen_noop", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_strlen_noop_li_utf8_sgt(string s);

    [Benchmark(Description = "LibraryImport string Utf8 + SuppressGC (noop)")]
    public int N5_LibraryImport_Utf8_SuppressGC() => bench_strlen_noop_li_utf8_sgt(_input);
#endif
}
