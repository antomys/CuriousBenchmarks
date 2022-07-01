# Getting Int or String from Enum using different approaches

### **Note:** All benchmarks chars are available here [Click to proceed to Github folder](assets)

### Table of contents
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
### Getting int value from Enum

| Method      |      Mean |     Error |    StdDev |    StdErr |       Min |        Q1 |    Median |        Q3 |       Max |          Op/s |  Gen 0 | Allocated |
|-------------|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|--------------:|-------:|----------:|
| IntCast     |  2.262 ns | 0.0789 ns | 0.0659 ns | 0.0183 ns |  2.167 ns |  2.224 ns |  2.250 ns |  2.288 ns |  2.419 ns | 442,145,721.5 |      - |         - |
| IntCustom   |  5.448 ns | 0.1165 ns | 0.0973 ns | 0.0270 ns |  5.279 ns |  5.407 ns |  5.484 ns |  5.505 ns |  5.582 ns | 183,551,001.9 |      - |         - |
| IntToString | 14.404 ns | 0.5976 ns | 1.7431 ns | 0.1761 ns | 12.039 ns | 12.774 ns | 14.185 ns | 15.502 ns | 18.667 ns |  69,425,828.0 | 0.0057 |      24 B |

#### MultimodalDistribution
`EnumValueBenchmarks.IntToString`: Default -> It seems that the distribution is bimodal (mValue = 3.52)
![BarPlot](assets/BoxingUnboxing.Benchmarks.Benchmarks.EnumValueBenchmarks-barplot.png)
![BoxPlot](assets/BoxingUnboxing.Benchmarks.Benchmarks.EnumValueBenchmarks-boxplot.png)

<a name="getting-name-of-current-enum"></a>
### Getting Name of current Enum

| Method       |      Mean |     Error |    StdDev |    StdErr |       Min |        Q1 |    Median |        Q3 |       Max |          Op/s |  Gen 0 | Allocated |
|--------------|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|--------------:|-------:|----------:|
| NameCustom   |  2.524 ns | 0.1371 ns | 0.2541 ns | 0.0387 ns |  2.155 ns |  2.336 ns |  2.480 ns |  2.684 ns |  3.154 ns | 396,139,904.2 |      - |         - |
| NameToString | 31.141 ns | 1.2277 ns | 3.5617 ns | 0.3616 ns | 26.017 ns | 28.289 ns | 30.565 ns | 33.086 ns | 40.831 ns |  32,112,087.9 | 0.0057 |      24 B |
| NameGetName  | 32.135 ns | 0.9130 ns | 2.6195 ns | 0.2688 ns | 28.383 ns | 30.145 ns | 31.817 ns | 33.568 ns | 39.307 ns |  31,118,650.2 |      - |         - |

#### MultimodalDistribution
`EnumNameBenchmarks.NameToString`: Default -> It seems that the distribution is multimodal (mValue = 4.48)

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

2. As for int value, best method is casting to int. It is rather cheap : `((int) Enum).ToString();`