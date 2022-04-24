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
|                                      Method | Categories |     Mean |    Error |   StdDev |  StdErr |   Median |      Min |        Max |       Q1 |         Q3 |        Op/s | Rank |  Gen 0 | Allocated |
|-------------------------------------------- |----------- |---------:|---------:|---------:|--------:|---------:|---------:|-----------:|---------:|-----------:|------------:|-----:|-------:|----------:|
|                       LinqBuildQueryV2ModV1 |            | 140.8 ns |  2.87 ns |  3.07 ns | 0.72 ns | 139.7 ns | 137.6 ns |   148.9 ns | 139.1 ns |   141.5 ns | 7,104,176.0 |    1 | 0.0610 |     384 B |
|                       LinqBuildQueryV2ModV2 |            | 170.0 ns |  2.98 ns |  7.53 ns | 0.87 ns | 167.7 ns | 162.4 ns |   198.7 ns | 166.3 ns |   169.6 ns | 5,881,497.0 |    2 | 0.0496 |     312 B |
|                            LinqBuildQueryV2 |            | 185.0 ns |  3.16 ns |  2.96 ns | 0.76 ns | 184.2 ns | 181.1 ns |   190.9 ns | 182.9 ns |   186.2 ns | 5,405,910.4 |    3 | 0.0725 |     456 B |
|                            LinqBuildQueryV3 |            | 246.0 ns |  2.72 ns |  2.27 ns | 0.63 ns | 245.4 ns | 241.9 ns |   250.1 ns | 244.8 ns |   247.2 ns | 4,064,820.2 |    4 | 0.0815 |     512 B |
|                            LinqBuildQueryV1 |            | 253.2 ns |  2.55 ns |  2.13 ns | 0.59 ns | 253.1 ns | 250.1 ns |   258.3 ns | 252.0 ns |   253.8 ns | 3,949,352.8 |    5 | 0.0930 |     584 B |
|                 AspNetCoreQueryBuilderQuery |            | 288.5 ns |  5.50 ns |  5.40 ns | 1.35 ns | 287.2 ns | 283.0 ns |   299.3 ns | 284.3 ns |   290.7 ns | 3,465,842.5 |    6 | 0.1183 |     744 B |
|                        BuildDictionaryQuery |            | 289.3 ns |  4.75 ns |  3.97 ns | 1.10 ns | 287.3 ns | 285.5 ns |   300.2 ns | 287.1 ns |   290.5 ns | 3,456,931.0 |    6 | 0.1197 |     752 B |
|        CustomMethodStaticStringBuilderQuery |            | 790.3 ns |  5.68 ns |  5.03 ns | 1.34 ns | 789.6 ns | 782.6 ns |   799.6 ns | 787.3 ns |   793.8 ns | 1,265,340.5 |    7 | 0.0496 |     312 B |
|                           CustomMethodQuery |            | 967.0 ns | 26.80 ns | 77.74 ns | 7.89 ns | 926.6 ns | 896.3 ns | 1,211.7 ns | 915.0 ns | 1,008.8 ns | 1,034,122.9 |    8 | 0.1049 |     664 B |
|                                             |            |          |          |          |         |          |          |            |          |            |             |      |        |           |
| BuildFormUrlEncodedContentKeyValuePairQuery |      Async | 849.7 ns | 15.35 ns | 11.98 ns | 3.46 ns | 845.8 ns | 840.3 ns |   884.4 ns | 843.6 ns |   849.6 ns | 1,176,955.2 |    1 | 0.2575 |   1,624 B |
|   BuildFormUrlEncodedContentDictionaryQuery |      Async | 925.6 ns | 16.32 ns | 12.74 ns | 3.68 ns | 923.0 ns | 904.3 ns |   940.6 ns | 916.7 ns |   939.8 ns | 1,080,429.5 |    2 | 0.2537 |   1,592 B |
