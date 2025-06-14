# SortArrayByArray.SortBenchmarks Performance Benchmarks

## Purpose
To compare the throughput, latency, and memory allocation of three different “order” implementations (V1 baseline, V1 Improved, and V2) in our `SortArrayByArray` routine. We want to identify which variant delivers the best performance and lowest GC pressure under both small and large input sizes.

## Overview
We used BenchmarkDotNet v0.15.1 on Windows 11 (.NET 9.0.6, X64 RyuJIT AVX2) to measure each method’s mean execution time, throughput (ops/sec), and allocation per operation. Two input sizes were tested:

- **Small array**: 10 elements
- **Large array**: 100 000 elements

## Benchmark Results

| Method               | Size   | Mean (ns) | Ops/sec (M) | Allocated (B) | Ratio vs V1 |
|----------------------|-------:|----------:|------------:|--------------:|------------:|
| **V2 order**         | 10     | 16.80     | 59.53       | 176           | 0.58        |
| **V1 Improved**      | 10     | 25.70     | 38.91       | 256           | 0.89        |
| **V1 order** (base)  | 10     | 28.85     | 34.67       | 256           | 1.00        |
| **V2 order**         | 100 000| 16.82     | 59.44       | 176           | 0.51        |
| **V1 Improved**      | 100 000| 28.16     | 35.51       | 256           | 0.85        |
| **V1 order** (base)  | 100 000| 33.16     | 30.15       | 256           | 1.00        |

> _Note: “Ratio vs V1” shows each method’s mean time divided by the V1 baseline._

## Analysis
- **V2 order is fastest** in both scenarios, cutting mean time by ~42% (size 10) and ~49% (size 100 000) compared to the V1 baseline. Its throughput is ~70% higher, reaching ~59 M ops/sec :contentReference[oaicite:1]{index=1}.
- **Memory allocations** are also lower with V2 (176 B vs. 256 B), reducing GC pressure by ~31%.
- **V1 Improved** yields moderate gains: ~11% faster on small inputs and ~15% faster on large ones, but its memory footprint remains the same as the baseline.
- **Baseline V1 order** is the slowest and allocates the most memory, making it the least desirable for production.

## Conclusion
The **V2 order** implementation clearly outperforms both the original and the “Improved” V1 variants, delivering significantly lower latency, higher throughput, and reduced memory allocations.  
**Next steps**:
1. Integrate the V2 ordering method into the main branch.
2. Run mixed read/write and real-world data tests to validate these micro-benchmark gains under production-like workloads.
3. Profile the critical path in V2 to ensure no hidden bottlenecks emerge in more complex scenarios.  
