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
|                                      Method | Categories |     Mean |    Error |    StdDev |   StdErr |   Median |      Min |        Max |       Q1 |         Q3 |        Op/s | Rank |  Gen 0 | Allocated |
|-------------------------------------------- |----------- |---------:|---------:|----------:|---------:|---------:|---------:|-----------:|---------:|-----------:|------------:|-----:|-------:|----------:|
|                        BuildDictionaryQuery |            | 272.7 ns |  4.58 ns |   3.83 ns |  1.06 ns | 271.4 ns | 268.6 ns |   281.0 ns | 270.0 ns |   273.8 ns | 3,666,708.5 |    1 | 0.1197 |     752 B |
|                              LinqBuildQuery |            | 340.6 ns | 21.49 ns |  63.37 ns |  6.34 ns | 343.3 ns | 232.8 ns |   459.5 ns | 288.2 ns |   392.9 ns | 2,936,415.0 |    2 | 0.0930 |     584 B |
|                 AspNetCoreQueryBuilderQuery |            | 355.7 ns | 26.96 ns |  79.49 ns |  7.95 ns | 353.8 ns | 262.3 ns |   544.4 ns | 269.3 ns |   415.4 ns | 2,811,179.2 |    2 | 0.1183 |     744 B |
|        CustomMethodStaticStringBuilderQuery |            | 780.5 ns | 15.43 ns |  13.68 ns |  3.66 ns | 780.8 ns | 763.8 ns |   805.8 ns | 769.4 ns |   789.3 ns | 1,281,164.5 |    3 | 0.0496 |     312 B |
|                           CustomMethodQuery |            | 940.8 ns | 54.41 ns | 158.71 ns | 16.03 ns | 841.0 ns | 816.0 ns | 1,371.4 ns | 825.7 ns | 1,036.9 ns | 1,062,941.3 |    4 | 0.1049 |     664 B |
|                                             |            |          |          |           |          |          |          |            |          |            |             |      |        |           |
| BuildFormUrlEncodedContentKeyValuePairQuery |      Async | 794.6 ns | 10.92 ns |   9.68 ns |  2.59 ns | 793.8 ns | 783.4 ns |   817.1 ns | 787.3 ns |   795.3 ns | 1,258,495.7 |    1 | 0.2584 |   1,624 B |
|   BuildFormUrlEncodedContentDictionaryQuery |      Async | 857.2 ns | 12.67 ns |  11.23 ns |  3.00 ns | 853.3 ns | 845.9 ns |   881.6 ns | 848.3 ns |   862.6 ns | 1,166,547.3 |    2 | 0.2537 |   1,592 B |
