# Getting name or value from Enum

## Table of contents
- [Machine information](#machine-information)
- [Benchmark results](#benchmark-results)
  * [Getting int value from Enum](#getting-int-value-from-enum)
  * [Getting Name of current Enum](#getting-name-of-current-enum)
- [Conclusions](#conclusions)

<a name="machine-info"></a>
## Machine Information

``` ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22621
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
```

<a name="benchmark-results"></a>
## Benchmark results

<a name="getting-int-value-from-enum"></a>
### Getting int value as string from Enum

| Method                 |      Mean |     Error |   StdDev |    StdErr |    Median |       Min |        Q1 |        Q3 |       Max |          Op/s |  Gen 0 | Allocated |
|------------------------|----------:|----------:|---------:|----------:|----------:|----------:|----------:|----------:|----------:|--------------:|-------:|----------:|
| IntCastToString        |  3.109 ns | 0.4105 ns | 1.151 ns | 0.1207 ns |  2.578 ns |  2.031 ns |  2.305 ns |  3.471 ns |  6.724 ns | 321,657,559.0 |      - |         - |
| ExternalMethodToString |  9.699 ns | 1.4750 ns | 4.303 ns | 0.4346 ns | 10.220 ns |  4.245 ns |  4.894 ns | 11.820 ns | 21.797 ns | 103,101,658.8 |      - |         - |
| ToStringFormatD        | 37.376 ns | 3.2854 ns | 9.213 ns | 0.9657 ns | 35.766 ns | 19.015 ns | 32.075 ns | 41.859 ns | 62.580 ns |  26,754,935.7 | 0.0057 |      24 B |
#### MultimodalDistribution
`EnumValueBenchmarks.ExternalMethodToString:` Default -> It seems that the distribution is multimodal (mValue = 4.22)

![BarPlot](assets/BoxingUnboxing.Benchmarks.Benchmarks.EnumValueBenchmarks-barplot.png)
![BoxPlot](assets/BoxingUnboxing.Benchmarks.Benchmarks.EnumValueBenchmarks-boxplot.png)


<a name="getting-name-of-current-enum"></a>
### Getting Name of current Enum

| Method          |      Mean |     Error |     StdDev |    StdErr |       Min |        Q1 |    Median |        Q3 |        Max |          Op/s |  Gen 0 | Allocated |
|-----------------|----------:|----------:|-----------:|----------:|----------:|----------:|----------:|----------:|-----------:|--------------:|-------:|----------:|
| CustomGetName   |  3.434 ns | 0.1860 ns |  0.2352 ns | 0.0490 ns |  3.134 ns |  3.228 ns |  3.445 ns |  3.569 ns |   3.988 ns | 291,230,187.1 |      - |         - |
| DefaultToString | 56.549 ns | 5.5221 ns | 15.8439 ns | 1.6256 ns | 31.282 ns | 49.889 ns | 52.423 ns | 60.615 ns |  93.776 ns |  17,683,834.4 | 0.0057 |      24 B |
| EnumGetName     | 60.710 ns | 6.2515 ns | 17.7345 ns | 1.8390 ns | 32.548 ns | 46.578 ns | 58.854 ns | 69.813 ns | 107.503 ns |  16,471,725.6 |      - |         - |

#### MultimodalDistribution
`EnumNameBenchmarks.EnumGetName:` Default -> It seems that the distribution is bimodal (mValue = 3.45)

![BarPlot](assets/BoxingUnboxing.Benchmarks.Benchmarks.EnumNameBenchmarks-barplot.png)
![BoxPlot](assets/BoxingUnboxing.Benchmarks.Benchmarks.EnumNameBenchmarks-boxplot.png)

<a name="conclusions"></a>
## Conclusions

1. The best method to get name of Enum is custom method:

```cs
internal static string GetName(TestEnum testEnum) 
  => testEnum switch
  {
      TestEnum.First => nameof(TestEnum.First),
      TestEnum.Second => nameof(TestEnum.Second),
      TestEnum.Third => nameof(TestEnum.Third),
      TestEnum.Fourth => nameof(TestEnum.Fourth),
      TestEnum.Fifth => nameof(TestEnum.Fifth),
      TestEnum.Sixth => nameof(TestEnum.Sixth),
      TestEnum.Seventh => nameof(TestEnum.Seventh),
      TestEnum.Eighth => nameof(TestEnum.Eighth),
      TestEnum.Ninth => nameof(TestEnum.Ninth),
      TestEnum.Tenth => nameof(TestEnum.Tenth),
      TestEnum.Eleventh => nameof(TestEnum.Eleventh),
      TestEnum.Twelfth => nameof(TestEnum.Twelfth),
      TestEnum.Zero => nameof(TestEnum.Zero),
      _ => throw new ArgumentOutOfRangeException(nameof(testEnum), testEnum, message: default)
  };
```

The problem is that common method `Enum.GetName` inside uses binary search for some reason. This approach eliminated extensive code and makes it straightforward.

2. As for int value, best method is casting to int. It is rather cheap : `((int) Enum).ToString();`.