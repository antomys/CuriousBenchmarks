## * Summary *

- BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1415 (21H2)
- Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores 
- .NET SDK=6.0.101
- [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT 
- DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                                  Method |        Mean |     Error |    StdDev |    StdErr |         Min |         Max |          Q1 |          Q3 |      Median |         Op/s | Ratio | Rank |  Gen 0 | Allocated |
|---------------------------------------- |------------:|----------:|----------:|----------:|------------:|------------:|------------:|------------:|------------:|-------------:|------:|-----:|-------:|----------:|
|                GenerateDashFormatNative |    29.74 ns |  0.656 ns |  1.279 ns |  0.186 ns |    27.50 ns |    32.60 ns |    28.84 ns |    30.77 ns |    29.35 ns | 33,629,356.6 |  0.01 |    1 | 0.0331 |     208 B |
|           GenerateDashFormatV2TwoValues |    30.54 ns |  0.617 ns |  0.515 ns |  0.143 ns |    29.89 ns |    31.17 ns |    29.99 ns |    30.97 ns |    30.85 ns | 32,742,128.2 |  0.01 |    1 | 0.0331 |     208 B |
|              GenerateDashFormatV2Length |    43.90 ns |  0.941 ns |  1.900 ns |  0.269 ns |    39.99 ns |    49.10 ns |    42.77 ns |    45.42 ns |    43.63 ns | 22,778,107.3 |  0.01 |    2 | 0.0331 |     208 B |
|             GenerateLinkFormatNewLength |   186.04 ns |  3.750 ns |  4.464 ns |  0.974 ns |   174.59 ns |   194.30 ns |   184.54 ns |   188.59 ns |   186.47 ns |  5,375,104.0 |  0.06 |    3 | 0.0331 |     208 B |
|           GenerateLinkFormatNewNoLength |   199.93 ns |  4.035 ns |  8.599 ns |  1.160 ns |   183.41 ns |   220.79 ns |   193.27 ns |   205.89 ns |   202.13 ns |  5,001,737.5 |  0.07 |    4 | 0.0331 |     208 B |
| GenerateLinkFormatAggressiveNewNoLength |   308.51 ns |  5.911 ns |  7.036 ns |  1.535 ns |   298.16 ns |   321.64 ns |   301.35 ns |   313.78 ns |   307.47 ns |  3,241,436.1 |  0.11 |    5 | 0.0596 |     376 B |
|   GenerateLinkFormatAggressiveNewLength |   315.89 ns |  6.258 ns | 10.627 ns |  1.747 ns |   290.79 ns |   337.20 ns |   310.12 ns |   322.73 ns |   315.73 ns |  3,165,642.7 |  0.11 |    6 | 0.0596 |     376 B |
|                   GenerateLinkFormatOld | 2,893.32 ns | 54.748 ns | 67.235 ns | 14.335 ns | 2,745.43 ns | 3,000.61 ns | 2,862.60 ns | 2,936.47 ns | 2,904.10 ns |    345,623.6 |  1.00 |    7 | 0.1144 |     720 B |

**Warnings**

    StringExtensionsTests.GenerateDashFormatNative: Default -> It seems that the distribution can have several modes (mValue = 3)

    InterpolationTests.CombineFormat: Default -> It seems that the distribution can have several modes (mValue = 3.04)

|               Method |     Mean |   Error |  StdDev |  StdErr |      Min |      Max |       Q1 |       Q3 |   Median |        Op/s | Rank |  Gen 0 | Allocated |
|--------------------- |---------:|--------:|--------:|--------:|---------:|---------:|---------:|---------:|---------:|------------:|-----:|-------:|----------:|
| CombineInterpolation | 135.0 ns | 2.11 ns | 1.98 ns | 0.51 ns | 131.7 ns | 138.9 ns | 133.4 ns | 136.0 ns | 135.1 ns | 7,409,389.0 |    1 | 0.0050 |      32 B |
|        CombineFormat | 212.4 ns | 4.28 ns | 9.30 ns | 1.23 ns | 195.0 ns | 235.3 ns | 205.7 ns | 218.1 ns | 214.5 ns | 4,708,622.4 |    2 | 0.0176 |     112 B |

## * Hints *
Outliers

GenericTestClass.GenerateLinkFormatOld: Default                   -> 1 outlier  was  removed (3.69 us)

GenericTestClass.GenerateLinkFormatNewLength: Default             -> 3 outliers were removed (327.53 ns..355.96 ns)

GenericTestClass.GenerateLinkFormatAggressiveNewNoLength: Default -> 1 outlier  was  removed, 4 outliers were detected (510.56 ns..517.26 ns, 589.03 ns)

GenericTestClass.GenerateLinkFormatAggressiveNewLength: Default   -> 1 outlier  was  removed (541.70 ns)

GenericTestClass.GenerateDashFormatNative: Default                -> 2 outliers were removed (94.40 ns, 97.64 ns)

GenericTestClass.GenerateDashFormatV2Length: Default              -> 1 outlier  was  removed (97.51 ns)

GenericTestClass.GenerateDashFormatV2TwoValues: Default           -> 1 outlier  was  removed (105.36 ns)
