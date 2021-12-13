## MacOs testing:

Mean = 37.250 ms, StdErr = 0.218 ms (0.59%), N = 90, StdDev = 2.072 ms
Min = 32.989 ms, Q1 = 35.814 ms, Median = 36.693 ms, Q3 = 38.356 ms, Max = 42.104 ms
IQR = 2.542 ms, LowerFence = 32.001 ms, UpperFence = 42.169 ms
ConfidenceInterval = [36.506 ms; 37.993 ms] (CI 99.9%), Margin = 0.743 ms (2.00% of Mean)
Skewness = 0.55, Kurtosis = 2.54, MValue = 2

// ***** BenchmarkRunner: Finish  *****

// * Export *
  BenchmarkDotNet.Artifacts/results/QueryBenchmarks.HttpMethods-report.csv
  BenchmarkDotNet.Artifacts/results/QueryBenchmarks.HttpMethods-report-github.md
  BenchmarkDotNet.Artifacts/results/QueryBenchmarks.HttpMethods-report.html

// * Detailed results *
HttpMethods.BuildDictionaryQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 37.621 ms, StdErr = 0.237 ms (0.63%), N = 98, StdDev = 2.342 ms
Min = 31.466 ms, Q1 = 35.950 ms, Median = 37.528 ms, Q3 = 38.988 ms, Max = 43.255 ms
IQR = 3.038 ms, LowerFence = 31.392 ms, UpperFence = 43.546 ms
ConfidenceInterval = [36.818 ms; 38.424 ms] (CI 99.9%), Margin = 0.803 ms (2.13% of Mean)
Skewness = 0.21, Kurtosis = 2.79, MValue = 2.64
-------------------- Histogram --------------------
[31.323 ms ; 32.656 ms) | @@
[32.656 ms ; 33.717 ms) | 
[33.717 ms ; 34.972 ms) | @@@@@@@@@
[34.972 ms ; 36.377 ms) | @@@@@@@@@@@@@@@@@@@
[36.377 ms ; 37.710 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@
[37.710 ms ; 39.221 ms) | @@@@@@@@@@@@@@@@@@@@@
[39.221 ms ; 40.576 ms) | @@@@@@@@@@@@@
[40.576 ms ; 41.505 ms) | @
[41.505 ms ; 42.839 ms) | @@@@@@@
[42.839 ms ; 43.921 ms) | @
---------------------------------------------------

HttpMethods.BuildFormUrlEncodedContentKeyValuePairQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 36.948 ms, StdErr = 0.213 ms (0.58%), N = 70, StdDev = 1.782 ms
Min = 34.131 ms, Q1 = 35.591 ms, Median = 36.763 ms, Q3 = 37.977 ms, Max = 41.949 ms
IQR = 2.386 ms, LowerFence = 32.013 ms, UpperFence = 41.555 ms
ConfidenceInterval = [36.216 ms; 37.681 ms] (CI 99.9%), Margin = 0.732 ms (1.98% of Mean)
Skewness = 0.71, Kurtosis = 2.94, MValue = 2
-------------------- Histogram --------------------
[33.996 ms ; 35.358 ms) | @@@@@@@@@@@
[35.358 ms ; 36.493 ms) | @@@@@@@@@@@@@@@@@@@@@
[36.493 ms ; 37.824 ms) | @@@@@@@@@@@@@@@@@@
[37.824 ms ; 38.960 ms) | @@@@@@@@@@@
[38.960 ms ; 40.111 ms) | @@@@@
[40.111 ms ; 41.486 ms) | @@@
[41.486 ms ; 42.517 ms) | @
---------------------------------------------------

HttpMethods.BuildFormUrlEncodedContentDictionaryQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 36.290 ms, StdErr = 0.209 ms (0.58%), N = 90, StdDev = 1.986 ms
Min = 31.343 ms, Q1 = 34.917 ms, Median = 36.363 ms, Q3 = 37.629 ms, Max = 41.694 ms
IQR = 2.712 ms, LowerFence = 30.850 ms, UpperFence = 41.697 ms
ConfidenceInterval = [35.578 ms; 37.003 ms] (CI 99.9%), Margin = 0.712 ms (1.96% of Mean)
Skewness = 0.15, Kurtosis = 2.99, MValue = 2
-------------------- Histogram --------------------
[30.943 ms ; 32.107 ms) | @@
[32.107 ms ; 33.366 ms) | @@
[33.366 ms ; 34.628 ms) | @@@@@@@@@@@@@@
[34.628 ms ; 35.791 ms) | @@@@@@@@@@@@@@@@@@@
[35.791 ms ; 37.278 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@
[37.278 ms ; 38.645 ms) | @@@@@@@@@@@@@@@@@@@@@
[38.645 ms ; 40.107 ms) | @@@@
[40.107 ms ; 41.825 ms) | @@@
---------------------------------------------------

HttpMethods.CustomMethodQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 37.175 ms, StdErr = 0.217 ms (0.58%), N = 79, StdDev = 1.931 ms
Min = 33.467 ms, Q1 = 35.528 ms, Median = 37.070 ms, Q3 = 38.311 ms, Max = 41.777 ms
IQR = 2.783 ms, LowerFence = 31.353 ms, UpperFence = 42.486 ms
ConfidenceInterval = [36.432 ms; 37.918 ms] (CI 99.9%), Margin = 0.743 ms (2.00% of Mean)
Skewness = 0.49, Kurtosis = 2.57, MValue = 2
-------------------- Histogram --------------------
[32.877 ms ; 34.214 ms) | @@
[34.214 ms ; 35.296 ms) | @@@@@@@@@@
[35.296 ms ; 37.031 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@
[37.031 ms ; 38.212 ms) | @@@@@@@@@@@@@@@@@@@@
[38.212 ms ; 39.724 ms) | @@@@@@@@@@@@@
[39.724 ms ; 41.517 ms) | @@@@@@@
[41.517 ms ; 42.368 ms) | @
---------------------------------------------------

HttpMethods.AspNetCoreQueryBuilderQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 37.250 ms, StdErr = 0.218 ms (0.59%), N = 90, StdDev = 2.072 ms
Min = 32.989 ms, Q1 = 35.814 ms, Median = 36.693 ms, Q3 = 38.356 ms, Max = 42.104 ms
IQR = 2.542 ms, LowerFence = 32.001 ms, UpperFence = 42.169 ms
ConfidenceInterval = [36.506 ms; 37.993 ms] (CI 99.9%), Margin = 0.743 ms (2.00% of Mean)
Skewness = 0.55, Kurtosis = 2.54, MValue = 2
-------------------- Histogram --------------------
[32.382 ms ; 33.552 ms) | @
[33.552 ms ; 34.439 ms) | @@@
[34.439 ms ; 35.761 ms) | @@@@@@@@@@@@@@@@@@
[35.761 ms ; 36.975 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@@@
[36.975 ms ; 38.447 ms) | @@@@@@@@@@@@@@@@@@
[38.447 ms ; 39.830 ms) | @@@@@@@@@@
[39.830 ms ; 41.169 ms) | @@@@@@@@
[41.169 ms ; 42.401 ms) | @@@@
---------------------------------------------------

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
