```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                        | Mean      | Error      | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |----------:|-----------:|----------:|------:|--------:|----------:|------------:|
| DllImport_Out                 | 11.348 ns |   9.033 ns | 0.4951 ns |  1.00 |    0.05 |         - |          NA |
| DllImport_Ref                 | 11.307 ns |   3.838 ns | 0.2103 ns |  1.00 |    0.04 |         - |          NA |
| DllImport_Pointer             |  8.880 ns |  14.688 ns | 0.8051 ns |  0.78 |    0.07 |         - |          NA |
| DllImport_IntPtr_AllocHGlobal | 98.335 ns | 174.523 ns | 9.5662 ns |  8.68 |    0.80 |         - |          NA |
| DllImport_StackallocSpan      | 11.641 ns |   6.989 ns | 0.3831 ns |  1.03 |    0.05 |         - |          NA |
| DllImport_RefInOut            | 11.062 ns |   4.700 ns | 0.2576 ns |  0.98 |    0.04 |         - |          NA |
| LibraryImport_Out             |  9.411 ns |  18.766 ns | 1.0286 ns |  0.83 |    0.08 |         - |          NA |
| LibraryImport_Ref_SuppressGC  |  2.389 ns |   9.706 ns | 0.5320 ns |  0.21 |    0.04 |         - |          NA |
