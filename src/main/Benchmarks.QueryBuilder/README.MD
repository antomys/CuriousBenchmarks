# QueryBuilderBenchmarks Performance Benchmarks

## Purpose
To compare various query-string construction strategies in our `QueryBuilder` library, measuring raw throughput, allocation pressure, and relative efficiency across different batch sizes.

## Overview
Benchmarks were run with BenchmarkDotNet v0.15.1 on Windows 11 (.NET 9.0.6, X64 RyuJIT AVX2). We measured mean execution time (ns), operations per second (M ops/sec), and bytes allocated per operation for each method, using QueryCount settings of 1, 2, 5, and 10.

## Benchmark Results (QueryCount = 1)

| Method                    | Mean (ns) | Ops/sec (M) | Allocated (B) | Ratio vs Dictionary |
|---------------------------|----------:|------------:|--------------:|--------------------:|
| QueryStringCreateConcat   |     34.14 |       29.29 |           128 |                0.37 |
| QueryConcatString         |     36.00 |       27.78 |           152 |                0.44 |
| LinqQuerySpanVer2         |     43.78 |       22.84 |            80 |                0.23 |
| QueryAspNetCore           |     45.73 |       21.87 |           232 |                0.67 |
| LinqQueryAggregate        |     50.25 |       19.90 |           184 |                0.53 |
| **QueryDictionary** (base)|     56.97 |       17.55 |           344 |                1.00 |
| QueryFormUrlEncodedContent|    190.05 |        5.26 |           744 |                2.16 |

> _Full results for QueryCount = 2, 5, 10 follow the same ordering and trends._

## Analysis
- **QueryStringCreateConcat** leads for small batches, with 29 M ops/sec and only 128 B allocated—over 60 % faster than the dictionary baseline.
- **LinqQuerySpanVer2** allocates the least (80 B) and still achieves 22.8 M ops/sec, making it the best low-allocation option.
- The **baseline** (`QueryDictionary`) sits in the middle (17.6 M ops/sec, 344 B), while `FormUrlEncodedContent` is the slowest and heaviest (5.3 M ops/sec, 744 B).
- As QueryCount increases, concatenation-based methods remain on top, Span-based approaches follow, and heavy allocation strategies fall further behind.

## Conclusion
For high-performance query construction:
1. Use **QueryStringCreateConcat** as the default for QueryCount ≤ 5.
2. Choose **LinqQuerySpanVer2** when minimal allocations are critical.
3. Avoid heavy allocations (e.g., FormUrlEncodedContent) in performance-sensitive paths.

---

# UriCombineBenchmarks Performance Benchmarks

## Purpose
To evaluate different strategies for combining base/relative segments into a URI, comparing string-based and `System.Uri`-based approaches.

## Overview
Using BenchmarkDotNet v0.15.1 on Windows 11 (.NET 9.0.6, X64 RyuJIT AVX2), we measured mean time (ns), ops/sec, and allocations for each of twelve methods across two categories: raw string URLs and `Uri` instances.

## Benchmark Results

| Method                       | Category   | Mean (ns) | Ops/sec (M) | Allocated (B) | Ratio vs StringUriSpan |
|------------------------------|-----------:|----------:|------------:|--------------:|-----------------------:|
| StringUriCombineCached       | String Url |     53.11 |       18.83 |           176 |                   0.78 |
| StringUriAppend              | String Url |     54.64 |       18.30 |           176 |                   0.80 |
| **StringUriSpan**            | String Url |     68.20 |       14.66 |           256 |                   1.00 |
| StringUriCombine             | String Url |     71.35 |       14.02 |           232 |                   0.91 |
| StringUriSwitch              | String Url |     81.20 |       12.32 |           232 |                   0.91 |
| StringUriBuilderTryCreate    | String Url |    473.50 |        2.11 |           840 |                   3.28 |
| UriFastAppend                | Uri Url    |     53.93 |       18.54 |           176 |                   0.74 |
| UriSpan                      | Uri Url    |     65.10 |       15.36 |           256 |                   0.90 |
| **NewUri**                   | Uri Url    |     72.71 |       13.75 |           136 |                   1.00 |
| UriCombine                   | Uri Url    |     69.67 |       14.35 |           232 |                   1.08 |
| UriBuilderTryCreate          | Uri Url    |     75.87 |       13.18 |           192 |                   1.11 |
| UriAppend                    | Uri Url    |    135.25 |        7.39 |           248 |                   1.98 |

## Analysis
- **Cached/append methods** (`StringUriCombineCached`, `StringUriAppend`, `UriFastAppend`) are the fastest (~53 ns) with only 176 B allocated.
- Baseline **Span-based** (`StringUriSpan`, `UriSpan`) methods cost ~68 ns and allocate 256 B—still efficient but slower than cached variants.
- **Builder-pattern** approaches add significant overhead (string builder ~473 ns, 840 B; URI builder ~76 ns, 192 B) and should be avoided in hot paths.
- The **`new Uri(...)`** option balances readability and performance (73 ns, 136 B), making it a strong general-purpose choice.

## Conclusion
For high-performance URI combination:
1. Use **cached/append** routines in tight loops.
2. Choose **`new Uri(...)`** for clarity with moderate overhead.
3. Avoid heavy builder patterns in performance-critical code.  
