using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

public partial class WideStringBenchmarks : Utf16StringBenchmarkBase
{
    [DllImport(Lib, EntryPoint = "bench_wstrlen", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    private static extern int bench_wstrlen_uni(string s);

    [Benchmark(Baseline = true)]
    public int DllImport_CharSetUnicode() => bench_wstrlen_uni(Input);


    [DllImport(Lib, EntryPoint = "bench_wstrlen", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_wstrlen_lpwstr([MarshalAs(UnmanagedType.LPWStr)] string s);

    [Benchmark]
    public int DllImport_LPWStr() => bench_wstrlen_lpwstr(Input);


    [DllImport(Lib, EntryPoint = "bench_wstrlen", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_wstrlen_ptr(char* s);

    [Benchmark]
    public unsafe int DllImport_CharPointer()
    {
        fixed (char* p = Input)
            return bench_wstrlen_ptr(p);
    }


    [DllImport(Lib, EntryPoint = "bench_wstrlen", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_wstrlen_arr([In] char[] s);

    [Benchmark]
    public int DllImport_CharArray() => bench_wstrlen_arr(PreEncodedChars);


    [DllImport(Lib, EntryPoint = "bench_wstrlen", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    private static extern int bench_wstrlen_sb(StringBuilder s);

    [Benchmark]
    public int DllImport_StringBuilder() => bench_wstrlen_sb(Sb);


#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_wstrlen", StringMarshalling = StringMarshalling.Utf16)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_wstrlen_li_utf16(string s);

    [Benchmark]
    public int LibraryImport_Utf16() => bench_wstrlen_li_utf16(Input);


    [LibraryImport(Lib, EntryPoint = "bench_wstrlen", StringMarshalling = StringMarshalling.Utf16)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_wstrlen_li_utf16_sgt(string s);

    [Benchmark]
    public int LibraryImport_Utf16_SuppressGC() => bench_wstrlen_li_utf16_sgt(Input);


    // char isn't blittable without DisableRuntimeMarshalling, so Span<char>
    // is rejected by the source generator. Cast to ushort via MemoryMarshal.
    [LibraryImport(Lib, EntryPoint = "bench_wstrlen")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_wstrlen_li_rospan(ReadOnlySpan<ushort> s);

    [Benchmark]
    public int LibraryImport_ROSpan()
        => bench_wstrlen_li_rospan(MemoryMarshal.Cast<char, ushort>(PreEncodedChars));


    [LibraryImport(Lib, EntryPoint = "bench_wstrlen")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_wstrlen_li_rospan_sgt(ReadOnlySpan<ushort> s);

    [Benchmark]
    public int LibraryImport_ROSpan_SuppressGC()
        => bench_wstrlen_li_rospan_sgt(MemoryMarshal.Cast<char, ushort>(PreEncodedChars));
#endif
}
