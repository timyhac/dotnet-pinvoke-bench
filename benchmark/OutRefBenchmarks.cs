using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

[MemoryDiagnoser]
public partial class OutRefBenchmarks
{
    private const string Lib = "bench";

    private int _value;

    [DllImport(Lib, EntryPoint = "bench_out_int", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_out_int_out(out int p);

    [Benchmark(Baseline = true)]
    public int DllImport_Out()
    {
        bench_out_int_out(out int v);
        return v;
    }


    [DllImport(Lib, EntryPoint = "bench_out_int", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_out_int_ref(ref int p);

    [Benchmark]
    public int DllImport_Ref()
    {
        bench_out_int_ref(ref _value);
        return _value;
    }


    [DllImport(Lib, EntryPoint = "bench_out_int", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_out_int_ptr(int* p);

    [Benchmark]
    public unsafe int DllImport_Pointer()
    {
        int v;
        bench_out_int_ptr(&v);
        return v;
    }


    [DllImport(Lib, EntryPoint = "bench_out_int", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_out_int_intptr(IntPtr p);

    [Benchmark]
    public int DllImport_IntPtr_AllocHGlobal()
    {
        IntPtr p = Marshal.AllocHGlobal(sizeof(int));
        try
        {
            bench_out_int_intptr(p);
            return Marshal.ReadInt32(p);
        }
        finally
        {
            Marshal.FreeHGlobal(p);
        }
    }


    [DllImport(Lib, EntryPoint = "bench_out_int", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_out_int_span(int* p);

    [Benchmark]
    public unsafe int DllImport_StackallocSpan()
    {
        Span<int> s = stackalloc int[1];
        fixed (int* p = s) bench_out_int_span(p);
        return s[0];
    }


    [DllImport(Lib, EntryPoint = "bench_inout_int", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_inout_int_ref(ref int p);

    [Benchmark]
    public int DllImport_RefInOut() => bench_inout_int_ref(ref _value);


#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_out_int")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_out_int_li_out(out int p);

    [Benchmark]
    public int LibraryImport_Out()
    {
        bench_out_int_li_out(out int v);
        return v;
    }


    [LibraryImport(Lib, EntryPoint = "bench_out_int")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_out_int_li_ref_sgt(ref int p);

    [Benchmark]
    public int LibraryImport_Ref_SuppressGC()
    {
        bench_out_int_li_ref_sgt(ref _value);
        return _value;
    }
#endif
}
