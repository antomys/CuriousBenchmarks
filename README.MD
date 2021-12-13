## MacOs testing:
// * Summary *

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.0.1 (21A559) [Darwin 21.1.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100
[Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


|                                      Method |     Mean |    Error |   StdDev |
|-------------------------------------------- |---------:|---------:|---------:|
|                        BuildDictionaryQuery | 37.62 ms | 0.803 ms | 2.342 ms |
| BuildFormUrlEncodedContentKeyValuePairQuery | 36.95 ms | 0.732 ms | 1.782 ms |
|   BuildFormUrlEncodedContentDictionaryQuery | 36.29 ms | 0.712 ms | 1.986 ms |
|                           CustomMethodQuery | 37.17 ms | 0.743 ms | 1.931 ms |
|                 AspNetCoreQueryBuilderQuery | 37.25 ms | 0.743 ms | 2.072 ms |

// * Hints *
Outliers
HttpMethods.BuildDictionaryQuery: Default                        -> 2 outliers were removed (44.80 ms, 51.15 ms)
HttpMethods.BuildFormUrlEncodedContentKeyValuePairQuery: Default -> 3 outliers were removed (43.02 ms..102.55 ms)
HttpMethods.BuildFormUrlEncodedContentDictionaryQuery: Default   -> 3 outliers were removed (42.16 ms..65.86 ms)
HttpMethods.CustomMethodQuery: Default                           -> 4 outliers were removed (46.44 ms..106.21 ms)
HttpMethods.AspNetCoreQueryBuilderQuery: Default                 -> 3 outliers were removed (45.11 ms..53.28 ms)

// * Legends *
Mean   : Arithmetic mean of all measurements
Error  : Half of 99.9% confidence interval
StdDev : Standard deviation of all measurements
1 ms   : 1 Millisecond (0.001 sec)

## No Http:
|                                      Method |       Mean |    Error |   StdDev |  Gen 0 | Allocated |
|-------------------------------------------- |-----------:|---------:|---------:|-------:|----------:|
|                        BuildDictionaryQuery |   335.3 ns |  5.43 ns |  5.08 ns | 0.1540 |     968 B |
| BuildFormUrlEncodedContentKeyValuePairQuery |   737.5 ns |  5.90 ns |  5.52 ns | 0.2232 |   1,400 B |
|   BuildFormUrlEncodedContentDictionaryQuery |   831.9 ns |  3.06 ns |  2.71 ns | 0.2518 |   1,584 B |
|                           CustomMethodQuery | 2,472.0 ns | 16.12 ns | 13.46 ns | 0.1945 |   1,232 B |
|                 AspNetCoreQueryBuilderQuery |   258.6 ns |  2.03 ns |  1.80 ns | 0.1183 |     744 B |

## Windows

// * Summary *

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1387 (21H2)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
[Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


|                                      Method |     Mean |    Error |   StdDev | Allocated |
|-------------------------------------------- |---------:|---------:|---------:|----------:|
|                        BuildDictionaryQuery | 22.50 ms | 0.639 ms | 1.833 ms |     38 KB |
| BuildFormUrlEncodedContentKeyValuePairQuery | 22.19 ms | 0.527 ms | 1.511 ms |     33 KB |
|   BuildFormUrlEncodedContentDictionaryQuery | 21.70 ms | 0.462 ms | 1.347 ms |     34 KB |
|                           CustomMethodQuery | 22.05 ms | 0.515 ms | 1.502 ms |     38 KB |
|                 AspNetCoreQueryBuilderQuery | 20.96 ms | 0.472 ms | 1.370 ms |     38 KB |

// * Warnings *
MultimodalDistribution
HttpMethods.BuildFormUrlEncodedContentDictionaryQuery: Default -> It seems that the distribution can have several modes (mValue = 3.15)

# No HTTP
|                                      Method |       Mean |    Error |   StdDev |  Gen 0 | Allocated |
|-------------------------------------------- |-----------:|---------:|---------:|-------:|----------:|
|                        BuildDictionaryQuery |   593.0 ns |  9.34 ns |  8.28 ns | 0.4625 |     968 B |
| BuildFormUrlEncodedContentKeyValuePairQuery | 1,198.5 ns | 22.34 ns | 19.80 ns | 0.7420 |   1,552 B |
|   BuildFormUrlEncodedContentDictionaryQuery | 1,353.8 ns | 27.02 ns | 45.14 ns | 0.8297 |   1,736 B |
|                           CustomMethodQuery | 3,347.1 ns | 29.15 ns | 25.84 ns | 0.5875 |   1,232 B |
|                 AspNetCoreQueryBuilderQuery |   452.5 ns |  8.12 ns | 10.84 ns | 0.3557 |     744 B |
