##Detailed results 

###GroupByTest.GroupByTake: DefaultJob
 - Runtime = .NET 6.0.1 (6.0.121.56705), X64 RyuJIT; GC = Concurrent Workstation
 - Mean = 28.428 ms, StdErr = 0.160 ms (0.56%), N = 45, StdDev = 1.074 ms
 - Min = 26.704 ms, Q1 = 27.677 ms, Median = 28.111 ms, Q3 = 28.918 ms, Max = 31.244 ms
 - IQR = 1.240 ms, LowerFence = 25.817 ms, UpperFence = 30.778 ms
 - ConfidenceInterval = [27.864 ms; 28.993 ms] (CI 99.9%), Margin = 0.565 ms (1.99% of Mean)
 - Skewness = 0.89, Kurtosis = 3.08, MValue = 2

-------------------- Histogram --------------------

[26.307 ms ; 26.866 ms) | @

[26.866 ms ; 27.572 ms) | @@@@@@

[27.572 ms ; 28.365 ms) | @@@@@@@@@@@@@@@@@@@@@

[28.365 ms ; 29.238 ms) | @@@@@@@@

[29.238 ms ; 30.575 ms) | @@@@@

[30.575 ms ; 31.368 ms) | @@@@

---------------------------------------------------

###GroupByTest.DistinctByTake: DefaultJob

- Runtime = .NET 6.0.1 (6.0.121.56705), X64 RyuJIT; GC = Concurrent Workstation 
- Mean = 8.101 ms, StdErr = 0.039 ms (0.48%), N = 19, StdDev = 0.170 ms 
- Min = 7.835 ms, Q1 = 7.955 ms, Median = 8.123 ms, Q3 = 8.234 ms, Max = 8.402 ms 
- IQR = 0.279 ms, LowerFence = 7.537 ms, UpperFence = 8.653 ms 
- ConfidenceInterval = [7.948 ms; 8.254 ms] (CI 99.9%), Margin = 0.153 ms (1.89% of Mean)
- Skewness = -0.03, Kurtosis = 1.67, MValue = 2

-------------------- Histogram --------------------

[7.823 ms ; 7.990 ms) | @@@@@@@

[7.990 ms ; 8.261 ms) | @@@@@@@@@

[8.261 ms ; 8.436 ms) | @@@

---------------------------------------------------

###GroupByTest.DistinctTake: DefaultJob

- Runtime = .NET 6.0.1 (6.0.121.56705), X64 RyuJIT; GC = Concurrent Workstation 
- Mean = 8.295 ms, StdErr = 0.023 ms (0.28%), N = 13, StdDev = 0.083 ms 
- Min = 8.104 ms, Q1 = 8.260 ms, Median = 8.296 ms, Q3 = 8.327 ms, Max = 8.415 ms 
- IQR = 0.067 ms, LowerFence = 8.159 ms, UpperFence = 8.428 ms 
- ConfidenceInterval = [8.196 ms; 8.395 ms] (CI 99.9%), Margin = 0.099 ms (1.20% of Mean)
- Skewness = -0.56, Kurtosis = 2.91, MValue = 2

-------------------- Histogram --------------------

[8.058 ms ; 8.461 ms) | @@@@@@@@@@@@@

---------------------------------------------------

#Summary

 - BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1415 (21H2)
 - Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores 
 - .NET SDK=6.0.101
 - [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT 
 - DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|         Method |      Mean |     Error |    StdDev | Ratio |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|--------------- |----------:|----------:|----------:|------:|---------:|---------:|---------:|----------:|
|    GroupByTake | 28.428 ms | 0.5647 ms | 1.0744 ms |  1.00 | 875.0000 | 437.5000 | 156.2500 |      6 MB |
| DistinctByTake |  8.101 ms | 0.1530 ms | 0.1700 ms |  0.29 | 203.1250 | 109.3750 |  93.7500 |      3 MB |
|   DistinctTake |  8.295 ms | 0.0992 ms | 0.0829 ms |  0.29 | 203.1250 | 109.3750 |  93.7500 |      3 MB |

### * Hints *
Outliers

GroupByTest.GroupByTake: Default    -> 8 outliers were removed (34.14 ms..51.22 ms)

GroupByTest.DistinctByTake: Default -> 1 outlier  was  removed (8.68 ms)

GroupByTest.DistinctTake: Default   -> 2 outliers were removed (8.62 ms, 8.89 ms)

### * Legends *

Mean      : Arithmetic mean of all measurements

Error     : Half of 99.9% confidence interval

StdDev    : Standard deviation of all measurements

Ratio     : Mean of the ratio distribution ([Current]/[Baseline])

Gen 0     : GC Generation 0 collects per 1000 operations

Gen 1     : GC Generation 1 collects per 1000 operations

Gen 2     : GC Generation 2 collects per 1000 operations

Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

1 ms      : 1 Millisecond (0.001 sec)
