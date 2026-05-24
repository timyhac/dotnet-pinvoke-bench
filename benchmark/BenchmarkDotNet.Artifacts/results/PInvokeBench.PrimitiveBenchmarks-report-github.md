```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.8457)
11th Gen Intel Core i7-1195G7 2.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.300
  [Host]   : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.27 (8.0.2726.22922), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                           | Mean      | Error      | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------- |----------:|-----------:|----------:|------:|--------:|----------:|------------:|
| DllImport_Bool_Default           |  9.513 ns | 12.8258 ns | 0.7030 ns |  1.00 |    0.09 |         - |          NA |
| DllImport_Bool_U1                | 11.089 ns | 10.3031 ns | 0.5647 ns |  1.17 |    0.09 |         - |          NA |
| DllImport_Bool_I1                | 11.341 ns |  9.1305 ns | 0.5005 ns |  1.20 |    0.09 |         - |          NA |
| DllImport_Bool_VariantBool       | 10.327 ns | 12.5897 ns | 0.6901 ns |  1.09 |    0.10 |         - |          NA |
| DllImport_Byte_NoMarshalling     |  8.079 ns |  8.2641 ns | 0.4530 ns |  0.85 |    0.07 |         - |          NA |
| DllImport_Int32                  |  8.613 ns | 36.0116 ns | 1.9739 ns |  0.91 |    0.19 |         - |          NA |
| DllImport_Int64                  | 18.095 ns |  0.9662 ns | 0.0530 ns |  1.91 |    0.12 |         - |          NA |
| DllImport_Float                  | 17.976 ns | 31.2539 ns | 1.7131 ns |  1.90 |    0.20 |         - |          NA |
| DllImport_Double                 | 16.575 ns |  4.8764 ns | 0.2673 ns |  1.75 |    0.12 |         - |          NA |
| LibraryImport_Bool_U1            | 17.942 ns |  4.3834 ns | 0.2403 ns |  1.89 |    0.13 |         - |          NA |
| LibraryImport_Bool_4Byte         | 22.696 ns | 43.6683 ns | 2.3936 ns |  2.39 |    0.27 |         - |          NA |
| LibraryImport_Byte_NoMarshalling | 15.017 ns | 21.3834 ns | 1.1721 ns |  1.58 |    0.15 |         - |          NA |
| LibraryImport_Byte_SuppressGC    |  2.956 ns |  1.8506 ns | 0.1014 ns |  0.31 |    0.02 |         - |          NA |
| LibraryImport_Int64              | 28.238 ns | 10.7285 ns | 0.5881 ns |  2.98 |    0.20 |         - |          NA |
| LibraryImport_Double             | 17.693 ns | 46.8266 ns | 2.5667 ns |  1.87 |    0.26 |         - |          NA |
| LibraryImport_Double_SuppressGC  |  3.766 ns |  3.7737 ns | 0.2068 ns |  0.40 |    0.03 |         - |          NA |
