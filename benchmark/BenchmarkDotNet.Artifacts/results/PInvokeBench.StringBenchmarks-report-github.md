```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8328)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.203
  [Host]   : .NET 8.0.26 (8.0.2626.16921), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.26 (8.0.2626.16921), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                                             | Length | Mean         | Error        | StdDev      | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------------------- |------- |-------------:|-------------:|------------:|------:|--------:|----------:|------------:|
| **&#39;DllImport string (default LPStr/ANSI)&#39;**            | **0**      |    **30.350 ns** |    **35.251 ns** |   **1.9322 ns** |  **1.00** |    **0.08** |         **-** |          **NA** |
| &#39;DllImport [LPUTF8Str] string&#39;                     | 0      |    22.104 ns |    14.161 ns |   0.7762 ns |  0.73 |    0.04 |         - |          NA |
| &#39;DllImport byte* + manual UTF-8 (stackalloc/pool)&#39; | 0      |    16.241 ns |    64.956 ns |   3.5605 ns |  0.54 |    0.11 |         - |          NA |
| &#39;DllImport byte* + pre-encoded buffer&#39;             | 0      |     8.615 ns |    21.994 ns |   1.2056 ns |  0.28 |    0.04 |         - |          NA |
| &#39;LibraryImport string Utf8&#39;                        | 0      |    13.995 ns |     5.057 ns |   0.2772 ns |  0.46 |    0.03 |         - |          NA |
| &#39;LibraryImport string Utf8 + SuppressGC&#39;           | 0      |    10.717 ns |     3.491 ns |   0.1914 ns |  0.35 |    0.02 |         - |          NA |
|                                                    |        |              |              |             |       |         |           |             |
| **&#39;DllImport string (default LPStr/ANSI)&#39;**            | **16**     |    **51.002 ns** |    **85.857 ns** |   **4.7061 ns** |  **1.01** |    **0.11** |         **-** |          **NA** |
| &#39;DllImport [LPUTF8Str] string&#39;                     | 16     |    27.308 ns |    35.663 ns |   1.9548 ns |  0.54 |    0.05 |         - |          NA |
| &#39;DllImport byte* + manual UTF-8 (stackalloc/pool)&#39; | 16     |    34.238 ns |   125.022 ns |   6.8529 ns |  0.68 |    0.13 |         - |          NA |
| &#39;DllImport byte* + pre-encoded buffer&#39;             | 16     |    14.555 ns |    17.448 ns |   0.9564 ns |  0.29 |    0.03 |         - |          NA |
| &#39;LibraryImport string Utf8&#39;                        | 16     |    26.324 ns |    25.117 ns |   1.3767 ns |  0.52 |    0.05 |         - |          NA |
| &#39;LibraryImport string Utf8 + SuppressGC&#39;           | 16     |    20.378 ns |     9.049 ns |   0.4960 ns |  0.40 |    0.03 |         - |          NA |
|                                                    |        |              |              |             |       |         |           |             |
| **&#39;DllImport string (default LPStr/ANSI)&#39;**            | **256**    |   **373.769 ns** | **1,319.864 ns** |  **72.3462 ns** |  **1.03** |    **0.26** |         **-** |          **NA** |
| &#39;DllImport [LPUTF8Str] string&#39;                     | 256    |   302.377 ns |   514.527 ns |  28.2029 ns |  0.83 |    0.17 |         - |          NA |
| &#39;DllImport byte* + manual UTF-8 (stackalloc/pool)&#39; | 256    |   175.387 ns |    64.388 ns |   3.5293 ns |  0.48 |    0.09 |         - |          NA |
| &#39;DllImport byte* + pre-encoded buffer&#39;             | 256    |   174.795 ns |   479.430 ns |  26.2792 ns |  0.48 |    0.11 |         - |          NA |
| &#39;LibraryImport string Utf8&#39;                        | 256    |   291.672 ns |   411.759 ns |  22.5699 ns |  0.80 |    0.16 |         - |          NA |
| &#39;LibraryImport string Utf8 + SuppressGC&#39;           | 256    |   307.758 ns |   214.181 ns |  11.7400 ns |  0.85 |    0.16 |         - |          NA |
|                                                    |        |              |              |             |       |         |           |             |
| **&#39;DllImport string (default LPStr/ANSI)&#39;**            | **4096**   | **5,162.863 ns** | **2,755.232 ns** | **151.0236 ns** |  **1.00** |    **0.04** |         **-** |          **NA** |
| &#39;DllImport [LPUTF8Str] string&#39;                     | 4096   | 2,639.806 ns | 3,838.691 ns | 210.4116 ns |  0.51 |    0.04 |         - |          NA |
| &#39;DllImport byte* + manual UTF-8 (stackalloc/pool)&#39; | 4096   | 2,439.744 ns | 4,726.474 ns | 259.0740 ns |  0.47 |    0.05 |         - |          NA |
| &#39;DllImport byte* + pre-encoded buffer&#39;             | 4096   | 1,916.645 ns | 1,457.030 ns |  79.8647 ns |  0.37 |    0.02 |         - |          NA |
| &#39;LibraryImport string Utf8&#39;                        | 4096   | 2,443.290 ns | 4,248.751 ns | 232.8884 ns |  0.47 |    0.04 |         - |          NA |
| &#39;LibraryImport string Utf8 + SuppressGC&#39;           | 4096   | 2,498.567 ns | 1,408.671 ns |  77.2140 ns |  0.48 |    0.02 |         - |          NA |
