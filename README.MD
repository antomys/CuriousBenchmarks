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