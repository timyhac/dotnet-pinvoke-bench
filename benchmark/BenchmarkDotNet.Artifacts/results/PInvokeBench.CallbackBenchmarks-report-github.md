```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                                  | Mean     | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------------- |---------:|----------:|----------:|------:|--------:|----------:|------------:|
| DllImport_Delegate                      | 63.70 ns |  23.91 ns |  1.311 ns |  1.00 |    0.03 |         - |          NA |
| DllImport_FunctionPointer_Cached        | 20.67 ns |  19.67 ns |  1.078 ns |  0.32 |    0.02 |         - |          NA |
| DllImport_FunctionPointer_PerCall       | 58.25 ns |  22.83 ns |  1.251 ns |  0.91 |    0.02 |         - |          NA |
| DllImport_UnmanagedCallersOnly          | 14.83 ns |  10.56 ns |  0.579 ns |  0.23 |    0.01 |         - |          NA |
| DllImport_Delegate_Userdata             | 71.22 ns |  70.50 ns |  3.864 ns |  1.12 |    0.06 |         - |          NA |
| DllImport_FunctionPointer_Userdata      | 40.63 ns |  37.03 ns |  2.029 ns |  0.64 |    0.03 |         - |          NA |
| DllImport_UnmanagedCallersOnly_Userdata | 16.74 ns |  31.00 ns |  1.699 ns |  0.26 |    0.02 |         - |          NA |
| LibraryImport_Delegate                  | 77.81 ns | 262.16 ns | 14.370 ns |  1.22 |    0.20 |         - |          NA |
| LibraryImport_UnmanagedCallersOnly      | 23.15 ns |  40.52 ns |  2.221 ns |  0.36 |    0.03 |         - |          NA |
