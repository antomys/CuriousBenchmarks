# Stopwatch Timing Comparison Benchmarks

A concise, human-friendly overview of performance tests comparing two methods of reading elapsed time from `System.Diagnostics.Stopwatch`.

---

## Overview

This document summarizes BenchmarkDotNet results for two approaches:

1. **Elapsed Property**: Reading `stopwatch.Elapsed`.
2. **Static API**: Calling `Stopwatch.GetElapsedTime(Stopwatch.GetTimestamp())` to avoid `TimeSpan` allocation.

The goal is to understand the performance trade-offs between simplicity and low-level access.

---

## Environment

```text
BenchmarkDotNet v0.15.1  
Windows 11 (10.0.26100.4351/24H2)  
.NET SDK 9.0.301  
Host runtime: .NET 9.0.6 (X64 RyuJIT AVX2)
```

---

## Benchmark Results

| Method                                                       | Mean (ns) | StdDev (ns) | Min (ns) | Max (ns)  | Throughput (M ops/s) | Relative |
|--------------------------------------------------------------|----------:|------------:|---------:|----------:|---------------------:|---------:|
| **Elapsed Property**<br>`stopwatch.Elapsed`                  |     26.94  |       0.08  |   26.84  |    27.09  |               37.12  | **1.00×**|
| **Static API**<br>`GetElapsedTime(GetTimestamp())`           |     29.12  |       0.52  |   28.63  |    30.14  |               34.34  | **1.08×**|

> *Note: No heap allocations were observed for either method.*

Below is a visual comparison of the mean execution times:

*(Refer to the chart above for a clear side-by-side view.)*

---

## Interpretation

- The **Elapsed Property** is marginally faster (~26.9 ns) than the **Static API** (~29.1 ns), resulting in an ~8% speed advantage.
- Both methods operate in under 30 ns, suitable for high-frequency timing scenarios.
- Use the static API when avoiding `TimeSpan` allocations is critical; otherwise, the simple `Elapsed` property is recommended.

---

## Recommendations

- **Default** to `stopwatch.Elapsed` for clarity and slightly better performance.
- **Use** `Stopwatch.GetElapsedTime(Stopwatch.GetTimestamp())` only when you specifically need a timestamp-only API without allocating a `TimeSpan`.

---