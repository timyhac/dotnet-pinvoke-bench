```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                        | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| DllImport_BytePointer         | 10.337 ns |  4.855 ns | 0.2661 ns |  1.00 |    0.03 |         - |          NA |
| DllImport_RefByte             | 12.025 ns | 33.085 ns | 1.8135 ns |  1.16 |    0.15 |         - |          NA |
| LibraryImport_Span            |  9.166 ns | 24.711 ns | 1.3545 ns |  0.89 |    0.12 |         - |          NA |
| LibraryImport_Span_SuppressGC |  3.416 ns |  4.947 ns | 0.2711 ns |  0.33 |    0.02 |         - |          NA |
