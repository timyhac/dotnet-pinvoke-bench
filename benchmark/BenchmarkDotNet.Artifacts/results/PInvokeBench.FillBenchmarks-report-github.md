```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8328)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.203
  [Host]   : .NET 8.0.26 (8.0.2626.16921), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.26 (8.0.2626.16921), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                                | Size | Mean       | Error        | StdDev      | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------------- |----- |-----------:|-------------:|------------:|------:|--------:|----------:|------------:|
| **&#39;DllImport byte[]&#39;**                    | **0**    |   **7.364 ns** |     **7.542 ns** |   **0.4134 ns** |  **1.00** |    **0.07** |         **-** |          **NA** |
| &#39;DllImport byte* + fixed&#39;             | 0    |   6.404 ns |     7.814 ns |   0.4283 ns |  0.87 |    0.07 |         - |          NA |
| &#39;DllImport ref byte + GetReference&#39;   | 0    |   8.312 ns |    19.251 ns |   1.0552 ns |  1.13 |    0.14 |         - |          NA |
| &#39;LibraryImport Span&lt;byte&gt;&#39;            | 0    |   8.158 ns |     7.862 ns |   0.4310 ns |  1.11 |    0.07 |         - |          NA |
| &#39;LibraryImport ref byte&#39;              | 0    |   7.902 ns |     3.322 ns |   0.1821 ns |  1.08 |    0.06 |         - |          NA |
| &#39;LibraryImport Span + SuppressGC&#39;     | 0    |   2.530 ns |     3.544 ns |   0.1943 ns |  0.34 |    0.03 |         - |          NA |
| &#39;LibraryImport ref byte + SuppressGC&#39; | 0    |   2.811 ns |     8.668 ns |   0.4751 ns |  0.38 |    0.06 |         - |          NA |
|                                       |      |            |              |             |       |         |           |             |
| **&#39;DllImport byte[]&#39;**                    | **16**   |  **14.979 ns** |    **45.164 ns** |   **2.4756 ns** |  **1.02** |    **0.22** |         **-** |          **NA** |
| &#39;DllImport byte* + fixed&#39;             | 16   |  10.676 ns |    23.931 ns |   1.3117 ns |  0.73 |    0.14 |         - |          NA |
| &#39;DllImport ref byte + GetReference&#39;   | 16   |  12.166 ns |    10.595 ns |   0.5808 ns |  0.83 |    0.13 |         - |          NA |
| &#39;LibraryImport Span&lt;byte&gt;&#39;            | 16   |  10.581 ns |     5.340 ns |   0.2927 ns |  0.72 |    0.11 |         - |          NA |
| &#39;LibraryImport ref byte&#39;              | 16   |  10.215 ns |    25.290 ns |   1.3862 ns |  0.70 |    0.14 |         - |          NA |
| &#39;LibraryImport Span + SuppressGC&#39;     | 16   |   6.622 ns |     2.325 ns |   0.1275 ns |  0.45 |    0.07 |         - |          NA |
| &#39;LibraryImport ref byte + SuppressGC&#39; | 16   |   7.199 ns |    23.765 ns |   1.3026 ns |  0.49 |    0.11 |         - |          NA |
|                                       |      |            |              |             |       |         |           |             |
| **&#39;DllImport byte[]&#39;**                    | **256**  |  **62.847 ns** |   **143.394 ns** |   **7.8599 ns** |  **1.01** |    **0.15** |         **-** |          **NA** |
| &#39;DllImport byte* + fixed&#39;             | 256  |  66.597 ns |     9.334 ns |   0.5116 ns |  1.07 |    0.11 |         - |          NA |
| &#39;DllImport ref byte + GetReference&#39;   | 256  |  59.170 ns |    58.233 ns |   3.1920 ns |  0.95 |    0.11 |         - |          NA |
| &#39;LibraryImport Span&lt;byte&gt;&#39;            | 256  |  58.338 ns |    29.117 ns |   1.5960 ns |  0.94 |    0.10 |         - |          NA |
| &#39;LibraryImport ref byte&#39;              | 256  |  68.044 ns |    24.479 ns |   1.3418 ns |  1.09 |    0.11 |         - |          NA |
| &#39;LibraryImport Span + SuppressGC&#39;     | 256  |  50.538 ns |    37.805 ns |   2.0722 ns |  0.81 |    0.09 |         - |          NA |
| &#39;LibraryImport ref byte + SuppressGC&#39; | 256  |  51.394 ns |   124.004 ns |   6.7971 ns |  0.83 |    0.13 |         - |          NA |
|                                       |      |            |              |             |       |         |           |             |
| **&#39;DllImport byte[]&#39;**                    | **4096** | **726.735 ns** |   **987.372 ns** |  **54.1212 ns** |  **1.00** |    **0.09** |         **-** |          **NA** |
| &#39;DllImport byte* + fixed&#39;             | 4096 | 701.227 ns |   985.405 ns |  54.0134 ns |  0.97 |    0.09 |         - |          NA |
| &#39;DllImport ref byte + GetReference&#39;   | 4096 | 722.305 ns | 1,050.854 ns |  57.6008 ns |  1.00 |    0.10 |         - |          NA |
| &#39;LibraryImport Span&lt;byte&gt;&#39;            | 4096 | 786.350 ns | 1,052.173 ns |  57.6732 ns |  1.09 |    0.10 |         - |          NA |
| &#39;LibraryImport ref byte&#39;              | 4096 | 784.884 ns |   262.701 ns |  14.3995 ns |  1.08 |    0.07 |         - |          NA |
| &#39;LibraryImport Span + SuppressGC&#39;     | 4096 | 707.069 ns | 2,068.260 ns | 113.3683 ns |  0.98 |    0.15 |         - |          NA |
| &#39;LibraryImport ref byte + SuppressGC&#39; | 4096 | 740.890 ns |   589.905 ns |  32.3347 ns |  1.02 |    0.08 |         - |          NA |
