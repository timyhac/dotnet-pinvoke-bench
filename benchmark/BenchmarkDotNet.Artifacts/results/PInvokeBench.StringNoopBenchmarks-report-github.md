```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8328)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.203
  [Host]   : .NET 8.0.26 (8.0.2626.16921), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.26 (8.0.2626.16921), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                                          | Length | Mean         | Error        | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------------------ |------- |-------------:|-------------:|-----------:|------:|--------:|----------:|------------:|
| **&#39;DllImport string default (noop)&#39;**               | **0**      |    **38.278 ns** |    **18.665 ns** |  **1.0231 ns** |  **1.00** |    **0.03** |         **-** |          **NA** |
| &#39;DllImport [LPUTF8Str] string (noop)&#39;           | 0      |    22.837 ns |    45.993 ns |  2.5210 ns |  0.60 |    0.06 |         - |          NA |
| &#39;DllImport byte* + manual UTF-8 (noop)&#39;         | 0      |    12.850 ns |    54.249 ns |  2.9736 ns |  0.34 |    0.07 |         - |          NA |
| &#39;DllImport byte* + pre-encoded buffer (noop)&#39;   | 0      |     8.668 ns |     5.880 ns |  0.3223 ns |  0.23 |    0.01 |         - |          NA |
| &#39;LibraryImport string Utf8 (noop)&#39;              | 0      |    12.408 ns |    19.594 ns |  1.0740 ns |  0.32 |    0.03 |         - |          NA |
| &#39;LibraryImport string Utf8 + SuppressGC (noop)&#39; | 0      |    11.042 ns |    24.545 ns |  1.3454 ns |  0.29 |    0.03 |         - |          NA |
|                                                 |        |              |              |            |       |         |           |             |
| **&#39;DllImport string default (noop)&#39;**               | **16**     |    **48.782 ns** |    **21.567 ns** |  **1.1821 ns** |  **1.00** |    **0.03** |         **-** |          **NA** |
| &#39;DllImport [LPUTF8Str] string (noop)&#39;           | 16     |    21.266 ns |    25.389 ns |  1.3917 ns |  0.44 |    0.03 |         - |          NA |
| &#39;DllImport byte* + manual UTF-8 (noop)&#39;         | 16     |    21.528 ns |    42.460 ns |  2.3274 ns |  0.44 |    0.04 |         - |          NA |
| &#39;DllImport byte* + pre-encoded buffer (noop)&#39;   | 16     |     6.163 ns |    11.345 ns |  0.6219 ns |  0.13 |    0.01 |         - |          NA |
| &#39;LibraryImport string Utf8 (noop)&#39;              | 16     |    13.092 ns |     9.095 ns |  0.4985 ns |  0.27 |    0.01 |         - |          NA |
| &#39;LibraryImport string Utf8 + SuppressGC (noop)&#39; | 16     |    10.874 ns |     8.276 ns |  0.4537 ns |  0.22 |    0.01 |         - |          NA |
|                                                 |        |              |              |            |       |         |           |             |
| **&#39;DllImport string default (noop)&#39;**               | **256**    |   **158.375 ns** |   **268.381 ns** | **14.7109 ns** |  **1.01** |    **0.11** |         **-** |          **NA** |
| &#39;DllImport [LPUTF8Str] string (noop)&#39;           | 256    |    89.155 ns |    70.711 ns |  3.8759 ns |  0.57 |    0.05 |         - |          NA |
| &#39;DllImport byte* + manual UTF-8 (noop)&#39;         | 256    |    33.675 ns |    18.799 ns |  1.0305 ns |  0.21 |    0.02 |         - |          NA |
| &#39;DllImport byte* + pre-encoded buffer (noop)&#39;   | 256    |     5.845 ns |     5.151 ns |  0.2824 ns |  0.04 |    0.00 |         - |          NA |
| &#39;LibraryImport string Utf8 (noop)&#39;              | 256    |   298.346 ns |   161.002 ns |  8.8251 ns |  1.89 |    0.15 |         - |          NA |
| &#39;LibraryImport string Utf8 + SuppressGC (noop)&#39; | 256    |    90.602 ns |    42.279 ns |  2.3175 ns |  0.58 |    0.05 |         - |          NA |
|                                                 |        |              |              |            |       |         |           |             |
| **&#39;DllImport string default (noop)&#39;**               | **4096**   | **1,958.643 ns** | **1,723.167 ns** | **94.4526 ns** | **1.002** |    **0.06** |         **-** |          **NA** |
| &#39;DllImport [LPUTF8Str] string (noop)&#39;           | 4096   |   274.211 ns |   301.126 ns | 16.5057 ns | 0.140 |    0.01 |         - |          NA |
| &#39;DllImport byte* + manual UTF-8 (noop)&#39;         | 4096   |   234.488 ns |    44.371 ns |  2.4321 ns | 0.120 |    0.01 |         - |          NA |
| &#39;DllImport byte* + pre-encoded buffer (noop)&#39;   | 4096   |     5.674 ns |     3.030 ns |  0.1661 ns | 0.003 |    0.00 |         - |          NA |
| &#39;LibraryImport string Utf8 (noop)&#39;              | 4096   |   266.126 ns |   200.352 ns | 10.9820 ns | 0.136 |    0.01 |         - |          NA |
| &#39;LibraryImport string Utf8 + SuppressGC (noop)&#39; | 4096   |   275.313 ns |   129.606 ns |  7.1041 ns | 0.141 |    0.01 |         - |          NA |
