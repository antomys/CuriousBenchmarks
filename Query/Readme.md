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

| Method                      | QueryCount |        Mean |     Error |    StdDev |    StdErr |         Min |          Q1 |      Median |          Q3 |         Max |         Op/s | Ratio | RatioSD |  Gen 0 | Allocated |
|-----------------------------|------------|------------:|----------:|----------:|----------:|------------:|------------:|------------:|------------:|------------:|-------------:|------:|--------:|-------:|----------:|
| LinqQuerySpanVer2           | 1          |    82.59 ns |  1.239 ns |  1.159 ns |  0.299 ns |    80.79 ns |    81.57 ns |    82.58 ns |    83.23 ns |    84.63 ns | 12,107,713.2 |  0.38 |    0.01 | 0.0191 |      80 B |
| QueryStringCreateConcat     | 1          |    96.12 ns |  1.811 ns |  1.605 ns |  0.429 ns |    93.41 ns |    95.16 ns |    96.36 ns |    96.77 ns |    99.31 ns | 10,403,690.4 |  0.45 |    0.01 | 0.0305 |     128 B |
| QueryConcatString           | 1          |    98.04 ns |  1.313 ns |  1.228 ns |  0.317 ns |    96.37 ns |    97.14 ns |    98.14 ns |    98.75 ns |   100.95 ns | 10,199,934.5 |  0.45 |    0.01 | 0.0362 |     152 B |
| LinqQueryAggregate          | 1          |   133.62 ns |  2.683 ns |  3.090 ns |  0.691 ns |   129.40 ns |   131.12 ns |   132.93 ns |   135.77 ns |   140.33 ns |  7,484,173.8 |  0.62 |    0.02 | 0.0439 |     184 B |
| QueryCustomBuilder          | 1          |   139.99 ns |  2.080 ns |  1.946 ns |  0.502 ns |   136.64 ns |   138.74 ns |   139.52 ns |   141.38 ns |   143.55 ns |  7,143,273.2 |  0.65 |    0.02 | 0.0305 |     128 B |
| QueryAspNetCore             | 1          |   163.08 ns |  3.187 ns |  3.543 ns |  0.813 ns |   159.07 ns |   160.21 ns |   162.20 ns |   165.53 ns |   170.21 ns |  6,132,068.0 |  0.76 |    0.03 | 0.0553 |     232 B |
| QueryValueStringBuilder     | 1          |   170.13 ns |  2.897 ns |  2.568 ns |  0.686 ns |   166.03 ns |   168.51 ns |   170.79 ns |   171.67 ns |   174.24 ns |  5,877,697.6 |  0.79 |    0.02 | 0.0305 |     128 B |
| QueryStringCreateStack      | 1          |   170.52 ns |  3.087 ns |  2.737 ns |  0.731 ns |   167.01 ns |   168.57 ns |   170.67 ns |   171.64 ns |   176.55 ns |  5,864,507.9 |  0.79 |    0.02 | 0.0324 |     136 B |
| QueryStringCreate           | 1          |   172.51 ns |  2.171 ns |  1.925 ns |  0.514 ns |   170.39 ns |   171.23 ns |   171.93 ns |   173.49 ns |   176.62 ns |  5,796,599.8 |  0.80 |    0.02 | 0.0324 |     136 B |
| QueryDictionary             | 1          |   215.13 ns |  4.348 ns |  5.340 ns |  1.138 ns |   205.60 ns |   211.31 ns |   213.66 ns |   217.90 ns |   226.80 ns |  4,648,383.7 |  1.00 |    0.00 | 0.0820 |     344 B |
| LinqSelectJoin              | 1          |   232.26 ns |  2.400 ns |  2.004 ns |  0.556 ns |   229.11 ns |   231.74 ns |   232.11 ns |   233.64 ns |   236.23 ns |  4,305,427.1 |  1.07 |    0.03 | 0.0572 |     240 B |
| QueryNvcStaticStringBuilder | 1          |   307.93 ns |  2.538 ns |  2.119 ns |  0.588 ns |   303.93 ns |   306.47 ns |   308.04 ns |   309.75 ns |   311.89 ns |  3,247,499.6 |  1.43 |    0.04 | 0.0305 |     128 B |
| QueryNvcStringBuilder       | 1          |   388.53 ns |  7.145 ns |  5.966 ns |  1.655 ns |   375.74 ns |   386.03 ns |   389.17 ns |   390.26 ns |   400.98 ns |  2,573,794.9 |  1.80 |    0.05 | 0.0553 |     232 B |
| QueryFormUrlEncodedContent  | 1          |   782.59 ns | 10.901 ns |  9.664 ns |  2.583 ns |   763.79 ns |   775.89 ns |   782.29 ns |   787.78 ns |   801.81 ns |  1,277,802.6 |  3.63 |    0.09 | 0.2537 |   1,064 B |
|                             |            |             |           |           |           |             |             |             |             |             |              |       |         |        |           |
| LinqQuerySpanVer2           | 2          |   128.71 ns |  2.634 ns |  3.331 ns |  0.695 ns |   124.02 ns |   126.11 ns |   127.88 ns |   131.11 ns |   135.25 ns |  7,769,600.5 |  0.40 |    0.01 | 0.0248 |     104 B |
| QueryCustomBuilder          | 2          |   172.32 ns |  3.503 ns |  3.105 ns |  0.830 ns |   168.43 ns |   170.24 ns |   171.40 ns |   173.98 ns |   178.74 ns |  5,803,009.4 |  0.53 |    0.01 | 0.0420 |     176 B |
| QueryStringCreateConcat     | 2          |   181.37 ns |  2.793 ns |  2.476 ns |  0.662 ns |   177.05 ns |   180.15 ns |   180.91 ns |   182.86 ns |   185.67 ns |  5,513,740.5 |  0.56 |    0.01 | 0.0648 |     272 B |
| QueryConcatString           | 2          |   190.86 ns |  1.877 ns |  1.664 ns |  0.445 ns |   187.30 ns |   189.99 ns |   190.95 ns |   191.76 ns |   193.63 ns |  5,239,467.1 |  0.59 |    0.01 | 0.0763 |     320 B |
| QueryStringCreateStack      | 2          |   232.88 ns |  4.591 ns |  5.287 ns |  1.182 ns |   225.79 ns |   228.81 ns |   232.67 ns |   235.33 ns |   244.89 ns |  4,294,136.6 |  0.72 |    0.02 | 0.0381 |     160 B |
| QueryStringCreate           | 2          |   234.53 ns |  2.422 ns |  2.147 ns |  0.574 ns |   231.49 ns |   233.45 ns |   234.07 ns |   235.17 ns |   238.73 ns |  4,263,862.4 |  0.73 |    0.01 | 0.0381 |     160 B |
| QueryValueStringBuilder     | 2          |   241.22 ns |  4.707 ns |  6.443 ns |  1.264 ns |   232.56 ns |   236.88 ns |   239.29 ns |   245.70 ns |   255.80 ns |  4,145,646.0 |  0.75 |    0.03 | 0.0420 |     176 B |
| LinqQueryAggregate          | 2          |   250.66 ns |  4.831 ns |  4.519 ns |  1.167 ns |   246.21 ns |   246.86 ns |   249.64 ns |   252.31 ns |   260.59 ns |  3,989,405.5 |  0.78 |    0.02 | 0.0823 |     344 B |
| QueryAspNetCore             | 2          |   254.04 ns |  4.303 ns |  3.593 ns |  0.997 ns |   248.37 ns |   251.56 ns |   254.72 ns |   255.49 ns |   260.41 ns |  3,936,455.8 |  0.79 |    0.02 | 0.0918 |     384 B |
| QueryDictionary             | 2          |   323.18 ns |  6.183 ns |  5.784 ns |  1.493 ns |   312.38 ns |   320.19 ns |   322.30 ns |   326.70 ns |   333.00 ns |  3,094,246.5 |  1.00 |    0.00 | 0.1202 |     504 B |
| LinqSelectJoin              | 2          |   351.25 ns |  3.419 ns |  3.358 ns |  0.840 ns |   344.76 ns |   349.52 ns |   350.90 ns |   353.51 ns |   357.15 ns |  2,846,977.7 |  1.09 |    0.02 | 0.0916 |     384 B |
| QueryNvcStaticStringBuilder | 2          |   567.15 ns | 10.682 ns | 10.491 ns |  2.623 ns |   555.91 ns |   559.88 ns |   564.22 ns |   570.00 ns |   589.90 ns |  1,763,206.1 |  1.76 |    0.05 | 0.0420 |     176 B |
| QueryNvcStringBuilder       | 2          |   681.06 ns | 13.247 ns | 15.769 ns |  3.441 ns |   662.88 ns |   669.71 ns |   676.90 ns |   689.35 ns |   713.11 ns |  1,468,290.4 |  2.11 |    0.07 | 0.0916 |     384 B |
| QueryFormUrlEncodedContent  | 2          |   919.47 ns | 18.305 ns | 23.802 ns |  4.859 ns |   891.51 ns |   901.04 ns |   910.42 ns |   932.30 ns |   968.18 ns |  1,087,585.8 |  2.84 |    0.09 | 0.2995 |   1,256 B |
|                             |            |             |           |           |           |             |             |             |             |             |              |       |         |        |           |
| LinqQuerySpanVer2           | 5          |   286.23 ns |  4.713 ns |  4.408 ns |  1.138 ns |   280.20 ns |   282.64 ns |   286.56 ns |   289.53 ns |   293.96 ns |  3,493,699.7 |  0.51 |    0.02 | 0.0420 |     176 B |
| QueryCustomBuilder          | 5          |   345.94 ns |  6.955 ns | 10.828 ns |  1.914 ns |   334.89 ns |   337.56 ns |   342.46 ns |   352.05 ns |   371.27 ns |  2,890,659.1 |  0.63 |    0.03 | 0.0763 |     320 B |
| QueryValueStringBuilder     | 5          |   412.52 ns |  7.525 ns |  6.671 ns |  1.783 ns |   403.95 ns |   408.72 ns |   410.47 ns |   415.15 ns |   426.23 ns |  2,424,111.4 |  0.74 |    0.03 | 0.0763 |     320 B |
| QueryStringCreateConcat     | 5          |   437.27 ns |  6.593 ns |  6.771 ns |  1.642 ns |   427.23 ns |   431.70 ns |   436.57 ns |   441.15 ns |   449.17 ns |  2,286,928.3 |  0.79 |    0.03 | 0.2027 |     848 B |
| QueryStringCreateStack      | 5          |   448.75 ns |  9.043 ns |  8.459 ns |  2.184 ns |   441.45 ns |   442.79 ns |   446.11 ns |   450.81 ns |   469.92 ns |  2,228,422.3 |  0.80 |    0.03 | 0.0553 |     232 B |
| QueryStringCreate           | 5          |   455.34 ns |  4.147 ns |  3.676 ns |  0.983 ns |   450.41 ns |   452.17 ns |   455.20 ns |   457.29 ns |   461.53 ns |  2,196,146.8 |  0.81 |    0.03 | 0.0553 |     232 B |
| QueryAspNetCore             | 5          |   465.98 ns |  9.243 ns |  9.890 ns |  2.331 ns |   451.77 ns |   459.29 ns |   464.54 ns |   470.45 ns |   487.66 ns |  2,145,995.1 |  0.84 |    0.03 | 0.1583 |     664 B |
| QueryConcatString           | 5          |   504.91 ns |  9.622 ns |  9.450 ns |  2.362 ns |   491.92 ns |   497.96 ns |   503.27 ns |   511.43 ns |   526.74 ns |  1,980,539.1 |  0.90 |    0.03 | 0.2656 |   1,112 B |
| QueryDictionary             | 5          |   546.44 ns | 10.874 ns | 18.756 ns |  3.043 ns |   524.63 ns |   531.16 ns |   541.10 ns |   560.44 ns |   589.37 ns |  1,830,017.8 |  1.00 |    0.00 | 0.1855 |     776 B |
| LinqQueryAggregate          | 5          |   594.80 ns | 10.562 ns |  9.363 ns |  2.502 ns |   577.82 ns |   588.28 ns |   595.47 ns |   600.17 ns |   612.53 ns |  1,681,235.6 |  1.06 |    0.04 | 0.2308 |     968 B |
| LinqSelectJoin              | 5          |   606.74 ns | 11.865 ns | 11.098 ns |  2.866 ns |   592.36 ns |   599.98 ns |   601.41 ns |   617.85 ns |   625.56 ns |  1,648,143.6 |  1.08 |    0.05 | 0.1602 |     672 B |
| QueryFormUrlEncodedContent  | 5          | 1,386.24 ns | 27.591 ns | 64.492 ns |  7.999 ns | 1,296.88 ns | 1,355.90 ns | 1,370.86 ns | 1,399.80 ns | 1,654.30 ns |    721,373.6 |  2.57 |    0.16 | 0.4025 |   1,688 B |
| QueryNvcStaticStringBuilder | 5          | 1,426.95 ns | 24.244 ns | 21.492 ns |  5.744 ns | 1,400.43 ns | 1,410.77 ns | 1,424.84 ns | 1,431.66 ns | 1,477.13 ns |    700,795.9 |  2.54 |    0.10 | 0.0763 |     320 B |
| QueryNvcStringBuilder       | 5          | 1,530.84 ns | 28.960 ns | 27.090 ns |  6.994 ns | 1,500.28 ns | 1,515.24 ns | 1,520.25 ns | 1,547.35 ns | 1,590.51 ns |    653,235.2 |  2.73 |    0.08 | 0.1583 |     664 B |
|                             |            |             |           |           |           |             |             |             |             |             |              |       |         |        |           |
| LinqQuerySpanVer2           | 10         |   483.91 ns |  9.355 ns | 10.010 ns |  2.359 ns |   471.38 ns |   476.32 ns |   481.24 ns |   489.01 ns |   507.61 ns |  2,066,478.8 |  0.53 |    0.01 | 0.0706 |     296 B |
| QueryCustomBuilder          | 10         |   601.98 ns | 11.578 ns | 13.783 ns |  3.008 ns |   586.73 ns |   591.85 ns |   596.36 ns |   615.43 ns |   637.45 ns |  1,661,179.0 |  0.67 |    0.02 | 0.1335 |     560 B |
| QueryValueStringBuilder     | 10         |   709.09 ns | 14.210 ns | 16.916 ns |  3.691 ns |   688.93 ns |   694.06 ns |   707.27 ns |   716.65 ns |   747.24 ns |  1,410,258.9 |  0.78 |    0.02 | 0.1335 |     560 B |
| QueryStringCreate           | 10         |   773.73 ns | 10.211 ns |  9.052 ns |  2.419 ns |   763.29 ns |   768.25 ns |   771.54 ns |   779.18 ns |   795.29 ns |  1,292,436.9 |  0.86 |    0.01 | 0.0839 |     352 B |
| QueryAspNetCore             | 10         |   790.02 ns |  7.895 ns |  6.164 ns |  1.779 ns |   782.50 ns |   785.74 ns |   788.97 ns |   793.84 ns |   804.19 ns |  1,265,788.9 |  0.87 |    0.01 | 0.2632 |   1,104 B |
| QueryStringCreateStack      | 10         |   804.09 ns |  8.602 ns |  7.183 ns |  1.992 ns |   793.74 ns |   797.85 ns |   803.65 ns |   805.79 ns |   821.64 ns |  1,243,645.6 |  0.89 |    0.01 | 0.0839 |     352 B |
| QueryDictionary             | 10         |   904.18 ns | 11.494 ns | 10.189 ns |  2.723 ns |   892.13 ns |   896.37 ns |   902.57 ns |   910.17 ns |   924.26 ns |  1,105,973.6 |  1.00 |    0.00 | 0.2918 |   1,224 B |
| QueryStringCreateConcat     | 10         |   956.91 ns | 19.010 ns | 32.280 ns |  5.307 ns |   891.85 ns |   931.42 ns |   957.53 ns |   977.91 ns | 1,027.38 ns |  1,045,025.3 |  1.04 |    0.05 | 0.5465 |   2,288 B |
| LinqSelectJoin              | 10         | 1,043.38 ns | 19.362 ns | 19.016 ns |  4.754 ns | 1,011.75 ns | 1,026.33 ns | 1,042.52 ns | 1,055.30 ns | 1,073.71 ns |    958,420.6 |  1.15 |    0.02 | 0.2747 |   1,152 B |
| QueryConcatString           | 10         | 1,206.28 ns | 20.923 ns | 19.571 ns |  5.053 ns | 1,171.66 ns | 1,191.62 ns | 1,205.54 ns | 1,217.10 ns | 1,242.76 ns |    828,995.5 |  1.34 |    0.03 | 0.8106 |   3,392 B |
| LinqQueryAggregate          | 10         | 1,345.09 ns | 24.960 ns | 22.126 ns |  5.913 ns | 1,310.16 ns | 1,334.44 ns | 1,345.85 ns | 1,358.96 ns | 1,390.16 ns |    743,445.1 |  1.49 |    0.03 | 0.5932 |   2,488 B |
| QueryFormUrlEncodedContent  | 10         | 1,967.12 ns | 37.754 ns | 44.943 ns |  9.807 ns | 1,907.58 ns | 1,934.61 ns | 1,962.88 ns | 1,987.66 ns | 2,065.02 ns |    508,357.7 |  2.18 |    0.05 | 0.5627 |   2,360 B |
| QueryNvcStaticStringBuilder | 10         | 2,728.17 ns | 26.419 ns | 22.061 ns |  6.119 ns | 2,693.70 ns | 2,714.10 ns | 2,723.38 ns | 2,749.26 ns | 2,765.96 ns |    366,545.8 |  3.02 |    0.04 | 0.1335 |     560 B |
| QueryNvcStringBuilder       | 10         | 2,885.87 ns | 41.479 ns | 38.799 ns | 10.018 ns | 2,819.36 ns | 2,860.26 ns | 2,873.60 ns | 2,910.89 ns | 2,963.49 ns |    346,515.7 |  3.19 |    0.05 | 0.2632 |   1,104 B |

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

