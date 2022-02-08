##  Summary 

- OS=Windows 10.0.19044.1415 (21H2)
- Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
- .NET SDK=6.0.101

## Serialization
|                           Method | Categories | CollectionSize |           Mean |        Error |       StdDev |      StdErr |         Median |            Min |            Max |             Q1 |             Q3 |       Op/s | Ratio | RatioSD | Rank |       Gen 0 |      Gen 1 |     Gen 2 |    Allocated |
|--------------------------------- |----------- |--------------- |---------------:|-------------:|-------------:|------------:|---------------:|---------------:|---------------:|---------------:|---------------:|-----------:|------:|--------:|-----:|------------:|-----------:|----------:|-------------:|
|          MsgPackStreamSerializer |     Stream |           1000 |       362.6 μs |      3.28 μs |      2.91 μs |     0.78 μs |       362.0 μs |       358.7 μs |       369.2 μs |       360.5 μs |       363.6 μs | 2,757.9365 |  0.41 |    0.01 |    1 |     45.4102 |    45.4102 |   45.4102 |       256 KB |
|             Utf8StreamSerializer |     Stream |           1000 |       613.3 μs |      6.67 μs |      6.24 μs |     1.61 μs |       612.9 μs |       604.4 μs |       626.7 μs |       608.2 μs |       616.0 μs | 1,630.6407 |  0.70 |    0.02 |    2 |    166.0156 |   166.0156 |  166.0156 |       517 KB |
|              GeneratedSerializer |     Stream |           1000 |       666.0 μs |     13.29 μs |     21.84 μs |     3.69 μs |       675.0 μs |       611.3 μs |       683.1 μs |       669.5 μs |       677.5 μs | 1,501.5128 |  0.77 |    0.04 |    3 |    166.0156 |   166.0156 |  166.0156 |       641 KB |
|                ClassicSerializer |     Stream |           1000 |       866.7 μs |     16.80 μs |     34.70 μs |     4.81 μs |       866.7 μs |       781.4 μs |       941.5 μs |       855.2 μs |       885.2 μs | 1,153.8162 |  1.00 |    0.00 |    4 |    166.0156 |   166.0156 |  166.0156 |       644 KB |
|                                  |            |                |                |              |              |             |                |                |                |                |                |            |       |         |      |             |            |           |              |
|         SpanJsonStringSerializer |     String |           1000 |       278.9 μs |      5.56 μs |      5.95 μs |     1.40 μs |       279.2 μs |       270.9 μs |       290.6 μs |       273.2 μs |       283.2 μs | 3,585.0124 |  0.50 |    0.02 |    1 |     83.0078 |    83.0078 |   83.0078 |       267 KB |
|        GeneratedStringSerializer |     String |           1000 |       415.2 μs |      6.58 μs |      5.83 μs |     1.56 μs |       416.1 μs |       406.4 μs |       426.7 μs |       411.6 μs |       418.5 μs | 2,408.4444 |  0.75 |    0.02 |    2 |     83.0078 |    83.0078 |   83.0078 |       267 KB |
| SpanJsonStringFromByteSerializer |     String |           1000 |       469.4 μs |      9.39 μs |     13.46 μs |     2.54 μs |       466.7 μs |       450.2 μs |       500.6 μs |       457.2 μs |       479.8 μs | 2,130.4128 |  0.82 |    0.05 |    3 |    124.0234 |   124.0234 |  124.0234 |       400 KB |
|              JilStringSerializer |     String |           1000 |       485.6 μs |      4.38 μs |      4.09 μs |     1.06 μs |       484.3 μs |       480.1 μs |       493.8 μs |       482.6 μs |       489.0 μs | 2,059.2468 |  0.87 |    0.03 |    4 |     83.0078 |    83.0078 |   83.0078 |       525 KB |
|          ClassicStringSerializer |     String |           1000 |       576.0 μs |     11.41 μs |     19.69 μs |     3.19 μs |       584.6 μs |       540.0 μs |       602.8 μs |       556.8 μs |       589.0 μs | 1,736.1357 |  1.00 |    0.00 |    5 |     83.0078 |    83.0078 |   83.0078 |       267 KB |
|         Utf8JsonStringSerializer |     String |           1000 |       747.9 μs |      8.21 μs |      6.85 μs |     1.90 μs |       745.9 μs |       738.8 μs |       761.2 μs |       743.5 μs |       753.5 μs | 1,337.0200 |  1.35 |    0.04 |    6 |    249.0234 |   249.0234 |  249.0234 |       784 KB |
|       NewtonsoftStringSerializer |     String |           1000 |     1,147.6 μs |      8.15 μs |      7.62 μs |     1.97 μs |     1,148.0 μs |     1,130.1 μs |     1,157.3 μs |     1,142.1 μs |     1,153.4 μs |   871.4189 |  2.06 |    0.07 |    7 |     82.0313 |    82.0313 |   82.0313 |       605 KB |
|          MsgPackStringSerializer |     String |           1000 |     1,515.6 μs |     11.70 μs |     10.94 μs |     2.82 μs |     1,516.9 μs |     1,490.1 μs |     1,530.8 μs |     1,509.9 μs |     1,522.6 μs |   659.8034 |  2.72 |    0.11 |    8 |    218.7500 |   109.3750 |  109.3750 |     1,110 KB |
|                                  |            |                |                |              |              |             |                |                |                |                |                |            |       |         |      |             |            |           |              |
|          MsgPackStreamSerializer |     Stream |          10000 |     2,560.9 μs |     51.16 μs |    116.52 μs |    14.80 μs |     2,583.4 μs |     2,225.4 μs |     2,786.5 μs |     2,504.8 μs |     2,630.2 μs |   390.4903 |  0.42 |    0.02 |    1 |    312.5000 |   296.8750 |  296.8750 |     2,273 KB |
|              GeneratedSerializer |     Stream |          10000 |     4,055.4 μs |     73.10 μs |     97.58 μs |    19.52 μs |     4,049.3 μs |     3,866.5 μs |     4,274.1 μs |     3,984.0 μs |     4,114.7 μs |   246.5849 |  0.66 |    0.02 |    2 |    687.5000 |   671.8750 |  671.8750 |     5,607 KB |
|             Utf8StreamSerializer |     Stream |          10000 |     4,832.2 μs |     64.44 μs |     57.12 μs |    15.27 μs |     4,834.8 μs |     4,707.3 μs |     4,958.4 μs |     4,799.3 μs |     4,862.4 μs |   206.9450 |  0.78 |    0.02 |    3 |    726.5625 |   726.5625 |  726.5625 |     5,304 KB |
|                ClassicSerializer |     Stream |          10000 |     6,154.0 μs |    117.93 μs |    131.08 μs |    30.07 μs |     6,166.6 μs |     5,943.4 μs |     6,406.0 μs |     6,061.0 μs |     6,228.8 μs |   162.4972 |  1.00 |    0.00 |    4 |    929.6875 |   914.0625 |  914.0625 |     5,628 KB |
|                                  |            |                |                |              |              |             |                |                |                |                |                |            |       |         |      |             |            |           |              |
|         SpanJsonStringSerializer |     String |          10000 |     3,665.2 μs |     72.81 μs |    113.36 μs |    20.04 μs |     3,660.8 μs |     3,490.3 μs |     3,905.0 μs |     3,577.6 μs |     3,734.6 μs |   272.8346 |  0.66 |    0.02 |    1 |    246.0938 |   246.0938 |  246.0938 |     2,666 KB |
|        GeneratedStringSerializer |     String |          10000 |     3,750.2 μs |     46.66 μs |     43.65 μs |    11.27 μs |     3,741.9 μs |     3,690.5 μs |     3,838.3 μs |     3,721.4 μs |     3,774.3 μs |   266.6509 |  0.69 |    0.01 |    2 |    246.0938 |   246.0938 |  246.0938 |     2,666 KB |
|              JilStringSerializer |     String |          10000 |     3,923.4 μs |     77.54 μs |     92.31 μs |    20.14 μs |     3,889.7 μs |     3,833.3 μs |     4,149.1 μs |     3,847.4 μs |     3,981.6 μs |   254.8793 |  0.72 |    0.02 |    3 |    757.8125 |   578.1250 |  335.9375 |     5,161 KB |
| SpanJsonStringFromByteSerializer |     String |          10000 |     4,240.3 μs |     74.05 μs |    152.92 μs |    21.21 μs |     4,229.0 μs |     4,001.0 μs |     4,720.8 μs |     4,144.4 μs |     4,286.9 μs |   235.8326 |  0.79 |    0.04 |    4 |    343.7500 |   343.7500 |  343.7500 |     3,999 KB |
|          ClassicStringSerializer |     String |          10000 |     5,430.5 μs |     37.80 μs |     35.36 μs |     9.13 μs |     5,420.0 μs |     5,383.3 μs |     5,501.4 μs |     5,402.5 μs |     5,452.4 μs |   184.1467 |  1.00 |    0.00 |    5 |    234.3750 |   234.3750 |  234.3750 |     2,667 KB |
|         Utf8JsonStringSerializer |     String |          10000 |     5,586.0 μs |    108.19 μs |    158.58 μs |    29.45 μs |     5,573.0 μs |     5,361.5 μs |     5,923.3 μs |     5,456.7 μs |     5,688.9 μs |   179.0200 |  1.03 |    0.04 |    5 |    984.3750 |   984.3750 |  984.3750 |     7,967 KB |
|       NewtonsoftStringSerializer |     String |          10000 |     9,931.7 μs |    111.25 μs |    104.06 μs |    26.87 μs |     9,926.6 μs |     9,805.8 μs |    10,110.8 μs |     9,835.3 μs |     9,993.7 μs |   100.6880 |  1.83 |    0.02 |    6 |    937.5000 |   703.1250 |  421.8750 |     5,898 KB |
|          MsgPackStringSerializer |     String |          10000 |    14,731.9 μs |    154.72 μs |    144.72 μs |    37.37 μs |    14,780.3 μs |    14,436.1 μs |    14,978.5 μs |    14,642.5 μs |    14,794.5 μs |    67.8801 |  2.71 |    0.02 |    7 |   1656.2500 |  1156.2500 |  468.7500 |    10,964 KB |
|                                  |            |                |                |              |              |             |                |                |                |                |                |            |       |         |      |             |            |           |              |
|          MsgPackStreamSerializer |     Stream |         100000 |    26,308.3 μs |    332.85 μs |    311.35 μs |    80.39 μs |    26,238.2 μs |    25,778.9 μs |    27,019.7 μs |    26,132.8 μs |    26,512.6 μs |    38.0108 |  0.38 |    0.01 |    1 |    500.0000 |   500.0000 |  500.0000 |    18,389 KB |
|              GeneratedSerializer |     Stream |         100000 |    50,264.9 μs |    820.90 μs |    767.87 μs |   198.26 μs |    49,955.2 μs |    49,256.4 μs |    51,577.1 μs |    49,769.7 μs |    50,827.1 μs |    19.8946 |  0.72 |    0.02 |    2 |    500.0000 |   500.0000 |  500.0000 |    47,803 KB |
|             Utf8StreamSerializer |     Stream |         100000 |    57,278.4 μs |    665.28 μs |    622.31 μs |   160.68 μs |    57,226.1 μs |    56,370.9 μs |    58,399.6 μs |    56,879.6 μs |    57,679.4 μs |    17.4586 |  0.83 |    0.03 |    3 |    400.0000 |   400.0000 |  400.0000 |    45,973 KB |
|                ClassicSerializer |     Stream |         100000 |    69,646.9 μs |  1,392.13 μs |  1,709.66 μs |   364.50 μs |    69,835.7 μs |    67,145.4 μs |    73,877.2 μs |    68,136.0 μs |    70,701.5 μs |    14.3581 |  1.00 |    0.00 |    4 |    714.2857 |   714.2857 |  714.2857 |    47,979 KB |
|                                  |            |                |                |              |              |             |                |                |                |                |                |            |       |         |      |             |            |           |              |
|         SpanJsonStringSerializer |     String |         100000 |    37,071.9 μs |    126.12 μs |    117.97 μs |    30.46 μs |    37,067.9 μs |    36,906.3 μs |    37,315.4 μs |    36,962.8 μs |    37,145.8 μs |    26.9746 |  0.60 |    0.00 |    1 |    285.7143 |   285.7143 |  285.7143 |    29,003 KB |
|        GeneratedStringSerializer |     String |         100000 |    45,885.4 μs |    314.90 μs |    279.15 μs |    74.61 μs |    45,863.0 μs |    45,419.5 μs |    46,407.8 μs |    45,746.8 μs |    46,018.4 μs |    21.7934 |  0.74 |    0.01 |    2 |    363.6364 |   363.6364 |  363.6364 |    33,353 KB |
|              JilStringSerializer |     String |         100000 |    47,495.2 μs |    779.27 μs |    728.93 μs |   188.21 μs |    47,296.9 μs |    46,525.1 μs |    48,886.5 μs |    46,928.1 μs |    47,970.0 μs |    21.0548 |  0.77 |    0.01 |    3 |   4909.0909 |  2454.5455 |  727.2727 |    51,492 KB |
| SpanJsonStringFromByteSerializer |     String |         100000 |    48,711.9 μs |    957.09 μs |  1,933.37 μs |   273.42 μs |    49,243.8 μs |    41,179.9 μs |    50,073.1 μs |    49,067.3 μs |    49,517.5 μs |    20.5289 |  0.76 |    0.05 |    4 |    363.6364 |   363.6364 |  363.6364 |    42,972 KB |
|          ClassicStringSerializer |     String |         100000 |    61,831.7 μs |    473.99 μs |    443.37 μs |   114.48 μs |    61,796.8 μs |    61,274.5 μs |    62,573.2 μs |    61,452.0 μs |    62,249.3 μs |    16.1729 |  1.00 |    0.00 |    5 |           - |          - |         - |    26,655 KB |
|         Utf8JsonStringSerializer |     String |         100000 |    70,330.6 μs |  1,404.27 μs |  3,111.77 μs |   405.12 μs |    71,320.0 μs |    61,441.0 μs |    78,089.4 μs |    68,501.3 μs |    72,435.0 μs |    14.2186 |  1.15 |    0.08 |    6 |    428.5714 |   428.5714 |  428.5714 |    72,633 KB |
|       NewtonsoftStringSerializer |     String |         100000 |   111,383.6 μs |    620.56 μs |    550.11 μs |   147.02 μs |   111,366.8 μs |   110,645.9 μs |   112,510.0 μs |   111,011.3 μs |   111,625.5 μs |     8.9780 |  1.80 |    0.01 |    7 |   6000.0000 |  2600.0000 |  800.0000 |    58,873 KB |
|          MsgPackStringSerializer |     String |         100000 |   140,309.8 μs |  2,771.58 μs |  3,885.37 μs |   747.74 μs |   140,900.0 μs |   133,478.6 μs |   148,570.4 μs |   136,914.6 μs |   142,981.7 μs |     7.1271 |  2.27 |    0.06 |    8 |  12000.0000 |  3000.0000 |         - |   109,615 KB |
|                                  |            |                |                |              |              |             |                |                |                |                |                |            |       |         |      |             |            |           |              |
|          MsgPackStreamSerializer |     Stream |        1000000 |   419,238.3 μs |  8,330.71 μs | 18,460.29 μs | 2,403.32 μs |   429,228.7 μs |   367,578.1 μs |   438,285.1 μs |   410,436.3 μs |   431,230.4 μs |     2.3853 |  0.59 |    0.03 |    1 |  12000.0000 |  6000.0000 |         - |   373,155 KB |
|              GeneratedSerializer |     Stream |        1000000 |   501,889.0 μs |  5,991.94 μs |  5,604.87 μs | 1,447.17 μs |   500,401.4 μs |   494,981.4 μs |   513,478.7 μs |   497,433.3 μs |   504,300.9 μs |     1.9925 |  0.75 |    0.01 |    2 |           - |          - |         - |   409,490 KB |
|                ClassicSerializer |     Stream |        1000000 |   672,950.2 μs |  5,437.91 μs |  4,820.56 μs | 1,288.35 μs |   673,046.3 μs |   665,244.7 μs |   682,112.9 μs |   668,991.7 μs |   675,990.6 μs |     1.4860 |  1.00 |    0.00 |    3 |           - |          - |         - |   410,800 KB |
|             Utf8StreamSerializer |     Stream |        1000000 |   751,293.2 μs | 14,227.73 μs | 17,993.53 μs | 3,751.91 μs |   754,254.7 μs |   695,731.6 μs |   774,835.9 μs |   746,966.2 μs |   762,785.6 μs |     1.3310 |  1.11 |    0.03 |    4 |   1000.0000 |  1000.0000 | 1000.0000 |   657,466 KB |
|                                  |            |                |                |              |              |             |                |                |                |                |                |            |       |         |      |             |            |           |              |
|         SpanJsonStringSerializer |     String |        1000000 |   344,813.2 μs |  2,608.99 μs |  2,312.81 μs |   618.12 μs |   344,674.5 μs |   342,073.7 μs |   350,124.4 μs |   342,762.3 μs |   345,776.6 μs |     2.9001 |  0.55 |    0.01 |    1 |           - |          - |         - |   266,609 KB |
| SpanJsonStringFromByteSerializer |     String |        1000000 |   457,260.8 μs |  3,488.72 μs |  3,263.35 μs |   842.59 μs |   457,887.2 μs |   451,052.1 μs |   462,369.1 μs |   455,109.4 μs |   459,432.1 μs |     2.1869 |  0.72 |    0.01 |    2 |           - |          - |         - |   399,915 KB |
|        GeneratedStringSerializer |     String |        1000000 |   466,819.6 μs |  7,153.50 μs | 13,782.36 μs | 2,032.10 μs |   462,052.6 μs |   451,920.4 μs |   517,398.5 μs |   459,600.0 μs |   467,388.0 μs |     2.1422 |  0.75 |    0.03 |    2 |           - |          - |         - |   266,534 KB |
|              JilStringSerializer |     String |        1000000 |   535,248.1 μs |  5,870.43 μs |  4,583.24 μs | 1,323.07 μs |   534,892.8 μs |   530,042.5 μs |   548,045.1 μs |   532,721.1 μs |   536,220.9 μs |     1.8683 |  0.85 |    0.01 |    3 |  43000.0000 | 18000.0000 | 1000.0000 |   514,852 KB |
|          ClassicStringSerializer |     String |        1000000 |   632,204.3 μs |  7,053.27 μs |  6,252.54 μs | 1,671.06 μs |   629,608.4 μs |   625,595.8 μs |   647,298.1 μs |   627,643.8 μs |   635,918.5 μs |     1.5818 |  1.00 |    0.00 |    4 |           - |          - |         - |   266,538 KB |
|         Utf8JsonStringSerializer |     String |        1000000 |   757,962.4 μs |  9,653.67 μs |  8,061.25 μs | 2,235.79 μs |   759,461.9 μs |   744,540.1 μs |   772,891.0 μs |   750,828.4 μs |   762,248.8 μs |     1.3193 |  1.20 |    0.01 |    5 |           - |          - |         - |   924,074 KB |
|       NewtonsoftStringSerializer |     String |        1000000 | 1,246,214.8 μs | 30,788.00 μs | 90,779.12 μs | 9,077.91 μs | 1,254,211.3 μs | 1,093,722.5 μs | 1,473,852.1 μs | 1,160,235.4 μs | 1,321,629.6 μs |     0.8024 |  1.97 |    0.13 |    6 |  53000.0000 | 18000.0000 | 1000.0000 |   588,671 KB |
|          MsgPackStringSerializer |     String |        1000000 | 1,595,377.8 μs | 14,161.92 μs | 13,247.07 μs | 3,420.38 μs | 1,592,277.9 μs | 1,579,682.5 μs | 1,618,663.3 μs | 1,585,206.1 μs | 1,602,294.1 μs |     0.6268 |  2.52 |    0.03 |    7 | 134000.0000 | 37000.0000 | 1000.0000 | 1,174,617 KB |

    SerializationBenchmarks.MsgPackStreamSerializer: Default          -> 1 outlier  was  removed (370.01 us)
    
    SerializationBenchmarks.GeneratedSerializer: Default              -> 1 outlier  was  removed, 7 outliers were detected (611.35 us..628.39 us, 696.16 us)
    
    SerializationBenchmarks.ClassicSerializer: Default                -> 7 outliers were removed, 11 outliers were detected (781.39 us..799.74 us, 952.37 us..1.11 ms)
    
    SerializationBenchmarks.GeneratedStringSerializer: Default        -> 1 outlier  was  removed (434.93 us)
    
    SerializationBenchmarks.SpanJsonStringFromByteSerializer: Default -> 2 outliers were removed (538.19 us, 567.00 us)
    
    SerializationBenchmarks.Utf8JsonStringSerializer: Default         -> 2 outliers were removed (817.82 us, 855.76 us)
    
    SerializationBenchmarks.MsgPackStringSerializer: Default          -> 1 outlier  was  detected (1.49 ms)
    
    SerializationBenchmarks.MsgPackStreamSerializer: Default          -> 1 outlier  was  removed, 4 outliers were detected (2.23 ms..2.29 ms, 2.97 ms)
    
    SerializationBenchmarks.GeneratedSerializer: Default              -> 2 outliers were removed (4.38 ms, 4.38 ms)
    
    SerializationBenchmarks.Utf8StreamSerializer: Default             -> 1 outlier  was  removed (4.98 ms)
    
    SerializationBenchmarks.ClassicSerializer: Default                -> 2 outliers were removed (6.62 ms, 6.62 ms)
    
    SerializationBenchmarks.JilStringSerializer: Default              -> 1 outlier  was  removed (4.26 ms)
    
    SerializationBenchmarks.SpanJsonStringFromByteSerializer: Default -> 11 outliers were removed (4.74 ms..5.02 ms)
    
    SerializationBenchmarks.ClassicSerializer: Default                -> 1 outlier  was  removed (90.73 ms)
    
    SerializationBenchmarks.GeneratedStringSerializer: Default        -> 1 outlier  was  removed (46.84 ms)
    
    SerializationBenchmarks.SpanJsonStringFromByteSerializer: Default -> 3 outliers were removed, 10 outliers were detected (41.18 ms..48.02 ms, 50.43 ms..51.51 ms)
    
    SerializationBenchmarks.Utf8JsonStringSerializer: Default         -> 1 outlier  was  detected (61.44 ms)
    
    SerializationBenchmarks.NewtonsoftStringSerializer: Default       -> 1 outlier  was  removed (113.07 ms)
    
    SerializationBenchmarks.MsgPackStreamSerializer: Default          -> 1 outlier  was  removed, 3 outliers were detected (367.58 ms, 374.76 ms, 463.77 ms)
    
    SerializationBenchmarks.ClassicSerializer: Default                -> 1 outlier  was  removed (689.39 ms)
    
    SerializationBenchmarks.Utf8StreamSerializer: Default             -> 3 outliers were removed, 5 outliers were detected (695.73 ms, 710.58 ms, 790.92 ms..805.06 ms)
    
    SerializationBenchmarks.SpanJsonStringSerializer: Default         -> 1 outlier  was  removed (351.94 ms)
    
    SerializationBenchmarks.GeneratedStringSerializer: Default        -> 9 outliers were removed (522.92 ms..636.72 ms)

    SerializationBenchmarks.JilStringSerializer: Default              -> 3 outliers were removed (576.70 ms..578.90 ms)

    SerializationBenchmarks.ClassicStringSerializer: Default          -> 1 outlier  was  removed (653.99 ms)

    SerializationBenchmarks.Utf8JsonStringSerializer: Default         -> 2 outliers were removed (796.83 ms, 822.79 ms)

**Warnings!**

    SerializationBenchmarks.Utf8JsonStringSerializer: Default   -> It seems that the distribution is bimodal (mValue = 3.92)

    SerializationBenchmarks.MsgPackStringSerializer: Default    -> It seems that the distribution can have several modes (mValue = 2.91)

    SerializationBenchmarks.NewtonsoftStringSerializer: Default -> It seems that the distribution can have several modes (mValue = 3.18)

## Deserialization

|                 Method | CollectionSize |           Mean |        Error |       StdDev |      StdErr |         Median |            Min |            Max |             Q1 |             Q3 |       Op/s | Ratio | RatioSD | Rank |      Gen 0 |      Gen 1 |     Gen 2 |  Allocated |
|----------------------- |--------------- |---------------:|-------------:|-------------:|------------:|---------------:|---------------:|---------------:|---------------:|---------------:|-----------:|------:|--------:|-----:|-----------:|-----------:|----------:|-----------:|
|   SpanJsonDeserializer |           1000 |       449.0 μs |      2.09 μs |      1.85 μs |     0.49 μs |       448.7 μs |       446.3 μs |       452.8 μs |       447.5 μs |       449.8 μs | 2,227.3496 |  0.49 |    0.00 |    1 |    28.3203 |    11.7188 |         - |     175 KB |
|    MsgPackDeserializer |           1000 |       469.1 μs |      2.63 μs |      2.46 μs |     0.64 μs |       469.3 μs |       466.0 μs |       474.9 μs |       467.1 μs |       470.3 μs | 2,131.8515 |  0.51 |    0.00 |    2 |    28.3203 |    11.2305 |         - |     175 KB |
|        JilDeserializer |           1000 |       756.3 μs |     14.75 μs |     14.49 μs |     3.62 μs |       752.2 μs |       738.2 μs |       785.3 μs |       745.7 μs |       768.5 μs | 1,322.2211 |  0.82 |    0.02 |    3 |    29.2969 |    12.6953 |         - |     183 KB |
|       Utf8Deserializer |           1000 |       808.4 μs |      2.80 μs |      2.19 μs |     0.63 μs |       809.1 μs |       804.1 μs |       811.7 μs |       807.5 μs |       809.5 μs | 1,237.0733 |  0.88 |    0.00 |    4 |    41.0156 |    41.0156 |   41.0156 |     316 KB |
|    ClassicDeserializer |           1000 |       921.1 μs |      3.78 μs |      3.16 μs |     0.88 μs |       921.1 μs |       914.6 μs |       925.8 μs |       919.6 μs |       923.4 μs | 1,085.7016 |  1.00 |    0.00 |    5 |    29.2969 |    10.7422 |         - |     184 KB |
|  GeneratedDeserializer |           1000 |       946.0 μs |      5.83 μs |      5.45 μs |     1.41 μs |       947.3 μs |       938.1 μs |       957.0 μs |       941.7 μs |       948.5 μs | 1,057.0378 |  1.03 |    0.01 |    6 |    29.2969 |    10.7422 |         - |     184 KB |
| NewtonsoftDeserializer |           1000 |     1,885.3 μs |      9.86 μs |      8.74 μs |     2.34 μs |     1,886.4 μs |     1,871.0 μs |     1,899.0 μs |     1,878.3 μs |     1,891.6 μs |   530.4180 |  2.05 |    0.01 |    7 |    78.1250 |    29.2969 |         - |     485 KB |
|                        |                |                |              |              |             |                |                |                |                |                |            |       |         |      |            |            |           |            |
|   SpanJsonDeserializer |          10000 |     5,031.8 μs |     36.98 μs |     34.59 μs |     8.93 μs |     5,020.9 μs |     4,982.0 μs |     5,089.5 μs |     5,008.5 μs |     5,061.9 μs |   198.7364 |  0.46 |    0.00 |    1 |   281.2500 |   140.6250 |         - |   1,751 KB |
|    MsgPackDeserializer |          10000 |     5,141.8 μs |     30.65 μs |     27.17 μs |     7.26 μs |     5,142.2 μs |     5,107.3 μs |     5,204.6 μs |     5,120.7 μs |     5,153.8 μs |   194.4844 |  0.47 |    0.00 |    2 |   281.2500 |   140.6250 |         - |   1,749 KB |
|       Utf8Deserializer |          10000 |     8,612.8 μs |    109.56 μs |     97.12 μs |    25.96 μs |     8,605.3 μs |     8,445.5 μs |     8,800.1 μs |     8,563.8 μs |     8,681.6 μs |   116.1067 |  0.78 |    0.01 |    3 |   406.2500 |   265.6250 |  140.6250 |   3,255 KB |
|        JilDeserializer |          10000 |     9,514.1 μs |     53.95 μs |     50.46 μs |    13.03 μs |     9,501.8 μs |     9,453.4 μs |     9,617.2 μs |     9,474.9 μs |     9,546.3 μs |   105.1069 |  0.87 |    0.00 |    4 |   328.1250 |   140.6250 |   46.8750 |   1,927 KB |
|    ClassicDeserializer |          10000 |    10,983.9 μs |     47.59 μs |     44.52 μs |    11.49 μs |    10,992.0 μs |    10,905.1 μs |    11,053.6 μs |    10,959.8 μs |    11,022.7 μs |    91.0427 |  1.00 |    0.00 |    5 |   406.2500 |   265.6250 |  156.2500 |   3,255 KB |
|  GeneratedDeserializer |          10000 |    11,183.4 μs |    101.71 μs |     90.17 μs |    24.10 μs |    11,187.0 μs |    11,038.1 μs |    11,322.1 μs |    11,114.9 μs |    11,230.8 μs |    89.4180 |  1.02 |    0.01 |    6 |   406.2500 |   265.6250 |  156.2500 |   3,255 KB |
| NewtonsoftDeserializer |          10000 |    23,260.1 μs |    161.51 μs |    151.07 μs |    39.01 μs |    23,217.9 μs |    23,071.9 μs |    23,591.0 μs |    23,162.0 μs |    23,360.8 μs |    42.9921 |  2.12 |    0.02 |    7 |   875.0000 |   312.5000 |  125.0000 |   4,901 KB |
|                        |                |                |              |              |             |                |                |                |                |                |            |       |         |      |            |            |           |            |
|    MsgPackDeserializer |         100000 |    67,252.9 μs |    493.19 μs |    437.20 μs |   116.85 μs |    67,231.9 μs |    66,613.0 μs |    67,992.5 μs |    67,046.3 μs |    67,371.4 μs |    14.8692 |  0.59 |    0.01 |    1 |  3000.0000 |  1250.0000 |  375.0000 |  17,489 KB |
|   SpanJsonDeserializer |         100000 |    75,152.1 μs |    941.12 μs |    834.28 μs |   222.97 μs |    75,132.7 μs |    73,779.3 μs |    76,898.1 μs |    74,615.3 μs |    75,586.6 μs |    13.3063 |  0.65 |    0.01 |    2 |  3142.8571 |  1428.5714 |  428.5714 |  18,185 KB |
|       Utf8Deserializer |         100000 |    93,950.2 μs |    733.88 μs |    686.47 μs |   177.25 μs |    93,835.7 μs |    92,879.6 μs |    95,083.3 μs |    93,407.5 μs |    94,480.6 μs |    10.6439 |  0.82 |    0.01 |    3 |  3000.0000 |  1166.6667 |  333.3333 |  32,035 KB |
|        JilDeserializer |         100000 |    96,498.2 μs |    811.31 μs |    758.90 μs |   195.95 μs |    96,279.8 μs |    95,209.3 μs |    98,031.7 μs |    96,115.3 μs |    97,080.8 μs |    10.3629 |  0.84 |    0.01 |    4 |  3000.0000 |  1166.6667 |  333.3333 |  18,757 KB |
|    ClassicDeserializer |         100000 |   114,789.8 μs |    785.25 μs |    696.10 μs |   186.04 μs |   114,540.3 μs |   114,112.7 μs |   116,390.2 μs |   114,277.7 μs |   115,088.5 μs |     8.7116 |  1.00 |    0.00 |    5 |  2800.0000 |  1000.0000 |  200.0000 |  32,035 KB |
|  GeneratedDeserializer |         100000 |   115,895.2 μs |    434.03 μs |    362.43 μs |   100.52 μs |   115,915.2 μs |   115,427.0 μs |   116,455.6 μs |   115,579.5 μs |   116,078.8 μs |     8.6285 |  1.01 |    0.01 |    5 |  2800.0000 |  1000.0000 |  200.0000 |  32,035 KB |
| NewtonsoftDeserializer |         100000 |   235,438.0 μs |  2,007.53 μs |  1,676.38 μs |   464.94 μs |   236,070.8 μs |   231,697.8 μs |   236,984.1 μs |   235,240.1 μs |   236,421.4 μs |     4.2474 |  2.05 |    0.02 |    6 |  7000.0000 |  2000.0000 |         - |  48,452 KB |
|                        |                |                |              |              |             |                |                |                |                |                |            |       |         |      |            |            |           |            |
|    MsgPackDeserializer |        1000000 |   797,400.4 μs | 15,696.43 μs | 36,378.86 μs | 4,547.36 μs |   807,584.4 μs |   711,106.4 μs |   858,198.9 μs |   790,031.9 μs |   818,645.1 μs |     1.2541 |  0.63 |    0.04 |    1 | 27000.0000 |  9000.0000 |         - | 174,882 KB |
|   SpanJsonDeserializer |        1000000 |   824,708.1 μs | 18,190.03 μs | 52,482.39 μs | 5,356.46 μs |   844,860.8 μs |   734,674.4 μs |   957,397.1 μs |   778,106.3 μs |   855,587.6 μs |     1.2126 |  0.66 |    0.04 |    2 | 27000.0000 |  9000.0000 |         - | 174,883 KB |
|       Utf8Deserializer |        1000000 |   990,007.4 μs |  4,376.01 μs |  3,879.22 μs | 1,036.76 μs |   989,607.6 μs |   985,215.3 μs |   998,674.8 μs |   987,045.5 μs |   992,193.8 μs |     1.0101 |  0.80 |    0.01 |    3 | 27000.0000 |  9000.0000 |         - | 316,233 KB |
|        JilDeserializer |        1000000 | 1,032,918.7 μs | 13,075.47 μs | 12,230.80 μs | 3,157.98 μs | 1,032,672.5 μs | 1,019,392.8 μs | 1,064,340.6 μs | 1,023,274.8 μs | 1,040,494.6 μs |     0.9681 |  0.84 |    0.01 |    4 | 27000.0000 |  9000.0000 |         - | 183,455 KB |
|  GeneratedDeserializer |        1000000 | 1,216,288.9 μs |  6,918.43 μs |  6,471.50 μs | 1,670.93 μs | 1,217,881.6 μs | 1,207,525.2 μs | 1,229,206.9 μs | 1,210,969.7 μs | 1,220,062.0 μs |     0.8222 |  0.99 |    0.01 |    5 | 27000.0000 |  9000.0000 |         - | 316,233 KB |
|    ClassicDeserializer |        1000000 | 1,232,959.1 μs |  8,683.54 μs |  8,122.59 μs | 2,097.24 μs | 1,231,640.2 μs | 1,221,234.5 μs | 1,247,528.1 μs | 1,226,529.8 μs | 1,236,587.5 μs |     0.8111 |  1.00 |    0.00 |    5 | 27000.0000 |  9000.0000 |         - | 316,236 KB |
| NewtonsoftDeserializer |        1000000 | 2,554,718.0 μs | 11,760.03 μs |  9,820.16 μs | 2,723.62 μs | 2,554,994.1 μs | 2,538,003.1 μs | 2,575,656.4 μs | 2,549,531.4 μs | 2,558,364.8 μs |     0.3914 |  2.07 |    0.02 |    6 | 76000.0000 | 21000.0000 | 1000.0000 | 480,340 KB |
