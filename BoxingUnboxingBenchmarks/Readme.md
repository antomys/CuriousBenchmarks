``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.3.1 (21E258) [Darwin 21.4.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
```
|                 Method |                   Categories |         Mean |      Error |      StdDev |     StdErr |       Median |         Min |          Max |         Q1 |           Q3 |          Op/s | Rank |  Gen 0 | Allocated |
|----------------------- |----------------------------- |-------------:|-----------:|------------:|-----------:|-------------:|------------:|-------------:|-----------:|-------------:|--------------:|-----:|-------:|----------:|
|        IntFromEnumCast |                Int from Enum |     1.973 ns |  0.2501 ns |   0.7376 ns |  0.0738 ns |     1.884 ns |   0.6346 ns |     4.233 ns |   1.326 ns |     2.573 ns | 506,773,772.4 |    1 |      - |         - |
|      IntFromEnumCustom |                Int from Enum |     5.525 ns |  0.3708 ns |   1.0933 ns |  0.1093 ns |     5.039 ns |   4.3345 ns |     8.555 ns |   4.552 ns |     6.266 ns | 180,987,797.9 |    2 |      - |         - |
|    IntFromEnumToString |                Int from Enum |    17.732 ns |  1.6539 ns |   4.8764 ns |  0.4876 ns |    19.035 ns |  10.3497 ns |    30.583 ns |  13.348 ns |    22.187 ns |  56,395,582.9 |    3 | 0.0038 |      24 B |
|                        |                              |              |            |             |            |              |             |              |            |              |               |      |        |           |
|   StringFromEnumCustom |             String from Enum |     1.467 ns |  0.0121 ns |   0.0101 ns |  0.0028 ns |     1.466 ns |   1.4541 ns |     1.484 ns |   1.458 ns |     1.475 ns | 681,886,079.2 |    1 |      - |         - |
|  StringFromEnumGetName |             String from Enum |    30.323 ns |  1.2475 ns |   3.6390 ns |  0.3676 ns |    28.915 ns |  26.2859 ns |    38.962 ns |  27.073 ns |    33.133 ns |  32,978,808.0 |    2 |      - |         - |
| StringFromEnumToString |             String from Enum |    33.196 ns |  1.4808 ns |   4.2725 ns |  0.4361 ns |    31.993 ns |  27.9248 ns |    44.303 ns |  29.728 ns |    35.366 ns |  30,124,261.9 |    3 | 0.0038 |      24 B |
|                        |                              |              |            |             |            |              |             |              |            |              |               |      |        |           |
|          EnumIntByCast |         Array. Int from Enum |   429.207 ns | 27.1434 ns |  80.0329 ns |  8.0033 ns |   417.310 ns | 293.7375 ns |   596.206 ns | 381.496 ns |   486.899 ns |   2,329,880.8 |    1 | 0.0763 |     480 B |
|        EnumIntToString |         Array. Int from Enum |   590.858 ns | 45.2798 ns | 133.5084 ns | 13.3508 ns |   576.639 ns | 418.3520 ns |   900.248 ns | 452.072 ns |   693.994 ns |   1,692,453.6 |    2 | 0.1221 |     768 B |
|          EnumIntCustom |         Array. Int from Enum |   600.762 ns | 35.6612 ns | 105.1478 ns | 10.5148 ns |   593.882 ns | 408.6111 ns |   826.525 ns | 532.086 ns |   685.749 ns |   1,664,552.6 |    2 | 0.0763 |     480 B |
|                        |                              |              |            |             |            |              |             |              |            |              |               |      |        |           |
|      EnumGetNameCustom |      Array. String from Enum |   779.670 ns | 39.0506 ns | 115.1416 ns | 11.5142 ns |   773.206 ns | 616.3060 ns | 1,011.532 ns | 694.233 ns |   870.682 ns |   1,282,594.3 |    1 | 0.0610 |     384 B |
|            EnumGetName |      Array. String from Enum |   955.437 ns | 17.6397 ns |  40.1745 ns |  5.1022 ns |   947.873 ns | 899.0619 ns | 1,070.460 ns | 944.502 ns |   952.489 ns |   1,046,642.0 |    2 | 0.0610 |     384 B |
|           EnumToString |      Array. String from Enum | 1,155.236 ns | 65.6207 ns | 192.4543 ns | 19.3424 ns | 1,168.553 ns | 867.1521 ns | 1,676.306 ns | 988.062 ns | 1,289.513 ns |     865,624.2 |    3 | 0.1068 |     672 B |
|                        |                              |              |            |             |            |              |             |              |            |              |               |      |        |           |
|      EnumIntByCastLinq |    Array. Int from Enum Linq |   314.232 ns | 13.6487 ns |  40.2436 ns |  4.0244 ns |   318.980 ns | 226.9130 ns |   393.494 ns | 281.953 ns |   344.324 ns |   3,182,365.8 |    1 | 0.0229 |     144 B |
|      EnumIntCustomLinq |    Array. Int from Enum Linq |   386.977 ns | 18.1798 ns |  53.6036 ns |  5.3604 ns |   383.890 ns | 308.1042 ns |   536.929 ns | 336.282 ns |   418.265 ns |   2,584,132.4 |    2 | 0.0229 |     144 B |
|  EnumIntByToStringLinq |    Array. Int from Enum Linq |   506.291 ns | 29.7018 ns |  87.5764 ns |  8.7576 ns |   509.609 ns | 352.8238 ns |   698.610 ns | 429.774 ns |   582.120 ns |   1,975,147.9 |    3 | 0.0687 |     432 B |
|                        |                              |              |            |             |            |              |             |              |            |              |               |      |        |           |
|  EnumGetNameCustomLinq | Array. String from Enum Linq |   180.077 ns |  2.3514 ns |   2.1995 ns |  0.5679 ns |   180.792 ns | 176.5887 ns |   183.998 ns | 178.261 ns |   181.656 ns |   5,553,172.6 |    1 | 0.0076 |      48 B |
|        EnumGetNameLinq | Array. String from Enum Linq |   508.993 ns | 17.9028 ns |  52.5058 ns |  5.2770 ns |   519.299 ns | 442.1033 ns |   652.640 ns | 453.111 ns |   531.461 ns |   1,964,664.4 |    2 | 0.0076 |      48 B |
|       EnumToStringLinq | Array. String from Enum Linq |   627.214 ns | 17.0133 ns |  48.5399 ns |  5.0065 ns |   628.417 ns | 515.3867 ns |   719.980 ns | 612.197 ns |   654.627 ns |   1,594,350.9 |    3 | 0.0534 |     336 B |
