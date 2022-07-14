# Comparing different approaches for building Query strings and concatenating links

### Table of contents
- [Machine information](#machine-information)
- [Benchmark results](#benchmark-results)
  * [Uri combining](#uri-combining)
  * [Building query string](#building-query-string)
- [Conclusions](#conclusions)

<a name="machine-information"></a>
## Machine Information

``` ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22621
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
```

<a name="benchmark-results"></a>
## Benchmark Results

<a name="uri-combining"></a>
### Uri combining

| Method                    | Categories |       Mean |    Error |   StdDev |  StdErr |        Min |         Q1 |     Median |         Q3 |        Max |        Op/s | Ratio | RatioSD |  Gen 0 | Allocated |
|---------------------------|------------|-----------:|---------:|---------:|--------:|-----------:|-----------:|-----------:|-----------:|-----------:|------------:|------:|--------:|-------:|----------:|
| UriFastAppend             | Uri Url    |   176.4 ns |  2.00 ns |  1.77 ns | 0.47 ns |   172.8 ns |   175.3 ns |   176.1 ns |   177.1 ns |   180.5 ns | 5,670,295.9 |  0.77 |    0.01 | 0.0420 |     176 B |
| UriCombine                | Uri Url    |   193.9 ns |  3.36 ns |  3.14 ns | 0.81 ns |   189.8 ns |   191.3 ns |   192.8 ns |   195.9 ns |   201.7 ns | 5,157,708.1 |  0.85 |    0.02 | 0.0553 |     232 B |
| NewUri                    | Uri Url    |   228.7 ns |  3.81 ns |  3.38 ns | 0.90 ns |   224.6 ns |   225.6 ns |   228.5 ns |   231.3 ns |   234.8 ns | 4,372,714.9 |  1.00 |    0.00 | 0.0324 |     136 B |
| UriSpan                   | Uri Url    |   229.5 ns |  2.49 ns |  2.20 ns | 0.59 ns |   225.8 ns |   228.1 ns |   229.2 ns |   229.9 ns |   233.3 ns | 4,358,123.4 |  1.00 |    0.02 | 0.0610 |     256 B |
| UriBuilderTryCreate       | Uri Url    |   233.8 ns |  2.82 ns |  2.64 ns | 0.68 ns |   230.2 ns |   231.5 ns |   233.9 ns |   235.4 ns |   238.5 ns | 4,276,460.9 |  1.02 |    0.02 | 0.0458 |     192 B |
| UriAppend                 | Uri Url    |   376.8 ns |  3.71 ns |  3.47 ns | 0.90 ns |   371.2 ns |   374.3 ns |   377.2 ns |   378.6 ns |   384.4 ns | 2,653,826.3 |  1.65 |    0.03 | 0.0591 |     248 B |
|                           |            |            |          |          |         |            |            |            |            |            |             |       |         |        |           |
| StringUriAppend           | String Url |   169.4 ns |  1.79 ns |  1.59 ns | 0.43 ns |   167.2 ns |   168.5 ns |   169.3 ns |   169.8 ns |   173.0 ns | 5,902,648.2 |  0.80 |    0.01 | 0.0420 |     176 B |
| StringUriCombineCached    | String Url |   172.4 ns |  1.81 ns |  1.60 ns | 0.43 ns |   169.9 ns |   171.3 ns |   172.2 ns |   173.6 ns |   175.4 ns | 5,800,310.6 |  0.81 |    0.01 | 0.0420 |     176 B |
| StringUriCombine          | String Url |   191.9 ns |  2.83 ns |  2.65 ns | 0.68 ns |   188.4 ns |   189.6 ns |   191.3 ns |   193.6 ns |   197.4 ns | 5,212,065.1 |  0.90 |    0.01 | 0.0553 |     232 B |
| StringUriSpan             | String Url |   212.4 ns |  2.50 ns |  2.34 ns | 0.60 ns |   209.2 ns |   210.5 ns |   211.7 ns |   214.5 ns |   216.5 ns | 4,708,803.2 |  1.00 |    0.00 | 0.0610 |     256 B |
| StringUriSwitch           | String Url |   252.8 ns |  3.93 ns |  3.68 ns | 0.95 ns |   246.9 ns |   250.7 ns |   251.4 ns |   255.3 ns |   260.7 ns | 3,955,532.8 |  1.19 |    0.02 | 0.0553 |     232 B |
| StringUriBuilderTryCreate | String Url | 1,272.5 ns | 11.30 ns | 10.02 ns | 2.68 ns | 1,259.9 ns | 1,262.8 ns | 1,274.8 ns | 1,281.2 ns | 1,284.7 ns |   785,850.0 |  5.99 |    0.07 | 0.2193 |     920 B |

![BarPlot](assets/Query.Benchmarks.Benchmarks.UriCombineBenchmarks-barplot.png)
![BoxPlot](assets/Query.Benchmarks.Benchmarks.UriCombineBenchmarks-boxplot.png)

<a name="building-query-string"></a>
### Building query string

| Method                      | QueryCount |        Mean |     Error |    StdDev |   StdErr |         Min |          Q1 |      Median |          Q3 |         Max |         Op/s | Ratio | RatioSD |  Gen 0 | Allocated |
|-----------------------------|------------|------------:|----------:|----------:|---------:|------------:|------------:|------------:|------------:|------------:|-------------:|------:|--------:|-------:|----------:|
| LinqQuerySpanVer2           | 1          |    86.60 ns |  0.909 ns |  0.759 ns | 0.211 ns |    85.61 ns |    86.13 ns |    86.46 ns |    87.09 ns |    87.92 ns | 11,547,146.5 |  0.41 |    0.00 | 0.0191 |      80 B |
| QueryStringCreateConcat     | 1          |    92.74 ns |  0.925 ns |  0.865 ns | 0.223 ns |    91.34 ns |    92.09 ns |    93.01 ns |    93.26 ns |    94.21 ns | 10,782,796.8 |  0.44 |    0.01 | 0.0305 |     128 B |
| QueryConcatString           | 1          |   103.09 ns |  1.112 ns |  1.040 ns | 0.269 ns |   101.47 ns |   102.20 ns |   103.16 ns |   103.50 ns |   104.99 ns |  9,700,618.8 |  0.49 |    0.01 | 0.0362 |     152 B |
| LinqQueryAggregate          | 1          |   138.35 ns |  2.478 ns |  2.318 ns | 0.598 ns |   134.01 ns |   136.79 ns |   138.84 ns |   140.02 ns |   141.67 ns |  7,228,140.2 |  0.65 |    0.01 | 0.0439 |     184 B |
| QueryCustomBuilder          | 1          |   142.73 ns |  2.496 ns |  2.085 ns | 0.578 ns |   137.82 ns |   141.74 ns |   142.74 ns |   143.91 ns |   146.44 ns |  7,006,149.5 |  0.67 |    0.01 | 0.0305 |     128 B |
| QueryAspNetCore             | 1          |   159.53 ns |  2.699 ns |  2.525 ns | 0.652 ns |   155.99 ns |   157.81 ns |   158.86 ns |   161.10 ns |   164.05 ns |  6,268,284.8 |  0.75 |    0.01 | 0.0553 |     232 B |
| QueryStringCreateStack      | 1          |   168.91 ns |  3.354 ns |  3.137 ns | 0.810 ns |   165.84 ns |   166.40 ns |   168.42 ns |   170.56 ns |   176.92 ns |  5,920,309.5 |  0.80 |    0.01 | 0.0324 |     136 B |
| QueryStringCreate           | 1          |   181.54 ns |  2.223 ns |  2.079 ns | 0.537 ns |   178.68 ns |   180.36 ns |   180.96 ns |   182.95 ns |   185.79 ns |  5,508,340.1 |  0.86 |    0.02 | 0.0324 |     136 B |
| QueryDictionary             | 1          |   211.97 ns |  3.210 ns |  2.846 ns | 0.761 ns |   208.57 ns |   210.36 ns |   211.27 ns |   212.77 ns |   217.43 ns |  4,717,754.5 |  1.00 |    0.00 | 0.0823 |     344 B |
| LinqSelectJoin              | 1          |   235.86 ns |  1.336 ns |  1.184 ns | 0.316 ns |   232.97 ns |   235.55 ns |   235.88 ns |   236.51 ns |   238.14 ns |  4,239,732.8 |  1.11 |    0.01 | 0.0572 |     240 B |
| QueryNvcStaticStringBuilder | 1          |   306.61 ns |  2.511 ns |  2.097 ns | 0.582 ns |   303.95 ns |   304.49 ns |   306.59 ns |   307.73 ns |   310.93 ns |  3,261,499.5 |  1.45 |    0.02 | 0.0305 |     128 B |
| QueryNvcStringBuilder       | 1          |   373.84 ns |  4.927 ns |  4.608 ns | 1.190 ns |   362.31 ns |   371.95 ns |   373.52 ns |   376.57 ns |   380.65 ns |  2,674,920.6 |  1.77 |    0.04 | 0.0553 |     232 B |
| QueryFormUrlEncodedContent  | 1          |   778.95 ns |  8.263 ns |  7.730 ns | 1.996 ns |   767.85 ns |   773.48 ns |   778.54 ns |   782.66 ns |   793.09 ns |  1,283,777.8 |  3.68 |    0.06 | 0.2537 |   1,064 B |
|                             |            |             |           |           |          |             |             |             |             |             |              |       |         |        |           |
| LinqQuerySpanVer2           | 2          |   129.60 ns |  1.971 ns |  1.747 ns | 0.467 ns |   126.68 ns |   128.76 ns |   129.45 ns |   130.82 ns |   132.28 ns |  7,716,225.0 |  0.39 |    0.01 | 0.0248 |     104 B |
| QueryStringCreateConcat     | 2          |   181.99 ns |  2.203 ns |  1.840 ns | 0.510 ns |   179.25 ns |   181.07 ns |   181.85 ns |   182.58 ns |   186.46 ns |  5,494,752.4 |  0.54 |    0.01 | 0.0648 |     272 B |
| QueryCustomBuilder          | 2          |   182.53 ns |  2.049 ns |  1.816 ns | 0.485 ns |   179.64 ns |   181.22 ns |   182.43 ns |   183.86 ns |   186.07 ns |  5,478,640.8 |  0.54 |    0.01 | 0.0420 |     176 B |
| QueryConcatString           | 2          |   189.96 ns |  1.187 ns |  0.927 ns | 0.268 ns |   188.02 ns |   189.34 ns |   190.02 ns |   190.62 ns |   191.42 ns |  5,264,398.0 |  0.57 |    0.01 | 0.0763 |     320 B |
| QueryStringCreateStack      | 2          |   226.90 ns |  2.212 ns |  2.069 ns | 0.534 ns |   224.38 ns |   225.52 ns |   225.98 ns |   228.08 ns |   231.17 ns |  4,407,318.8 |  0.68 |    0.01 | 0.0381 |     160 B |
| QueryStringCreate           | 2          |   233.80 ns |  2.287 ns |  2.139 ns | 0.552 ns |   229.31 ns |   233.57 ns |   234.41 ns |   235.41 ns |   235.94 ns |  4,277,205.6 |  0.70 |    0.01 | 0.0381 |     160 B |
| LinqQueryAggregate          | 2          |   252.79 ns |  5.032 ns |  7.377 ns | 1.370 ns |   242.42 ns |   247.84 ns |   250.81 ns |   257.60 ns |   267.39 ns |  3,955,901.4 |  0.76 |    0.03 | 0.0823 |     344 B |
| QueryAspNetCore             | 2          |   262.66 ns |  4.833 ns |  4.285 ns | 1.145 ns |   250.93 ns |   261.61 ns |   263.18 ns |   265.50 ns |   268.43 ns |  3,807,245.3 |  0.78 |    0.02 | 0.0918 |     384 B |
| QueryDictionary             | 2          |   336.01 ns |  5.023 ns |  4.698 ns | 1.213 ns |   327.33 ns |   333.51 ns |   335.81 ns |   338.56 ns |   344.25 ns |  2,976,072.5 |  1.00 |    0.00 | 0.1202 |     504 B |
| LinqSelectJoin              | 2          |   358.72 ns |  5.304 ns |  4.961 ns | 1.281 ns |   352.09 ns |   355.20 ns |   357.39 ns |   360.57 ns |   367.52 ns |  2,787,652.1 |  1.07 |    0.02 | 0.0916 |     384 B |
| QueryNvcStaticStringBuilder | 2          |   581.19 ns |  5.899 ns |  5.229 ns | 1.398 ns |   571.01 ns |   578.29 ns |   580.15 ns |   582.48 ns |   591.77 ns |  1,720,612.6 |  1.73 |    0.02 | 0.0420 |     176 B |
| QueryNvcStringBuilder       | 2          |   667.30 ns |  6.882 ns |  6.101 ns | 1.631 ns |   655.61 ns |   663.73 ns |   666.96 ns |   671.31 ns |   678.31 ns |  1,498,578.5 |  1.99 |    0.03 | 0.0916 |     384 B |
| QueryFormUrlEncodedContent  | 2          |   893.73 ns | 12.799 ns | 11.972 ns | 3.091 ns |   868.84 ns |   885.50 ns |   892.36 ns |   904.30 ns |   912.39 ns |  1,118,905.4 |  2.66 |    0.05 | 0.2995 |   1,256 B |
|                             |            |             |           |           |          |             |             |             |             |             |              |       |         |        |           |
| LinqQuerySpanVer2           | 5          |   286.33 ns |  3.057 ns |  2.553 ns | 0.708 ns |   283.11 ns |   284.60 ns |   285.60 ns |   287.27 ns |   291.08 ns |  3,492,472.6 |  0.53 |    0.00 | 0.0420 |     176 B |
| QueryCustomBuilder          | 5          |   355.15 ns |  4.116 ns |  3.850 ns | 0.994 ns |   348.74 ns |   352.29 ns |   356.12 ns |   357.45 ns |   363.88 ns |  2,815,710.0 |  0.66 |    0.01 | 0.0763 |     320 B |
| QueryStringCreateConcat     | 5          |   443.08 ns |  7.973 ns |  7.458 ns | 1.926 ns |   433.31 ns |   437.23 ns |   441.75 ns |   447.00 ns |   456.13 ns |  2,256,914.3 |  0.82 |    0.02 | 0.2027 |     848 B |
| QueryStringCreateStack      | 5          |   451.20 ns |  4.696 ns |  4.163 ns | 1.113 ns |   446.38 ns |   448.26 ns |   450.25 ns |   452.94 ns |   460.94 ns |  2,216,315.2 |  0.84 |    0.01 | 0.0553 |     232 B |
| QueryStringCreate           | 5          |   454.64 ns |  4.855 ns |  4.541 ns | 1.173 ns |   446.77 ns |   451.06 ns |   454.04 ns |   456.93 ns |   464.90 ns |  2,199,542.9 |  0.84 |    0.01 | 0.0553 |     232 B |
| QueryAspNetCore             | 5          |   489.82 ns |  7.561 ns |  7.072 ns | 1.826 ns |   479.99 ns |   485.70 ns |   488.60 ns |   494.07 ns |   504.18 ns |  2,041,545.8 |  0.91 |    0.02 | 0.1583 |     664 B |
| QueryConcatString           | 5          |   512.81 ns |  8.729 ns |  8.165 ns | 2.108 ns |   503.81 ns |   506.03 ns |   510.75 ns |   518.71 ns |   526.29 ns |  1,950,032.1 |  0.95 |    0.02 | 0.2656 |   1,112 B |
| QueryDictionary             | 5          |   539.67 ns |  6.628 ns |  6.200 ns | 1.601 ns |   530.18 ns |   535.46 ns |   539.61 ns |   544.03 ns |   552.15 ns |  1,852,984.5 |  1.00 |    0.00 | 0.1855 |     776 B |
| LinqSelectJoin              | 5          |   626.21 ns |  6.340 ns |  5.930 ns | 1.531 ns |   616.03 ns |   621.36 ns |   627.92 ns |   630.78 ns |   634.66 ns |  1,596,896.4 |  1.16 |    0.01 | 0.1602 |     672 B |
| LinqQueryAggregate          | 5          |   639.96 ns | 12.799 ns | 14.226 ns | 3.264 ns |   623.61 ns |   627.78 ns |   637.51 ns |   648.39 ns |   674.95 ns |  1,562,596.3 |  1.19 |    0.03 | 0.2308 |     968 B |
| QueryFormUrlEncodedContent  | 5          | 1,334.30 ns | 14.268 ns | 11.139 ns | 3.216 ns | 1,314.82 ns | 1,326.67 ns | 1,335.30 ns | 1,340.82 ns | 1,351.55 ns |    749,454.8 |  2.47 |    0.05 | 0.4025 |   1,688 B |
| QueryNvcStaticStringBuilder | 5          | 1,354.62 ns |  6.502 ns |  5.764 ns | 1.541 ns | 1,347.74 ns | 1,350.88 ns | 1,353.33 ns | 1,358.99 ns | 1,365.95 ns |    738,213.6 |  2.51 |    0.03 | 0.0763 |     320 B |
| QueryNvcStringBuilder       | 5          | 1,613.77 ns | 19.271 ns | 18.026 ns | 4.654 ns | 1,584.03 ns | 1,603.47 ns | 1,607.74 ns | 1,621.94 ns | 1,647.32 ns |    619,666.9 |  2.99 |    0.05 | 0.1583 |     664 B |
|                             |            |             |           |           |          |             |             |             |             |             |              |       |         |        |           |
| LinqQuerySpanVer2           | 10         |   486.86 ns |  2.569 ns |  2.403 ns | 0.621 ns |   483.53 ns |   484.98 ns |   486.57 ns |   488.23 ns |   492.30 ns |  2,053,991.9 |  0.53 |    0.00 | 0.0706 |     296 B |
| QueryCustomBuilder          | 10         |   622.53 ns |  6.665 ns |  5.908 ns | 1.579 ns |   614.70 ns |   618.90 ns |   620.96 ns |   626.32 ns |   636.26 ns |  1,606,356.0 |  0.67 |    0.01 | 0.1335 |     560 B |
| QueryStringCreate           | 10         |   793.48 ns |  5.246 ns |  4.908 ns | 1.267 ns |   784.34 ns |   790.12 ns |   793.29 ns |   797.68 ns |   802.05 ns |  1,260,267.8 |  0.86 |    0.01 | 0.0839 |     352 B |
| QueryStringCreateStack      | 10         |   795.00 ns |  6.862 ns |  6.083 ns | 1.626 ns |   785.40 ns |   790.63 ns |   794.55 ns |   797.02 ns |   807.06 ns |  1,257,856.5 |  0.86 |    0.01 | 0.0839 |     352 B |
| QueryAspNetCore             | 10         |   858.67 ns | 14.846 ns | 13.887 ns | 3.586 ns |   839.33 ns |   849.39 ns |   855.75 ns |   869.33 ns |   882.81 ns |  1,164,596.1 |  0.93 |    0.02 | 0.2632 |   1,104 B |
| QueryDictionary             | 10         |   924.93 ns |  9.717 ns |  9.089 ns | 2.347 ns |   914.97 ns |   917.57 ns |   923.53 ns |   931.38 ns |   945.11 ns |  1,081,165.3 |  1.00 |    0.00 | 0.2918 |   1,224 B |
| QueryStringCreateConcat     | 10         |   982.88 ns | 12.379 ns |  9.665 ns | 2.790 ns |   972.98 ns |   973.80 ns |   981.10 ns |   991.24 ns |   998.53 ns |  1,017,420.1 |  1.06 |    0.02 | 0.5465 |   2,288 B |
| LinqSelectJoin              | 10         | 1,059.20 ns |  9.737 ns |  8.131 ns | 2.255 ns | 1,044.61 ns | 1,054.70 ns | 1,058.09 ns | 1,061.04 ns | 1,075.99 ns |    944,112.2 |  1.15 |    0.02 | 0.2747 |   1,152 B |
| QueryConcatString           | 10         | 1,230.33 ns | 19.103 ns | 17.869 ns | 4.614 ns | 1,201.03 ns | 1,218.22 ns | 1,224.48 ns | 1,248.99 ns | 1,255.50 ns |    812,793.1 |  1.33 |    0.02 | 0.8106 |   3,392 B |
| LinqQueryAggregate          | 10         | 1,350.91 ns | 19.578 ns | 18.313 ns | 4.728 ns | 1,316.45 ns | 1,339.23 ns | 1,351.50 ns | 1,364.29 ns | 1,391.14 ns |    740,244.2 |  1.46 |    0.02 | 0.5932 |   2,488 B |
| QueryFormUrlEncodedContent  | 10         | 1,927.13 ns | 27.096 ns | 25.345 ns | 6.544 ns | 1,893.91 ns | 1,905.52 ns | 1,918.15 ns | 1,950.41 ns | 1,972.57 ns |    518,906.6 |  2.08 |    0.04 | 0.5627 |   2,360 B |
| QueryNvcStaticStringBuilder | 10         | 2,801.35 ns | 28.999 ns | 24.215 ns | 6.716 ns | 2,764.85 ns | 2,784.25 ns | 2,792.71 ns | 2,818.84 ns | 2,846.24 ns |    356,970.6 |  3.03 |    0.04 | 0.1335 |     560 B |
| QueryNvcStringBuilder       | 10         | 3,088.62 ns | 23.883 ns | 22.340 ns | 5.768 ns | 3,048.26 ns | 3,074.26 ns | 3,087.58 ns | 3,100.51 ns | 3,124.41 ns |    323,769.2 |  3.34 |    0.03 | 0.2632 |   1,104 B |

![BarPlot](assets/Query.Benchmarks.Benchmarks.QueryBuilderBenchmarks-barplot.png)
![BoxPlot](assets/Query.Benchmarks.Benchmarks.QueryBuilderBenchmarks-boxplot.png)

<a name="conclusions"></a>
## Conclusions

For building Query strings prefer using native `AspNetCoreQueryBuilder` or my own implementation using spans: `QueryCustomBuilder`.
`AspNetCoreQueryBuilder` does not support mirroring for some special chars.  `QueryCustomBuilder` supports mirroring and is well tested.
Difference is about 30-40%

As for Uri concatenation: 
I think that it is better to stick with `New Uri` approach or my own implementation using spans `UriFastAppend`. It is well tested and outputs
perfect concatenated Url.

