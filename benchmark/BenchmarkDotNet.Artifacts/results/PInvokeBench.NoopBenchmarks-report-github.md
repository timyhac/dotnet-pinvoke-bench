```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8328)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.203
  [Host]   : .NET 8.0.26 (8.0.2626.16921), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.26 (8.0.2626.16921), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                                   | Mean     | Error    | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------- |---------:|---------:|----------:|------:|--------:|----------:|------------:|
| &#39;DllImport byte* + fixed (noop)&#39;         | 7.439 ns | 7.573 ns | 0.4151 ns |  1.00 |    0.07 |         - |          NA |
| &#39;DllImport ref byte (noop)&#39;              | 8.377 ns | 7.490 ns | 0.4105 ns |  1.13 |    0.07 |         - |          NA |
| &#39;LibraryImport Span (noop)&#39;              | 9.409 ns | 4.886 ns | 0.2678 ns |  1.27 |    0.07 |         - |          NA |
| &#39;LibraryImport Span + SuppressGC (noop)&#39; | 1.661 ns | 1.059 ns | 0.0580 ns |  0.22 |    0.01 |         - |          NA |
