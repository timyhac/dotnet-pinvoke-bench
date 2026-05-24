```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                          | Length | Pay    | Mean         | Error         | StdDev      | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------- |------- |------- |-------------:|--------------:|------------:|------:|--------:|----------:|------------:|
| **DllImport_CharSetUnicode**        | **0**      | **Ascii**  |     **9.870 ns** |    **16.4467 ns** |   **0.9015 ns** |  **1.01** |    **0.11** |         **-** |          **NA** |
| DllImport_LPWStr                | 0      | Ascii  |     6.600 ns |     3.7615 ns |   0.2062 ns |  0.67 |    0.06 |         - |          NA |
| DllImport_CharPointer           | 0      | Ascii  |     5.185 ns |     2.3659 ns |   0.1297 ns |  0.53 |    0.04 |         - |          NA |
| DllImport_CharArray             | 0      | Ascii  |   206.999 ns |   387.6680 ns |  21.2494 ns | 21.09 |    2.50 |         - |          NA |
| DllImport_StringBuilder         | 0      | Ascii  |    23.923 ns |    18.2172 ns |   0.9985 ns |  2.44 |    0.21 |         - |          NA |
| LibraryImport_Utf16             | 0      | Ascii  |     5.966 ns |     8.2856 ns |   0.4542 ns |  0.61 |    0.06 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 0      | Ascii  |     1.823 ns |     3.2487 ns |   0.1781 ns |  0.19 |    0.02 |         - |          NA |
| LibraryImport_ROSpan            | 0      | Ascii  |     7.012 ns |     0.8535 ns |   0.0468 ns |  0.71 |    0.06 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Ascii  |     1.447 ns |     1.0489 ns |   0.0575 ns |  0.15 |    0.01 |         - |          NA |
|                                 |        |        |              |               |             |       |         |           |             |
| **DllImport_CharSetUnicode**        | **0**      | **Latin1** |    **10.158 ns** |    **23.4763 ns** |   **1.2868 ns** |  **1.01** |    **0.16** |         **-** |          **NA** |
| DllImport_LPWStr                | 0      | Latin1 |     8.146 ns |    17.2332 ns |   0.9446 ns |  0.81 |    0.12 |         - |          NA |
| DllImport_CharPointer           | 0      | Latin1 |     8.730 ns |     8.0635 ns |   0.4420 ns |  0.87 |    0.11 |         - |          NA |
| DllImport_CharArray             | 0      | Latin1 |   201.510 ns |   321.4834 ns |  17.6216 ns | 20.06 |    2.74 |         - |          NA |
| DllImport_StringBuilder         | 0      | Latin1 |    26.667 ns |    19.4404 ns |   1.0656 ns |  2.65 |    0.31 |         - |          NA |
| LibraryImport_Utf16             | 0      | Latin1 |     8.097 ns |    20.4814 ns |   1.1227 ns |  0.81 |    0.13 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 0      | Latin1 |     2.186 ns |     3.0535 ns |   0.1674 ns |  0.22 |    0.03 |         - |          NA |
| LibraryImport_ROSpan            | 0      | Latin1 |     5.832 ns |     5.6104 ns |   0.3075 ns |  0.58 |    0.07 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Latin1 |     4.710 ns |     7.3750 ns |   0.4042 ns |  0.47 |    0.06 |         - |          NA |
|                                 |        |        |              |               |             |       |         |           |             |
| **DllImport_CharSetUnicode**        | **0**      | **Cjk**    |    **12.399 ns** |    **19.6754 ns** |   **1.0785 ns** |  **1.01** |    **0.11** |         **-** |          **NA** |
| DllImport_LPWStr                | 0      | Cjk    |    16.749 ns |    12.2141 ns |   0.6695 ns |  1.36 |    0.12 |         - |          NA |
| DllImport_CharPointer           | 0      | Cjk    |    14.648 ns |    27.8366 ns |   1.5258 ns |  1.19 |    0.14 |         - |          NA |
| DllImport_CharArray             | 0      | Cjk    |   185.475 ns |   242.6461 ns |  13.3003 ns | 15.04 |    1.51 |         - |          NA |
| DllImport_StringBuilder         | 0      | Cjk    |    25.335 ns |    29.5948 ns |   1.6222 ns |  2.05 |    0.20 |         - |          NA |
| LibraryImport_Utf16             | 0      | Cjk    |     7.447 ns |    19.9395 ns |   1.0929 ns |  0.60 |    0.09 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 0      | Cjk    |     1.778 ns |     1.8418 ns |   0.1010 ns |  0.14 |    0.01 |         - |          NA |
| LibraryImport_ROSpan            | 0      | Cjk    |    10.363 ns |    12.3695 ns |   0.6780 ns |  0.84 |    0.08 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Cjk    |     3.765 ns |     6.3444 ns |   0.3478 ns |  0.31 |    0.03 |         - |          NA |
|                                 |        |        |              |               |             |       |         |           |             |
| **DllImport_CharSetUnicode**        | **16**     | **Ascii**  |    **27.263 ns** |    **27.4762 ns** |   **1.5061 ns** |  **1.00** |    **0.07** |         **-** |          **NA** |
| DllImport_LPWStr                | 16     | Ascii  |    29.538 ns |    27.0792 ns |   1.4843 ns |  1.09 |    0.07 |         - |          NA |
| DllImport_CharPointer           | 16     | Ascii  |    17.349 ns |    26.1144 ns |   1.4314 ns |  0.64 |    0.06 |         - |          NA |
| DllImport_CharArray             | 16     | Ascii  |   267.946 ns |   306.7643 ns |  16.8148 ns |  9.85 |    0.72 |         - |          NA |
| DllImport_StringBuilder         | 16     | Ascii  |    49.718 ns |    19.7088 ns |   1.0803 ns |  1.83 |    0.10 |         - |          NA |
| LibraryImport_Utf16             | 16     | Ascii  |    17.884 ns |    19.4071 ns |   1.0638 ns |  0.66 |    0.05 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 16     | Ascii  |    12.837 ns |    12.7063 ns |   0.6965 ns |  0.47 |    0.03 |         - |          NA |
| LibraryImport_ROSpan            | 16     | Ascii  |    10.894 ns |    11.8493 ns |   0.6495 ns |  0.40 |    0.03 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Ascii  |     9.069 ns |     4.8930 ns |   0.2682 ns |  0.33 |    0.02 |         - |          NA |
|                                 |        |        |              |               |             |       |         |           |             |
| **DllImport_CharSetUnicode**        | **16**     | **Latin1** |    **11.189 ns** |     **0.4152 ns** |   **0.0228 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| DllImport_LPWStr                | 16     | Latin1 |    19.144 ns |     7.1505 ns |   0.3919 ns |  1.71 |    0.03 |         - |          NA |
| DllImport_CharPointer           | 16     | Latin1 |    17.605 ns |    13.8118 ns |   0.7571 ns |  1.57 |    0.06 |         - |          NA |
| DllImport_CharArray             | 16     | Latin1 |   506.972 ns |    33.0658 ns |   1.8125 ns | 45.31 |    0.16 |         - |          NA |
| DllImport_StringBuilder         | 16     | Latin1 |    89.475 ns |    26.8260 ns |   1.4704 ns |  8.00 |    0.11 |         - |          NA |
| LibraryImport_Utf16             | 16     | Latin1 |    17.061 ns |     6.2997 ns |   0.3453 ns |  1.52 |    0.03 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 16     | Latin1 |     9.784 ns |     8.6514 ns |   0.4742 ns |  0.87 |    0.04 |         - |          NA |
| LibraryImport_ROSpan            | 16     | Latin1 |    18.038 ns |    11.0125 ns |   0.6036 ns |  1.61 |    0.05 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Latin1 |    12.203 ns |    32.2695 ns |   1.7688 ns |  1.09 |    0.14 |         - |          NA |
|                                 |        |        |              |               |             |       |         |           |             |
| **DllImport_CharSetUnicode**        | **16**     | **Cjk**    |    **11.766 ns** |    **37.1791 ns** |   **2.0379 ns** |  **1.02** |    **0.21** |         **-** |          **NA** |
| DllImport_LPWStr                | 16     | Cjk    |    15.097 ns |    38.0083 ns |   2.0834 ns |  1.31 |    0.24 |         - |          NA |
| DllImport_CharPointer           | 16     | Cjk    |    10.755 ns |     7.8452 ns |   0.4300 ns |  0.93 |    0.13 |         - |          NA |
| DllImport_CharArray             | 16     | Cjk    |   221.322 ns |   561.9734 ns |  30.8037 ns | 19.16 |    3.51 |         - |          NA |
| DllImport_StringBuilder         | 16     | Cjk    |    41.579 ns |    64.8212 ns |   3.5531 ns |  3.60 |    0.56 |         - |          NA |
| LibraryImport_Utf16             | 16     | Cjk    |    10.991 ns |    16.5403 ns |   0.9066 ns |  0.95 |    0.15 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 16     | Cjk    |     7.846 ns |     6.7772 ns |   0.3715 ns |  0.68 |    0.10 |         - |          NA |
| LibraryImport_ROSpan            | 16     | Cjk    |    14.175 ns |    47.9048 ns |   2.6258 ns |  1.23 |    0.26 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Cjk    |     9.012 ns |     9.2920 ns |   0.5093 ns |  0.78 |    0.11 |         - |          NA |
|                                 |        |        |              |               |             |       |         |           |             |
| **DllImport_CharSetUnicode**        | **256**    | **Ascii**  |   **122.390 ns** |    **64.4492 ns** |   **3.5327 ns** |  **1.00** |    **0.04** |         **-** |          **NA** |
| DllImport_LPWStr                | 256    | Ascii  |   163.305 ns |    62.7077 ns |   3.4372 ns |  1.34 |    0.04 |         - |          NA |
| DllImport_CharPointer           | 256    | Ascii  |   230.093 ns |   493.6555 ns |  27.0589 ns |  1.88 |    0.20 |         - |          NA |
| DllImport_CharArray             | 256    | Ascii  |   435.773 ns |   607.2370 ns |  33.2847 ns |  3.56 |    0.25 |         - |          NA |
| DllImport_StringBuilder         | 256    | Ascii  |   207.755 ns |    23.7733 ns |   1.3031 ns |  1.70 |    0.04 |         - |          NA |
| LibraryImport_Utf16             | 256    | Ascii  |   167.650 ns |   275.9938 ns |  15.1282 ns |  1.37 |    0.11 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 256    | Ascii  |   163.893 ns |   149.8915 ns |   8.2161 ns |  1.34 |    0.07 |         - |          NA |
| LibraryImport_ROSpan            | 256    | Ascii  |   147.151 ns |   263.2469 ns |  14.4295 ns |  1.20 |    0.11 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Ascii  |   131.852 ns |   110.6102 ns |   6.0629 ns |  1.08 |    0.05 |         - |          NA |
|                                 |        |        |              |               |             |       |         |           |             |
| **DllImport_CharSetUnicode**        | **256**    | **Latin1** |   **157.162 ns** |    **28.7472 ns** |   **1.5757 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| DllImport_LPWStr                | 256    | Latin1 |   137.853 ns |   156.6213 ns |   8.5849 ns |  0.88 |    0.05 |         - |          NA |
| DllImport_CharPointer           | 256    | Latin1 |   149.782 ns |   171.3943 ns |   9.3947 ns |  0.95 |    0.05 |         - |          NA |
| DllImport_CharArray             | 256    | Latin1 |   548.494 ns |   670.4063 ns |  36.7472 ns |  3.49 |    0.20 |         - |          NA |
| DllImport_StringBuilder         | 256    | Latin1 |   184.215 ns |   185.5058 ns |  10.1682 ns |  1.17 |    0.06 |         - |          NA |
| LibraryImport_Utf16             | 256    | Latin1 |   132.488 ns |    37.0648 ns |   2.0316 ns |  0.84 |    0.01 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 256    | Latin1 |   125.175 ns |    53.6535 ns |   2.9409 ns |  0.80 |    0.02 |         - |          NA |
| LibraryImport_ROSpan            | 256    | Latin1 |   133.597 ns |   181.8255 ns |   9.9665 ns |  0.85 |    0.06 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Latin1 |   121.765 ns |    53.1325 ns |   2.9124 ns |  0.77 |    0.02 |         - |          NA |
|                                 |        |        |              |               |             |       |         |           |             |
| **DllImport_CharSetUnicode**        | **256**    | **Cjk**    |   **132.816 ns** |    **85.6886 ns** |   **4.6969 ns** |  **1.00** |    **0.04** |         **-** |          **NA** |
| DllImport_LPWStr                | 256    | Cjk    |   132.981 ns |    94.0628 ns |   5.1559 ns |  1.00 |    0.05 |         - |          NA |
| DllImport_CharPointer           | 256    | Cjk    |   126.144 ns |    70.8302 ns |   3.8824 ns |  0.95 |    0.04 |         - |          NA |
| DllImport_CharArray             | 256    | Cjk    |   598.752 ns | 2,744.3678 ns | 150.4281 ns |  4.51 |    0.99 |         - |          NA |
| DllImport_StringBuilder         | 256    | Cjk    |   190.419 ns |   293.9333 ns |  16.1115 ns |  1.43 |    0.11 |         - |          NA |
| LibraryImport_Utf16             | 256    | Cjk    |   127.717 ns |    42.3375 ns |   2.3207 ns |  0.96 |    0.03 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 256    | Cjk    |   122.176 ns |    54.8524 ns |   3.0066 ns |  0.92 |    0.03 |         - |          NA |
| LibraryImport_ROSpan            | 256    | Cjk    |   124.869 ns |    44.2193 ns |   2.4238 ns |  0.94 |    0.03 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Cjk    |   122.046 ns |    49.3148 ns |   2.7031 ns |  0.92 |    0.03 |         - |          NA |
|                                 |        |        |              |               |             |       |         |           |             |
| **DllImport_CharSetUnicode**        | **4096**   | **Ascii**  | **1,805.096 ns** |   **664.6995 ns** |  **36.4344 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| DllImport_LPWStr                | 4096   | Ascii  | 1,819.994 ns |   771.1874 ns |  42.2714 ns |  1.01 |    0.03 |         - |          NA |
| DllImport_CharPointer           | 4096   | Ascii  | 1,891.157 ns | 1,348.5299 ns |  73.9175 ns |  1.05 |    0.04 |         - |          NA |
| DllImport_CharArray             | 4096   | Ascii  | 3,294.489 ns | 2,716.5488 ns | 148.9032 ns |  1.83 |    0.08 |         - |          NA |
| DllImport_StringBuilder         | 4096   | Ascii  | 2,446.787 ns | 2,185.7201 ns | 119.8067 ns |  1.36 |    0.06 |         - |          NA |
| LibraryImport_Utf16             | 4096   | Ascii  | 1,788.336 ns |   415.3738 ns |  22.7680 ns |  0.99 |    0.02 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 4096   | Ascii  | 1,832.048 ns |   412.6814 ns |  22.6205 ns |  1.02 |    0.02 |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Ascii  | 1,818.075 ns |   719.1981 ns |  39.4217 ns |  1.01 |    0.03 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Ascii  | 1,820.351 ns |   672.7000 ns |  36.8730 ns |  1.01 |    0.02 |         - |          NA |
|                                 |        |        |              |               |             |       |         |           |             |
| **DllImport_CharSetUnicode**        | **4096**   | **Latin1** | **1,915.206 ns** | **2,154.5121 ns** | **118.0961 ns** |  **1.00** |    **0.08** |         **-** |          **NA** |
| DllImport_LPWStr                | 4096   | Latin1 | 1,852.931 ns |   998.2321 ns |  54.7165 ns |  0.97 |    0.06 |         - |          NA |
| DllImport_CharPointer           | 4096   | Latin1 | 1,887.182 ns |   878.9634 ns |  48.1789 ns |  0.99 |    0.06 |         - |          NA |
| DllImport_CharArray             | 4096   | Latin1 | 3,489.078 ns | 7,505.8123 ns | 411.4189 ns |  1.83 |    0.21 |         - |          NA |
| DllImport_StringBuilder         | 4096   | Latin1 | 3,788.251 ns | 7,648.6479 ns | 419.2482 ns |  1.98 |    0.22 |         - |          NA |
| LibraryImport_Utf16             | 4096   | Latin1 | 1,948.982 ns | 1,497.1183 ns |  82.0621 ns |  1.02 |    0.07 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 4096   | Latin1 | 2,014.267 ns | 3,263.0645 ns | 178.8596 ns |  1.05 |    0.10 |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Latin1 | 1,806.101 ns |   484.1683 ns |  26.5389 ns |  0.95 |    0.05 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Latin1 | 1,890.410 ns | 1,193.7715 ns |  65.4346 ns |  0.99 |    0.06 |         - |          NA |
|                                 |        |        |              |               |             |       |         |           |             |
| **DllImport_CharSetUnicode**        | **4096**   | **Cjk**    | **1,942.871 ns** |   **706.7140 ns** |  **38.7374 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| DllImport_LPWStr                | 4096   | Cjk    | 1,845.567 ns |   970.9969 ns |  53.2236 ns |  0.95 |    0.03 |         - |          NA |
| DllImport_CharPointer           | 4096   | Cjk    | 2,164.478 ns | 1,779.8525 ns |  97.5597 ns |  1.11 |    0.05 |         - |          NA |
| DllImport_CharArray             | 4096   | Cjk    | 3,651.439 ns | 5,330.6612 ns | 292.1915 ns |  1.88 |    0.13 |         - |          NA |
| DllImport_StringBuilder         | 4096   | Cjk    | 2,277.881 ns |   896.6075 ns |  49.1461 ns |  1.17 |    0.03 |         - |          NA |
| LibraryImport_Utf16             | 4096   | Cjk    | 1,912.219 ns | 1,394.8860 ns |  76.4584 ns |  0.98 |    0.04 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 4096   | Cjk    | 1,796.124 ns |   409.3939 ns |  22.4403 ns |  0.92 |    0.02 |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Cjk    | 1,801.828 ns |   592.7971 ns |  32.4932 ns |  0.93 |    0.02 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Cjk    | 1,851.377 ns | 1,760.1495 ns |  96.4797 ns |  0.95 |    0.05 |         - |          NA |
