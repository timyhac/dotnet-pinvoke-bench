```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                             | Mean     | Error     | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------- |---------:|----------:|---------:|------:|--------:|----------:|------------:|
| DllImport_NoSetLastError           | 11.07 ns | 29.932 ns | 1.641 ns |  1.01 |    0.18 |         - |          NA |
| DllImport_SetLastError             | 18.49 ns | 10.320 ns | 0.566 ns |  1.69 |    0.21 |         - |          NA |
| DllImport_SetLastError_AndRead     | 20.03 ns | 10.834 ns | 0.594 ns |  1.83 |    0.23 |         - |          NA |
| LibraryImport_NoSetLastError       | 10.60 ns |  8.971 ns | 0.492 ns |  0.97 |    0.13 |         - |          NA |
| LibraryImport_SetLastError         | 12.59 ns |  2.004 ns | 0.110 ns |  1.15 |    0.14 |         - |          NA |
| LibraryImport_SetLastError_AndRead | 15.96 ns | 30.522 ns | 1.673 ns |  1.46 |    0.22 |         - |          NA |
