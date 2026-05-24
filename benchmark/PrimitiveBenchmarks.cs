using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

// Bool marshalling: [MarshalAs(I4)] is rejected by the runtime — bool only
// pairs with I1/U1/Bool/VariantBool. `Bool` is the 4-byte (Win32 BOOL) width
// and is the default; that's what `DllImport_Default` exercises.
[MemoryDiagnoser]
public partial class PrimitiveBenchmarks
{
    private const string Lib = "bench";

    private readonly bool _true = true;

    [DllImport(Lib, EntryPoint = "bench_bool_i32", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_bool_default(bool b);

    [Benchmark(Baseline = true)]
    public int DllImport_Bool_Default() => bench_bool_default(_true);


    [DllImport(Lib, EntryPoint = "bench_bool_u8", CallingConvention = CallingConvention.Cdecl)]
    private static extern byte bench_bool_u1([MarshalAs(UnmanagedType.U1)] bool b);

    [Benchmark]
    public byte DllImport_Bool_U1() => bench_bool_u1(_true);


    [DllImport(Lib, EntryPoint = "bench_bool_u8", CallingConvention = CallingConvention.Cdecl)]
    private static extern byte bench_bool_i1([MarshalAs(UnmanagedType.I1)] bool b);

    [Benchmark]
    public byte DllImport_Bool_I1() => bench_bool_i1(_true);


    // VariantBool is the COM convention: true serialises as 0xFFFF, false as 0.
    [DllImport(Lib, EntryPoint = "bench_bool_i32", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_bool_variant([MarshalAs(UnmanagedType.VariantBool)] bool b);

    [Benchmark]
    public int DllImport_Bool_VariantBool() => bench_bool_variant(_true);


    [DllImport(Lib, EntryPoint = "bench_bool_u8", CallingConvention = CallingConvention.Cdecl)]
    private static extern byte bench_bool_byte(byte b);

    [Benchmark]
    public byte DllImport_Byte_NoMarshalling() => bench_bool_byte(1);


    [DllImport(Lib, EntryPoint = "bench_scalar_i32", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_scalar_i32(int v);

    [Benchmark]
    public int DllImport_Int32() => bench_scalar_i32(42);


    [DllImport(Lib, EntryPoint = "bench_scalar_i64", CallingConvention = CallingConvention.Cdecl)]
    private static extern long bench_scalar_i64(long v);

    [Benchmark]
    public long DllImport_Int64() => bench_scalar_i64(42L);


    [DllImport(Lib, EntryPoint = "bench_scalar_f32", CallingConvention = CallingConvention.Cdecl)]
    private static extern float bench_scalar_f32(float v);

    [Benchmark]
    public float DllImport_Float() => bench_scalar_f32(42f);


    [DllImport(Lib, EntryPoint = "bench_scalar_f64", CallingConvention = CallingConvention.Cdecl)]
    private static extern double bench_scalar_f64(double v);

    [Benchmark]
    public double DllImport_Double() => bench_scalar_f64(42.0);


#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_bool_u8")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial byte bench_bool_li_u1([MarshalAs(UnmanagedType.U1)] bool b);

    [Benchmark]
    public byte LibraryImport_Bool_U1() => bench_bool_li_u1(_true);


    [LibraryImport(Lib, EntryPoint = "bench_bool_i32")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_bool_li_bool([MarshalAs(UnmanagedType.Bool)] bool b);

    [Benchmark]
    public int LibraryImport_Bool_4Byte() => bench_bool_li_bool(_true);


    [LibraryImport(Lib, EntryPoint = "bench_bool_u8")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial byte bench_bool_li_byte(byte b);

    [Benchmark]
    public byte LibraryImport_Byte_NoMarshalling() => bench_bool_li_byte(1);


    [LibraryImport(Lib, EntryPoint = "bench_bool_u8")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial byte bench_bool_li_byte_sgt(byte b);

    [Benchmark]
    public byte LibraryImport_Byte_SuppressGC() => bench_bool_li_byte_sgt(1);


    [LibraryImport(Lib, EntryPoint = "bench_scalar_i64")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial long bench_scalar_li_i64(long v);

    [Benchmark]
    public long LibraryImport_Int64() => bench_scalar_li_i64(42L);


    [LibraryImport(Lib, EntryPoint = "bench_scalar_f64")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial double bench_scalar_li_f64(double v);

    [Benchmark]
    public double LibraryImport_Double() => bench_scalar_li_f64(42.0);


    [LibraryImport(Lib, EntryPoint = "bench_scalar_f64")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial double bench_scalar_li_f64_sgt(double v);

    [Benchmark]
    public double LibraryImport_Double_SuppressGC() => bench_scalar_li_f64_sgt(42.0);
#endif
}
