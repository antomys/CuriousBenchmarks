## MacOs testing:
// * Summary *

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.0.1 (21A559) [Darwin 21.1.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100
[Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT

|                                      Method |       Mean |    Error |   StdDev |     Median |  Gen 0 | Allocated |
|-------------------------------------------- |-----------:|---------:|---------:|-----------:|-------:|----------:|
|                        BuildDictionaryQuery |   387.0 ns |  7.70 ns | 21.08 ns |   384.4 ns | 0.1540 |     968 B |
| BuildFormUrlEncodedContentKeyValuePairQuery |   770.3 ns |  6.18 ns |  5.78 ns |   773.1 ns | 0.2232 |   1,400 B |
|   BuildFormUrlEncodedContentDictionaryQuery |   848.7 ns |  2.44 ns |  2.28 ns |   849.1 ns | 0.2518 |   1,584 B |
|                           CustomMethodQuery | 2,483.6 ns | 36.50 ns | 56.82 ns | 2,455.9 ns | 0.1945 |   1,232 B |
|        CustomMethodStaticStringBuilderQuery | 2,381.5 ns | 16.03 ns | 12.52 ns | 2,381.5 ns | 0.1373 |     880 B |
|                 AspNetCoreQueryBuilderQuery |   286.7 ns |  5.75 ns |  8.60 ns |   282.6 ns | 0.1183 |     744 B |
|                              LinqBuildQuery |   329.5 ns |  6.52 ns | 11.77 ns |   324.9 ns | 0.1273 |     800 B |

## Windows Testing:
// * Summary *

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1387 (21H2)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
[Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


|                                      Method |       Mean |    Error |   StdDev |  Gen 0 | Allocated |
|-------------------------------------------- |-----------:|---------:|---------:|-------:|----------:|
|                        BuildDictionaryQuery |   581.5 ns |  8.52 ns |  7.97 ns | 0.4625 |     968 B |
| BuildFormUrlEncodedContentKeyValuePairQuery | 1,112.6 ns | 13.21 ns | 10.31 ns | 0.6695 |   1,400 B |
|   BuildFormUrlEncodedContentDictionaryQuery | 1,304.0 ns | 26.01 ns | 55.99 ns | 0.7572 |   1,584 B |
|                           CustomMethodQuery | 3,263.6 ns | 23.32 ns | 21.81 ns | 0.5875 |   1,232 B |
|        CustomMethodStaticStringBuilderQuery | 3,066.0 ns | 16.22 ns | 14.38 ns | 0.4196 |     880 B |
|                 AspNetCoreQueryBuilderQuery |   476.8 ns |  9.49 ns | 13.61 ns | 0.3557 |     744 B |
|                              LinqBuildQuery |   544.9 ns | 10.15 ns | 10.43 ns | 0.3824 |     800 B |

## Url combining MacOs:

|                          Method |        Mean |     Error |    StdDev |      Median |  Gen 0 | Allocated |
|-------------------------------- |------------:|----------:|----------:|------------:|-------:|----------:|
|                          NewUri |   259.84 ns |  1.363 ns |  1.275 ns |   259.40 ns | 0.0367 |     232 B |
|             NewUriStringCombine |    54.62 ns |  1.069 ns |  1.050 ns |    54.61 ns | 0.0395 |     248 B |
|              NewUriOfficeDevPnP |    74.24 ns |  0.455 ns |  0.425 ns |    74.27 ns | 0.0395 |     248 B |
| NewUriCombineUriBuilderToString | 1,568.96 ns | 28.783 ns | 25.515 ns | 1,565.71 ns | 0.1755 |   1,104 B |
|         NewUriCombineUriBuilder | 1,191.66 ns | 12.725 ns | 10.626 ns | 1,191.78 ns | 0.1335 |     840 B |
|    NewUriCombineFormatAndNewUri |   533.27 ns | 23.693 ns | 69.861 ns |   497.46 ns | 0.0629 |     400 B |
|     NewUriCombineFormatAndNoUri |    42.20 ns |  2.938 ns |  8.663 ns |    38.63 ns | 0.0293 |     184 B |

## Url combining Windows

|                          Method |        Mean |     Error |    StdDev |  Gen 0 | Allocated |
|-------------------------------- |------------:|----------:|----------:|-------:|----------:|
|                          NewUri |   313.53 ns |  3.738 ns |  3.314 ns | 0.1106 |     232 B |
|             NewUriStringCombine |    87.49 ns |  1.709 ns |  1.427 ns | 0.1186 |     248 B |
|              NewUriOfficeDevPnP |   113.53 ns |  2.301 ns |  2.910 ns | 0.1185 |     248 B |
| NewUriCombineUriBuilderToString | 1,869.03 ns | 19.779 ns | 16.517 ns | 0.5264 |   1,104 B |
|         NewUriCombineUriBuilder | 1,450.61 ns | 20.730 ns | 18.376 ns | 0.4005 |     840 B |
|    NewUriCombineFormatAndNewUri |   546.38 ns |  7.408 ns |  6.567 ns | 0.1912 |     400 B |
|     NewUriCombineFormatAndNoUri |    70.07 ns |  1.418 ns |  2.122 ns | 0.0880 |     184 B |

## Enum benchmarks

// * Summary *

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1387 (21H2)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
[Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


|        Method |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|-------------- |----------:|----------:|----------:|-------:|----------:|
| UnboxByString | 59.686 ns | 0.7811 ns | 0.7307 ns | 0.0344 |      72 B |
|   UnboxByShit |  9.053 ns | 0.0820 ns | 0.0727 ns |      - |         - |
