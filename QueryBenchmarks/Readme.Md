## Query builder

|                                      Method |       Mean |    Error |   StdDev |  Gen 0 | Allocated |
|-------------------------------------------- |-----------:|---------:|---------:|-------:|----------:|
|                        BuildDictionaryQuery |   679.1 ns | 13.26 ns | 20.65 ns | 0.4625 |     968 B |
| BuildFormUrlEncodedContentKeyValuePairQuery | 1,295.7 ns | 25.23 ns | 31.90 ns | 0.6695 |   1,400 B |
|   BuildFormUrlEncodedContentDictionaryQuery | 1,457.1 ns | 28.29 ns | 49.56 ns | 0.7572 |   1,584 B |
|                           CustomMethodQuery | 3,539.3 ns | 27.83 ns | 24.67 ns | 0.5875 |   1,232 B |
|        CustomMethodStaticStringBuilderQuery | 3,404.6 ns | 65.67 ns | 61.43 ns | 0.4196 |     880 B |
|                 AspNetCoreQueryBuilderQuery |   527.9 ns |  9.73 ns |  8.63 ns | 0.3557 |     744 B |
|                              LinqBuildQuery |   611.0 ns | 11.90 ns | 12.74 ns | 0.3824 |     800 B |

## Url builder

|                            Method |        Mean |     Error |    StdDev |  Gen 0 | Allocated |
|---------------------------------- |------------:|----------:|----------:|-------:|----------:|
|                            NewUri |   352.80 ns |  4.644 ns |  4.344 ns | 0.1106 |     232 B |
|               NewUriStringCombine |   102.78 ns |  2.473 ns |  6.811 ns | 0.1185 |     248 B |
|                NewUriOfficeDevPnP |   135.30 ns |  2.672 ns |  3.077 ns | 0.1185 |     248 B |
|   NewUriCombineUriBuilderToString | 1,944.03 ns | 37.673 ns | 31.458 ns | 0.5264 |   1,104 B |
|           NewUriCombineUriBuilder | 1,594.32 ns | 30.030 ns | 58.570 ns | 0.4005 |     840 B |
|      NewUriCombineFormatAndNewUri |   609.86 ns |  9.746 ns |  9.116 ns | 0.1907 |     400 B |
|       NewUriCombineFormatAndNoUri |    74.76 ns |  1.504 ns |  1.544 ns | 0.0880 |     184 B |
| NewUriCombineFormatAndNoUriCached |    70.49 ns |  1.443 ns |  1.544 ns | 0.0880 |     184 B |
