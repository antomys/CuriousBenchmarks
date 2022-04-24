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
|                                      Method | Categories |      Mean |     Error |    StdDev |   StdErr |       Min |         Max |        Q1 |        Q3 |    Median |         Op/s | Rank |  Gen 0 | Allocated |
|-------------------------------------------- |----------- |----------:|----------:|----------:|---------:|----------:|------------:|----------:|----------:|----------:|-------------:|-----:|-------:|----------:|
|                            LinqBuildQueryV2 |            |  56.28 ns |  1.049 ns |  1.166 ns | 0.268 ns |  53.09 ns |    57.27 ns |  56.49 ns |  56.82 ns |  56.70 ns | 17,769,399.0 |    1 | 0.0356 |     224 B |
|                            LinqBuildQueryV1 |            | 241.03 ns |  1.555 ns |  1.379 ns | 0.369 ns | 238.78 ns |   243.92 ns | 240.44 ns | 241.60 ns | 240.73 ns |  4,148,856.4 |    2 | 0.0930 |     584 B |
|                        BuildDictionaryQuery |            | 259.11 ns |  2.753 ns |  2.441 ns | 0.652 ns | 256.12 ns |   265.07 ns | 257.65 ns | 260.01 ns | 258.49 ns |  3,859,431.1 |    3 | 0.1197 |     752 B |
|                 AspNetCoreQueryBuilderQuery |            | 274.41 ns |  0.944 ns |  0.883 ns | 0.228 ns | 273.31 ns |   276.21 ns | 273.69 ns | 275.06 ns | 274.14 ns |  3,644,181.4 |    4 | 0.1183 |     744 B |
|                            LinqBuildQueryV3 |            | 284.71 ns | 11.517 ns | 33.957 ns | 3.396 ns | 247.27 ns |   351.49 ns | 250.25 ns | 313.33 ns | 279.69 ns |  3,512,332.4 |    4 | 0.0815 |     512 B |
|        CustomMethodStaticStringBuilderQuery |            | 789.49 ns |  1.610 ns |  1.257 ns | 0.363 ns | 787.24 ns |   791.23 ns | 788.91 ns | 790.29 ns | 789.61 ns |  1,266,638.9 |    5 | 0.0496 |     312 B |
|                           CustomMethodQuery |            | 888.97 ns |  1.774 ns |  1.573 ns | 0.420 ns | 886.51 ns |   891.22 ns | 888.26 ns | 890.12 ns | 888.98 ns |  1,124,891.9 |    6 | 0.1049 |     664 B |
|                                             |            |           |           |           |          |           |             |           |           |           |              |      |        |           |
|   BuildFormUrlEncodedContentDictionaryQuery |      Async | 849.91 ns |  2.372 ns |  1.981 ns | 0.549 ns | 847.48 ns |   854.81 ns | 848.67 ns | 850.73 ns | 849.88 ns |  1,176,589.5 |    1 | 0.2537 |   1,592 B |
| BuildFormUrlEncodedContentKeyValuePairQuery |      Async | 868.09 ns | 33.369 ns | 96.809 ns | 9.829 ns | 763.95 ns | 1,148.24 ns | 783.40 ns | 921.91 ns | 844.28 ns |  1,151,953.6 |    1 | 0.2584 |   1,624 B |
