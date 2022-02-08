``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|               Method |     Mean |   Error |  StdDev |  StdErr |      Min |      Max |       Q1 |       Q3 |   Median |        Op/s | Rank |  Gen 0 | Allocated |
|--------------------- |---------:|--------:|--------:|--------:|---------:|---------:|---------:|---------:|---------:|------------:|-----:|-------:|----------:|
| CombineInterpolation | 133.4 ns | 0.53 ns | 0.50 ns | 0.13 ns | 132.4 ns | 133.9 ns | 133.2 ns | 133.7 ns | 133.4 ns | 7,498,773.1 |    1 | 0.0050 |      32 B |
|        CombineFormat | 198.7 ns | 1.32 ns | 1.10 ns | 0.31 ns | 197.2 ns | 201.0 ns | 197.6 ns | 199.1 ns | 198.8 ns | 5,032,188.9 |    2 | 0.0176 |     112 B |
