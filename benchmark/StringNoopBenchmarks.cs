using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

// Subtract per-row from StringBenchmarks to isolate encoding + transition
// cost from the native strlen walk.
public partial class StringNoopBenchmarks : Utf8StringBenchmarkBase
{
    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_strlen_default(string s);

    [Benchmark(Baseline = true)]
    public int DllImport_Default() => bench_strlen_default(Input);


    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern int bench_strlen_ansi(string s);

    [Benchmark]
    public int DllImport_CharSetAnsi() => bench_strlen_ansi(Input);


    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_strlen_lpstr([MarshalAs(UnmanagedType.LPStr)] string s);

    [Benchmark]
    public int DllImport_LPStr() => bench_strlen_lpstr(Input);


    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    private static extern int bench_strlen_auto(string s);

    [Benchmark]
    public int DllImport_CharSetAuto() => bench_strlen_auto(Input);


    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_strlen_utf8([MarshalAs(UnmanagedType.LPUTF8Str)] string s);

    [Benchmark]
    public int DllImport_LPUTF8Str() => bench_strlen_utf8(Input);


    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_strlen_ptr(byte* s);

    [Benchmark]
    public unsafe int DllImport_ManualUtf8()
    {
        fixed (char* c = Input)
        {
            int len = Input.Length;
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


    [Benchmark]
    public unsafe int DllImport_PreEncoded()
    {
        fixed (byte* p = PreEncoded)
            return bench_strlen_ptr(p);
    }


    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_strlen_arr([In] byte[] s);

    [Benchmark]
    public int DllImport_ByteArray() => bench_strlen_arr(PreEncoded);


    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern int bench_strlen_sb(StringBuilder s);

    [Benchmark]
    public int DllImport_StringBuilder() => bench_strlen_sb(Sb);


#if NET7_0_OR_GREATER
    [DllImport(Lib, EntryPoint = "bench_strlen_noop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_strlen_intptr(IntPtr s);

    [Benchmark]
    public int DllImport_StringToCoTaskMemUTF8()
    {
        IntPtr p = Marshal.StringToCoTaskMemUTF8(Input);
        try { return bench_strlen_intptr(p); }
        finally { Marshal.FreeCoTaskMem(p); }
    }


    [LibraryImport(Lib, EntryPoint = "bench_strlen_noop", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_strlen_li_utf8(string s);

    [Benchmark]
    public int LibraryImport_Utf8() => bench_strlen_li_utf8(Input);


    [LibraryImport(Lib, EntryPoint = "bench_strlen_noop", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_strlen_li_utf8_sgt(string s);

    [Benchmark]
    public int LibraryImport_Utf8_SuppressGC() => bench_strlen_li_utf8_sgt(Input);


    [LibraryImport(Lib, EntryPoint = "bench_strlen_noop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_strlen_li_rospan(ReadOnlySpan<byte> s);

    [Benchmark]
    public int LibraryImport_ROSpan() => bench_strlen_li_rospan(PreEncoded);


    [LibraryImport(Lib, EntryPoint = "bench_strlen_noop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_strlen_li_rospan_sgt(ReadOnlySpan<byte> s);

    [Benchmark]
    public int LibraryImport_ROSpan_SuppressGC() => bench_strlen_li_rospan_sgt(PreEncoded);
#endif
}
