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

## Windows
Mean = 20.964 ms, StdErr = 0.139 ms (0.66%), N = 97, StdDev = 1.370 ms
Min = 18.402 ms, Q1 = 19.886 ms, Median = 20.914 ms, Q3 = 21.905 ms, Max = 25.305 ms
IQR = 2.019 ms, LowerFence = 16.858 ms, UpperFence = 24.933 ms
ConfidenceInterval = [20.492 ms; 21.436 ms] (CI 99.9%), Margin = 0.472 ms (2.25% of Mean)
Skewness = 0.44, Kurtosis = 2.92, MValue = 2.19

// ***** BenchmarkRunner: Finish  *****

// * Export *
BenchmarkDotNet.Artifacts\results\QueryBenchmarks.HttpMethods-report.csv
BenchmarkDotNet.Artifacts\results\QueryBenchmarks.HttpMethods-report-github.md
BenchmarkDotNet.Artifacts\results\QueryBenchmarks.HttpMethods-report.html

// * Detailed results *
HttpMethods.BuildDictionaryQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 22.497 ms, StdErr = 0.188 ms (0.84%), N = 95, StdDev = 1.833 ms
Min = 18.689 ms, Q1 = 21.165 ms, Median = 22.304 ms, Q3 = 23.758 ms, Max = 27.415 ms
IQR = 2.593 ms, LowerFence = 17.275 ms, UpperFence = 27.648 ms
ConfidenceInterval = [21.858 ms; 23.136 ms] (CI 99.9%), Margin = 0.639 ms (2.84% of Mean)
Skewness = 0.41, Kurtosis = 2.74, MValue = 2.75
-------------------- Histogram --------------------
[18.162 ms ; 19.095 ms) | @
[19.095 ms ; 20.184 ms) | @@@@@@
[20.184 ms ; 21.239 ms) | @@@@@@@@@@@@@@@@@@@
[21.239 ms ; 22.578 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
[22.578 ms ; 23.262 ms) | @@@@@@
[23.262 ms ; 24.316 ms) | @@@@@@@@@@@@@@@@
[24.316 ms ; 25.627 ms) | @@@@@@@@@@@
[25.627 ms ; 26.519 ms) | @
[26.519 ms ; 27.574 ms) | @@@
---------------------------------------------------

HttpMethods.BuildFormUrlEncodedContentKeyValuePairQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 22.191 ms, StdErr = 0.155 ms (0.70%), N = 95, StdDev = 1.511 ms
Min = 19.263 ms, Q1 = 21.063 ms, Median = 21.950 ms, Q3 = 23.226 ms, Max = 26.046 ms
IQR = 2.164 ms, LowerFence = 17.817 ms, UpperFence = 26.472 ms
ConfidenceInterval = [21.665 ms; 22.718 ms] (CI 99.9%), Margin = 0.527 ms (2.37% of Mean)
Skewness = 0.37, Kurtosis = 2.53, MValue = 2
-------------------- Histogram --------------------
[18.828 ms ; 19.820 ms) | @@@
[19.820 ms ; 20.762 ms) | @@@@@@@@@@@@
[20.762 ms ; 21.732 ms) | @@@@@@@@@@@@@@@@@@@@@
[21.732 ms ; 22.601 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@
[22.601 ms ; 23.870 ms) | @@@@@@@@@@@@@@@@@@@
[23.870 ms ; 24.851 ms) | @@@@@@@@@
[24.851 ms ; 25.768 ms) | @@@@
[25.768 ms ; 26.481 ms) | @
---------------------------------------------------

HttpMethods.BuildFormUrlEncodedContentDictionaryQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 21.698 ms, StdErr = 0.136 ms (0.63%), N = 98, StdDev = 1.347 ms
Min = 18.461 ms, Q1 = 20.852 ms, Median = 21.597 ms, Q3 = 22.792 ms, Max = 25.145 ms
IQR = 1.940 ms, LowerFence = 17.943 ms, UpperFence = 25.702 ms
ConfidenceInterval = [21.237 ms; 22.160 ms] (CI 99.9%), Margin = 0.462 ms (2.13% of Mean)
Skewness = 0.01, Kurtosis = 2.53, MValue = 3.15
-------------------- Histogram --------------------
[18.262 ms ; 19.029 ms) | @@
[19.029 ms ; 19.848 ms) | @@@@@@@
[19.848 ms ; 20.615 ms) | @@@@@@@@@@@@@@
[20.615 ms ; 21.563 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@
[21.563 ms ; 22.147 ms) | @@@@@@@@
[22.147 ms ; 22.914 ms) | @@@@@@@@@@@@@@@@@@@@@@@
[22.914 ms ; 23.850 ms) | @@@@@@@@@@@@
[23.850 ms ; 24.617 ms) | @@@@@
[24.617 ms ; 25.528 ms) | @
---------------------------------------------------

HttpMethods.CustomMethodQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 22.054 ms, StdErr = 0.152 ms (0.69%), N = 98, StdDev = 1.502 ms
Min = 18.794 ms, Q1 = 20.876 ms, Median = 22.116 ms, Q3 = 23.047 ms, Max = 25.990 ms
IQR = 2.172 ms, LowerFence = 17.618 ms, UpperFence = 26.304 ms
ConfidenceInterval = [21.539 ms; 22.569 ms] (CI 99.9%), Margin = 0.515 ms (2.33% of Mean)
Skewness = 0.15, Kurtosis = 2.66, MValue = 2.43
-------------------- Histogram --------------------
[18.614 ms ; 19.486 ms) | @@@@
[19.486 ms ; 20.308 ms) | @@@@@@
[20.308 ms ; 21.163 ms) | @@@@@@@@@@@@@@@@@@@@@
[21.163 ms ; 22.115 ms) | @@@@@@@@@@@@@@@@@
[22.115 ms ; 22.970 ms) | @@@@@@@@@@@@@@@@@@@@@@@
[22.970 ms ; 23.859 ms) | @@@@@@@@@@@@@@@@@
[23.859 ms ; 24.620 ms) | @@@@@@@
[24.620 ms ; 25.555 ms) | @
[25.555 ms ; 26.417 ms) | @@
---------------------------------------------------

HttpMethods.AspNetCoreQueryBuilderQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 20.964 ms, StdErr = 0.139 ms (0.66%), N = 97, StdDev = 1.370 ms
Min = 18.402 ms, Q1 = 19.886 ms, Median = 20.914 ms, Q3 = 21.905 ms, Max = 25.305 ms
IQR = 2.019 ms, LowerFence = 16.858 ms, UpperFence = 24.933 ms
ConfidenceInterval = [20.492 ms; 21.436 ms] (CI 99.9%), Margin = 0.472 ms (2.25% of Mean)
Skewness = 0.44, Kurtosis = 2.92, MValue = 2.19
-------------------- Histogram --------------------
[18.011 ms ; 18.482 ms) | @
[18.482 ms ; 19.262 ms) | @@@@@@@@
[19.262 ms ; 20.044 ms) | @@@@@@@@@@@@@@@@@@@@@@
[20.044 ms ; 21.203 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@@
[21.203 ms ; 21.637 ms) | @@@@@@
[21.637 ms ; 22.420 ms) | @@@@@@@@@@@@@@@@@@@@@@
[22.420 ms ; 23.166 ms) | @@@@@@@
[23.166 ms ; 23.876 ms) | @
[23.876 ms ; 24.913 ms) | @@
[24.913 ms ; 25.696 ms) | @
---------------------------------------------------

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

// * Hints *
Outliers
HttpMethods.BuildDictionaryQuery: Default                        -> 5 outliers were removed (28.17 ms..49.88 ms)
HttpMethods.BuildFormUrlEncodedContentKeyValuePairQuery: Default -> 5 outliers were removed (27.46 ms..56.29 ms)
HttpMethods.BuildFormUrlEncodedContentDictionaryQuery: Default   -> 2 outliers were removed (27.07 ms, 27.29 ms)
HttpMethods.CustomMethodQuery: Default                           -> 2 outliers were removed (30.91 ms, 53.38 ms)
HttpMethods.AspNetCoreQueryBuilderQuery: Default                 -> 3 outliers were removed (25.61 ms..30.57 ms)

// * Legends *
Mean      : Arithmetic mean of all measurements
Error     : Half of 99.9% confidence interval
StdDev    : Standard deviation of all measurements
Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
1 ms      : 1 Millisecond (0.001 sec)

Mean = 20.964 ms, StdErr = 0.139 ms (0.66%), N = 97, StdDev = 1.370 ms
Min = 18.402 ms, Q1 = 19.886 ms, Median = 20.914 ms, Q3 = 21.905 ms, Max = 25.305 ms
IQR = 2.019 ms, LowerFence = 16.858 ms, UpperFence = 24.933 ms
ConfidenceInterval = [20.492 ms; 21.436 ms] (CI 99.9%), Margin = 0.472 ms (2.25% of Mean)
Skewness = 0.44, Kurtosis = 2.92, MValue = 2.19

// ***** BenchmarkRunner: Finish  *****

// * Export *
BenchmarkDotNet.Artifacts\results\QueryBenchmarks.HttpMethods-report.csv
BenchmarkDotNet.Artifacts\results\QueryBenchmarks.HttpMethods-report-github.md
BenchmarkDotNet.Artifacts\results\QueryBenchmarks.HttpMethods-report.html

// * Detailed results *
HttpMethods.BuildDictionaryQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 22.497 ms, StdErr = 0.188 ms (0.84%), N = 95, StdDev = 1.833 ms
Min = 18.689 ms, Q1 = 21.165 ms, Median = 22.304 ms, Q3 = 23.758 ms, Max = 27.415 ms
IQR = 2.593 ms, LowerFence = 17.275 ms, UpperFence = 27.648 ms
ConfidenceInterval = [21.858 ms; 23.136 ms] (CI 99.9%), Margin = 0.639 ms (2.84% of Mean)
Skewness = 0.41, Kurtosis = 2.74, MValue = 2.75
-------------------- Histogram --------------------
[18.162 ms ; 19.095 ms) | @
[19.095 ms ; 20.184 ms) | @@@@@@
[20.184 ms ; 21.239 ms) | @@@@@@@@@@@@@@@@@@@
[21.239 ms ; 22.578 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
[22.578 ms ; 23.262 ms) | @@@@@@
[23.262 ms ; 24.316 ms) | @@@@@@@@@@@@@@@@
[24.316 ms ; 25.627 ms) | @@@@@@@@@@@
[25.627 ms ; 26.519 ms) | @
[26.519 ms ; 27.574 ms) | @@@
---------------------------------------------------

HttpMethods.BuildFormUrlEncodedContentKeyValuePairQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 22.191 ms, StdErr = 0.155 ms (0.70%), N = 95, StdDev = 1.511 ms
Min = 19.263 ms, Q1 = 21.063 ms, Median = 21.950 ms, Q3 = 23.226 ms, Max = 26.046 ms
IQR = 2.164 ms, LowerFence = 17.817 ms, UpperFence = 26.472 ms
ConfidenceInterval = [21.665 ms; 22.718 ms] (CI 99.9%), Margin = 0.527 ms (2.37% of Mean)
Skewness = 0.37, Kurtosis = 2.53, MValue = 2
-------------------- Histogram --------------------
[18.828 ms ; 19.820 ms) | @@@
[19.820 ms ; 20.762 ms) | @@@@@@@@@@@@
[20.762 ms ; 21.732 ms) | @@@@@@@@@@@@@@@@@@@@@
[21.732 ms ; 22.601 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@
[22.601 ms ; 23.870 ms) | @@@@@@@@@@@@@@@@@@@
[23.870 ms ; 24.851 ms) | @@@@@@@@@
[24.851 ms ; 25.768 ms) | @@@@
[25.768 ms ; 26.481 ms) | @
---------------------------------------------------

HttpMethods.BuildFormUrlEncodedContentDictionaryQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 21.698 ms, StdErr = 0.136 ms (0.63%), N = 98, StdDev = 1.347 ms
Min = 18.461 ms, Q1 = 20.852 ms, Median = 21.597 ms, Q3 = 22.792 ms, Max = 25.145 ms
IQR = 1.940 ms, LowerFence = 17.943 ms, UpperFence = 25.702 ms
ConfidenceInterval = [21.237 ms; 22.160 ms] (CI 99.9%), Margin = 0.462 ms (2.13% of Mean)
Skewness = 0.01, Kurtosis = 2.53, MValue = 3.15
-------------------- Histogram --------------------
[18.262 ms ; 19.029 ms) | @@
[19.029 ms ; 19.848 ms) | @@@@@@@
[19.848 ms ; 20.615 ms) | @@@@@@@@@@@@@@
[20.615 ms ; 21.563 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@
[21.563 ms ; 22.147 ms) | @@@@@@@@
[22.147 ms ; 22.914 ms) | @@@@@@@@@@@@@@@@@@@@@@@
[22.914 ms ; 23.850 ms) | @@@@@@@@@@@@
[23.850 ms ; 24.617 ms) | @@@@@
[24.617 ms ; 25.528 ms) | @
---------------------------------------------------

HttpMethods.CustomMethodQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 22.054 ms, StdErr = 0.152 ms (0.69%), N = 98, StdDev = 1.502 ms
Min = 18.794 ms, Q1 = 20.876 ms, Median = 22.116 ms, Q3 = 23.047 ms, Max = 25.990 ms
IQR = 2.172 ms, LowerFence = 17.618 ms, UpperFence = 26.304 ms
ConfidenceInterval = [21.539 ms; 22.569 ms] (CI 99.9%), Margin = 0.515 ms (2.33% of Mean)
Skewness = 0.15, Kurtosis = 2.66, MValue = 2.43
-------------------- Histogram --------------------
[18.614 ms ; 19.486 ms) | @@@@
[19.486 ms ; 20.308 ms) | @@@@@@
[20.308 ms ; 21.163 ms) | @@@@@@@@@@@@@@@@@@@@@
[21.163 ms ; 22.115 ms) | @@@@@@@@@@@@@@@@@
[22.115 ms ; 22.970 ms) | @@@@@@@@@@@@@@@@@@@@@@@
[22.970 ms ; 23.859 ms) | @@@@@@@@@@@@@@@@@
[23.859 ms ; 24.620 ms) | @@@@@@@
[24.620 ms ; 25.555 ms) | @
[25.555 ms ; 26.417 ms) | @@
---------------------------------------------------

HttpMethods.AspNetCoreQueryBuilderQuery: DefaultJob
Runtime = .NET 6.0.0 (6.0.21.52210), X64 RyuJIT; GC = Concurrent Workstation
Mean = 20.964 ms, StdErr = 0.139 ms (0.66%), N = 97, StdDev = 1.370 ms
Min = 18.402 ms, Q1 = 19.886 ms, Median = 20.914 ms, Q3 = 21.905 ms, Max = 25.305 ms
IQR = 2.019 ms, LowerFence = 16.858 ms, UpperFence = 24.933 ms
ConfidenceInterval = [20.492 ms; 21.436 ms] (CI 99.9%), Margin = 0.472 ms (2.25% of Mean)
Skewness = 0.44, Kurtosis = 2.92, MValue = 2.19
-------------------- Histogram --------------------
[18.011 ms ; 18.482 ms) | @
[18.482 ms ; 19.262 ms) | @@@@@@@@
[19.262 ms ; 20.044 ms) | @@@@@@@@@@@@@@@@@@@@@@
[20.044 ms ; 21.203 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@@
[21.203 ms ; 21.637 ms) | @@@@@@
[21.637 ms ; 22.420 ms) | @@@@@@@@@@@@@@@@@@@@@@
[22.420 ms ; 23.166 ms) | @@@@@@@
[23.166 ms ; 23.876 ms) | @
[23.876 ms ; 24.913 ms) | @@
[24.913 ms ; 25.696 ms) | @
---------------------------------------------------

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

// * Hints *
Outliers
HttpMethods.BuildDictionaryQuery: Default                        -> 5 outliers were removed (28.17 ms..49.88 ms)
HttpMethods.BuildFormUrlEncodedContentKeyValuePairQuery: Default -> 5 outliers were removed (27.46 ms..56.29 ms)
HttpMethods.BuildFormUrlEncodedContentDictionaryQuery: Default   -> 2 outliers were removed (27.07 ms, 27.29 ms)
HttpMethods.CustomMethodQuery: Default                           -> 2 outliers were removed (30.91 ms, 53.38 ms)
HttpMethods.AspNetCoreQueryBuilderQuery: Default                 -> 3 outliers were removed (25.61 ms..30.57 ms)

// * Legends *
Mean      : Arithmetic mean of all measurements
Error     : Half of 99.9% confidence interval
StdDev    : Standard deviation of all measurements
Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
1 ms      : 1 Millisecond (0.001 sec)

# No HTTP
|                                      Method |       Mean |    Error |   StdDev |  Gen 0 | Allocated |
|-------------------------------------------- |-----------:|---------:|---------:|-------:|----------:|
|                        BuildDictionaryQuery |   593.0 ns |  9.34 ns |  8.28 ns | 0.4625 |     968 B |
| BuildFormUrlEncodedContentKeyValuePairQuery | 1,198.5 ns | 22.34 ns | 19.80 ns | 0.7420 |   1,552 B |
|   BuildFormUrlEncodedContentDictionaryQuery | 1,353.8 ns | 27.02 ns | 45.14 ns | 0.8297 |   1,736 B |
|                           CustomMethodQuery | 3,347.1 ns | 29.15 ns | 25.84 ns | 0.5875 |   1,232 B |
|                 AspNetCoreQueryBuilderQuery |   452.5 ns |  8.12 ns | 10.84 ns | 0.3557 |     744 B |
