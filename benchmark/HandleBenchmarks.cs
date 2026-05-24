using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using Microsoft.Win32.SafeHandles;

namespace PInvokeBench;

// SafeHandle is incompatible with SuppressGCTransition (the AddRef/Release
// dance requires a normal cooperative transition).
[MemoryDiagnoser]
public partial class HandleBenchmarks
{
    private const string Lib = "bench";

    private sealed class BenchHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public BenchHandle() : base(ownsHandle: false) { }
        public BenchHandle(IntPtr h) : base(ownsHandle: false) { SetHandle(h); }
        protected override bool ReleaseHandle() => true;
    }

    private readonly IntPtr _ptr = new IntPtr(0xDEADBEEF);
    private readonly BenchHandle _safe = new BenchHandle(new IntPtr(0xDEADBEEF));

    [DllImport(Lib, EntryPoint = "bench_handle_passthrough", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr bench_handle_intptr(IntPtr h);

    [Benchmark(Baseline = true)]
    public IntPtr DllImport_IntPtr() => bench_handle_intptr(_ptr);


    [DllImport(Lib, EntryPoint = "bench_handle_passthrough", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr bench_handle_safehandle(SafeHandle h);

    [Benchmark]
    public IntPtr DllImport_SafeHandle() => bench_handle_safehandle(_safe);


#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_handle_passthrough")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial IntPtr bench_handle_li_intptr(IntPtr h);

    [Benchmark]
    public IntPtr LibraryImport_IntPtr() => bench_handle_li_intptr(_ptr);


    [LibraryImport(Lib, EntryPoint = "bench_handle_passthrough")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial IntPtr bench_handle_li_safehandle(SafeHandle h);

    [Benchmark]
    public IntPtr LibraryImport_SafeHandle() => bench_handle_li_safehandle(_safe);


    [LibraryImport(Lib, EntryPoint = "bench_handle_passthrough")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [SuppressGCTransition]
    private static partial IntPtr bench_handle_li_intptr_sgt(IntPtr h);

    [Benchmark]
    public IntPtr LibraryImport_IntPtr_SuppressGC() => bench_handle_li_intptr_sgt(_ptr);
#endif
}
