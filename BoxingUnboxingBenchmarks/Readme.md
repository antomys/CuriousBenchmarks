# 1. Enum unboxing test

In this test i've benchmarked unboxing and different approaches to retrieve either name of value from enum.

``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                    Method |                   Categories |      Mean |    Error |   StdDev |   StdErr |       Min |       Max |        Q1 |        Q3 |    Median |         Op/s | Rank |  Gen 0 | Allocated |
|-------------------------- |----------------------------- |----------:|---------:|---------:|---------:|----------:|----------:|----------:|----------:|----------:|-------------:|-----:|-------:|----------:|
|        IntFromEnumOneCast |                Int from Enum |  19.22 ns | 0.113 ns | 0.100 ns | 0.027 ns |  19.08 ns |  19.45 ns |  19.14 ns |  19.29 ns |  19.21 ns | 52,020,472.2 |    1 | 0.0051 |      32 B |
|    IntFromEnumOneToString |                Int from Enum |  27.74 ns | 0.164 ns | 0.154 ns | 0.040 ns |  27.53 ns |  28.04 ns |  27.65 ns |  27.82 ns |  27.68 ns | 36,052,230.1 |    2 | 0.0089 |      56 B |
|                           |                              |           |          |          |          |           |           |           |           |           |              |      |        |           |
|  StringFromEnumOneGetName |             String from Enum |  60.48 ns | 0.426 ns | 0.399 ns | 0.103 ns |  59.69 ns |  61.22 ns |  60.28 ns |  60.66 ns |  60.51 ns | 16,534,144.1 |    1 | 0.0050 |      32 B |
| StringFromEnumOneToString |             String from Enum |  61.51 ns | 0.528 ns | 0.441 ns | 0.122 ns |  60.95 ns |  62.47 ns |  61.24 ns |  61.68 ns |  61.37 ns | 16,256,685.8 |    2 | 0.0088 |      56 B |
|                           |                              |           |          |          |          |           |           |           |           |           |              |      |        |           |
|             EnumIntByCast |         Array. Int from Enum | 282.17 ns | 0.908 ns | 0.758 ns | 0.210 ns | 280.99 ns | 283.53 ns | 281.69 ns | 282.53 ns | 282.24 ns |  3,543,971.1 |    1 | 0.0763 |     480 B |
|         EnumIntByToString |         Array. Int from Enum | 400.43 ns | 2.831 ns | 2.510 ns | 0.671 ns | 396.02 ns | 404.50 ns | 398.57 ns | 402.25 ns | 400.07 ns |  2,497,298.9 |    2 | 0.1221 |     768 B |
|                           |                              |           |          |          |          |           |           |           |           |           |              |      |        |           |
|              EnumToString |      Array. String from Enum | 837.40 ns | 3.846 ns | 3.597 ns | 0.929 ns | 832.42 ns | 843.85 ns | 835.13 ns | 839.35 ns | 836.20 ns |  1,194,171.9 |    1 | 0.1068 |     672 B |
|               EnumGetName |      Array. String from Enum | 893.44 ns | 3.169 ns | 2.809 ns | 0.751 ns | 887.46 ns | 897.81 ns | 892.14 ns | 895.08 ns | 893.76 ns |  1,119,265.2 |    2 | 0.0610 |     384 B |
|                           |                              |           |          |          |          |           |           |           |           |           |              |      |        |           |
|         EnumIntByCastLinq |    Array. Int from Enum Linq | 219.24 ns | 0.994 ns | 0.776 ns | 0.224 ns | 217.76 ns | 220.36 ns | 219.03 ns | 219.61 ns | 219.28 ns |  4,561,314.6 |    1 | 0.0229 |     144 B |
|     EnumIntByToStringLinq |    Array. Int from Enum Linq | 338.92 ns | 1.934 ns | 1.715 ns | 0.458 ns | 335.94 ns | 341.45 ns | 338.23 ns | 340.13 ns | 338.66 ns |  2,950,519.2 |    2 | 0.0687 |     432 B |
|                           |                              |           |          |          |          |           |           |           |           |           |              |      |        |           |
|           EnumGetNameLinq | Array. String from Enum Linq | 458.95 ns | 3.503 ns | 3.277 ns | 0.846 ns | 453.55 ns | 465.22 ns | 456.97 ns | 460.56 ns | 458.91 ns |  2,178,881.3 |    1 | 0.0172 |     112 B |
|          EnumToStringLinq | Array. String from Enum Linq | 469.30 ns | 1.720 ns | 1.525 ns | 0.407 ns | 465.08 ns | 470.95 ns | 468.77 ns | 470.37 ns | 469.76 ns |  2,130,823.2 |    2 | 0.0534 |     336 B |

      EnumUnboxingTesting.IntFromEnumOneCast: Default        -> 1 outlier  was  removed (21.02 ns)

      EnumUnboxingTesting.StringFromEnumOneGetName: Default  -> 1 outlier  was  detected (61.43 ns)
      
      EnumUnboxingTesting.StringFromEnumOneToString: Default -> 2 outliers were removed (65.21 ns, 66.60 ns)

      EnumUnboxingTesting.EnumIntByCast: Default             -> 2 outliers were removed (286.95 ns, 290.97 ns)

      EnumUnboxingTesting.EnumIntByToString: Default         -> 1 outlier  was  removed (427.04 ns)

      EnumUnboxingTesting.EnumGetName: Default               -> 1 outlier  was  removed, 2 outliers were detected (889.33 ns, 903.02 ns)

      EnumUnboxingTesting.EnumIntByCastLinq: Default         -> 3 outliers were removed (223.78 ns..225.51 ns)

      EnumUnboxingTesting.EnumIntByToStringLinq: Default     -> 1 outlier  was  removed (347.06 ns)

      EnumUnboxingTesting.EnumToStringLinq: Default          -> 1 outlier  was  removed, 2 outliers were detected (466.82 ns, 475.21 ns)

## Conclusion :

1. Best way to take enum int value is `((int) @enum).ToString();`.
2. Best way to get enum name is `Enum.GetName(@enum);`
