```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                          | Length | Pay    | Mean          | Error          | StdDev         | Median        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |------- |------- |--------------:|---------------:|---------------:|--------------:|------:|--------:|-------:|----------:|------------:|
| **DllImport_Default**               | **0**      | **Ascii**  |    **100.168 ns** |      **72.513 ns** |      **3.9747 ns** |     **98.320 ns** |  **1.00** |    **0.05** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 0      | Ascii  |     99.589 ns |      83.232 ns |      4.5622 ns |     98.663 ns |  1.00 |    0.05 |      - |         - |          NA |
| DllImport_LPStr                 | 0      | Ascii  |     92.508 ns |      24.547 ns |      1.3455 ns |     92.131 ns |  0.92 |    0.03 |      - |         - |          NA |
| DllImport_CharSetAuto           | 0      | Ascii  |     25.177 ns |      89.985 ns |      4.9324 ns |     22.856 ns |  0.25 |    0.04 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 0      | Ascii  |     55.734 ns |      46.978 ns |      2.5750 ns |     56.580 ns |  0.56 |    0.03 |      - |         - |          NA |
| DllImport_ManualUtf8            | 0      | Ascii  |     45.519 ns |      64.821 ns |      3.5530 ns |     44.949 ns |  0.45 |    0.03 |      - |         - |          NA |
| DllImport_PreEncoded            | 0      | Ascii  |     21.006 ns |       7.454 ns |      0.4086 ns |     21.150 ns |  0.21 |    0.01 |      - |         - |          NA |
| DllImport_ByteArray             | 0      | Ascii  |     22.104 ns |       5.295 ns |      0.2902 ns |     22.190 ns |  0.22 |    0.01 |      - |         - |          NA |
| DllImport_StringBuilder         | 0      | Ascii  |    212.311 ns |     294.139 ns |     16.1228 ns |    214.669 ns |  2.12 |    0.16 | 0.0050 |      32 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 0      | Ascii  |    184.624 ns |      93.871 ns |      5.1454 ns |    186.094 ns |  1.85 |    0.08 |      - |         - |          NA |
| LibraryImport_Utf8              | 0      | Ascii  |     41.016 ns |      36.606 ns |      2.0065 ns |     41.419 ns |  0.41 |    0.02 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 0      | Ascii  |     32.615 ns |      12.811 ns |      0.7022 ns |     32.979 ns |  0.33 |    0.01 |      - |         - |          NA |
| LibraryImport_ROSpan            | 0      | Ascii  |     20.273 ns |      30.921 ns |      1.6949 ns |     19.776 ns |  0.20 |    0.02 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Ascii  |      7.899 ns |       6.392 ns |      0.3504 ns |      8.028 ns |  0.08 |    0.00 |      - |         - |          NA |
|                                 |        |        |               |                |                |               |       |         |        |           |             |
| **DllImport_Default**               | **0**      | **Latin1** |    **102.821 ns** |     **101.510 ns** |      **5.5641 ns** |    **103.177 ns** |  **1.00** |    **0.07** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 0      | Latin1 |    103.770 ns |      94.740 ns |      5.1930 ns |    101.083 ns |  1.01 |    0.06 |      - |         - |          NA |
| DllImport_LPStr                 | 0      | Latin1 |    104.259 ns |      37.620 ns |      2.0621 ns |    104.256 ns |  1.02 |    0.05 |      - |         - |          NA |
| DllImport_CharSetAuto           | 0      | Latin1 |     24.596 ns |      11.442 ns |      0.6272 ns |     24.605 ns |  0.24 |    0.01 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 0      | Latin1 |     64.918 ns |     198.284 ns |     10.8686 ns |     58.818 ns |  0.63 |    0.10 |      - |         - |          NA |
| DllImport_ManualUtf8            | 0      | Latin1 |     42.829 ns |      24.633 ns |      1.3502 ns |     42.529 ns |  0.42 |    0.02 |      - |         - |          NA |
| DllImport_PreEncoded            | 0      | Latin1 |     21.713 ns |      20.740 ns |      1.1368 ns |     21.176 ns |  0.21 |    0.01 |      - |         - |          NA |
| DllImport_ByteArray             | 0      | Latin1 |     23.880 ns |      28.451 ns |      1.5595 ns |     24.547 ns |  0.23 |    0.02 |      - |         - |          NA |
| DllImport_StringBuilder         | 0      | Latin1 |    275.960 ns |     844.409 ns |     46.2849 ns |    296.602 ns |  2.69 |    0.41 | 0.0050 |      32 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 0      | Latin1 |    203.684 ns |     108.913 ns |      5.9699 ns |    202.018 ns |  1.98 |    0.11 |      - |         - |          NA |
| LibraryImport_Utf8              | 0      | Latin1 |     48.391 ns |      27.900 ns |      1.5293 ns |     48.037 ns |  0.47 |    0.03 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 0      | Latin1 |     35.038 ns |       5.956 ns |      0.3265 ns |     35.085 ns |  0.34 |    0.02 |      - |         - |          NA |
| LibraryImport_ROSpan            | 0      | Latin1 |     19.365 ns |      53.648 ns |      2.9406 ns |     20.613 ns |  0.19 |    0.03 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Latin1 |      7.173 ns |       3.460 ns |      0.1897 ns |      7.164 ns |  0.07 |    0.00 |      - |         - |          NA |
|                                 |        |        |               |                |                |               |       |         |        |           |             |
| **DllImport_Default**               | **0**      | **Cjk**    |    **104.943 ns** |      **61.246 ns** |      **3.3571 ns** |    **104.172 ns** |  **1.00** |    **0.04** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 0      | Cjk    |    101.022 ns |      75.757 ns |      4.1525 ns |     98.775 ns |  0.96 |    0.04 |      - |         - |          NA |
| DllImport_LPStr                 | 0      | Cjk    |    105.282 ns |      13.196 ns |      0.7233 ns |    105.432 ns |  1.00 |    0.03 |      - |         - |          NA |
| DllImport_CharSetAuto           | 0      | Cjk    |     27.349 ns |     119.231 ns |      6.5354 ns |     25.243 ns |  0.26 |    0.05 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 0      | Cjk    |     66.177 ns |      90.567 ns |      4.9643 ns |     67.701 ns |  0.63 |    0.04 |      - |         - |          NA |
| DllImport_ManualUtf8            | 0      | Cjk    |     42.895 ns |      60.715 ns |      3.3280 ns |     42.803 ns |  0.41 |    0.03 |      - |         - |          NA |
| DllImport_PreEncoded            | 0      | Cjk    |     23.208 ns |      15.543 ns |      0.8520 ns |     22.740 ns |  0.22 |    0.01 |      - |         - |          NA |
| DllImport_ByteArray             | 0      | Cjk    |     22.984 ns |      14.817 ns |      0.8122 ns |     22.683 ns |  0.22 |    0.01 |      - |         - |          NA |
| DllImport_StringBuilder         | 0      | Cjk    |    251.009 ns |      27.936 ns |      1.5312 ns |    251.402 ns |  2.39 |    0.07 | 0.0050 |      32 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 0      | Cjk    |    212.620 ns |     147.095 ns |      8.0627 ns |    214.877 ns |  2.03 |    0.09 |      - |         - |          NA |
| LibraryImport_Utf8              | 0      | Cjk    |     50.026 ns |      29.153 ns |      1.5980 ns |     50.187 ns |  0.48 |    0.02 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 0      | Cjk    |     41.074 ns |     107.242 ns |      5.8783 ns |     37.776 ns |  0.39 |    0.05 |      - |         - |          NA |
| LibraryImport_ROSpan            | 0      | Cjk    |     29.389 ns |      87.496 ns |      4.7959 ns |     31.378 ns |  0.28 |    0.04 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Cjk    |     10.699 ns |       5.149 ns |      0.2823 ns |     10.708 ns |  0.10 |    0.00 |      - |         - |          NA |
|                                 |        |        |               |                |                |               |       |         |        |           |             |
| **DllImport_Default**               | **16**     | **Ascii**  |    **217.193 ns** |     **124.401 ns** |      **6.8188 ns** |    **219.781 ns** |  **1.00** |    **0.04** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 16     | Ascii  |    222.301 ns |     121.657 ns |      6.6684 ns |    223.783 ns |  1.02 |    0.04 |      - |         - |          NA |
| DllImport_LPStr                 | 16     | Ascii  |    233.290 ns |     213.808 ns |     11.7195 ns |    231.720 ns |  1.07 |    0.06 |      - |         - |          NA |
| DllImport_CharSetAuto           | 16     | Ascii  |  6,453.002 ns | 203,133.385 ns | 11,134.4263 ns |     35.509 ns | 29.73 |   44.45 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 16     | Ascii  |    116.938 ns |      46.376 ns |      2.5420 ns |    117.404 ns |  0.54 |    0.02 |      - |         - |          NA |
| DllImport_ManualUtf8            | 16     | Ascii  |    134.185 ns |     177.424 ns |      9.7252 ns |    129.207 ns |  0.62 |    0.04 |      - |         - |          NA |
| DllImport_PreEncoded            | 16     | Ascii  |     47.474 ns |      16.705 ns |      0.9157 ns |     47.555 ns |  0.22 |    0.01 |      - |         - |          NA |
| DllImport_ByteArray             | 16     | Ascii  |     53.565 ns |      17.103 ns |      0.9375 ns |     53.204 ns |  0.25 |    0.01 |      - |         - |          NA |
| DllImport_StringBuilder         | 16     | Ascii  |    473.748 ns |     372.577 ns |     20.4222 ns |    462.675 ns |  2.18 |    0.10 | 0.0162 |     104 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 16     | Ascii  |    227.835 ns |     357.393 ns |     19.5899 ns |    223.356 ns |  1.05 |    0.08 |      - |         - |          NA |
| LibraryImport_Utf8              | 16     | Ascii  |     61.431 ns |      32.007 ns |      1.7544 ns |     62.268 ns |  0.28 |    0.01 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 16     | Ascii  |     57.225 ns |      56.963 ns |      3.1224 ns |     58.602 ns |  0.26 |    0.01 |      - |         - |          NA |
| LibraryImport_ROSpan            | 16     | Ascii  |     34.022 ns |      35.631 ns |      1.9530 ns |     33.380 ns |  0.16 |    0.01 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Ascii  |     21.255 ns |      13.205 ns |      0.7238 ns |     21.207 ns |  0.10 |    0.00 |      - |         - |          NA |
|                                 |        |        |               |                |                |               |       |         |        |           |             |
| **DllImport_Default**               | **16**     | **Latin1** |    **114.897 ns** |      **56.836 ns** |      **3.1154 ns** |    **114.593 ns** |  **1.00** |    **0.03** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 16     | Latin1 |    121.666 ns |     176.014 ns |      9.6479 ns |    126.115 ns |  1.06 |    0.08 |      - |         - |          NA |
| DllImport_LPStr                 | 16     | Latin1 |    110.091 ns |     147.048 ns |      8.0602 ns |    109.554 ns |  0.96 |    0.06 |      - |         - |          NA |
| DllImport_CharSetAuto           | 16     | Latin1 |     18.093 ns |      74.023 ns |      4.0575 ns |     16.308 ns |  0.16 |    0.03 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 16     | Latin1 |    109.059 ns |     190.499 ns |     10.4419 ns |    103.826 ns |  0.95 |    0.08 |      - |         - |          NA |
| DllImport_ManualUtf8            | 16     | Latin1 |    115.830 ns |      53.393 ns |      2.9266 ns |    114.273 ns |  1.01 |    0.03 |      - |         - |          NA |
| DllImport_PreEncoded            | 16     | Latin1 |     58.080 ns |     121.284 ns |      6.6480 ns |     58.885 ns |  0.51 |    0.05 |      - |         - |          NA |
| DllImport_ByteArray             | 16     | Latin1 |     44.980 ns |       7.365 ns |      0.4037 ns |     44.908 ns |  0.39 |    0.01 |      - |         - |          NA |
| DllImport_StringBuilder         | 16     | Latin1 |    257.331 ns |     110.547 ns |      6.0594 ns |    258.655 ns |  2.24 |    0.07 | 0.0165 |     104 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 16     | Latin1 |    193.654 ns |     106.920 ns |      5.8607 ns |    192.420 ns |  1.69 |    0.06 |      - |         - |          NA |
| LibraryImport_Utf8              | 16     | Latin1 |     99.849 ns |      17.082 ns |      0.9363 ns |     99.740 ns |  0.87 |    0.02 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 16     | Latin1 |     85.113 ns |      35.076 ns |      1.9227 ns |     84.933 ns |  0.74 |    0.02 |      - |         - |          NA |
| LibraryImport_ROSpan            | 16     | Latin1 |     43.253 ns |      24.860 ns |      1.3627 ns |     43.591 ns |  0.38 |    0.01 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Latin1 |     31.353 ns |      40.621 ns |      2.2266 ns |     32.551 ns |  0.27 |    0.02 |      - |         - |          NA |
|                                 |        |        |               |                |                |               |       |         |        |           |             |
| **DllImport_Default**               | **16**     | **Cjk**    |    **105.168 ns** |     **114.713 ns** |      **6.2878 ns** |    **107.529 ns** |  **1.00** |    **0.07** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 16     | Cjk    |    103.708 ns |      67.044 ns |      3.6749 ns |    103.046 ns |  0.99 |    0.06 |      - |         - |          NA |
| DllImport_LPStr                 | 16     | Cjk    |    105.727 ns |      61.983 ns |      3.3975 ns |    105.796 ns |  1.01 |    0.06 |      - |         - |          NA |
| DllImport_CharSetAuto           | 16     | Cjk    |     60.634 ns |      46.530 ns |      2.5505 ns |     59.211 ns |  0.58 |    0.04 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 16     | Cjk    |    184.572 ns |     124.788 ns |      6.8401 ns |    184.404 ns |  1.76 |    0.11 |      - |         - |          NA |
| DllImport_ManualUtf8            | 16     | Cjk    |    213.599 ns |     443.188 ns |     24.2926 ns |    227.441 ns |  2.04 |    0.23 |      - |         - |          NA |
| DllImport_PreEncoded            | 16     | Cjk    |    126.414 ns |      44.512 ns |      2.4399 ns |    125.385 ns |  1.20 |    0.07 |      - |         - |          NA |
| DllImport_ByteArray             | 16     | Cjk    |    119.188 ns |     138.045 ns |      7.5667 ns |    121.234 ns |  1.14 |    0.09 |      - |         - |          NA |
| DllImport_StringBuilder         | 16     | Cjk    |    294.274 ns |     455.615 ns |     24.9738 ns |    282.137 ns |  2.81 |    0.25 | 0.0162 |     104 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 16     | Cjk    |    401.140 ns |     336.304 ns |     18.4340 ns |    391.299 ns |  3.82 |    0.25 |      - |         - |          NA |
| LibraryImport_Utf8              | 16     | Cjk    |    207.149 ns |     365.059 ns |     20.0101 ns |    202.384 ns |  1.97 |    0.20 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 16     | Cjk    |    192.419 ns |     348.960 ns |     19.1277 ns |    193.844 ns |  1.83 |    0.19 |      - |         - |          NA |
| LibraryImport_ROSpan            | 16     | Cjk    |    101.077 ns |     101.306 ns |      5.5529 ns |     99.778 ns |  0.96 |    0.07 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Cjk    |     93.813 ns |     132.118 ns |      7.2419 ns |     91.657 ns |  0.89 |    0.08 |      - |         - |          NA |
|                                 |        |        |               |                |                |               |       |         |        |           |             |
| **DllImport_Default**               | **256**    | **Ascii**  |    **763.139 ns** |     **371.061 ns** |     **20.3391 ns** |    **768.609 ns** |  **1.00** |    **0.03** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 256    | Ascii  |    815.001 ns |   1,835.774 ns |    100.6250 ns |    773.712 ns |  1.07 |    0.12 |      - |         - |          NA |
| DllImport_LPStr                 | 256    | Ascii  |    828.818 ns |     456.614 ns |     25.0286 ns |    838.754 ns |  1.09 |    0.04 |      - |         - |          NA |
| DllImport_CharSetAuto           | 256    | Ascii  |     28.252 ns |      40.216 ns |      2.2044 ns |     27.031 ns |  0.04 |    0.00 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 256    | Ascii  |  1,101.317 ns |     288.300 ns |     15.8027 ns |  1,104.504 ns |  1.44 |    0.04 |      - |         - |          NA |
| DllImport_ManualUtf8            | 256    | Ascii  |    703.331 ns |     586.919 ns |     32.1710 ns |    688.945 ns |  0.92 |    0.04 |      - |         - |          NA |
| DllImport_PreEncoded            | 256    | Ascii  |    552.686 ns |     361.704 ns |     19.8262 ns |    547.813 ns |  0.72 |    0.03 |      - |         - |          NA |
| DllImport_ByteArray             | 256    | Ascii  |    587.725 ns |     278.111 ns |     15.2442 ns |    589.735 ns |  0.77 |    0.02 |      - |         - |          NA |
| DllImport_StringBuilder         | 256    | Ascii  |  2,874.007 ns |   5,629.002 ns |    308.5446 ns |  2,765.732 ns |  3.77 |    0.36 | 0.1297 |     824 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 256    | Ascii  |    982.853 ns |   2,004.560 ns |    109.8767 ns |    985.336 ns |  1.29 |    0.13 |      - |         - |          NA |
| LibraryImport_Utf8              | 256    | Ascii  |    953.838 ns |   2,071.682 ns |    113.5559 ns |    968.101 ns |  1.25 |    0.13 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 256    | Ascii  |    890.422 ns |   3,267.752 ns |    179.1165 ns |    965.608 ns |  1.17 |    0.21 |      - |         - |          NA |
| LibraryImport_ROSpan            | 256    | Ascii  |    487.902 ns |     991.974 ns |     54.3735 ns |    476.778 ns |  0.64 |    0.06 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Ascii  |    442.308 ns |   1,139.747 ns |     62.4734 ns |    454.413 ns |  0.58 |    0.07 |      - |         - |          NA |
|                                 |        |        |               |                |                |               |       |         |        |           |             |
| **DllImport_Default**               | **256**    | **Latin1** |  **1,394.834 ns** |   **1,162.096 ns** |     **63.6984 ns** |  **1,403.662 ns** |  **1.00** |    **0.06** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 256    | Latin1 |  1,250.788 ns |   2,303.392 ns |    126.2567 ns |  1,192.658 ns |  0.90 |    0.09 |      - |         - |          NA |
| DllImport_LPStr                 | 256    | Latin1 |    902.607 ns |     712.897 ns |     39.0763 ns |    910.890 ns |  0.65 |    0.04 |      - |         - |          NA |
| DllImport_CharSetAuto           | 256    | Latin1 |     29.192 ns |     117.490 ns |      6.4400 ns |     25.699 ns |  0.02 |    0.00 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 256    | Latin1 |  2,602.106 ns |   4,448.094 ns |    243.8150 ns |  2,558.978 ns |  1.87 |    0.17 |      - |         - |          NA |
| DllImport_ManualUtf8            | 256    | Latin1 |  2,202.208 ns |   4,819.110 ns |    264.1517 ns |  2,168.359 ns |  1.58 |    0.18 |      - |         - |          NA |
| DllImport_PreEncoded            | 256    | Latin1 |    865.645 ns |   1,599.956 ns |     87.6990 ns |    868.553 ns |  0.62 |    0.06 |      - |         - |          NA |
| DllImport_ByteArray             | 256    | Latin1 |    933.096 ns |   2,343.010 ns |    128.4283 ns |    999.080 ns |  0.67 |    0.08 |      - |         - |          NA |
| DllImport_StringBuilder         | 256    | Latin1 |  2,380.856 ns |  10,081.596 ns |    552.6063 ns |  2,074.690 ns |  1.71 |    0.35 | 0.1297 |     824 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 256    | Latin1 |  2,583.431 ns |   7,554.171 ns |    414.0696 ns |  2,528.433 ns |  1.85 |    0.27 |      - |         - |          NA |
| LibraryImport_Utf8              | 256    | Latin1 |  3,429.331 ns |  21,774.003 ns |  1,193.5066 ns |  4,042.203 ns |  2.46 |    0.75 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 256    | Latin1 |  2,309.561 ns |   4,285.498 ns |    234.9026 ns |  2,195.457 ns |  1.66 |    0.16 |      - |         - |          NA |
| LibraryImport_ROSpan            | 256    | Latin1 |  1,083.213 ns |   3,254.618 ns |    178.3966 ns |  1,003.916 ns |  0.78 |    0.12 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Latin1 |  1,036.164 ns |     729.779 ns |     40.0016 ns |  1,031.724 ns |  0.74 |    0.04 |      - |         - |          NA |
|                                 |        |        |               |                |                |               |       |         |        |           |             |
| **DllImport_Default**               | **256**    | **Cjk**    |  **1,471.698 ns** |     **188.141 ns** |     **10.3126 ns** |  **1,471.652 ns** |  **1.00** |    **0.01** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 256    | Cjk    |    866.442 ns |   1,257.296 ns |     68.9166 ns |    886.987 ns |  0.59 |    0.04 |      - |         - |          NA |
| DllImport_LPStr                 | 256    | Cjk    |    869.567 ns |   2,325.205 ns |    127.4523 ns |    811.011 ns |  0.59 |    0.08 |      - |         - |          NA |
| DllImport_CharSetAuto           | 256    | Cjk    |    785.103 ns |   1,036.516 ns |     56.8149 ns |    800.106 ns |  0.53 |    0.03 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 256    | Cjk    |  2,997.703 ns |   3,002.655 ns |    164.5856 ns |  2,986.271 ns |  2.04 |    0.10 |      - |         - |          NA |
| DllImport_ManualUtf8            | 256    | Cjk    |  3,499.329 ns |   5,445.186 ns |    298.4690 ns |  3,371.082 ns |  2.38 |    0.18 |      - |         - |          NA |
| DllImport_PreEncoded            | 256    | Cjk    |  1,404.182 ns |   3,618.364 ns |    198.3347 ns |  1,491.628 ns |  0.95 |    0.12 |      - |         - |          NA |
| DllImport_ByteArray             | 256    | Cjk    |  1,304.398 ns |   2,475.368 ns |    135.6833 ns |  1,276.249 ns |  0.89 |    0.08 |      - |         - |          NA |
| DllImport_StringBuilder         | 256    | Cjk    |  2,266.509 ns |   3,505.135 ns |    192.1283 ns |  2,208.857 ns |  1.54 |    0.11 | 0.1297 |     824 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 256    | Cjk    |  2,476.140 ns |   6,935.790 ns |    380.1741 ns |  2,266.413 ns |  1.68 |    0.22 |      - |         - |          NA |
| LibraryImport_Utf8              | 256    | Cjk    |  3,196.737 ns |   4,388.995 ns |    240.5756 ns |  3,247.491 ns |  2.17 |    0.14 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 256    | Cjk    |  3,911.419 ns |   1,789.601 ns |     98.0941 ns |  3,923.115 ns |  2.66 |    0.06 |      - |         - |          NA |
| LibraryImport_ROSpan            | 256    | Cjk    |  1,122.294 ns |   1,272.584 ns |     69.7546 ns |  1,154.159 ns |  0.76 |    0.04 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Cjk    |  1,099.426 ns |   1,385.035 ns |     75.9185 ns |  1,131.570 ns |  0.75 |    0.04 |      - |         - |          NA |
|                                 |        |        |               |                |                |               |       |         |        |           |             |
| **DllImport_Default**               | **4096**   | **Ascii**  | **12,422.981 ns** |   **8,269.037 ns** |    **453.2538 ns** | **12,611.861 ns** | **1.001** |    **0.05** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 4096   | Ascii  | 13,030.959 ns |   6,916.253 ns |    379.1031 ns | 12,978.542 ns | 1.050 |    0.04 |      - |         - |          NA |
| DllImport_LPStr                 | 4096   | Ascii  | 12,981.903 ns |  45,780.614 ns |  2,509.3900 ns | 13,051.892 ns | 1.046 |    0.18 |      - |         - |          NA |
| DllImport_CharSetAuto           | 4096   | Ascii  |     38.539 ns |      52.622 ns |      2.8844 ns |     37.391 ns | 0.003 |    0.00 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 4096   | Ascii  | 11,697.659 ns |   9,821.339 ns |    538.3407 ns | 11,982.780 ns | 0.942 |    0.05 |      - |         - |          NA |
| DllImport_ManualUtf8            | 4096   | Ascii  |  8,619.316 ns |   1,759.582 ns |     96.4487 ns |  8,627.694 ns | 0.694 |    0.02 |      - |         - |          NA |
| DllImport_PreEncoded            | 4096   | Ascii  |  6,887.442 ns |   3,188.622 ns |    174.7792 ns |  6,795.022 ns | 0.555 |    0.02 |      - |         - |          NA |
| DllImport_ByteArray             | 4096   | Ascii  |  5,456.815 ns |   3,990.117 ns |    218.7118 ns |  5,546.569 ns | 0.440 |    0.02 |      - |         - |          NA |
| DllImport_StringBuilder         | 4096   | Ascii  | 55,857.944 ns | 177,329.906 ns |  9,720.0505 ns | 58,411.868 ns | 4.500 |    0.69 | 1.9531 |   12344 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 4096   | Ascii  | 13,938.256 ns |  25,443.614 ns |  1,394.6504 ns | 14,168.374 ns | 1.123 |    0.10 |      - |         - |          NA |
| LibraryImport_Utf8              | 4096   | Ascii  | 14,080.226 ns |  49,809.350 ns |  2,730.2185 ns | 15,555.843 ns | 1.134 |    0.19 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 4096   | Ascii  | 14,166.251 ns |  46,204.138 ns |  2,532.6047 ns | 13,160.952 ns | 1.141 |    0.18 |      - |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Ascii  | 12,216.416 ns |   4,141.031 ns |    226.9839 ns | 12,161.861 ns | 0.984 |    0.04 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Ascii  |  5,287.982 ns |  17,301.763 ns |    948.3680 ns |  5,101.888 ns | 0.426 |    0.07 |      - |         - |          NA |
|                                 |        |        |               |                |                |               |       |         |        |           |             |
| **DllImport_Default**               | **4096**   | **Latin1** | **19,858.310 ns** |  **33,199.028 ns** |  **1,819.7507 ns** | **20,210.065 ns** | **1.006** |    **0.11** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 4096   | Latin1 | 17,947.696 ns |   1,659.708 ns |     90.9742 ns | 17,927.858 ns | 0.909 |    0.07 |      - |         - |          NA |
| DllImport_LPStr                 | 4096   | Latin1 | 20,931.800 ns |  22,916.173 ns |  1,256.1127 ns | 21,495.123 ns | 1.060 |    0.10 |      - |         - |          NA |
| DllImport_CharSetAuto           | 4096   | Latin1 |     27.618 ns |      18.199 ns |      0.9976 ns |     27.620 ns | 0.001 |    0.00 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 4096   | Latin1 | 35,650.900 ns |  34,299.208 ns |  1,880.0553 ns | 36,471.255 ns | 1.806 |    0.17 |      - |         - |          NA |
| DllImport_ManualUtf8            | 4096   | Latin1 | 40,897.779 ns |  34,701.008 ns |  1,902.0793 ns | 40,006.174 ns | 2.071 |    0.19 |      - |       1 B |          NA |
| DllImport_PreEncoded            | 4096   | Latin1 |  4,686.337 ns |  17,867.776 ns |    979.3931 ns |  4,207.898 ns | 0.237 |    0.05 |      - |         - |          NA |
| DllImport_ByteArray             | 4096   | Latin1 |  3,798.696 ns |   8,875.967 ns |    486.5217 ns |  3,531.880 ns | 0.192 |    0.03 |      - |         - |          NA |
| DllImport_StringBuilder         | 4096   | Latin1 |  7,666.387 ns |   2,284.762 ns |    125.2355 ns |  7,653.637 ns | 0.388 |    0.03 | 1.9684 |   12344 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 4096   | Latin1 |  6,798.123 ns |  10,803.354 ns |    592.1683 ns |  7,016.776 ns | 0.344 |    0.04 |      - |         - |          NA |
| LibraryImport_Utf8              | 4096   | Latin1 |  7,352.136 ns |  10,572.531 ns |    579.5161 ns |  7,130.074 ns | 0.372 |    0.04 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 4096   | Latin1 |  7,163.426 ns |   3,848.336 ns |    210.9403 ns |  7,172.887 ns | 0.363 |    0.03 |      - |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Latin1 |  3,655.722 ns |     430.109 ns |     23.5757 ns |  3,660.504 ns | 0.185 |    0.02 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Latin1 |  5,170.413 ns |  17,306.447 ns |    948.6248 ns |  4,998.008 ns | 0.262 |    0.05 |      - |         - |          NA |
|                                 |        |        |               |                |                |               |       |         |        |           |             |
| **DllImport_Default**               | **4096**   | **Cjk**    |  **8,682.091 ns** |  **15,819.363 ns** |    **867.1127 ns** |  **9,128.599 ns** |  **1.01** |    **0.13** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 4096   | Cjk    |  4,384.446 ns |   1,998.068 ns |    109.5209 ns |  4,399.356 ns |  0.51 |    0.05 |      - |         - |          NA |
| DllImport_LPStr                 | 4096   | Cjk    |  3,982.957 ns |   1,236.306 ns |     67.7661 ns |  3,968.077 ns |  0.46 |    0.04 |      - |         - |          NA |
| DllImport_CharSetAuto           | 4096   | Cjk    |  4,052.640 ns |   8,800.799 ns |    482.4015 ns |  3,880.466 ns |  0.47 |    0.06 |      - |         - |          NA |
| DllImport_LPUTF8Str             | 4096   | Cjk    | 19,114.348 ns |  53,170.425 ns |  2,914.4504 ns | 19,334.390 ns |  2.22 |    0.36 |      - |         - |          NA |
| DllImport_ManualUtf8            | 4096   | Cjk    | 15,135.372 ns |  13,556.135 ns |    743.0575 ns | 14,808.388 ns |  1.76 |    0.18 |      - |       1 B |          NA |
| DllImport_PreEncoded            | 4096   | Cjk    |  6,274.798 ns |   8,511.051 ns |    466.5194 ns |  6,295.074 ns |  0.73 |    0.08 |      - |         - |          NA |
| DllImport_ByteArray             | 4096   | Cjk    |  7,114.295 ns |   4,595.161 ns |    251.8763 ns |  7,241.204 ns |  0.83 |    0.08 |      - |         - |          NA |
| DllImport_StringBuilder         | 4096   | Cjk    | 13,596.443 ns |  92,759.030 ns |  5,084.4354 ns | 12,008.902 ns |  1.58 |    0.53 | 1.9684 |   12344 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 4096   | Cjk    | 19,265.841 ns |  30,204.891 ns |  1,655.6320 ns | 19,387.961 ns |  2.23 |    0.26 |      - |         - |          NA |
| LibraryImport_Utf8              | 4096   | Cjk    | 13,173.960 ns |  15,098.110 ns |    827.5783 ns | 13,420.338 ns |  1.53 |    0.16 |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 4096   | Cjk    | 13,380.763 ns |   6,506.477 ns |    356.6420 ns | 13,406.259 ns |  1.55 |    0.15 |      - |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Cjk    |  6,475.772 ns |   8,880.583 ns |    486.7747 ns |  6,595.945 ns |  0.75 |    0.08 |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Cjk    |  5,459.037 ns |     130.621 ns |      7.1598 ns |  5,459.225 ns |  0.63 |    0.06 |      - |         - |          NA |
