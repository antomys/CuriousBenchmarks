# Getting name or value of Enum

## Table of contents

- [Machine information](#machine-information)
- [Benchmark results](#benchmark-results)
    * [Getting integer value from Enum](#getting-integer-value-from-enum)
    * [Getting Name of current Enum](#getting-name-of-current-enum)
- [Conclusions](#conclusions)

<a name="machine-info"></a>

## Machine Information

``` ini
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
13th Gen Intel Core i9-13905H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
```

<a name="benchmark-results"></a>

## Benchmark results

<a name="getting-integer-value-from-enum"></a>

### Getting integer value as string from Enum

| Method                            |     Mean |     Error |    StdDev |    StdErr |      Min |       Q1 |   Median |       Q3 |      Max |          Op/s |   Gen0 | Allocated |
|-----------------------------------|---------:|----------:|----------:|----------:|---------:|---------:|---------:|---------:|---------:|--------------:|-------:|----------:|
| ((int) TestEnum.First).ToString() | 2.055 ns | 0.0851 ns | 0.1046 ns | 0.0223 ns | 1.905 ns | 1.976 ns | 2.029 ns | 2.168 ns | 2.210 ns | 486,724,516.9 |      - |         - |
| ExternalMethodToString            | 2.515 ns | 0.0356 ns | 0.0297 ns | 0.0082 ns | 2.443 ns | 2.503 ns | 2.517 ns | 2.523 ns | 2.563 ns | 397,653,335.7 |      - |         - |
| ToString.("D")                    | 7.829 ns | 0.1070 ns | 0.0894 ns | 0.0248 ns | 7.634 ns | 7.799 ns | 7.844 ns | 7.886 ns | 7.963 ns | 127,735,703.1 | 0.0019 |      24 B |

![Plot](assets/EnumValueBenchmarks.png)

<a name="getting-name-of-current-enum"></a>

### Getting Name of current Enum

| Method         |      Mean |     Error |    StdDev |    StdErr |       Min |        Q1 |    Median |        Q3 |       Max |            Op/s |   Gen0 | Allocated |
|----------------|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------------:|-------:|----------:|
| CustomGetName  | 0.9441 ns | 0.0147 ns | 0.0130 ns | 0.0035 ns | 0.9167 ns | 0.9359 ns | 0.9436 ns | 0.9521 ns | 0.9675 ns | 1,059,194,095.7 |      - |         - |
| Enum.GetName() | 3.8159 ns | 0.0430 ns | 0.0402 ns | 0.0104 ns | 3.7122 ns | 3.7934 ns | 3.8234 ns | 3.8471 ns | 3.8652 ns |   262,062,177.2 |      - |         - |
| .ToString()    | 7.9074 ns | 0.1945 ns | 0.1724 ns | 0.0461 ns | 7.5675 ns | 7.7672 ns | 7.9369 ns | 8.0154 ns | 8.2302 ns |   126,464,033.8 | 0.0019 |      24 B |

#### MultimodalDistribution

`EnumNameBenchmarks.EnumGetName:` Default -> It seems that the distribution is bimodal (mValue = 3.45)

![Plot](assets/EnumNameBenchmarks.png)

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

The problem is that common method `Enum.GetName` inside uses binary search for some reason. This approach eliminated
extensive code and makes it straightforward.

2. As for int value, best method is casting to int. It is rather cheap : `((int) TestEnum.First).ToString();`.