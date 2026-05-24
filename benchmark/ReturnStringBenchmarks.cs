using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

// Direct `return string` from DllImport / LibraryImport is *omitted* here:
// the runtime calls CoTaskMemFree on the returned pointer, which crashes when
// the library returns a static buffer. The correct shape for library-owned
// strings is IntPtr + Marshal.PtrToString*.
[MemoryDiagnoser]
public partial class ReturnStringBenchmarks
{
    private const string Lib = "bench";

    [DllImport(Lib, EntryPoint = "bench_get_utf8_string", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr bench_get_utf8();

    [DllImport(Lib, EntryPoint = "bench_get_utf16_string", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr bench_get_utf16();

    [Benchmark(Baseline = true)]
    public IntPtr DllImport_IntPtr_NoDecode() => bench_get_utf8();


    [Benchmark]
    public string? DllImport_IntPtr_PtrToStringAnsi()
        => Marshal.PtrToStringAnsi(bench_get_utf8());


#if NET5_0_OR_GREATER
    [Benchmark]
    public string? DllImport_IntPtr_PtrToStringUTF8()
        => Marshal.PtrToStringUTF8(bench_get_utf8());
#endif


    [Benchmark]
    public string? DllImport_IntPtr_PtrToStringUni()
        => Marshal.PtrToStringUni(bench_get_utf16());


#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_get_utf8_string")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial IntPtr bench_get_utf8_li();

    [Benchmark]
    public IntPtr LibraryImport_IntPtr_NoDecode() => bench_get_utf8_li();


    [LibraryImport(Lib, EntryPoint = "bench_get_utf8_string")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial IntPtr bench_get_utf8_li_sgt();

    [Benchmark]
    public string? LibraryImport_IntPtr_SuppressGC_PtrToStringUTF8()
        => Marshal.PtrToStringUTF8(bench_get_utf8_li_sgt());
#endif
}
