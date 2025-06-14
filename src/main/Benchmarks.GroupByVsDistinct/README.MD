# Comparing `GroupBy()` with `Distinct()`

## Table of contents

* [Reasons and introduction](#reasons-and-introduction)
* [Machine information](#machine-information)
* [Benchmarks](#benchmarks)
* [Conclusions](#conclusions)

<a name="reasons-and-introduction"></a>

## Reasons and introduction

We needed to decide on the most efficient way to extract a de-duplicated sequence of `InnerModel` instances from a list of `SimpleModel` items. The contenders:

1. **GroupBy + Select**
2. **DistinctBy + Select**
3. **Select → Distinct → Select**

<a name="machine-information"></a>

## Machine information

```ini
BenchmarkDotNet v0.15.1, Windows 11 (10.0.26100.4351/24H2/2024Update/HudsonValley)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
```

<a name="benchmarks"></a>

## Benchmarks

### Collection size: 10

| Method             | Mean (ns) |   Ops/sec | Allocated (B) | Ratio vs GroupBy |
| ------------------ | --------: | --------: | ------------: | ---------------: |
| **DistinctTake**   |     485.1 | 2,061,392 |           936 |             0.65 |
| **DistinctByTake** |     548.7 | 1,822,452 |           936 |             0.73 |
| **GroupByTake**    |     748.0 | 1,336,814 |         1,840 |             1.00 |

### Collection size: 10,000

| Method             |   Mean (ns) | Ops/sec | Allocated (B) | Ratio vs GroupBy |
| ------------------ | ----------: | ------: | ------------: | ---------------: |
| **DistinctTake**   |   578,432.0 |   1,729 |       673,457 |             0.30 |
| **DistinctByTake** |   608,348.2 |   1,644 |       673,476 |             0.31 |
| **GroupByTake**    | 1,949,810.4 |     513 |     1,405,293 |             1.00 |

<a name="conclusions"></a>

## Conclusions

The **`Select → Distinct → Select`** approach (`DistinctTake`) is the fastest and most memory-efficient:

* Allocates roughly **50% less** than the GroupBy version at small scales, and **70% less** at large scales.
* Runs **35–50% faster** on small sets, and **3–4×** faster on large sets.

**Next steps:**

1. Adopt **`DistinctTake`** in performance-critical paths.
2. Validate with real-world key selectors and complex equality.
3. Monitor GC metrics in production scenarios.
