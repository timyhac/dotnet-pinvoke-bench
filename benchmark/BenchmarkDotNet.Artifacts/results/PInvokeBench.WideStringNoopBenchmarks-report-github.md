```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                          | Length | Pay    | Mean        | Error       | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------- |------- |------- |------------:|------------:|-----------:|------:|--------:|----------:|------------:|
| **DllImport_CharSetUnicode**        | **0**      | **Ascii**  |   **7.3629 ns** |   **3.8629 ns** |  **0.2117 ns** |  **1.00** |    **0.04** |         **-** |          **NA** |
| DllImport_CharPointer           | 0      | Ascii  |   6.3832 ns |  10.3012 ns |  0.5646 ns |  0.87 |    0.07 |         - |          NA |
| DllImport_StringBuilder         | 0      | Ascii  |  31.6914 ns |  33.5250 ns |  1.8376 ns |  4.31 |    0.24 |         - |          NA |
| LibraryImport_Utf16             | 0      | Ascii  |   6.1284 ns |   2.1160 ns |  0.1160 ns |  0.83 |    0.02 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 0      | Ascii  |   2.1753 ns |   3.3206 ns |  0.1820 ns |  0.30 |    0.02 |         - |          NA |
| LibraryImport_ROSpan            | 0      | Ascii  |   5.3842 ns |   4.2442 ns |  0.2326 ns |  0.73 |    0.03 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Ascii  |   0.6734 ns |   1.6688 ns |  0.0915 ns |  0.09 |    0.01 |         - |          NA |
|                                 |        |        |             |             |            |       |         |           |             |
| **DllImport_CharSetUnicode**        | **0**      | **Latin1** |   **8.4930 ns** |   **3.8240 ns** |  **0.2096 ns** |  **1.00** |    **0.03** |         **-** |          **NA** |
| DllImport_CharPointer           | 0      | Latin1 |   5.3877 ns |   1.0638 ns |  0.0583 ns |  0.63 |    0.01 |         - |          NA |
| DllImport_StringBuilder         | 0      | Latin1 |  23.3311 ns |  18.9682 ns |  1.0397 ns |  2.75 |    0.12 |         - |          NA |
| LibraryImport_Utf16             | 0      | Latin1 |   5.5139 ns |  13.8258 ns |  0.7578 ns |  0.65 |    0.08 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 0      | Latin1 |   2.0585 ns |   1.6276 ns |  0.0892 ns |  0.24 |    0.01 |         - |          NA |
| LibraryImport_ROSpan            | 0      | Latin1 |   6.3172 ns |   3.9916 ns |  0.2188 ns |  0.74 |    0.03 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Latin1 |   1.5525 ns |   4.1681 ns |  0.2285 ns |  0.18 |    0.02 |         - |          NA |
|                                 |        |        |             |             |            |       |         |           |             |
| **DllImport_CharSetUnicode**        | **0**      | **Cjk**    |   **7.5727 ns** |   **9.9468 ns** |  **0.5452 ns** |  **1.00** |    **0.09** |         **-** |          **NA** |
| DllImport_CharPointer           | 0      | Cjk    |  10.0266 ns |  30.2433 ns |  1.6577 ns |  1.33 |    0.21 |         - |          NA |
| DllImport_StringBuilder         | 0      | Cjk    |  33.1104 ns |  42.3644 ns |  2.3221 ns |  4.39 |    0.39 |         - |          NA |
| LibraryImport_Utf16             | 0      | Cjk    |   7.8278 ns |   5.5796 ns |  0.3058 ns |  1.04 |    0.08 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 0      | Cjk    |   1.9517 ns |   0.8395 ns |  0.0460 ns |  0.26 |    0.02 |         - |          NA |
| LibraryImport_ROSpan            | 0      | Cjk    |   7.7076 ns |  19.8516 ns |  1.0881 ns |  1.02 |    0.14 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Cjk    |   1.8263 ns |   5.2432 ns |  0.2874 ns |  0.24 |    0.04 |         - |          NA |
|                                 |        |        |             |             |            |       |         |           |             |
| **DllImport_CharSetUnicode**        | **16**     | **Ascii**  |  **10.5856 ns** |  **23.6606 ns** |  **1.2969 ns** |  **1.01** |    **0.15** |         **-** |          **NA** |
| DllImport_CharPointer           | 16     | Ascii  |  11.6096 ns |  12.9027 ns |  0.7072 ns |  1.11 |    0.13 |         - |          NA |
| DllImport_StringBuilder         | 16     | Ascii  |  61.5354 ns |  49.1218 ns |  2.6925 ns |  5.87 |    0.65 |         - |          NA |
| LibraryImport_Utf16             | 16     | Ascii  |  10.1692 ns |  44.5274 ns |  2.4407 ns |  0.97 |    0.23 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 16     | Ascii  |   2.5535 ns |   3.3657 ns |  0.1845 ns |  0.24 |    0.03 |         - |          NA |
| LibraryImport_ROSpan            | 16     | Ascii  |   6.6817 ns |   1.5132 ns |  0.0829 ns |  0.64 |    0.07 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Ascii  |   1.6101 ns |   4.7944 ns |  0.2628 ns |  0.15 |    0.03 |         - |          NA |
|                                 |        |        |             |             |            |       |         |           |             |
| **DllImport_CharSetUnicode**        | **16**     | **Latin1** |   **8.0938 ns** |   **5.5929 ns** |  **0.3066 ns** |  **1.00** |    **0.05** |         **-** |          **NA** |
| DllImport_CharPointer           | 16     | Latin1 |   5.0861 ns |   9.4858 ns |  0.5199 ns |  0.63 |    0.06 |         - |          NA |
| DllImport_StringBuilder         | 16     | Latin1 |  32.7538 ns |   3.0819 ns |  0.1689 ns |  4.05 |    0.14 |         - |          NA |
| LibraryImport_Utf16             | 16     | Latin1 |   7.9596 ns |  17.6863 ns |  0.9694 ns |  0.98 |    0.11 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 16     | Latin1 |   2.3048 ns |   0.7812 ns |  0.0428 ns |  0.29 |    0.01 |         - |          NA |
| LibraryImport_ROSpan            | 16     | Latin1 |   6.5594 ns |   8.2631 ns |  0.4529 ns |  0.81 |    0.06 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Latin1 |   1.7938 ns |   0.6403 ns |  0.0351 ns |  0.22 |    0.01 |         - |          NA |
|                                 |        |        |             |             |            |       |         |           |             |
| **DllImport_CharSetUnicode**        | **16**     | **Cjk**    |   **7.0915 ns** |   **1.7447 ns** |  **0.0956 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| DllImport_CharPointer           | 16     | Cjk    |   7.9037 ns |   4.2853 ns |  0.2349 ns |  1.11 |    0.03 |         - |          NA |
| DllImport_StringBuilder         | 16     | Cjk    |  32.8497 ns |   7.7313 ns |  0.4238 ns |  4.63 |    0.07 |         - |          NA |
| LibraryImport_Utf16             | 16     | Cjk    |   5.6661 ns |   4.4148 ns |  0.2420 ns |  0.80 |    0.03 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 16     | Cjk    |   2.0640 ns |   3.7873 ns |  0.2076 ns |  0.29 |    0.03 |         - |          NA |
| LibraryImport_ROSpan            | 16     | Cjk    |   5.7840 ns |   2.6253 ns |  0.1439 ns |  0.82 |    0.02 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Cjk    |   1.5768 ns |   4.6011 ns |  0.2522 ns |  0.22 |    0.03 |         - |          NA |
|                                 |        |        |             |             |            |       |         |           |             |
| **DllImport_CharSetUnicode**        | **256**    | **Ascii**  |   **6.6737 ns** |   **2.2174 ns** |  **0.1215 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| DllImport_CharPointer           | 256    | Ascii  |   5.2121 ns |   3.7899 ns |  0.2077 ns |  0.78 |    0.03 |         - |          NA |
| DllImport_StringBuilder         | 256    | Ascii  |  43.9445 ns |  32.8967 ns |  1.8032 ns |  6.59 |    0.26 |         - |          NA |
| LibraryImport_Utf16             | 256    | Ascii  |   6.9007 ns |   2.4099 ns |  0.1321 ns |  1.03 |    0.02 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 256    | Ascii  |   1.7655 ns |   1.9076 ns |  0.1046 ns |  0.26 |    0.01 |         - |          NA |
| LibraryImport_ROSpan            | 256    | Ascii  |   7.8251 ns |  15.3502 ns |  0.8414 ns |  1.17 |    0.11 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Ascii  |   1.5873 ns |   2.8585 ns |  0.1567 ns |  0.24 |    0.02 |         - |          NA |
|                                 |        |        |             |             |            |       |         |           |             |
| **DllImport_CharSetUnicode**        | **256**    | **Latin1** |   **6.8500 ns** |   **6.8191 ns** |  **0.3738 ns** |  **1.00** |    **0.07** |         **-** |          **NA** |
| DllImport_CharPointer           | 256    | Latin1 |   5.9815 ns |   9.9888 ns |  0.5475 ns |  0.87 |    0.08 |         - |          NA |
| DllImport_StringBuilder         | 256    | Latin1 |  44.2096 ns |  13.3677 ns |  0.7327 ns |  6.47 |    0.32 |         - |          NA |
| LibraryImport_Utf16             | 256    | Latin1 |   5.6135 ns |   2.2779 ns |  0.1249 ns |  0.82 |    0.04 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 256    | Latin1 |   1.9930 ns |   2.2479 ns |  0.1232 ns |  0.29 |    0.02 |         - |          NA |
| LibraryImport_ROSpan            | 256    | Latin1 |   6.1083 ns |   3.6225 ns |  0.1986 ns |  0.89 |    0.05 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Latin1 |   1.5724 ns |   2.9834 ns |  0.1635 ns |  0.23 |    0.02 |         - |          NA |
|                                 |        |        |             |             |            |       |         |           |             |
| **DllImport_CharSetUnicode**        | **256**    | **Cjk**    |   **6.5707 ns** |   **1.5735 ns** |  **0.0862 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| DllImport_CharPointer           | 256    | Cjk    |   6.0882 ns |   5.4468 ns |  0.2986 ns |  0.93 |    0.04 |         - |          NA |
| DllImport_StringBuilder         | 256    | Cjk    |  48.6027 ns |  66.6039 ns |  3.6508 ns |  7.40 |    0.49 |         - |          NA |
| LibraryImport_Utf16             | 256    | Cjk    |   5.8665 ns |   5.5824 ns |  0.3060 ns |  0.89 |    0.04 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 256    | Cjk    |   2.0480 ns |   1.2556 ns |  0.0688 ns |  0.31 |    0.01 |         - |          NA |
| LibraryImport_ROSpan            | 256    | Cjk    |   6.0796 ns |   5.9044 ns |  0.3236 ns |  0.93 |    0.04 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Cjk    |   1.3983 ns |   1.2664 ns |  0.0694 ns |  0.21 |    0.01 |         - |          NA |
|                                 |        |        |             |             |            |       |         |           |             |
| **DllImport_CharSetUnicode**        | **4096**   | **Ascii**  |   **7.2081 ns** |   **2.9017 ns** |  **0.1590 ns** |  **1.00** |    **0.03** |         **-** |          **NA** |
| DllImport_CharPointer           | 4096   | Ascii  |   5.7869 ns |   3.4470 ns |  0.1889 ns |  0.80 |    0.03 |         - |          NA |
| DllImport_StringBuilder         | 4096   | Ascii  | 459.7404 ns | 355.1926 ns | 19.4693 ns | 63.80 |    2.64 |         - |          NA |
| LibraryImport_Utf16             | 4096   | Ascii  |   5.6926 ns |   4.5206 ns |  0.2478 ns |  0.79 |    0.03 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 4096   | Ascii  |   2.2055 ns |   1.7368 ns |  0.0952 ns |  0.31 |    0.01 |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Ascii  |   5.8982 ns |   3.6626 ns |  0.2008 ns |  0.82 |    0.03 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Ascii  |   1.4812 ns |   1.1524 ns |  0.0632 ns |  0.21 |    0.01 |         - |          NA |
|                                 |        |        |             |             |            |       |         |           |             |
| **DllImport_CharSetUnicode**        | **4096**   | **Latin1** |   **6.6246 ns** |   **2.9552 ns** |  **0.1620 ns** |  **1.00** |    **0.03** |         **-** |          **NA** |
| DllImport_CharPointer           | 4096   | Latin1 |   5.5181 ns |   1.3724 ns |  0.0752 ns |  0.83 |    0.02 |         - |          NA |
| DllImport_StringBuilder         | 4096   | Latin1 | 393.5537 ns | 128.6381 ns |  7.0511 ns | 59.43 |    1.57 |         - |          NA |
| LibraryImport_Utf16             | 4096   | Latin1 |   6.6287 ns |  16.9439 ns |  0.9288 ns |  1.00 |    0.12 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 4096   | Latin1 |   2.0990 ns |   1.1449 ns |  0.0628 ns |  0.32 |    0.01 |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Latin1 |   5.5458 ns |   4.9494 ns |  0.2713 ns |  0.84 |    0.04 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Latin1 |   1.6825 ns |   2.3833 ns |  0.1306 ns |  0.25 |    0.02 |         - |          NA |
|                                 |        |        |             |             |            |       |         |           |             |
| **DllImport_CharSetUnicode**        | **4096**   | **Cjk**    |   **6.9652 ns** |   **4.8615 ns** |  **0.2665 ns** |  **1.00** |    **0.05** |         **-** |          **NA** |
| DllImport_CharPointer           | 4096   | Cjk    |   5.6775 ns |   2.2248 ns |  0.1219 ns |  0.82 |    0.03 |         - |          NA |
| DllImport_StringBuilder         | 4096   | Cjk    | 403.0285 ns | 496.0039 ns | 27.1876 ns | 57.92 |    3.87 |         - |          NA |
| LibraryImport_Utf16             | 4096   | Cjk    |   6.2686 ns |   1.7529 ns |  0.0961 ns |  0.90 |    0.03 |         - |          NA |
| LibraryImport_Utf16_SuppressGC  | 4096   | Cjk    |   2.4605 ns |   1.9747 ns |  0.1082 ns |  0.35 |    0.02 |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Cjk    |   6.3108 ns |  10.8961 ns |  0.5973 ns |  0.91 |    0.08 |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Cjk    |   1.3800 ns |   0.8157 ns |  0.0447 ns |  0.20 |    0.01 |         - |          NA |
