## MacOs testing:
// * Summary *

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.0.1 (21A559) [Darwin 21.1.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100
[Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT

|                                      Method |       Mean |    Error |   StdDev |  Gen 0 | Allocated |
|-------------------------------------------- |-----------:|---------:|---------:|-------:|----------:|
|                        BuildDictionaryQuery |   381.0 ns |  3.95 ns |  3.09 ns | 0.1540 |     968 B |
| BuildFormUrlEncodedContentKeyValuePairQuery |   764.5 ns |  4.28 ns |  3.57 ns | 0.2232 |   1,400 B |
|   BuildFormUrlEncodedContentDictionaryQuery |   839.7 ns |  3.18 ns |  2.82 ns | 0.2518 |   1,584 B |
|                           CustomMethodQuery | 2,362.7 ns | 19.42 ns | 18.17 ns | 0.1945 |   1,232 B |
|        CustomMethodStaticStringBuilderQuery | 2,311.0 ns | 10.14 ns |  9.48 ns | 0.1373 |     880 B |
|                 AspNetCoreQueryBuilderQuery |   278.7 ns |  1.97 ns |  1.85 ns | 0.1183 |     744 B |
|                              LinqBuildQuery |   332.3 ns |  6.28 ns |  5.87 ns | 0.1273 |     800 B |