```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
Unknown processor
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2

```

| Method                           |     Mean |   Error |  StdDev |  StdErr |      Min |       Q1 |   Median |       Q3 |      Max |        Op/s | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------------------------|---------:|--------:|--------:|--------:|---------:|---------:|---------:|---------:|---------:|------------:|------:|--------:|-------:|----------:|------------:|
| &#39;ToFlat direct model&#39;    | 151.8 ns | 0.81 ns | 0.76 ns | 0.20 ns | 150.5 ns | 151.4 ns | 151.8 ns | 152.2 ns | 153.1 ns | 6,587,404.6 |  1.00 |    0.01 | 0.0408 |     512 B |        1.00 |
| &#39;ToFlat with reflection&#39; | 326.8 ns | 2.16 ns | 2.02 ns | 0.52 ns | 322.4 ns | 325.5 ns | 327.1 ns | 328.0 ns | 330.5 ns | 3,059,850.7 |  2.15 |    0.02 | 0.0668 |     840 B |        1.64 |
