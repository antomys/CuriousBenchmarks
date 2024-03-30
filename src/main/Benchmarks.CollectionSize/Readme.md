# Comparing .Length check with .Any check for collection.

### Table of contents

- [Machine information](#machine-information)
- [Benchmark results](#benchmark-results)
- [Conclusions](#conclusions)

<a name="machine-information"></a>

## Machine Information

``` ini
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
13th Gen Intel Core i9-13905H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
```

<a name="benchmark-results"></a>

## Benchmark Results

| Method                       | Categories           | Size  |      Mean |     Error |    StdDev |    StdErr |       Min |        Q1 |    Median |        Q3 |       Max |             Op/s | Allocated |
|------------------------------|----------------------|-------|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|-----------------:|----------:|
| ListAnyEmpty                 | Any Empty            | 10000 | 0.1575 ns | 0.0102 ns | 0.0090 ns | 0.0024 ns | 0.1321 ns | 0.1540 ns | 0.1591 ns | 0.1628 ns | 0.1693 ns |  6,348,659,655.4 |         - |
| CollectionAnyEmpty           | Any Empty            | 10000 | 0.1616 ns | 0.0136 ns | 0.0106 ns | 0.0031 ns | 0.1395 ns | 0.1609 ns | 0.1635 ns | 0.1676 ns | 0.1731 ns |  6,187,631,887.6 |         - |
| ArrayAnyEmpty                | Any Empty            | 10000 | 0.1629 ns | 0.0057 ns | 0.0050 ns | 0.0013 ns | 0.1542 ns | 0.1591 ns | 0.1623 ns | 0.1675 ns | 0.1705 ns |  6,137,454,191.2 |         - |
| EnumerableAnyEmpty           | Any Empty            | 10000 | 0.1679 ns | 0.0049 ns | 0.0046 ns | 0.0012 ns | 0.1588 ns | 0.1659 ns | 0.1694 ns | 0.1707 ns | 0.1739 ns |  5,956,805,902.1 |         - |
|                              |                      |       |           |           |           |           |           |           |           |           |           |                  |           |
| ListAnyExists                | Any Exists           | 10000 | 4.2009 ns | 0.0369 ns | 0.0327 ns | 0.0087 ns | 4.1261 ns | 4.1909 ns | 4.2085 ns | 4.2185 ns | 4.2435 ns |    238,045,897.8 |         - |
| EnumerableAnyExists          | Any Exists           | 10000 | 4.2317 ns | 0.0358 ns | 0.0317 ns | 0.0085 ns | 4.1693 ns | 4.2177 ns | 4.2404 ns | 4.2422 ns | 4.2798 ns |    236,313,616.2 |         - |
| CollectionAnyExists          | Any Exists           | 10000 | 4.2496 ns | 0.0340 ns | 0.0318 ns | 0.0082 ns | 4.2130 ns | 4.2269 ns | 4.2394 ns | 4.2680 ns | 4.3174 ns |    235,315,449.7 |         - |
| ArrayAnyExists               | Any Exists           | 10000 | 7.9174 ns | 0.1175 ns | 0.1099 ns | 0.0284 ns | 7.6922 ns | 7.8355 ns | 7.9253 ns | 7.9733 ns | 8.1004 ns |    126,303,828.2 |         - |
|                              |                      |       |           |           |           |           |           |           |           |           |           |                  |           |
| ArrayCountEmpty              | Count Empty          | 10000 | 0.0381 ns | 0.0139 ns | 0.0124 ns | 0.0033 ns | 0.0243 ns | 0.0259 ns | 0.0388 ns | 0.0460 ns | 0.0650 ns | 26,244,019,715.3 |         - |
| EnumerableCountEmpty         | Count Empty          | 10000 | 0.1623 ns | 0.0036 ns | 0.0030 ns | 0.0008 ns | 0.1542 ns | 0.1615 ns | 0.1629 ns | 0.1640 ns | 0.1663 ns |  6,161,384,507.6 |         - |
| ListCountEmpty               | Count Empty          | 10000 | 0.1683 ns | 0.0123 ns | 0.0103 ns | 0.0029 ns | 0.1487 ns | 0.1599 ns | 0.1723 ns | 0.1777 ns | 0.1808 ns |  5,942,393,755.6 |         - |
| CollectionCountEmpty         | Count Empty          | 10000 | 0.1686 ns | 0.0156 ns | 0.0138 ns | 0.0037 ns | 0.1379 ns | 0.1640 ns | 0.1689 ns | 0.1778 ns | 0.1905 ns |  5,932,726,195.4 |         - |
|                              |                      |       |           |           |           |           |           |           |           |           |           |                  |           |
| ListCountExists              | Count Exists         | 10000 | 0.1839 ns | 0.0158 ns | 0.0132 ns | 0.0036 ns | 0.1565 ns | 0.1817 ns | 0.1866 ns | 0.1923 ns | 0.2023 ns |  5,439,195,656.5 |         - |
| ArrayCountExists             | Count Exists         | 10000 | 0.1862 ns | 0.0088 ns | 0.0082 ns | 0.0021 ns | 0.1736 ns | 0.1806 ns | 0.1862 ns | 0.1902 ns | 0.2045 ns |  5,371,758,129.9 |         - |
| CollectionCountExists        | Count Exists         | 10000 | 1.7454 ns | 0.0166 ns | 0.0147 ns | 0.0039 ns | 1.7044 ns | 1.7450 ns | 1.7476 ns | 1.7517 ns | 1.7632 ns |    572,927,716.8 |         - |
| EnumerableCountExists        | Count Exists         | 10000 | 3.7330 ns | 0.0119 ns | 0.0105 ns | 0.0028 ns | 3.7135 ns | 3.7286 ns | 3.7318 ns | 3.7377 ns | 3.7560 ns |    267,880,232.1 |         - |
|                              |                      |       |           |           |           |           |           |           |           |           |           |                  |           |
| ArrayCountPatternEmpty       | Count Pattern Empty  | 10000 | 0.0431 ns | 0.0045 ns | 0.0040 ns | 0.0011 ns | 0.0368 ns | 0.0402 ns | 0.0425 ns | 0.0463 ns | 0.0492 ns | 23,212,389,984.1 |         - |
| CollectionCountPatternEmpty  | Count Pattern Empty  | 10000 | 0.1673 ns | 0.0056 ns | 0.0053 ns | 0.0014 ns | 0.1576 ns | 0.1647 ns | 0.1677 ns | 0.1712 ns | 0.1746 ns |  5,978,230,800.6 |         - |
| ListCountPatternEmpty        | Count Pattern Empty  | 10000 | 0.1681 ns | 0.0085 ns | 0.0079 ns | 0.0020 ns | 0.1536 ns | 0.1630 ns | 0.1660 ns | 0.1738 ns | 0.1819 ns |  5,948,789,021.4 |         - |
|                              |                      |       |           |           |           |           |           |           |           |           |           |                  |           |
| ArrayCountPatternExists      | Count Pattern Exists | 10000 | 0.1808 ns | 0.0047 ns | 0.0044 ns | 0.0011 ns | 0.1744 ns | 0.1775 ns | 0.1812 ns | 0.1830 ns | 0.1909 ns |  5,532,369,899.3 |         - |
| ListCountPatternExists       | Count Pattern Exists | 10000 | 0.1811 ns | 0.0118 ns | 0.0099 ns | 0.0027 ns | 0.1593 ns | 0.1798 ns | 0.1827 ns | 0.1856 ns | 0.1953 ns |  5,521,226,198.4 |         - |
| CollectionCountPatternExists | Count Pattern Exists | 10000 | 1.5557 ns | 0.0154 ns | 0.0144 ns | 0.0037 ns | 1.5317 ns | 1.5483 ns | 1.5557 ns | 1.5646 ns | 1.5864 ns |    642,807,376.0 |         - |

<a name="conclusions"></a>

## Conclusions

For array - use native `.Length` or `.Count` methods. Elsewhere, use `.Any` with no performance impact.
