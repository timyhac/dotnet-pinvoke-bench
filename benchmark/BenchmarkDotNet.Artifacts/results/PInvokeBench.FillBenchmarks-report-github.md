```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                           | Size | Mean         | Error        | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------- |----- |-------------:|-------------:|-----------:|------:|--------:|----------:|------------:|
| **DllImport_ByteArray**              | **0**    |    **25.251 ns** |     **6.885 ns** |  **0.3774 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| DllImport_BytePointer            | 0    |    16.011 ns |     8.230 ns |  0.4511 ns |  0.63 |    0.02 |         - |          NA |
| DllImport_RefByte                | 0    |    20.086 ns |    45.185 ns |  2.4767 ns |  0.80 |    0.09 |         - |          NA |
| LibraryImport_Span               | 0    |    20.201 ns |    13.936 ns |  0.7639 ns |  0.80 |    0.03 |         - |          NA |
| LibraryImport_RefByte            | 0    |    12.992 ns |    57.121 ns |  3.1310 ns |  0.51 |    0.11 |         - |          NA |
| LibraryImport_Span_SuppressGC    | 0    |     5.222 ns |     5.231 ns |  0.2867 ns |  0.21 |    0.01 |         - |          NA |
| LibraryImport_RefByte_SuppressGC | 0    |     4.789 ns |     7.374 ns |  0.4042 ns |  0.19 |    0.01 |         - |          NA |
|                                  |      |              |              |            |       |         |           |             |
| **DllImport_ByteArray**              | **16**   |    **19.908 ns** |    **39.410 ns** |  **2.1602 ns** |  **1.01** |    **0.14** |         **-** |          **NA** |
| DllImport_BytePointer            | 16   |    18.179 ns |     4.935 ns |  0.2705 ns |  0.92 |    0.09 |         - |          NA |
| DllImport_RefByte                | 16   |    20.243 ns |    31.261 ns |  1.7135 ns |  1.03 |    0.13 |         - |          NA |
| LibraryImport_Span               | 16   |    22.218 ns |    27.849 ns |  1.5265 ns |  1.13 |    0.13 |         - |          NA |
| LibraryImport_RefByte            | 16   |    18.606 ns |    21.512 ns |  1.1791 ns |  0.94 |    0.11 |         - |          NA |
| LibraryImport_Span_SuppressGC    | 16   |    11.878 ns |    35.148 ns |  1.9266 ns |  0.60 |    0.10 |         - |          NA |
| LibraryImport_RefByte_SuppressGC | 16   |     8.889 ns |     7.507 ns |  0.4115 ns |  0.45 |    0.05 |         - |          NA |
|                                  |      |              |              |            |       |         |           |             |
| **DllImport_ByteArray**              | **256**  |   **101.497 ns** |   **116.389 ns** |  **6.3797 ns** |  **1.00** |    **0.08** |         **-** |          **NA** |
| DllImport_BytePointer            | 256  |   105.481 ns |    87.021 ns |  4.7699 ns |  1.04 |    0.07 |         - |          NA |
| DllImport_RefByte                | 256  |   102.378 ns |    51.910 ns |  2.8454 ns |  1.01 |    0.06 |         - |          NA |
| LibraryImport_Span               | 256  |    94.778 ns |    60.699 ns |  3.3271 ns |  0.94 |    0.06 |         - |          NA |
| LibraryImport_RefByte            | 256  |    92.017 ns |    86.300 ns |  4.7304 ns |  0.91 |    0.06 |         - |          NA |
| LibraryImport_Span_SuppressGC    | 256  |    86.968 ns |    71.870 ns |  3.9394 ns |  0.86 |    0.06 |         - |          NA |
| LibraryImport_RefByte_SuppressGC | 256  |    78.605 ns |    63.703 ns |  3.4918 ns |  0.78 |    0.05 |         - |          NA |
|                                  |      |              |              |            |       |         |           |             |
| **DllImport_ByteArray**              | **4096** | **1,160.295 ns** |   **956.056 ns** | **52.4047 ns** |  **1.00** |    **0.06** |         **-** |          **NA** |
| DllImport_BytePointer            | 4096 | 1,136.909 ns | 1,231.263 ns | 67.4897 ns |  0.98 |    0.06 |         - |          NA |
| DllImport_RefByte                | 4096 | 1,187.622 ns |   547.303 ns | 29.9995 ns |  1.02 |    0.05 |         - |          NA |
| LibraryImport_Span               | 4096 | 1,255.952 ns | 1,723.221 ns | 94.4556 ns |  1.08 |    0.08 |         - |          NA |
| LibraryImport_RefByte            | 4096 | 1,190.765 ns | 1,028.844 ns | 56.3944 ns |  1.03 |    0.06 |         - |          NA |
| LibraryImport_Span_SuppressGC    | 4096 | 1,101.995 ns |   269.031 ns | 14.7465 ns |  0.95 |    0.04 |         - |          NA |
| LibraryImport_RefByte_SuppressGC | 4096 | 1,078.026 ns |   404.540 ns | 22.1742 ns |  0.93 |    0.04 |         - |          NA |
