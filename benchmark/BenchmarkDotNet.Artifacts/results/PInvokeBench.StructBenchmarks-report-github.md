```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                               | ArrayLen | Mean          | Error         | StdDev      | Ratio  | RatioSD | Allocated | Alloc Ratio |
|------------------------------------- |--------- |--------------:|--------------:|------------:|-------:|--------:|----------:|------------:|
| **DllImport_ByVal_Small**                | **0**        |     **5.5149 ns** |     **6.6111 ns** |   **0.3624 ns** |   **1.00** |    **0.08** |         **-** |          **NA** |
| DllImport_In_Small                   | 0        |     7.4463 ns |     6.2232 ns |   0.3411 ns |   1.35 |    0.09 |         - |          NA |
| DllImport_Ref_Small                  | 0        |     7.7426 ns |    13.0482 ns |   0.7152 ns |   1.41 |    0.14 |         - |          NA |
| DllImport_Pointer_Small              | 0        |     4.9507 ns |     9.4169 ns |   0.5162 ns |   0.90 |    0.10 |         - |          NA |
| DllImport_ByVal_Large                | 0        |     5.8741 ns |     5.0108 ns |   0.2747 ns |   1.07 |    0.07 |         - |          NA |
| DllImport_In_Large                   | 0        |     7.5010 ns |     7.5527 ns |   0.4140 ns |   1.36 |    0.10 |         - |          NA |
| DllImport_Array                      | 0        |   135.7899 ns |   404.2994 ns |  22.1610 ns |  24.69 |    3.75 |         - |          NA |
| LibraryImport_ByVal_Small            | 0        |     6.1963 ns |     6.8741 ns |   0.3768 ns |   1.13 |    0.09 |         - |          NA |
| LibraryImport_In_Small               | 0        |     6.6102 ns |     4.9137 ns |   0.2693 ns |   1.20 |    0.08 |         - |          NA |
| LibraryImport_ByVal_Small_SuppressGC | 0        |     1.3810 ns |     5.9574 ns |   0.3265 ns |   0.25 |    0.05 |         - |          NA |
| LibraryImport_Array_Span             | 0        |     5.6454 ns |     4.7426 ns |   0.2600 ns |   1.03 |    0.07 |         - |          NA |
|                                      |          |               |               |             |        |         |           |             |
| **DllImport_ByVal_Small**                | **16**       |     **5.0890 ns** |     **2.8219 ns** |   **0.1547 ns** |   **1.00** |    **0.04** |         **-** |          **NA** |
| DllImport_In_Small                   | 16       |     6.6518 ns |     4.6249 ns |   0.2535 ns |   1.31 |    0.05 |         - |          NA |
| DllImport_Ref_Small                  | 16       |     6.7139 ns |     5.0683 ns |   0.2778 ns |   1.32 |    0.06 |         - |          NA |
| DllImport_Pointer_Small              | 16       |     6.9883 ns |     0.7585 ns |   0.0416 ns |   1.37 |    0.04 |         - |          NA |
| DllImport_ByVal_Large                | 16       |     7.0894 ns |     9.8557 ns |   0.5402 ns |   1.39 |    0.10 |         - |          NA |
| DllImport_In_Large                   | 16       |    13.2408 ns |    47.4480 ns |   2.6008 ns |   2.60 |    0.45 |         - |          NA |
| DllImport_Array                      | 16       |   172.7018 ns |   167.8986 ns |   9.2031 ns |  33.96 |    1.80 |         - |          NA |
| LibraryImport_ByVal_Small            | 16       |     7.5736 ns |    10.3319 ns |   0.5663 ns |   1.49 |    0.10 |         - |          NA |
| LibraryImport_In_Small               | 16       |    10.9722 ns |    14.1682 ns |   0.7766 ns |   2.16 |    0.14 |         - |          NA |
| LibraryImport_ByVal_Small_SuppressGC | 16       |     1.1791 ns |     0.8921 ns |   0.0489 ns |   0.23 |    0.01 |         - |          NA |
| LibraryImport_Array_Span             | 16       |    11.6277 ns |     2.5455 ns |   0.1395 ns |   2.29 |    0.06 |         - |          NA |
|                                      |          |               |               |             |        |         |           |             |
| **DllImport_ByVal_Small**                | **256**      |     **7.0051 ns** |     **7.4683 ns** |   **0.4094 ns** |   **1.00** |    **0.07** |         **-** |          **NA** |
| DllImport_In_Small                   | 256      |     6.9506 ns |     4.4961 ns |   0.2464 ns |   0.99 |    0.06 |         - |          NA |
| DllImport_Ref_Small                  | 256      |     7.2154 ns |     2.6603 ns |   0.1458 ns |   1.03 |    0.05 |         - |          NA |
| DllImport_Pointer_Small              | 256      |     6.7354 ns |     1.4848 ns |   0.0814 ns |   0.96 |    0.05 |         - |          NA |
| DllImport_ByVal_Large                | 256      |     7.4882 ns |     3.1523 ns |   0.1728 ns |   1.07 |    0.06 |         - |          NA |
| DllImport_In_Large                   | 256      |     7.6109 ns |     9.3468 ns |   0.5123 ns |   1.09 |    0.08 |         - |          NA |
| DllImport_Array                      | 256      |   359.7630 ns |   375.4350 ns |  20.5789 ns |  51.47 |    3.59 |         - |          NA |
| LibraryImport_ByVal_Small            | 256      |     5.3648 ns |     2.6134 ns |   0.1433 ns |   0.77 |    0.04 |         - |          NA |
| LibraryImport_In_Small               | 256      |     6.0625 ns |     3.3924 ns |   0.1859 ns |   0.87 |    0.05 |         - |          NA |
| LibraryImport_ByVal_Small_SuppressGC | 256      |     0.7558 ns |     2.6471 ns |   0.1451 ns |   0.11 |    0.02 |         - |          NA |
| LibraryImport_Array_Span             | 256      |   133.8609 ns |     6.4805 ns |   0.3552 ns |  19.15 |    0.94 |         - |          NA |
|                                      |          |               |               |             |        |         |           |             |
| **DllImport_ByVal_Small**                | **4096**     |     **5.0252 ns** |     **3.6410 ns** |   **0.1996 ns** |   **1.00** |    **0.05** |         **-** |          **NA** |
| DllImport_In_Small                   | 4096     |     7.7024 ns |    21.2470 ns |   1.1646 ns |   1.53 |    0.21 |         - |          NA |
| DllImport_Ref_Small                  | 4096     |     7.7833 ns |     7.0117 ns |   0.3843 ns |   1.55 |    0.09 |         - |          NA |
| DllImport_Pointer_Small              | 4096     |     5.8302 ns |    15.2992 ns |   0.8386 ns |   1.16 |    0.15 |         - |          NA |
| DllImport_ByVal_Large                | 4096     |     5.6882 ns |     2.4012 ns |   0.1316 ns |   1.13 |    0.05 |         - |          NA |
| DllImport_In_Large                   | 4096     |     8.4311 ns |    11.6839 ns |   0.6404 ns |   1.68 |    0.13 |         - |          NA |
| DllImport_Array                      | 4096     | 3,417.7124 ns | 2,614.8576 ns | 143.3292 ns | 680.84 |   34.42 |         - |          NA |
| LibraryImport_ByVal_Small            | 4096     |     5.6198 ns |     9.6707 ns |   0.5301 ns |   1.12 |    0.10 |         - |          NA |
| LibraryImport_In_Small               | 4096     |     5.8933 ns |     4.2965 ns |   0.2355 ns |   1.17 |    0.06 |         - |          NA |
| LibraryImport_ByVal_Small_SuppressGC | 4096     |     1.5308 ns |     3.3513 ns |   0.1837 ns |   0.30 |    0.03 |         - |          NA |
| LibraryImport_Array_Span             | 4096     | 2,314.4697 ns | 3,751.6714 ns | 205.6418 ns | 461.07 |   39.02 |         - |          NA |
