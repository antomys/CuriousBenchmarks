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

|                            Method |        Mean |     Error |    StdDev |  Gen 0 |  Gen 1 | Allocated |
|---------------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
|                            NewUri |   275.81 ns |  7.082 ns | 20.090 ns | 0.0367 | 0.0005 |     232 B |
|               NewUriStringCombine |    56.06 ns |  1.474 ns |  4.346 ns | 0.0395 |      - |     248 B |
|                NewUriOfficeDevPnP |    70.19 ns |  1.089 ns |  0.966 ns | 0.0395 |      - |     248 B |
|   NewUriCombineUriBuilderToString | 1,474.98 ns | 28.667 ns | 41.113 ns | 0.1755 |      - |   1,104 B |
|           NewUriCombineUriBuilder | 1,078.42 ns | 14.039 ns | 12.445 ns | 0.1335 |      - |     840 B |
|      NewUriCombineFormatAndNewUri |   463.06 ns |  5.086 ns |  4.247 ns | 0.0634 |      - |     400 B |
|       NewUriCombineFormatAndNoUri |    32.34 ns |  0.205 ns |  0.191 ns | 0.0293 |      - |     184 B |
| NewUriCombineFormatAndNoUriCached |    30.64 ns |  0.293 ns |  0.274 ns | 0.0293 |      - |     184 B |

## Url combining Windows

|                            Method |        Mean |     Error |    StdDev |  Gen 0 | Allocated |
|---------------------------------- |------------:|----------:|----------:|-------:|----------:|
|                            NewUri |   336.86 ns |  4.097 ns |  3.632 ns | 0.1106 |     232 B |
|               NewUriStringCombine |    97.90 ns |  1.675 ns |  2.057 ns | 0.1186 |     248 B |
|                NewUriOfficeDevPnP |   128.15 ns |  2.333 ns |  2.292 ns | 0.1185 |     248 B |
|   NewUriCombineUriBuilderToString | 1,916.28 ns | 24.827 ns | 23.223 ns | 0.5264 |   1,104 B |
|           NewUriCombineUriBuilder | 1,477.95 ns | 16.800 ns | 14.893 ns | 0.4005 |     840 B |
|      NewUriCombineFormatAndNewUri |   559.36 ns | 11.229 ns | 10.504 ns | 0.1907 |     400 B |
|       NewUriCombineFormatAndNoUri |    71.32 ns |  1.444 ns |  2.205 ns | 0.0880 |     184 B |
| NewUriCombineFormatAndNoUriCached |    67.70 ns |  1.352 ns |  1.939 ns | 0.0880 |     184 B |

## Enum benchmarks

// * Summary *

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1387 (21H2)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
[Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


| Method             |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|--------------------|----------:|----------:|----------:|-------:|----------:|
| UnboxByString      | 59.686 ns | 0.7811 ns | 0.7307 ns | 0.0344 |      72 B |
| UnboxByIntToString |  9.053 ns | 0.0820 ns | 0.0727 ns |      - |         - |


# MacOs

|        Method |      Mean |    Error |   StdDev |  Gen 0 | Allocated |
|-------------- |----------:|---------:|---------:|-------:|----------:|
| UnboxByString | 172.17 ns | 1.596 ns | 1.332 ns | 0.0560 |     352 B |
|   UnboxByCast |  42.55 ns | 0.303 ns | 0.269 ns | 0.0102 |      64 B |
|  EnumToString | 303.11 ns | 2.596 ns | 2.301 ns | 0.0458 |     288 B |
|   EnumGetName | 314.46 ns | 0.927 ns | 0.774 ns |      - |         - |