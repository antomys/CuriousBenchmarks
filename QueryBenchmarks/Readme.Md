``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.3.1 (21E258) [Darwin 21.4.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
```
## Uri combining
|                            Method |       Mean |    Error |   StdDev |  StdErr |        Min |        Max |         Q1 |         Q3 |     Median |        Op/s | Rank |  Gen 0 | Allocated |
|---------------------------------- |-----------:|---------:|---------:|--------:|-----------:|-----------:|-----------:|-----------:|-----------:|------------:|-----:|-------:|----------:|
|                            NewUri |   240.9 ns |  2.74 ns |  2.56 ns | 0.66 ns |   237.3 ns |   246.5 ns |   239.0 ns |   242.1 ns |   240.6 ns | 4,150,547.1 |    1 | 0.0367 |     232 B |
| NewUriCombineFormatAndNoUriCached |   243.0 ns |  4.42 ns |  8.08 ns | 1.25 ns |   234.8 ns |   274.5 ns |   237.8 ns |   244.0 ns |   241.5 ns | 4,115,855.7 |    1 | 0.0343 |     216 B |
|               NewUriStringCombine |   259.2 ns |  2.13 ns |  2.00 ns | 0.52 ns |   256.4 ns |   262.4 ns |   257.6 ns |   260.9 ns |   258.5 ns | 3,857,798.7 |    2 | 0.0443 |     280 B |
|                NewUriOfficeDevPnP |   279.3 ns |  2.17 ns |  1.81 ns | 0.50 ns |   276.3 ns |   282.2 ns |   278.3 ns |   281.3 ns |   279.0 ns | 3,580,469.6 |    3 | 0.0443 |     280 B |
|       NewUriCombineFormatAndNoUri |   279.6 ns | 10.88 ns | 31.92 ns | 3.21 ns |   238.5 ns |   359.0 ns |   253.1 ns |   305.2 ns |   271.9 ns | 3,576,151.1 |    3 | 0.0343 |     216 B |
|      NewUriCombineFormatAndNewUri |   456.6 ns |  6.82 ns |  6.38 ns | 1.65 ns |   447.2 ns |   467.5 ns |   452.6 ns |   461.4 ns |   454.2 ns | 2,190,187.7 |    4 | 0.0634 |     400 B |
|           NewUriCombineUriBuilder | 1,280.1 ns | 13.71 ns | 12.83 ns | 3.31 ns | 1,262.6 ns | 1,303.7 ns | 1,269.7 ns | 1,286.3 ns | 1,280.0 ns |   781,191.3 |    5 | 0.1373 |     872 B |
|   NewUriCombineUriBuilderToString | 1,633.5 ns |  9.22 ns |  8.17 ns | 2.18 ns | 1,624.4 ns | 1,651.3 ns | 1,628.7 ns | 1,634.1 ns | 1,630.3 ns |   612,166.5 |    6 | 0.1793 |   1,136 B |

## Query builders
|                                      Method | Categories |       Mean |    Error |    StdDev |   StdErr |   Median |      Min |        Max |       Q1 |         Q3 |        Op/s | Rank |  Gen 0 | Allocated |
|-------------------------------------------- |----------- |-----------:|---------:|----------:|---------:|---------:|---------:|-----------:|---------:|-----------:|------------:|-----:|-------:|----------:|
|                              LinqBuildQuery |            |   251.4 ns |  1.51 ns |   1.26 ns |  0.35 ns | 251.0 ns | 250.1 ns |   254.0 ns | 250.3 ns |   252.3 ns | 3,977,086.6 |    1 | 0.0930 |     584 B |
|                 AspNetCoreQueryBuilderQuery |            |   291.4 ns |  1.97 ns |   1.65 ns |  0.46 ns | 290.8 ns | 289.6 ns |   295.7 ns | 290.4 ns |   292.2 ns | 3,432,214.2 |    2 | 0.1183 |     744 B |
|                        BuildDictionaryQuery |            |   301.0 ns |  6.00 ns |   8.41 ns |  1.62 ns | 297.1 ns | 293.2 ns |   322.7 ns | 295.2 ns |   304.9 ns | 3,322,295.4 |    3 | 0.1197 |     752 B |
|        CustomMethodStaticStringBuilderQuery |            |   810.6 ns |  3.26 ns |   2.54 ns |  0.73 ns | 810.0 ns | 807.7 ns |   816.2 ns | 809.2 ns |   810.8 ns | 1,233,607.8 |    4 | 0.0496 |     312 B |
|                           CustomMethodQuery |            |   910.0 ns |  5.86 ns |   8.40 ns |  1.59 ns | 906.9 ns | 902.0 ns |   933.5 ns | 903.3 ns |   915.0 ns | 1,098,950.2 |    5 | 0.1049 |     664 B |
|                                             |            |            |          |           |          |          |          |            |          |            |             |      |        |           |
| BuildFormUrlEncodedContentKeyValuePairQuery |      Async |   898.3 ns | 17.82 ns |  20.52 ns |  4.59 ns | 895.2 ns | 876.2 ns |   943.3 ns | 879.7 ns |   906.6 ns | 1,113,268.2 |    1 | 0.2584 |   1,624 B |
|   BuildFormUrlEncodedContentDictionaryQuery |      Async | 1,014.1 ns | 45.98 ns | 134.84 ns | 13.55 ns | 937.9 ns | 893.8 ns | 1,356.3 ns | 900.9 ns | 1,116.6 ns |   986,143.7 |    2 | 0.2537 |   1,592 B |
