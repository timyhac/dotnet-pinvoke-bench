```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                          | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| DllImport_IntPtr                |  8.189 ns |  3.806 ns | 0.2086 ns |  1.00 |    0.03 |         - |          NA |
| DllImport_SafeHandle            | 29.882 ns |  7.951 ns | 0.4358 ns |  3.65 |    0.09 |         - |          NA |
| LibraryImport_IntPtr            |  8.461 ns |  6.238 ns | 0.3419 ns |  1.03 |    0.04 |         - |          NA |
| LibraryImport_SafeHandle        | 30.444 ns | 14.681 ns | 0.8047 ns |  3.72 |    0.12 |         - |          NA |
| LibraryImport_IntPtr_SuppressGC |  1.925 ns |  5.170 ns | 0.2834 ns |  0.24 |    0.03 |         - |          NA |
