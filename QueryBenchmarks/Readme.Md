## Query builder

|                                      Method |       Mean |    Error |    StdDev |   StdErr |     Median |        Min |        Max |         Q1 |         Q3 |        Op/s | Rank |  Gen 0 | Allocated |
|-------------------------------------------- |-----------:|---------:|----------:|---------:|-----------:|-----------:|-----------:|-----------:|-----------:|------------:|-----:|-------:|----------:|
|                 AspNetCoreQueryBuilderQuery |   314.7 ns |  8.36 ns |  23.86 ns |  2.46 ns |   308.8 ns |   286.7 ns |   384.8 ns |   294.7 ns |   325.8 ns | 3,177,835.9 |    1 | 0.1183 |     744 B |
|                              LinqBuildQuery |   335.6 ns |  5.54 ns |   5.18 ns |  1.34 ns |   336.2 ns |   327.7 ns |   343.5 ns |   331.1 ns |   338.7 ns | 2,979,747.9 |    2 | 0.1273 |     800 B |
|                        BuildDictionaryQuery |   398.7 ns |  8.01 ns |  13.38 ns |  2.23 ns |   398.3 ns |   363.9 ns |   429.7 ns |   387.4 ns |   406.3 ns | 2,508,353.5 |    3 | 0.1535 |     968 B |
| BuildFormUrlEncodedContentKeyValuePairQuery |   850.4 ns | 16.94 ns |  29.22 ns |  4.74 ns |   852.2 ns |   792.4 ns |   939.3 ns |   832.3 ns |   867.4 ns | 1,175,856.1 |    4 | 0.2232 |   1,400 B |
|   BuildFormUrlEncodedContentDictionaryQuery |   985.6 ns | 28.48 ns |  80.79 ns |  8.38 ns |   951.1 ns |   871.7 ns | 1,232.7 ns |   925.2 ns | 1,029.9 ns | 1,014,644.9 |    5 | 0.2518 |   1,584 B |
|        CustomMethodStaticStringBuilderQuery | 2,548.1 ns | 47.78 ns | 114.47 ns | 13.88 ns | 2,501.1 ns | 2,425.7 ns | 2,922.8 ns | 2,471.0 ns | 2,604.1 ns |   392,450.7 |    6 | 0.1373 |     880 B |
|                           CustomMethodQuery | 2,814.8 ns | 96.59 ns | 277.12 ns | 28.43 ns | 2,701.9 ns | 2,443.9 ns | 3,588.8 ns | 2,610.9 ns | 2,952.3 ns |   355,269.7 |    7 | 0.1945 |   1,232 B |

## Url builder

|                            Method |       Mean |    Error |   StdDev |  StdErr |        Min |        Max |         Q1 |         Q3 |     Median |        Op/s | Rank |  Gen 0 | Allocated |
|---------------------------------- |-----------:|---------:|---------:|--------:|-----------:|-----------:|-----------:|-----------:|-----------:|------------:|-----:|-------:|----------:|
|                            NewUri |   239.1 ns |  3.54 ns |  3.14 ns | 0.84 ns |   235.3 ns |   245.4 ns |   236.9 ns |   240.2 ns |   238.3 ns | 4,181,717.2 |    1 | 0.0367 |     232 B |
| NewUriCombineFormatAndNoUriCached |   254.3 ns |  5.09 ns |  6.80 ns | 1.36 ns |   234.1 ns |   263.2 ns |   254.2 ns |   258.1 ns |   255.9 ns | 3,932,054.0 |    2 | 0.0343 |     216 B |
|               NewUriStringCombine |   255.2 ns |  2.84 ns |  2.66 ns | 0.69 ns |   252.1 ns |   260.2 ns |   253.1 ns |   256.6 ns |   254.5 ns | 3,919,251.5 |    2 | 0.0443 |     280 B |
|       NewUriCombineFormatAndNoUri |   258.6 ns |  5.10 ns |  7.15 ns | 1.38 ns |   244.1 ns |   272.7 ns |   255.6 ns |   262.2 ns |   259.7 ns | 3,866,697.1 |    2 | 0.0343 |     216 B |
|                NewUriOfficeDevPnP |   272.4 ns |  2.25 ns |  1.99 ns | 0.53 ns |   269.4 ns |   276.1 ns |   271.3 ns |   273.6 ns |   272.1 ns | 3,670,790.2 |    3 | 0.0443 |     280 B |
|      NewUriCombineFormatAndNewUri |   489.2 ns |  9.55 ns | 17.47 ns | 2.70 ns |   453.3 ns |   519.9 ns |   477.8 ns |   499.4 ns |   491.1 ns | 2,044,312.9 |    4 | 0.0629 |     400 B |
|           NewUriCombineUriBuilder | 1,411.2 ns | 27.18 ns | 34.38 ns | 7.17 ns | 1,330.8 ns | 1,474.6 ns | 1,401.7 ns | 1,428.7 ns | 1,415.9 ns |   708,629.5 |    5 | 0.1373 |     872 B |
|   NewUriCombineUriBuilderToString | 1,571.1 ns | 24.63 ns | 28.36 ns | 6.34 ns | 1,538.5 ns | 1,657.7 ns | 1,547.9 ns | 1,582.5 ns | 1,569.9 ns |   636,515.5 |    6 | 0.1793 |   1,136 B |
