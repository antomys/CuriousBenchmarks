# Any-Length and Count Predicate Performance Benchmarks

## Table of contents

* [Reasons and introduction](#reasons-and-introduction)
* [Machine information](#machine-information)
* [Benchmarks](#benchmarks)

  * [Any on Empty Collections](#any-on-empty-collections)
  * [Any on Non-Empty Collections](#any-on-non-empty-collections)
  * [Count Equals Zero](#count-equals-zero)
  * [Count Greater Than Zero](#count-greater-than-zero)
  * [Count with Predicate (Empty)](#count-with-predicate-empty)
  * [Count with Predicate (Non-Empty)](#count-with-predicate-non-empty)
* [Conclusions](#conclusions)

<a name="reasons-and-introduction"></a>

## Reasons and introduction

In performance-critical loops, checking whether a sequence is empty or contains matching items can dramatically impact throughput and GC pressure. This benchmark compares:

1. `.Any()` variants on different collection types
2. `.Count() == 0` and `.Count() > 0` checks
3. `.Count(predicate)` for conditional counts

Results guide you to the fastest approach for presence or absence checks.

<a name="machine-information"></a>

## Machine information

```ini
BenchmarkDotNet v0.15.1
Windows 11 (10.0.26100)
.NET SDK 9.0.301
Host: .NET 9.0.6 (X64 RyuJIT AVX2)
```

<a name="benchmarks"></a>

## Benchmarks

All tests run on a collection of 10 000 integers.

<a name="any-on-empty-collections"></a>

### Any on Empty Collections

`Any()` should return false immediately, but implementations vary:

| Method              | Mean (ns) | Throughput (B/sec) |
| ------------------- | --------: | -----------------: |
| `List.Any()`        |     0.019 |     52 500 000 000 |
| `Enumerable.Any()`  |     0.035 |     28 600 000 000 |
| `ICollection.Any()` |     0.045 |     22 500 000 000 |
| `Array.Any()`       |     0.222 |      4 500 000 000 |

<a name="any-on-non-empty-collections"></a>

### Any on Non-Empty Collections

`Any()` should stop after finding the first element:

| Method             | Mean (ns) | Throughput (M ops/sec) |
| ------------------ | --------: | ---------------------: |
| `Collection.Any()` |      2.98 |                   0.34 |
| `Enumerable.Any()` |      2.98 |                   0.34 |
| `List.Any()`       |      2.99 |                   0.33 |
| `Array.Any()`      |      5.21 |                   0.19 |

<a name="count-equals-zero"></a>

### Count Equals Zero

Checking emptiness by counting all elements:

| Method                    | Mean (ns) | Throughput (B/sec) |
| ------------------------- | --------: | -----------------: |
| `Enumerable.Count() == 0` |     0.011 |     95 000 000 000 |
| `Array.Count == 0`        |     0.029 |     34 000 000 000 |
| `List.Count == 0`         |     0.045 |     22 100 000 000 |
| `ICollection.Count == 0`  |     0.269 |      3 700 000 000 |

<a name="count-greater-than-zero"></a>

### Count Greater Than Zero

Checking non-emptiness via count:

| Method                   | Mean (ns) | Throughput (B/sec) |
| ------------------------ | --------: | -----------------: |
| `Array.Count > 0`        |     0.068 |     14 700 000 000 |
| `List.Count > 0`         |     0.254 |      3 940 000 000 |
| `ICollection.Count > 0`  |     1.143 |   0.87 000 000 000 |
| `Enumerable.Count() > 0` |     2.992 |   0.33 000 000 000 |

<a name="count-with-predicate-empty"></a>

### Count with Predicate (Empty)

Counting matching items in an empty set:

| Method                         | Mean (ns) | Throughput (B/sec) |
| ------------------------------ | --------: | -----------------: |
| `List.Count(predicate)`        |     0.039 |     25 700 000 000 |
| `Array.Count(predicate)`       |     0.040 |     25 200 000 000 |
| `ICollection.Count(predicate)` |     0.244 |      4 090 000 000 |

<a name="count-with-predicate-non-empty"></a>

### Count with Predicate (Non-Empty)

Counting matching items when half the elements satisfy the predicate:

| Method                         | Mean (ns) | Throughput (B/sec) |
| ------------------------------ | --------: | -----------------: |
| `Array.Count(predicate)`       |     0.079 |     12 600 000 000 |
| `List.Count(predicate)`        |     0.253 |      3 950 000 000 |
| `ICollection.Count(predicate)` |     1.152 |   0.87 000 000 000 |

<a name="conclusions"></a>

## Conclusions

* **Empty scans:** `List.Any()` wins by a large margin; avoid `Array.Any()` for empty checks.
* **Existence tests:** `Any()` on any collection type is \~3 ns except arrays (\~5 ns).
* **Count-based emptiness:** `Enumerable.Count() == 0` is fastest but use `Count == 0` on lists for readability.
* **Count-based existence:** `Array.Count > 0` is very fast; avoid `Enumerable.Count() > 0`.
* **Predicate counts:** Inline `Count(predicate)` on arrays/lists is efficient (\~0.04 ns); `ICollection.Count(predicate)` is costly.

**Recommendation:** Use `.Any()` on lists or collections for presence checks, and rely on simple `Count == 0` for emptiness. For predicate-driven counts in tight loops, prefer list/array implementations or manual loops when maximum speed matters.
