using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

[MemoryDiagnoser]
public partial class CallbackBenchmarks
{
    private const string Lib = "bench";

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int CallbackDelegate(int arg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int CallbackUserdataDelegate(IntPtr ctx, int arg);

    // Field references keep the delegates alive across calls.
    private static readonly CallbackDelegate s_delegate = static a => a + 1;
    private static readonly CallbackUserdataDelegate s_delegateUserdata = static (ctx, a) => a + 1;
    private static readonly IntPtr s_funcPtr = Marshal.GetFunctionPointerForDelegate(s_delegate);
    private static readonly IntPtr s_funcPtrUserdata = Marshal.GetFunctionPointerForDelegate(s_delegateUserdata);

#if NET5_0_OR_GREATER
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static int UnmanagedAdd(int a) => a + 1;

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static int UnmanagedAddWithCtx(IntPtr ctx, int a) => a + 1;
#endif

    [DllImport(Lib, EntryPoint = "bench_invoke_callback", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_invoke_callback_delegate(CallbackDelegate cb, int arg);

    [Benchmark(Baseline = true)]
    public int DllImport_Delegate() => bench_invoke_callback_delegate(s_delegate, 1);


    [DllImport(Lib, EntryPoint = "bench_invoke_callback", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_invoke_callback_intptr(IntPtr cb, int arg);

    [Benchmark]
    public int DllImport_FunctionPointer_Cached() => bench_invoke_callback_intptr(s_funcPtr, 1);


    // Pay GetFunctionPointerForDelegate on every call. The runtime caches the
    // reverse stub per delegate instance, so the second+ calls are cheaper
    // than the very first — but still non-zero.
    [Benchmark]
    public int DllImport_FunctionPointer_PerCall()
        => bench_invoke_callback_intptr(Marshal.GetFunctionPointerForDelegate(s_delegate), 1);


#if NET5_0_OR_GREATER
    [DllImport(Lib, EntryPoint = "bench_invoke_callback", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_invoke_callback_fp(delegate* unmanaged[Cdecl]<int, int> cb, int arg);

    [Benchmark]
    public unsafe int DllImport_UnmanagedCallersOnly()
        => bench_invoke_callback_fp(&UnmanagedAdd, 1);
#endif


    [DllImport(Lib, EntryPoint = "bench_invoke_callback_userdata", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_invoke_callback_userdata_delegate(CallbackUserdataDelegate cb, IntPtr ctx, int arg);

    [Benchmark]
    public int DllImport_Delegate_Userdata()
        => bench_invoke_callback_userdata_delegate(s_delegateUserdata, IntPtr.Zero, 1);


    [DllImport(Lib, EntryPoint = "bench_invoke_callback_userdata", CallingConvention = CallingConvention.Cdecl)]
    private static extern int bench_invoke_callback_userdata_intptr(IntPtr cb, IntPtr ctx, int arg);

    [Benchmark]
    public int DllImport_FunctionPointer_Userdata()
        => bench_invoke_callback_userdata_intptr(s_funcPtrUserdata, IntPtr.Zero, 1);


#if NET5_0_OR_GREATER
    [DllImport(Lib, EntryPoint = "bench_invoke_callback_userdata", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int bench_invoke_callback_userdata_fp(delegate* unmanaged[Cdecl]<IntPtr, int, int> cb, IntPtr ctx, int arg);

    [Benchmark]
    public unsafe int DllImport_UnmanagedCallersOnly_Userdata()
        => bench_invoke_callback_userdata_fp(&UnmanagedAddWithCtx, IntPtr.Zero, 1);
#endif


#if NET7_0_OR_GREATER
    [LibraryImport(Lib, EntryPoint = "bench_invoke_callback")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static partial int bench_invoke_callback_li(CallbackDelegate cb, int arg);

    [Benchmark]
    public int LibraryImport_Delegate() => bench_invoke_callback_li(s_delegate, 1);


    [LibraryImport(Lib, EntryPoint = "bench_invoke_callback")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe partial int bench_invoke_callback_li_fp(delegate* unmanaged[Cdecl]<int, int> cb, int arg);

    [Benchmark]
    public unsafe int LibraryImport_UnmanagedCallersOnly()
        => bench_invoke_callback_li_fp(&UnmanagedAdd, 1);
#endif
}
