# Comparing .Length check with .Any check for collection.

### Table of contents
- [Machine information](#machine-information)
- [Benchmark results](#benchmark-results)
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

| Method                       | Categories           | Size  |       Mean |            Op/s | Allocated |
|------------------------------|----------------------|-------|-----------:|----------------:|----------:|
| ListCountExists              | Count Exists         | 10000 |  0.6154 ns | 1,624,950,322.7 |         - |
| ArrayCountExists             | Count Exists         | 10000 |  0.6440 ns | 1,552,843,262.0 |         - |
| CollectionCountExists        | Count Exists         | 10000 |  1.9619 ns |   509,705,427.3 |         - |
| EnumerableCountExists        | Count Exists         | 10000 |  6.1827 ns |   161,741,533.6 |         - |
|                              |                      |       |            |                 |           |
| ListCountPatternExists       | Count Pattern Exists | 10000 |  0.4388 ns | 2,278,822,714.0 |         - |
| ArrayCountPatternExists      | Count Pattern Exists | 10000 |  0.6555 ns | 1,525,653,718.4 |         - |
| CollectionCountPatternExists | Count Pattern Exists | 10000 |  1.8425 ns |   542,746,307.2 |         - |
|                              |                      |       |            |                 |           |
| CollectionAnyExists          | Any Exists           | 10000 |  6.0756 ns |   164,593,033.8 |         - |
| EnumerableAnyExists          | Any Exists           | 10000 |  6.2009 ns |   161,267,490.5 |         - |
| ListAnyExists                | Any Exists           | 10000 |  6.2251 ns |   160,639,130.8 |         - |
| ArrayAnyExists               | Any Exists           | 10000 | 12.6248 ns |    79,209,160.3 |         - |
|                              |                      |       |            |                 |           |
| CollectionCountEmpty         | Count Empty          | 10000 |  0.3242 ns | 3,084,480,029.1 |         - |
| ListCountEmpty               | Count Empty          | 10000 |  0.3341 ns | 2,993,530,025.4 |         - |
| EnumerableCountEmpty         | Count Empty          | 10000 |  0.3419 ns | 2,924,954,279.1 |         - |
| ArrayCountEmpty              | Count Empty          | 10000 |  0.3443 ns | 2,904,825,690.6 |         - |
|                              |                      |       |            |                 |           |
| ListCountPatternEmpty        | Count Pattern Empty  | 10000 |  0.3524 ns | 2,837,684,161.8 |         - |
| ArrayCountPatternEmpty       | Count Pattern Empty  | 10000 |  0.3630 ns | 2,754,999,094.5 |         - |
| CollectionCountPatternEmpty  | Count Pattern Empty  | 10000 |  0.8636 ns | 1,157,884,811.5 |         - |
|                              |                      |       |            |                 |           |
| ArrayAnyEmpty                | Any Empty            | 10000 |  0.3306 ns | 3,024,678,777.2 |         - |
| ListAnyEmpty                 | Any Empty            | 10000 |  0.3438 ns | 2,908,628,967.2 |         - |
| CollectionAnyEmpty           | Any Empty            | 10000 |  0.3635 ns | 2,751,317,098.1 |         - |
| EnumerableAnyEmpty           | Any Empty            | 10000 |  0.3678 ns | 2,718,925,516.7 |         - |

<a name="conclusions"></a>
## Conclusions

For array, and collections that does not implement IEnumerable - use native `.Length` or `.Count` methods. Elsewhere, use `.Any` with no performance impact.

Pattern is somewhat slower when collection is empty, consider using native methods or `.Any`.