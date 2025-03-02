```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
Unknown processor
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                                               |     Mean |    Error |   StdDev |   StdErr |      Min |       Q1 |   Median |       Q3 |      Max |         Op/s | Ratio |   Gen0 | Allocated | Alloc Ratio |
|----------------------------------------------------------------------|---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|-------------:|------:|-------:|----------:|------------:|
| Stopwatch.GetElapsedTime(System.Diagnostics.Stopwatch.GetTimestamp() | 23.61 ns | 0.066 ns | 0.058 ns | 0.016 ns | 23.49 ns | 23.57 ns | 23.61 ns | 23.65 ns | 23.71 ns | 42,356,265.5 |  0.88 |      - |         - |        0.00 |
| Stopwatch.StartNew().Elapsed                                         | 26.78 ns | 0.113 ns | 0.106 ns | 0.027 ns | 26.52 ns | 26.73 ns | 26.75 ns | 26.86 ns | 26.96 ns | 37,343,337.0 |  1.00 | 0.0032 |      40 B |        1.00 |
