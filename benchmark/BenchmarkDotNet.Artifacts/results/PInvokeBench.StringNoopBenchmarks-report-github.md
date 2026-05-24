```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                          | Length | Pay    | Mean           | Error          | StdDev      | Median         | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|-------------------------------- |------- |------- |---------------:|---------------:|------------:|---------------:|------:|--------:|-------:|-------:|----------:|------------:|
| **DllImport_Default**               | **0**      | **Ascii**  |     **40.5674 ns** |     **72.5354 ns** |   **3.9759 ns** |     **38.3860 ns** |  **1.01** |    **0.12** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 0      | Ascii  |     58.3557 ns |    285.7101 ns |  15.6607 ns |     65.1409 ns |  1.45 |    0.36 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 0      | Ascii  |     42.7048 ns |    110.8976 ns |   6.0787 ns |     41.5708 ns |  1.06 |    0.16 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 0      | Ascii  |      8.1614 ns |      2.6486 ns |   0.1452 ns |      8.0776 ns |  0.20 |    0.02 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 0      | Ascii  |     20.4013 ns |     35.0004 ns |   1.9185 ns |     20.2365 ns |  0.51 |    0.06 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 0      | Ascii  |     14.3534 ns |     21.6928 ns |   1.1891 ns |     13.9153 ns |  0.36 |    0.04 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 0      | Ascii  |     12.9418 ns |     57.5807 ns |   3.1562 ns |     12.1449 ns |  0.32 |    0.07 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 0      | Ascii  |      7.1742 ns |      2.1725 ns |   0.1191 ns |      7.1493 ns |  0.18 |    0.01 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 0      | Ascii  |    102.7703 ns |    226.7236 ns |  12.4275 ns |    106.9978 ns |  2.55 |    0.34 | 0.0050 |      - |      32 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 0      | Ascii  |     71.0934 ns |     16.2554 ns |   0.8910 ns |     71.1419 ns |  1.76 |    0.14 |      - |      - |         - |          NA |
| LibraryImport_Utf8              | 0      | Ascii  |     13.6630 ns |     10.2948 ns |   0.5643 ns |     13.5437 ns |  0.34 |    0.03 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 0      | Ascii  |     11.1339 ns |      4.9430 ns |   0.2709 ns |     11.2441 ns |  0.28 |    0.02 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 0      | Ascii  |      7.2268 ns |      2.2073 ns |   0.1210 ns |      7.2583 ns |  0.18 |    0.01 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Ascii  |      1.4336 ns |      0.8830 ns |   0.0484 ns |      1.4094 ns |  0.04 |    0.00 |      - |      - |         - |          NA |
|                                 |        |        |                |                |             |                |       |         |        |        |           |             |
| **DllImport_Default**               | **0**      | **Latin1** |     **37.1472 ns** |     **15.3723 ns** |   **0.8426 ns** |     **36.8903 ns** |  **1.00** |    **0.03** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 0      | Latin1 |     43.6120 ns |     49.4668 ns |   2.7114 ns |     44.5082 ns |  1.17 |    0.07 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 0      | Latin1 |     83.7322 ns |     10.4858 ns |   0.5748 ns |     83.5595 ns |  2.25 |    0.05 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 0      | Latin1 |     10.0330 ns |     20.5395 ns |   1.1258 ns |     10.4290 ns |  0.27 |    0.03 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 0      | Latin1 |     19.8334 ns |     26.1152 ns |   1.4315 ns |     19.8366 ns |  0.53 |    0.03 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 0      | Latin1 |     12.0336 ns |     24.8632 ns |   1.3628 ns |     11.9810 ns |  0.32 |    0.03 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 0      | Latin1 |      6.7780 ns |     11.0286 ns |   0.6045 ns |      6.5650 ns |  0.18 |    0.01 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 0      | Latin1 |      7.7342 ns |     15.6569 ns |   0.8582 ns |      7.9641 ns |  0.21 |    0.02 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 0      | Latin1 |     82.0100 ns |     81.9628 ns |   4.4927 ns |     80.1789 ns |  2.21 |    0.11 | 0.0050 |      - |      32 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 0      | Latin1 |     69.3281 ns |     19.2750 ns |   1.0565 ns |     69.2992 ns |  1.87 |    0.04 |      - |      - |         - |          NA |
| LibraryImport_Utf8              | 0      | Latin1 |      9.6009 ns |      5.0646 ns |   0.2776 ns |      9.5019 ns |  0.26 |    0.01 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 0      | Latin1 |     11.2842 ns |     12.0223 ns |   0.6590 ns |     11.3102 ns |  0.30 |    0.02 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 0      | Latin1 |      7.8123 ns |     26.3573 ns |   1.4447 ns |      8.0583 ns |  0.21 |    0.03 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Latin1 |      1.0240 ns |      0.5014 ns |   0.0275 ns |      1.0394 ns |  0.03 |    0.00 |      - |      - |         - |          NA |
|                                 |        |        |                |                |             |                |       |         |        |        |           |             |
| **DllImport_Default**               | **0**      | **Cjk**    |     **45.4114 ns** |     **77.6982 ns** |   **4.2589 ns** |     **44.2097 ns** |  **1.01** |    **0.11** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 0      | Cjk    |     29.2609 ns |      9.0289 ns |   0.4949 ns |     29.4790 ns |  0.65 |    0.05 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 0      | Cjk    |     49.9579 ns |     80.9278 ns |   4.4359 ns |     50.4499 ns |  1.11 |    0.12 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 0      | Cjk    |      6.8970 ns |      8.7885 ns |   0.4817 ns |      6.8074 ns |  0.15 |    0.02 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 0      | Cjk    |     22.4429 ns |     50.1407 ns |   2.7484 ns |     22.7371 ns |  0.50 |    0.07 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 0      | Cjk    |     33.5336 ns |      3.3952 ns |   0.1861 ns |     33.4564 ns |  0.74 |    0.06 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 0      | Cjk    |     16.7244 ns |      8.6373 ns |   0.4734 ns |     16.9861 ns |  0.37 |    0.03 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 0      | Cjk    |     15.3820 ns |     13.1057 ns |   0.7184 ns |     15.6761 ns |  0.34 |    0.03 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 0      | Cjk    |    171.2404 ns |     16.3083 ns |   0.8939 ns |    170.8162 ns |  3.79 |    0.30 | 0.0050 |      - |      32 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 0      | Cjk    |    187.3477 ns |    134.0438 ns |   7.3474 ns |    185.7498 ns |  4.15 |    0.36 |      - |      - |         - |          NA |
| LibraryImport_Utf8              | 0      | Cjk    |     39.9512 ns |     11.2799 ns |   0.6183 ns |     40.0183 ns |  0.88 |    0.07 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 0      | Cjk    |     27.0254 ns |     25.5638 ns |   1.4012 ns |     27.8144 ns |  0.60 |    0.05 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 0      | Cjk    |     15.8145 ns |      3.6103 ns |   0.1979 ns |     15.7027 ns |  0.35 |    0.03 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 0      | Cjk    |      3.4571 ns |      2.4614 ns |   0.1349 ns |      3.4078 ns |  0.08 |    0.01 |      - |      - |         - |          NA |
|                                 |        |        |                |                |             |                |       |         |        |        |           |             |
| **DllImport_Default**               | **16**     | **Ascii**  |    **112.6040 ns** |     **11.0506 ns** |   **0.6057 ns** |    **112.7759 ns** |  **1.00** |    **0.01** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 16     | Ascii  |    111.3078 ns |    145.9079 ns |   7.9977 ns |    107.1396 ns |  0.99 |    0.06 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 16     | Ascii  |    121.9905 ns |     15.9135 ns |   0.8723 ns |    121.5147 ns |  1.08 |    0.01 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 16     | Ascii  |     18.1521 ns |      3.0204 ns |   0.1656 ns |     18.0837 ns |  0.16 |    0.00 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 16     | Ascii  |     54.7173 ns |     15.7156 ns |   0.8614 ns |     54.2699 ns |  0.49 |    0.01 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 16     | Ascii  |     56.3814 ns |     22.9484 ns |   1.2579 ns |     57.0145 ns |  0.50 |    0.01 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 16     | Ascii  |     16.2458 ns |     39.9968 ns |   2.1924 ns |     17.1587 ns |  0.14 |    0.02 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 16     | Ascii  |     17.3007 ns |      7.6512 ns |   0.4194 ns |     17.4392 ns |  0.15 |    0.00 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 16     | Ascii  |    299.9319 ns |    283.0668 ns |  15.5158 ns |    305.9499 ns |  2.66 |    0.12 | 0.0162 |      - |     104 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 16     | Ascii  |    186.6033 ns |     55.6350 ns |   3.0495 ns |    186.7850 ns |  1.66 |    0.02 | 0.0002 | 0.0002 |         - |          NA |
| LibraryImport_Utf8              | 16     | Ascii  |     45.1409 ns |      7.8635 ns |   0.4310 ns |     45.1275 ns |  0.40 |    0.00 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 16     | Ascii  |     31.1512 ns |      8.2085 ns |   0.4499 ns |     31.0910 ns |  0.28 |    0.00 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 16     | Ascii  |     16.3133 ns |      1.4041 ns |   0.0770 ns |     16.3124 ns |  0.14 |    0.00 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Ascii  |      3.0347 ns |      2.5484 ns |   0.1397 ns |      3.0192 ns |  0.03 |    0.00 |      - |      - |         - |          NA |
|                                 |        |        |                |                |             |                |       |         |        |        |           |             |
| **DllImport_Default**               | **16**     | **Latin1** |    **122.9413 ns** |     **65.0485 ns** |   **3.5655 ns** |    **121.9430 ns** |  **1.00** |    **0.04** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 16     | Latin1 |    115.9819 ns |     59.2973 ns |   3.2503 ns |    116.1613 ns |  0.94 |    0.03 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 16     | Latin1 |    116.0317 ns |     82.1085 ns |   4.5006 ns |    114.6936 ns |  0.94 |    0.04 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 16     | Latin1 |     16.2080 ns |     15.7876 ns |   0.8654 ns |     16.1668 ns |  0.13 |    0.01 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 16     | Latin1 |     71.5785 ns |    304.7197 ns |  16.7027 ns |     75.7018 ns |  0.58 |    0.12 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 16     | Latin1 |     92.2390 ns |     49.0514 ns |   2.6887 ns |     93.0962 ns |  0.75 |    0.03 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 16     | Latin1 |     14.6982 ns |     66.7789 ns |   3.6604 ns |     14.2987 ns |  0.12 |    0.03 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 16     | Latin1 |     14.1327 ns |     54.2504 ns |   2.9736 ns |     14.5109 ns |  0.12 |    0.02 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 16     | Latin1 |    182.2845 ns |    429.6738 ns |  23.5519 ns |    180.9764 ns |  1.48 |    0.17 | 0.0165 |      - |     104 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 16     | Latin1 |    123.2629 ns |    110.0741 ns |   6.0335 ns |    119.9617 ns |  1.00 |    0.05 |      - |      - |         - |          NA |
| LibraryImport_Utf8              | 16     | Latin1 |     57.6954 ns |    103.9023 ns |   5.6952 ns |     56.4525 ns |  0.47 |    0.04 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 16     | Latin1 |     51.4542 ns |     51.5066 ns |   2.8233 ns |     50.6229 ns |  0.42 |    0.02 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 16     | Latin1 |     11.3643 ns |      2.0145 ns |   0.1104 ns |     11.3213 ns |  0.09 |    0.00 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Latin1 |      1.2798 ns |      4.1527 ns |   0.2276 ns |      1.3443 ns |  0.01 |    0.00 |      - |      - |         - |          NA |
|                                 |        |        |                |                |             |                |       |         |        |        |           |             |
| **DllImport_Default**               | **16**     | **Cjk**    |     **53.2009 ns** |     **56.3279 ns** |   **3.0875 ns** |     **54.9426 ns** |  **1.00** |    **0.07** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 16     | Cjk    |     56.9602 ns |     31.8672 ns |   1.7468 ns |     57.9525 ns |  1.07 |    0.06 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 16     | Cjk    |     56.6728 ns |      8.8232 ns |   0.4836 ns |     56.8280 ns |  1.07 |    0.06 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 16     | Cjk    |      8.0538 ns |      5.7286 ns |   0.3140 ns |      7.9205 ns |  0.15 |    0.01 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 16     | Cjk    |     49.9045 ns |     52.9616 ns |   2.9030 ns |     50.9585 ns |  0.94 |    0.07 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 16     | Cjk    |     59.5403 ns |     29.9079 ns |   1.6394 ns |     59.0176 ns |  1.12 |    0.06 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 16     | Cjk    |      8.6236 ns |      3.9716 ns |   0.2177 ns |      8.6254 ns |  0.16 |    0.01 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 16     | Cjk    |      8.5916 ns |      9.1275 ns |   0.5003 ns |      8.4127 ns |  0.16 |    0.01 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 16     | Cjk    |    138.6305 ns |    101.5586 ns |   5.5668 ns |    135.4745 ns |  2.61 |    0.16 | 0.0166 |      - |     104 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 16     | Cjk    |    163.8691 ns |    381.3042 ns |  20.9006 ns |    158.2838 ns |  3.09 |    0.38 |      - |      - |         - |          NA |
| LibraryImport_Utf8              | 16     | Cjk    |     47.1349 ns |     21.9086 ns |   1.2009 ns |     47.7024 ns |  0.89 |    0.05 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 16     | Cjk    |     41.0685 ns |     36.9940 ns |   2.0278 ns |     42.1628 ns |  0.77 |    0.05 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 16     | Cjk    |      8.0624 ns |      2.6192 ns |   0.1436 ns |      8.0727 ns |  0.15 |    0.01 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 16     | Cjk    |      1.7171 ns |      4.8701 ns |   0.2669 ns |      1.6827 ns |  0.03 |    0.00 |      - |      - |         - |          NA |
|                                 |        |        |                |                |             |                |       |         |        |        |           |             |
| **DllImport_Default**               | **256**    | **Ascii**  |    **204.3947 ns** |    **249.5134 ns** |  **13.6767 ns** |    **210.3429 ns** | **1.003** |    **0.08** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 256    | Ascii  |    207.0058 ns |    153.0611 ns |   8.3898 ns |    210.3952 ns | 1.016 |    0.07 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 256    | Ascii  |    212.0699 ns |    138.9227 ns |   7.6148 ns |    216.1510 ns | 1.041 |    0.07 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 256    | Ascii  |      8.3303 ns |      2.8164 ns |   0.1544 ns |      8.3413 ns | 0.041 |    0.00 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 256    | Ascii  |     91.0594 ns |     18.1179 ns |   0.9931 ns |     91.1525 ns | 0.447 |    0.03 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 256    | Ascii  |     34.8769 ns |     51.3759 ns |   2.8161 ns |     35.9030 ns | 0.171 |    0.02 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 256    | Ascii  |      5.9301 ns |     10.1165 ns |   0.5545 ns |      5.8699 ns | 0.029 |    0.00 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 256    | Ascii  |      5.9691 ns |      6.2509 ns |   0.3426 ns |      5.8356 ns | 0.029 |    0.00 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 256    | Ascii  |    347.2645 ns |     91.9892 ns |   5.0422 ns |    346.5237 ns | 1.704 |    0.10 | 0.1311 |      - |     824 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 256    | Ascii  |     75.5536 ns |    242.4914 ns |  13.2918 ns |     69.2291 ns | 0.371 |    0.06 |      - |      - |         - |          NA |
| LibraryImport_Utf8              | 256    | Ascii  |    142.5508 ns |  2,159.0541 ns | 118.3450 ns |     77.1256 ns | 0.700 |    0.51 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 256    | Ascii  |     86.4752 ns |     82.9455 ns |   4.5465 ns |     84.1349 ns | 0.424 |    0.03 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 256    | Ascii  |      4.9764 ns |      1.6838 ns |   0.0923 ns |      4.9723 ns | 0.024 |    0.00 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Ascii  |      0.9508 ns |      0.9202 ns |   0.0504 ns |      0.9522 ns | 0.005 |    0.00 |      - |      - |         - |          NA |
|                                 |        |        |                |                |             |                |       |         |        |        |           |             |
| **DllImport_Default**               | **256**    | **Latin1** |    **157.1601 ns** |    **474.3437 ns** |  **26.0004 ns** |    **149.8103 ns** |  **1.02** |    **0.20** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 256    | Latin1 |    135.8850 ns |     36.5864 ns |   2.0054 ns |    135.3666 ns |  0.88 |    0.12 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 256    | Latin1 |    137.0506 ns |      7.9684 ns |   0.4368 ns |    137.1069 ns |  0.89 |    0.12 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 256    | Latin1 |      6.3205 ns |      2.7087 ns |   0.1485 ns |      6.3473 ns |  0.04 |    0.01 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 256    | Latin1 |    251.6471 ns |    103.3343 ns |   5.6641 ns |    248.8498 ns |  1.63 |    0.22 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 256    | Latin1 |    208.1118 ns |    117.6537 ns |   6.4490 ns |    207.1054 ns |  1.35 |    0.19 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 256    | Latin1 |      6.7689 ns |     24.3714 ns |   1.3359 ns |      7.0692 ns |  0.04 |    0.01 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 256    | Latin1 |      7.2588 ns |      1.4954 ns |   0.0820 ns |      7.2469 ns |  0.05 |    0.01 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 256    | Latin1 |    431.3243 ns |    166.3134 ns |   9.1162 ns |    427.3582 ns |  2.79 |    0.38 | 0.1307 |      - |     824 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 256    | Latin1 |    240.2989 ns |    159.0250 ns |   8.7167 ns |    236.9290 ns |  1.56 |    0.22 |      - |      - |         - |          NA |
| LibraryImport_Utf8              | 256    | Latin1 |    365.5870 ns |    253.9538 ns |  13.9201 ns |    363.8180 ns |  2.37 |    0.33 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 256    | Latin1 |    355.6083 ns |    150.2652 ns |   8.2365 ns |    351.4100 ns |  2.30 |    0.32 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 256    | Latin1 |      6.6423 ns |      3.5756 ns |   0.1960 ns |      6.6608 ns |  0.04 |    0.01 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Latin1 |      2.3620 ns |      2.9272 ns |   0.1605 ns |      2.3434 ns |  0.02 |    0.00 |      - |      - |         - |          NA |
|                                 |        |        |                |                |             |                |       |         |        |        |           |             |
| **DllImport_Default**               | **256**    | **Cjk**    |    **194.7793 ns** |    **102.6732 ns** |   **5.6279 ns** |    **193.5661 ns** | **1.001** |    **0.04** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 256    | Cjk    |    324.6874 ns |    338.0581 ns |  18.5301 ns |    321.5843 ns | 1.668 |    0.09 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 256    | Cjk    |    211.4155 ns |    124.3998 ns |   6.8188 ns |    208.3011 ns | 1.086 |    0.04 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 256    | Cjk    |      6.5293 ns |      1.2417 ns |   0.0681 ns |      6.4913 ns | 0.034 |    0.00 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 256    | Cjk    |    568.2419 ns |    222.4818 ns |  12.1950 ns |    566.0074 ns | 2.919 |    0.09 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 256    | Cjk    |    688.3353 ns |  1,491.9468 ns |  81.7786 ns |    730.1771 ns | 3.536 |    0.37 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 256    | Cjk    |      6.9859 ns |      4.8867 ns |   0.2679 ns |      7.0043 ns | 0.036 |    0.00 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 256    | Cjk    |      6.5890 ns |      5.4414 ns |   0.2983 ns |      6.7261 ns | 0.034 |    0.00 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 256    | Cjk    |    469.6472 ns |    246.7239 ns |  13.5238 ns |    472.0618 ns | 2.413 |    0.08 | 0.1311 |      - |     824 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 256    | Cjk    |    409.4089 ns |    429.1827 ns |  23.5250 ns |    413.0686 ns | 2.103 |    0.12 |      - |      - |         - |          NA |
| LibraryImport_Utf8              | 256    | Cjk    |    483.6721 ns |    313.2115 ns |  17.1682 ns |    474.4247 ns | 2.485 |    0.10 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 256    | Cjk    |    586.0532 ns |    167.4879 ns |   9.1806 ns |    580.8334 ns | 3.010 |    0.09 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 256    | Cjk    |      6.4953 ns |      1.5046 ns |   0.0825 ns |      6.4562 ns | 0.033 |    0.00 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 256    | Cjk    |      1.3737 ns |      4.2021 ns |   0.2303 ns |      1.2926 ns | 0.007 |    0.00 |      - |      - |         - |          NA |
|                                 |        |        |                |                |             |                |       |         |        |        |           |             |
| **DllImport_Default**               | **4096**   | **Ascii**  |  **2,649.4403 ns** |  **2,800.7999 ns** | **153.5213 ns** |  **2,605.2181 ns** | **1.002** |    **0.07** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 4096   | Ascii  |  2,592.6286 ns |  2,632.8212 ns | 144.3138 ns |  2,513.9103 ns | 0.981 |    0.07 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 4096   | Ascii  |  5,373.6562 ns |  9,179.5192 ns | 503.1604 ns |  5,455.6992 ns | 2.033 |    0.19 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 4096   | Ascii  |     10.5986 ns |     35.9876 ns |   1.9726 ns |      9.5221 ns | 0.004 |    0.00 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 4096   | Ascii  |    340.5890 ns |     38.1696 ns |   2.0922 ns |    340.1493 ns | 0.129 |    0.01 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 4096   | Ascii  |    294.2211 ns |     64.4650 ns |   3.5335 ns |    295.2600 ns | 0.111 |    0.01 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 4096   | Ascii  |      8.3114 ns |     11.8293 ns |   0.6484 ns |      8.1343 ns | 0.003 |    0.00 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 4096   | Ascii  |      7.8964 ns |      1.9578 ns |   0.1073 ns |      7.8669 ns | 0.003 |    0.00 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 4096   | Ascii  |  6,603.9698 ns |  1,663.6560 ns |  91.1906 ns |  6,609.6306 ns | 2.498 |    0.13 | 1.9684 |      - |   12344 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 4096   | Ascii  |    228.4630 ns |     21.6002 ns |   1.1840 ns |    228.9953 ns | 0.086 |    0.00 |      - |      - |         - |          NA |
| LibraryImport_Utf8              | 4096   | Ascii  |    373.3644 ns |  1,140.1662 ns |  62.4964 ns |    339.3734 ns | 0.141 |    0.02 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 4096   | Ascii  |    380.7421 ns |    945.3045 ns |  51.8153 ns |    359.4660 ns | 0.144 |    0.02 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Ascii  |      6.4328 ns |      4.0915 ns |   0.2243 ns |      6.4652 ns | 0.002 |    0.00 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Ascii  |      1.5488 ns |      4.2760 ns |   0.2344 ns |      1.4458 ns | 0.001 |    0.00 |      - |      - |         - |          NA |
|                                 |        |        |                |                |             |                |       |         |        |        |           |             |
| **DllImport_Default**               | **4096**   | **Latin1** |  **3,685.2404 ns** |  **5,352.3587 ns** | **293.3808 ns** |  **3,727.1175 ns** | **1.004** |    **0.10** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 4096   | Latin1 |  4,389.2904 ns |  4,494.2815 ns | 246.3467 ns |  4,299.4606 ns | 1.196 |    0.10 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 4096   | Latin1 |  4,284.4275 ns |  8,342.4433 ns | 457.2775 ns |  4,426.5837 ns | 1.168 |    0.14 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 4096   | Latin1 |     11.4214 ns |     14.2278 ns |   0.7799 ns |     11.2594 ns | 0.003 |    0.00 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 4096   | Latin1 |  6,159.2723 ns |  4,202.9887 ns | 230.3800 ns |  6,192.8329 ns | 1.679 |    0.13 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 4096   | Latin1 |  6,189.4834 ns |  6,262.5259 ns | 343.2702 ns |  6,225.6668 ns | 1.687 |    0.14 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 4096   | Latin1 |     11.8894 ns |     10.8883 ns |   0.5968 ns |     11.6041 ns | 0.003 |    0.00 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 4096   | Latin1 |     12.2040 ns |     12.7339 ns |   0.6980 ns |     12.4869 ns | 0.003 |    0.00 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 4096   | Latin1 | 12,013.6820 ns | 11,514.7335 ns | 631.1614 ns | 11,655.4398 ns | 3.274 |    0.27 | 1.9684 |      - |   12344 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 4096   | Latin1 |  5,626.3011 ns | 10,029.3646 ns | 549.7433 ns |  5,811.8782 ns | 1.533 |    0.17 |      - |      - |         - |          NA |
| LibraryImport_Utf8              | 4096   | Latin1 |  5,891.2074 ns |  4,457.6422 ns | 244.3384 ns |  5,809.4307 ns | 1.606 |    0.13 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 4096   | Latin1 |  6,791.0276 ns |  9,549.5416 ns | 523.4426 ns |  6,665.4175 ns | 1.851 |    0.18 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Latin1 |     10.6151 ns |     10.8243 ns |   0.5933 ns |     10.8123 ns | 0.003 |    0.00 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Latin1 |      3.4806 ns |      2.7894 ns |   0.1529 ns |      3.4929 ns | 0.001 |    0.00 |      - |      - |         - |          NA |
|                                 |        |        |                |                |             |                |       |         |        |        |           |             |
| **DllImport_Default**               | **4096**   | **Cjk**    |  **4,385.6499 ns** |  **7,244.6424 ns** | **397.1033 ns** |  **4,499.8100 ns** | **1.006** |    **0.11** |      **-** |      **-** |         **-** |          **NA** |
| DllImport_CharSetAnsi           | 4096   | Cjk    |  3,966.5316 ns |  3,373.2096 ns | 184.8970 ns |  4,062.7831 ns | 0.910 |    0.08 |      - |      - |         - |          NA |
| DllImport_LPStr                 | 4096   | Cjk    |  2,764.6098 ns |  4,778.8634 ns | 261.9456 ns |  2,708.7029 ns | 0.634 |    0.07 |      - |      - |         - |          NA |
| DllImport_CharSetAuto           | 4096   | Cjk    |     11.0101 ns |     22.0716 ns |   1.2098 ns |     10.4930 ns | 0.003 |    0.00 |      - |      - |         - |          NA |
| DllImport_LPUTF8Str             | 4096   | Cjk    |  6,904.5375 ns |    582.7164 ns |  31.9407 ns |  6,904.4098 ns | 1.583 |    0.13 |      - |      - |         - |          NA |
| DllImport_ManualUtf8            | 4096   | Cjk    |  7,315.8020 ns | 12,451.9394 ns | 682.5328 ns |  7,413.1760 ns | 1.678 |    0.19 |      - |      - |         - |          NA |
| DllImport_PreEncoded            | 4096   | Cjk    |      8.7875 ns |     26.2505 ns |   1.4389 ns |      8.1192 ns | 0.002 |    0.00 |      - |      - |         - |          NA |
| DllImport_ByteArray             | 4096   | Cjk    |      8.0547 ns |      1.3005 ns |   0.0713 ns |      8.0407 ns | 0.002 |    0.00 |      - |      - |         - |          NA |
| DllImport_StringBuilder         | 4096   | Cjk    |  6,612.5168 ns |  4,814.4461 ns | 263.8960 ns |  6,681.3499 ns | 1.516 |    0.13 | 1.9684 |      - |   12344 B |          NA |
| DllImport_StringToCoTaskMemUTF8 | 4096   | Cjk    |  5,653.8895 ns |  2,787.0407 ns | 152.7671 ns |  5,568.9598 ns | 1.297 |    0.11 |      - |      - |         - |          NA |
| LibraryImport_Utf8              | 4096   | Cjk    |  6,976.4104 ns |  5,216.8899 ns | 285.9553 ns |  6,986.8919 ns | 1.600 |    0.14 |      - |      - |         - |          NA |
| LibraryImport_Utf8_SuppressGC   | 4096   | Cjk    |  7,176.5266 ns |  4,704.3527 ns | 257.8614 ns |  7,037.2246 ns | 1.646 |    0.14 |      - |      - |         - |          NA |
| LibraryImport_ROSpan            | 4096   | Cjk    |      5.9722 ns |     10.2588 ns |   0.5623 ns |      5.7124 ns | 0.001 |    0.00 |      - |      - |         - |          NA |
| LibraryImport_ROSpan_SuppressGC | 4096   | Cjk    |      1.4078 ns |      1.4867 ns |   0.0815 ns |      1.3737 ns | 0.000 |    0.00 |      - |      - |         - |          NA |
