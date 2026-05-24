```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                                          | Mean      | Error     | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------------ |----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| DllImport_IntPtr_NoDecode                       |  20.81 ns |  97.94 ns | 5.369 ns |  1.04 |    0.32 |      - |         - |          NA |
| DllImport_IntPtr_PtrToStringAnsi                | 266.66 ns |  75.47 ns | 4.137 ns | 13.37 |    2.83 | 0.0124 |      80 B |          NA |
| DllImport_IntPtr_PtrToStringUTF8                | 151.01 ns | 147.62 ns | 8.092 ns |  7.57 |    1.64 | 0.0126 |      80 B |          NA |
| DllImport_IntPtr_PtrToStringUni                 |  93.33 ns |  25.04 ns | 1.373 ns |  4.68 |    0.99 | 0.0126 |      80 B |          NA |
| LibraryImport_IntPtr_NoDecode                   |  17.23 ns |  39.90 ns | 2.187 ns |  0.86 |    0.21 |      - |         - |          NA |
| LibraryImport_IntPtr_SuppressGC_PtrToStringUTF8 | 130.76 ns | 126.32 ns | 6.924 ns |  6.55 |    1.42 | 0.0126 |      80 B |          NA |
