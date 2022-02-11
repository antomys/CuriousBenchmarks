``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                        Method |   Count |                Mean |            Error |           StdDev |         StdErr |              Median |                 Min |                 Max |                  Q1 |                  Q3 |            Op/s | Ratio | RatioSD | Rank |       Gen 0 |  Gen 1 |     Allocated |
|------------------------------ |-------- |--------------------:|-----------------:|-----------------:|---------------:|--------------------:|--------------------:|--------------------:|--------------------:|--------------------:|----------------:|------:|--------:|-----:|------------:|-------:|--------------:|
|           ConcatStringBuilder |      10 |            15.06 ns |         0.044 ns |         0.041 ns |       0.011 ns |            15.06 ns |            14.99 ns |            15.13 ns |            15.04 ns |            15.09 ns | 66,395,697.3771 |     ? |       ? |    1 |      0.0051 |      - |          32 B |
|                    ConcatSpan |      10 |            30.36 ns |         0.059 ns |         0.056 ns |       0.014 ns |            30.36 ns |            30.28 ns |            30.47 ns |            30.32 ns |            30.40 ns | 32,937,669.9019 |     ? |       ? |    2 |      0.0446 |      - |         280 B |
|                  ConcatString |      10 |           213.21 ns |         4.294 ns |         9.244 ns |       1.235 ns |           209.35 ns |           204.80 ns |           241.05 ns |           206.01 ns |           219.26 ns |  4,690,183.8180 |     ? |       ? |    3 |      0.0203 |      - |         128 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
| GenerateLinkFormatNewNoLength |      10 |         1,671.21 ns |         5.830 ns |         4.552 ns |       1.314 ns |         1,671.08 ns |         1,663.90 ns |         1,680.79 ns |         1,669.58 ns |         1,672.61 ns |    598,367.9399 |  0.17 |    0.00 |    1 |      0.5856 |      - |       3,680 B |
|         GenerateLinkFormatOld |      10 |         9,916.47 ns |        16.903 ns |        14.984 ns |       4.005 ns |         9,917.31 ns |         9,886.36 ns |         9,937.28 ns |         9,905.30 ns |         9,929.53 ns |    100,842.3093 |  1.00 |    0.00 |    2 |      1.0529 |      - |       6,648 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
|      GenerateDashFormatNative |      10 |           559.18 ns |         1.712 ns |         1.518 ns |       0.406 ns |           559.19 ns |           556.40 ns |           561.84 ns |           558.73 ns |           560.35 ns |  1,788,341.2409 |     ? |       ? |    1 |      0.3557 |      - |       2,232 B |
| GenerateDashFormatV2TwoValues |      10 |           572.04 ns |         1.559 ns |         1.458 ns |       0.376 ns |           572.44 ns |           569.74 ns |           574.86 ns |           571.02 ns |           572.89 ns |  1,748,142.7503 |     ? |       ? |    2 |      0.4101 |      - |       2,576 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
|           ConcatStringBuilder |     100 |            26.79 ns |         0.517 ns |         0.932 ns |       0.146 ns |            26.45 ns |            25.31 ns |            28.93 ns |            26.29 ns |            26.71 ns | 37,332,228.0209 |     ? |       ? |    1 |      0.0370 |      - |         232 B |
|                    ConcatSpan |     100 |            34.25 ns |         0.088 ns |         0.078 ns |       0.021 ns |            34.23 ns |            34.11 ns |            34.41 ns |            34.19 ns |            34.30 ns | 29,200,874.3557 |     ? |       ? |    2 |      0.0573 | 0.0001 |         360 B |
|                  ConcatString |     100 |           657.49 ns |         1.328 ns |         1.242 ns |       0.321 ns |           657.09 ns |           655.71 ns |           659.88 ns |           656.81 ns |           658.06 ns |  1,520,936.8536 |     ? |       ? |    3 |      0.0505 |      - |         320 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
| GenerateLinkFormatNewNoLength |     100 |        18,072.79 ns |        53.851 ns |        44.968 ns |      12.472 ns |        18,079.05 ns |        18,018.19 ns |        18,143.80 ns |        18,036.28 ns |        18,112.31 ns |     55,331.8001 |  0.17 |    0.01 |    1 |      6.2866 |      - |      39,552 B |
|         GenerateLinkFormatOld |     100 |       106,685.46 ns |     2,109.369 ns |     3,345.683 ns |     582.409 ns |       105,205.11 ns |       102,455.79 ns |       116,005.44 ns |       104,870.60 ns |       107,653.92 ns |      9,373.3487 |  1.00 |    0.00 |    2 |     10.3760 |      - |      65,641 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
|      GenerateDashFormatNative |     100 |         5,290.88 ns |        17.183 ns |        15.233 ns |       4.071 ns |         5,291.55 ns |         5,262.46 ns |         5,322.54 ns |         5,283.85 ns |         5,293.76 ns |    189,004.4691 |     ? |       ? |    1 |      3.4943 |      - |      21,960 B |
| GenerateDashFormatV2TwoValues |     100 |         5,460.50 ns |        10.667 ns |         9.456 ns |       2.527 ns |         5,461.47 ns |         5,442.17 ns |         5,475.65 ns |         5,456.29 ns |         5,467.28 ns |    183,133.4288 |     ? |       ? |    2 |      3.8223 |      - |      24,016 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
|                    ConcatSpan |    1000 |            16.61 ns |         0.314 ns |         0.294 ns |       0.076 ns |            16.65 ns |            16.05 ns |            17.00 ns |            16.54 ns |            16.77 ns | 60,220,255.6550 |     ? |       ? |    1 |      0.0127 |      - |          80 B |
|           ConcatStringBuilder |    1000 |            23.48 ns |         0.082 ns |         0.069 ns |       0.019 ns |            23.45 ns |            23.39 ns |            23.60 ns |            23.43 ns |            23.50 ns | 42,597,403.9238 |     ? |       ? |    2 |      0.0306 |      - |         192 B |
|                  ConcatString |    1000 |           605.01 ns |         1.201 ns |         1.065 ns |       0.285 ns |           604.63 ns |           603.63 ns |           607.45 ns |           604.39 ns |           605.39 ns |  1,652,867.2895 |     ? |       ? |    3 |      0.0467 |      - |         296 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
| GenerateLinkFormatNewNoLength |    1000 |       198,206.56 ns |     1,834.563 ns |     1,716.051 ns |     443.082 ns |       197,684.33 ns |       195,927.13 ns |       201,377.64 ns |       197,080.12 ns |       199,175.35 ns |      5,045.2417 |  0.19 |    0.00 |    1 |     67.1387 |      - |     421,176 B |
|         GenerateLinkFormatOld |    1000 |     1,026,732.18 ns |     6,321.784 ns |     5,278.976 ns |   1,464.124 ns |     1,026,247.24 ns |     1,017,581.40 ns |     1,034,529.49 ns |     1,023,312.89 ns |     1,030,931.27 ns |        973.9638 |  1.00 |    0.00 |    2 |    109.3750 |      - |     693,648 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
| GenerateDashFormatV2TwoValues |    1000 |        62,171.55 ns |       339.618 ns |       301.063 ns |      80.462 ns |        62,203.28 ns |        61,551.62 ns |        62,554.38 ns |        62,072.80 ns |        62,397.07 ns |     16,084.5278 |     ? |       ? |    1 |     36.9873 |      - |     232,344 B |
|      GenerateDashFormatNative |    1000 |        62,604.31 ns |     1,027.008 ns |       801.820 ns |     231.465 ns |        62,510.06 ns |        61,300.86 ns |        63,873.58 ns |        62,289.42 ns |        63,140.41 ns |     15,973.3402 |     ? |       ? |    1 |     37.3535 |      - |     234,776 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
|                    ConcatSpan |   10000 |            18.52 ns |         0.033 ns |         0.028 ns |       0.008 ns |            18.52 ns |            18.48 ns |            18.58 ns |            18.49 ns |            18.54 ns | 53,995,859.7688 |     ? |       ? |    1 |      0.0140 |      - |          88 B |
|           ConcatStringBuilder |   10000 |            19.17 ns |         0.110 ns |         0.103 ns |       0.027 ns |            19.15 ns |            19.02 ns |            19.35 ns |            19.11 ns |            19.24 ns | 52,161,208.7393 |     ? |       ? |    2 |      0.0229 |      - |         144 B |
|                  ConcatString |   10000 |           425.01 ns |         8.273 ns |         9.849 ns |       2.149 ns |           427.99 ns |           395.06 ns |           432.81 ns |           427.09 ns |           428.39 ns |  2,352,889.5709 |     ? |       ? |    3 |      0.0343 |      - |         216 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
| GenerateLinkFormatNewNoLength |   10000 |     2,272,432.46 ns |     3,437.442 ns |     2,870.420 ns |     796.111 ns |     2,272,678.88 ns |     2,267,767.27 ns |     2,278,275.91 ns |     2,270,810.54 ns |     2,274,120.13 ns |        440.0571 |  0.21 |    0.00 |    1 |    675.7813 |      - |   4,250,867 B |
|         GenerateLinkFormatOld |   10000 |    10,848,773.73 ns |    28,179.304 ns |    24,980.219 ns |   6,676.244 ns |    10,850,836.87 ns |    10,793,808.01 ns |    10,883,075.09 ns |    10,839,842.49 ns |    10,865,873.13 ns |         92.1763 |  1.00 |    0.00 |    2 |   1078.1250 |      - |   6,828,180 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
|      GenerateDashFormatNative |   10000 |       755,226.36 ns |     1,686.519 ns |     1,408.320 ns |     390.598 ns |       754,697.44 ns |       753,611.33 ns |       758,717.75 ns |       754,257.30 ns |       755,589.26 ns |      1,324.1063 |     ? |       ? |    1 |    368.1641 |      - |   2,309,697 B |
| GenerateDashFormatV2TwoValues |   10000 |       756,585.92 ns |     1,309.210 ns |     1,160.580 ns |     310.178 ns |       756,513.75 ns |       754,922.35 ns |       759,485.43 ns |       755,748.87 ns |       757,222.50 ns |      1,321.7270 |     ? |       ? |    1 |    369.1406 |      - |   2,317,017 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
|                    ConcatSpan |  100000 |            20.12 ns |         0.049 ns |         0.041 ns |       0.011 ns |            20.13 ns |            20.06 ns |            20.20 ns |            20.09 ns |            20.14 ns | 49,693,933.2885 |     ? |       ? |    1 |      0.0179 |      - |         112 B |
|           ConcatStringBuilder |  100000 |            21.05 ns |         0.099 ns |         0.088 ns |       0.023 ns |            21.05 ns |            20.89 ns |            21.20 ns |            21.01 ns |            21.09 ns | 47,513,551.8935 |     ? |       ? |    2 |      0.0268 |      - |         168 B |
|                  ConcatString |  100000 |           594.67 ns |        11.760 ns |        19.649 ns |       3.275 ns |           590.07 ns |           561.53 ns |           652.16 ns |           579.85 ns |           609.47 ns |  1,681,615.9261 |     ? |       ? |    3 |      0.0439 |      - |         280 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
| GenerateLinkFormatNewNoLength |  100000 |    23,211,923.71 ns |   441,307.093 ns |   412,798.929 ns | 106,584.225 ns |    23,053,754.91 ns |    22,758,978.38 ns |    24,144,907.62 ns |    22,930,031.16 ns |    23,425,835.53 ns |         43.0813 |  0.21 |    0.00 |    1 |   6718.7500 |      - |  42,267,995 B |
|         GenerateLinkFormatOld |  100000 |   109,914,303.39 ns |   538,790.136 ns |   477,623.422 ns | 127,650.229 ns |   110,003,880.80 ns |   109,142,140.00 ns |   110,725,472.40 ns |   109,487,671.20 ns |   110,266,624.30 ns |          9.0980 |  1.00 |    0.00 |    2 |  10800.0000 |      - |  68,167,378 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
| GenerateDashFormatV2TwoValues |  100000 |     8,600,455.69 ns |    43,324.294 ns |    33,824.759 ns |   9,764.367 ns |     8,604,197.97 ns |     8,550,292.12 ns |     8,644,766.34 ns |     8,574,735.16 ns |     8,626,532.66 ns |        116.2729 |     ? |       ? |    1 |   3671.8750 |      - |  23,109,957 B |
|      GenerateDashFormatNative |  100000 |     8,609,400.70 ns |    45,993.639 ns |    43,022.478 ns |  11,108.356 ns |     8,604,360.75 ns |     8,553,208.95 ns |     8,716,270.45 ns |     8,569,834.46 ns |     8,629,365.02 ns |        116.1521 |     ? |       ? |    1 |   3687.5000 |      - |  23,144,309 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
|           ConcatStringBuilder | 1000000 |            20.34 ns |         0.188 ns |         0.175 ns |       0.045 ns |            20.25 ns |            20.18 ns |            20.73 ns |            20.21 ns |            20.51 ns | 49,153,992.3064 |     ? |       ? |    1 |      0.0217 |      - |         136 B |
|                    ConcatSpan | 1000000 |            31.32 ns |         0.581 ns |         0.571 ns |       0.143 ns |            31.26 ns |            30.37 ns |            32.69 ns |            31.00 ns |            31.40 ns | 31,929,573.3537 |     ? |       ? |    2 |      0.0471 |      - |         296 B |
|                  ConcatString | 1000000 |           309.45 ns |         0.518 ns |         0.404 ns |       0.117 ns |           309.44 ns |           308.61 ns |           310.28 ns |           309.27 ns |           309.68 ns |  3,231,528.5206 |     ? |       ? |    3 |      0.0048 |      - |          32 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
| GenerateLinkFormatNewNoLength | 1000000 |   228,917,945.39 ns | 2,288,201.467 ns | 1,786,477.194 ns | 515,711.544 ns |   228,212,319.67 ns |   227,769,410.33 ns |   234,168,908.33 ns |   228,036,629.92 ns |   228,924,093.83 ns |          4.3684 |  0.21 |    0.00 |    1 |  67333.3333 |      - | 423,110,336 B |
|         GenerateLinkFormatOld | 1000000 | 1,095,001,014.69 ns | 2,005,465.625 ns | 1,674,654.625 ns | 464,465.625 ns | 1,094,501,397.00 ns | 1,092,380,568.00 ns | 1,097,533,287.00 ns | 1,093,997,725.00 ns | 1,096,941,331.00 ns |          0.9132 |  1.00 |    0.00 |    2 | 108000.0000 |      - | 680,801,768 B |
|                               |         |                     |                  |                  |                |                     |                     |                     |                     |                     |                 |       |         |      |             |        |               |
|      GenerateDashFormatNative | 1000000 |    86,375,908.50 ns |   411,223.462 ns |   343,390.215 ns |  95,239.310 ns |    86,434,179.17 ns |    85,770,992.17 ns |    86,892,956.33 ns |    86,204,237.50 ns |    86,586,289.50 ns |         11.5773 |     ? |       ? |    1 |  36666.6667 |      - | 231,030,081 B |
| GenerateDashFormatV2TwoValues | 1000000 |    88,109,889.42 ns | 1,646,765.945 ns | 1,375,124.146 ns | 381,390.817 ns |    88,499,973.83 ns |    86,210,314.83 ns |    90,795,363.17 ns |    86,587,324.83 ns |    88,886,914.50 ns |         11.3495 |     ? |       ? |    1 |  36666.6667 |      - | 231,001,880 B |

**Warnings**

    Summary -> A question mark '?' symbol indicates that it was not possible to compute the (Ratio, RatioSD) column(s) because the baseline value is too close to zero.


|               Method |     Mean |   Error |  StdDev |  StdErr |      Min |      Max |       Q1 |       Q3 |   Median |        Op/s | Rank |  Gen 0 | Allocated |
|--------------------- |---------:|--------:|--------:|--------:|---------:|---------:|---------:|---------:|---------:|------------:|-----:|-------:|----------:|
| CombineInterpolation | 142.2 ns | 0.22 ns | 0.20 ns | 0.05 ns | 141.7 ns | 142.5 ns | 142.1 ns | 142.3 ns | 142.2 ns | 7,032,873.2 |    1 | 0.0050 |      32 B |
|        CombineFormat | 216.7 ns | 2.71 ns | 2.66 ns | 0.66 ns | 209.5 ns | 220.7 ns | 215.9 ns | 218.3 ns | 216.3 ns | 4,615,683.5 |    2 | 0.0176 |     112 B |

## * Hints *
Outliers
StringExtensionsTests.ConcatString: Default                  -> 5 outliers were removed (256.08 ns..405.92 ns)

StringExtensionsTests.GenerateLinkFormatNewNoLength: Default -> 3 outliers were removed (1.73 us..1.76 us)

StringExtensionsTests.GenerateLinkFormatOld: Default         -> 1 outlier  was  removed (9.98 us)

StringExtensionsTests.GenerateDashFormatNative: Default      -> 1 outlier  was  removed (565.22 ns)

StringExtensionsTests.ConcatStringBuilder: Default           -> 8 outliers were removed (35.13 ns..49.38 ns)

StringExtensionsTests.ConcatSpan: Default                    -> 1 outlier  was  removed (38.24 ns)

StringExtensionsTests.GenerateLinkFormatNewNoLength: Default -> 2 outliers were removed (18.27 us, 18.38 us)

StringExtensionsTests.GenerateLinkFormatOld: Default         -> 4 outliers were removed (119.59 us..129.02 us)

StringExtensionsTests.GenerateDashFormatNative: Default      -> 1 outlier  was  removed (5.33 us)

StringExtensionsTests.GenerateDashFormatV2TwoValues: Default -> 1 outlier  was  removed (5.50 us)

StringExtensionsTests.ConcatSpan: Default                    -> 3 outliers were detected (19.81 ns..19.95 ns)

StringExtensionsTests.ConcatStringBuilder: Default           -> 2 outliers were removed (31.49 ns, 34.21 ns)

StringExtensionsTests.ConcatString: Default                  -> 1 outlier  was  removed (610.79 ns)

StringExtensionsTests.GenerateLinkFormatOld: Default         -> 2 outliers were removed (1.05 ms, 1.05 ms)

StringExtensionsTests.GenerateDashFormatV2TwoValues: Default -> 1 outlier  was  removed, 3 outliers were detected (61.55 us, 61.61 us, 62.88 us)

StringExtensionsTests.GenerateDashFormatNative: Default      -> 3 outliers were removed (65.64 us..67.03 us)

StringExtensionsTests.ConcatSpan: Default                    -> 2 outliers were removed (22.30 ns, 22.32 ns)

StringExtensionsTests.ConcatString: Default                  -> 4 outliers were removed, 6 outliers were detected (396.79 ns, 398.22 ns, 435.83 ns..484.31 ns)

StringExtensionsTests.GenerateLinkFormatNewNoLength: Default -> 2 outliers were removed (2.28 ms, 2.29 ms)

StringExtensionsTests.GenerateLinkFormatOld: Default         -> 1 outlier  was  removed, 2 outliers were detected (10.79 ms, 10.98 ms)

StringExtensionsTests.GenerateDashFormatNative: Default      -> 2 outliers were removed (761.08 us, 761.19 us)

StringExtensionsTests.GenerateDashFormatV2TwoValues: Default -> 1 outlier  was  removed (765.02 us)

StringExtensionsTests.ConcatSpan: Default                    -> 2 outliers were removed (24.15 ns, 24.25 ns)

StringExtensionsTests.ConcatStringBuilder: Default           -> 1 outlier  was  removed (26.00 ns)

StringExtensionsTests.ConcatString: Default                  -> 1 outlier  was  removed (757.77 ns)

StringExtensionsTests.GenerateLinkFormatNewNoLength: Default -> 2 outliers were removed (24.90 ms, 25.10 ms)

StringExtensionsTests.GenerateLinkFormatOld: Default         -> 1 outlier  was  removed (112.67 ms)

StringExtensionsTests.GenerateDashFormatV2TwoValues: Default -> 3 outliers were removed (9.81 ms..10.60 ms)

StringExtensionsTests.ConcatSpan: Default                    -> 3 outliers were removed (38.35 ns..50.51 ns)

StringExtensionsTests.ConcatString: Default                  -> 3 outliers were removed (313.82 ns..314.68 ns)

StringExtensionsTests.GenerateLinkFormatNewNoLength: Default -> 3 outliers were removed (238.29 ms..249.84 ms)

StringExtensionsTests.GenerateLinkFormatOld: Default         -> 2 outliers were removed (1.18 s, 1.21 s)

StringExtensionsTests.GenerateDashFormatNative: Default      -> 2 outliers were removed (87.86 ms, 88.07 ms)

StringExtensionsTests.GenerateDashFormatV2TwoValues: Default -> 2 outliers were removed (94.19 ms, 99.00 ms)
