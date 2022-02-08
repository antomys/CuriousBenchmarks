``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                                  Method |        Mean |     Error |    StdDev |    StdErr |      Median |         Min |         Max |          Q1 |          Q3 |         Op/s | Ratio | Rank |  Gen 0 | Allocated |
|---------------------------------------- |------------:|----------:|----------:|----------:|------------:|------------:|------------:|------------:|------------:|-------------:|------:|-----:|-------:|----------:|
|                   GenerateLinkFormatOld | 2,854.02 ns | 55.983 ns | 99.510 ns | 15.734 ns | 2,879.80 ns | 2,696.48 ns | 3,119.44 ns | 2,733.97 ns | 2,926.50 ns |    350,382.5 |  1.00 |    8 | 0.1144 |     720 B |
|           GenerateLinkFormatNewNoLength |   216.25 ns |  4.873 ns | 14.136 ns |  1.435 ns |   210.66 ns |   193.30 ns |   252.40 ns |   206.02 ns |   224.87 ns |  4,624,259.1 |  0.08 |    5 | 0.0331 |     208 B |
|             GenerateLinkFormatNewLength |   199.72 ns |  4.416 ns | 12.883 ns |  1.301 ns |   197.38 ns |   174.87 ns |   238.41 ns |   189.11 ns |   209.97 ns |  5,007,012.8 |  0.07 |    4 | 0.0331 |     208 B |
| GenerateLinkFormatAggressiveNewNoLength |   356.52 ns | 14.178 ns | 41.358 ns |  4.178 ns |   339.82 ns |   309.80 ns |   459.19 ns |   326.96 ns |   376.97 ns |  2,804,873.2 |  0.12 |    7 | 0.0596 |     376 B |
|   GenerateLinkFormatAggressiveNewLength |   309.77 ns |  6.199 ns |  9.466 ns |  1.700 ns |   305.92 ns |   296.41 ns |   328.16 ns |   302.77 ns |   318.49 ns |  3,228,160.0 |  0.11 |    6 | 0.0596 |     376 B |
|                GenerateDashFormatNative |    28.31 ns |  0.305 ns |  0.286 ns |  0.074 ns |    28.21 ns |    27.89 ns |    28.81 ns |    28.11 ns |    28.50 ns | 35,322,430.3 |  0.01 |    1 | 0.0331 |     208 B |
|              GenerateDashFormatV2Length |    31.81 ns |  0.659 ns |  1.554 ns |  0.191 ns |    31.26 ns |    30.18 ns |    36.19 ns |    30.81 ns |    31.93 ns | 31,435,674.4 |  0.01 |    3 | 0.0331 |     208 B |
|           GenerateDashFormatV2TwoValues |    29.91 ns |  0.169 ns |  0.158 ns |  0.041 ns |    29.93 ns |    29.68 ns |    30.19 ns |    29.79 ns |    30.00 ns | 33,430,346.7 |  0.01 |    2 | 0.0331 |     208 B |
