## MacOs testing:

// * Summary *

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.0.1 (21A559) [Darwin 21.1.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


|                                      Method |     Mean |   Error |   StdDev |   Median |
|-------------------------------------------- |---------:|--------:|---------:|---------:|
|                        BuildDictionaryQuery | 190.2 ms | 3.61 ms |  3.87 ms | 191.2 ms |
| BuildFormUrlEncodedContentKeyValuePairQuery | 190.2 ms | 3.72 ms |  4.13 ms | 189.6 ms |
|   BuildFormUrlEncodedContentDictionaryQuery | 188.6 ms | 3.65 ms |  3.05 ms | 187.7 ms |
|                           CustomMethodQuery | 226.9 ms | 9.54 ms | 27.98 ms | 210.3 ms |
|                 AspNetCoreQueryBuilderQuery | 230.6 ms | 9.48 ms | 27.66 ms | 239.2 ms |

// * Warnings *
MultimodalDistribution
  HttpMethods.CustomMethodQuery: Default           -> It seems that the distribution is bimodal (mValue = 3.88)
  HttpMethods.AspNetCoreQueryBuilderQuery: Default -> It seems that the distribution is multimodal (mValue = 4.31)

// * Hints *
Outliers
  HttpMethods.BuildDictionaryQuery: Default                        -> 1 outlier  was  removed (203.16 ms)
  HttpMethods.BuildFormUrlEncodedContentKeyValuePairQuery: Default -> 1 outlier  was  removed (255.57 ms)
  HttpMethods.BuildFormUrlEncodedContentDictionaryQuery: Default   -> 2 outliers were removed (202.73 ms, 228.69 ms)
  HttpMethods.CustomMethodQuery: Default                           -> 1 outlier  was  removed (339.12 ms)
  HttpMethods.AspNetCoreQueryBuilderQuery: Default                 -> 2 outliers were removed (354.00 ms, 447.79 ms)

// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  Median : Value separating the higher half of all measurements (50th percentile)
  1 ms   : 1 Millisecond (0.001 sec)
