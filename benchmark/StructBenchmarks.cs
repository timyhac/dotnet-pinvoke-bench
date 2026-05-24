using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

[MemoryDiagnoser]
public partial class StructBenchmarks
{
    private const string Lib = "bench";

    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [Params(0, 16, 256, 4096)]
    public int ArrayLen;

    private Point _pt = new() { X = 3, Y = 4 };
    private Rect _rect = new() { Left = 0, Top = 0, Right = 10, Bottom = 20 };
    private Point[] _arr = Array.Empty<Point>();

    [GlobalSetup]
    public void Setup()
    {
        _arr = new Point[Math.Max(ArrayLen, 1)];
        for (int i = 0; i < ArrayLen; i++) _arr[i] = new Point { X = i, Y = i };
    }


    [DllImport(Lib, EntryPoint = "bench_struct_byval", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_struct_byval(Point p);

    [Benchmark(Baseline = true)]
    public int DllImport_ByVal_Small() => bench_struct_byval(_pt);


    [DllImport(Lib, EntryPoint = "bench_struct_byref", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_struct_in(in Point p);

    [Benchmark]
    public int DllImport_In_Small() => bench_struct_in(in _pt);


    [DllImport(Lib, EntryPoint = "bench_struct_byref", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_struct_ref(ref Point p);

    [Benchmark]
    public int DllImport_Ref_Small() => bench_struct_ref(ref _pt);


    [DllImport(Lib, EntryPoint = "bench_struct_byref", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_struct_ptr(Point* p);

    [Benchmark]
    public unsafe int DllImport_Pointer_Small()
    {
        fixed (Point* p = &_pt) return bench_struct_ptr(p);
    }


    // Windows x64 passes >8-byte aggregates by hidden pointer; SysV uses regs
    // up to 16 bytes. Expect the Windows-vs-Linux gap to widen here.
    [DllImport(Lib, EntryPoint = "bench_struct_byval_large", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_struct_byval_large(Rect r);

    [Benchmark]
    public int DllImport_ByVal_Large() => bench_struct_byval_large(_rect);


    [DllImport(Lib, EntryPoint = "bench_struct_byref_large", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_struct_in_large(in Rect r);

    [Benchmark]
    public int DllImport_In_Large() => bench_struct_in_large(in _rect);


    [DllImport(Lib, EntryPoint = "bench_struct_array_sum", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_struct_array_arr([In] Point[] arr, int len);

    [Benchmark]
    public int DllImport_Array() => bench_struct_array_arr(_arr, ArrayLen);


#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_struct_byval")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_struct_byval_li(Point p);

    [Benchmark]
    public int LibraryImport_ByVal_Small() => bench_struct_byval_li(_pt);


    [LibraryImport(Lib, EntryPoint = "bench_struct_byref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_struct_in_li(in Point p);

    [Benchmark]
    public int LibraryImport_In_Small() => bench_struct_in_li(in _pt);


    [LibraryImport(Lib, EntryPoint = "bench_struct_byval")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial int bench_struct_byval_li_sgt(Point p);

    [Benchmark]
    public int LibraryImport_ByVal_Small_SuppressGC() => bench_struct_byval_li_sgt(_pt);


    [LibraryImport(Lib, EntryPoint = "bench_struct_array_sum")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_struct_array_li(ReadOnlySpan<Point> arr, int len);

    [Benchmark]
    public int LibraryImport_Array_Span() => bench_struct_array_li(_arr.AsSpan(0, ArrayLen), ArrayLen);
#endif
}
