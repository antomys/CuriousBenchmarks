## * Summary *

- BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1415 (21H2)
- Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores 
- .NET SDK=6.0.101
- [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT 
- DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                                  Method |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Allocated |
|---------------------------------------- |------------:|----------:|----------:|------:|-------:|----------:|
|                   GenerateLinkFormatOld | 3,527.83 ns | 40.585 ns | 35.978 ns |  1.00 | 0.3433 |     720 B |
|           GenerateLinkFormatNewNoLength |   308.97 ns |  4.896 ns |  4.579 ns |  0.09 | 0.0992 |     208 B |
|             GenerateLinkFormatNewLength |   294.53 ns |  5.922 ns |  6.820 ns |  0.08 | 0.0992 |     208 B |
| GenerateLinkFormatAggressiveNewNoLength |   525.00 ns | 10.307 ns |  9.137 ns |  0.15 | 0.1798 |     376 B |
|   GenerateLinkFormatAggressiveNewLength |   503.52 ns |  4.859 ns |  4.307 ns |  0.14 | 0.1798 |     376 B |
|                GenerateDashFormatNative |    76.10 ns |  1.585 ns |  1.761 ns |  0.02 | 0.0994 |     208 B |
|              GenerateDashFormatV2Length |    74.82 ns |  1.576 ns |  2.454 ns |  0.02 | 0.0994 |     208 B |
|           GenerateDashFormatV2TwoValues |    72.63 ns |  1.522 ns |  1.979 ns |  0.02 | 0.0994 |     208 B |

## * Hints *
Outliers

GenericTestClass.GenerateLinkFormatOld: Default                   -> 1 outlier  was  removed (3.69 us)

GenericTestClass.GenerateLinkFormatNewLength: Default             -> 3 outliers were removed (327.53 ns..355.96 ns)

GenericTestClass.GenerateLinkFormatAggressiveNewNoLength: Default -> 1 outlier  was  removed, 4 outliers were detected (510.56 ns..517.26 ns, 589.03 ns)

GenericTestClass.GenerateLinkFormatAggressiveNewLength: Default   -> 1 outlier  was  removed (541.70 ns)

GenericTestClass.GenerateDashFormatNative: Default                -> 2 outliers were removed (94.40 ns, 97.64 ns)

GenericTestClass.GenerateDashFormatV2Length: Default              -> 1 outlier  was  removed (97.51 ns)

GenericTestClass.GenerateDashFormatV2TwoValues: Default           -> 1 outlier  was  removed (105.36 ns)
