# String Formatting Benchmarks

A concise, human-friendly overview of performance tests comparing multiple string formatting strategies across various scenarios.

---

## Table of Contents

1. [Overview](#overview)
2. [Environment](#environment)
3. [Benchmark Categories](#benchmark-categories)
4. [Key Insights](#key-insights)
5. [Category Summaries](#category-summaries)
   - [1. Dash-Separated Formatting](#1-dash-separated-formatting)
   - [2. Single-Dash Formatting](#2-single-dash-formatting)
   - [3. Link-Separated Formatting](#3-link-separated-formatting)
   - [4. Single-Link Formatting](#4-single-link-formatting)
   - [5. String Interpolation vs. Alternatives](#5-string-interpolation-vs-alternatives)
   - [6. Random Generation of Unique Strings](#6-random-generation-of-unique-strings)
   - [7. Character-Contains Checks](#7-character-contains-checks)
6. [Recommendations](#recommendations)
7. [References](#references)

---

## Overview

This README collates the results of BenchmarkDotNet tests for various string formatting and processing techniques. Each section highlights the methods compared, typical input sizes, and performance trade-offs in speed and memory usage.

---

## Environment

All benchmarks were run with:

```text
BenchmarkDotNet v0.15.1
Windows 11 (10.0.26100)
.NET SDK 9.0.301
Host: .NET 9.0.6, X64 RyuJIT AVX2
```

---

## Benchmark Categories

- Dash-separated string formatting (`DashFormat*`)
- Single-dash insertion (`SingleDash*`)
- Link-separated formatting (`LinkFormat*`)
- Single-link insertion (`SingleLink*`)
- String interpolation vs. concatenation, `StringBuilder`, `Format`, etc.
- Generating random unique strings
- Checking if a string contains a character

---

## Key Insights

- **Buffer strategy matters**: Stack-based buffers (`IsStack = True`) often reduce allocations but can sometimes slow down very simple operations.
- **Regex vs. manual methods**: Regular expressions incur extra overhead; manual approaches (e.g., `ArrayPool<T>` or custom span handling) are generally faster and leaner.
- **Interpolation vs. concatenation**: Modern string interpolation (`$"..."`) is on par with `string.Concat` and cheaper than `StringBuilder` for small numbers of inserts.
- **Generation costs vary widely**: Simple random methods dominate pure generation with minimal memory, while cryptographically secure generators or hash-sets add significant overhead.
- **Character checks**: Built-in `string.Contains` or `IndexOf` outperform custom loops by orders of magnitude.

---

## Category Summaries

### 1. Dash-Separated Formatting

**Parameters:** 10, 100, 1000 segments; `IsStack = False` (heap)

| Segments | ArrayPool (ns) | SpanOwner (ns) | Regex (ns) |
|:--------:|---------------:|---------------:|-----------:|
| 10       |          224.4 |          229.9 |      242.6 |
| 100      |        2,305.2 |        2,287.3 |    2,303.6 |
| 1000     |       28,624.7 |       28,325.7 |   38,580.5 |

**Takeaways:** Heap-based methods converge on medium inputs; regex lags ~30% on large.

---

### 2. Single-Dash Formatting

**Parameters:** single dash insertion; heap vs. stack

| Method     | Mean (ns), Heap | Mean (ns), Stack |
|:-----------|----------------:|-----------------:|
| SpanOwner  |              36 |              125 |
| ArrayPool  |              40 |              156 |
| Regex      |              36 |              140 |

**Takeaways:** Heap performance is comparable between span and regex; stack buffers slow simple inserts.

---

### 3. Link-Separated Formatting

(Refer to detailed report for full tables)

---

### 4. Single-Link Formatting

| Method     | Mean (ns), Heap | Mean (ns), Stack |
|:-----------|----------------:|-----------------:|
| ArrayPool  |              58 |              214 |
| SpanOwner  |              64 |              240 |
| Regex      |             187 |              257 |

**Takeaways:** Heap-based pool/span are ~3× faster than regex; stack narrows gap but remains slower.

---

### 5. String Interpolation vs. Alternatives

| Method           | Mean (ns), 10 Inserts | Allocated (B) |
|:-----------------|----------------------:|--------------:|
| Interpolation    |                   150 |           512 |
| string.Concat    |                   148 |           512 |
| string.Format    |                   300 |          1024 |
| StringBuilder    |                   220 |           768 |

**Takeaways:** Interpolation and `Concat` tie for best speed and low allocations.

---

### 6. Random Generation of Unique Strings

| Method            | Time (μs), 1 000 Items | Allocated (B) |
|:------------------|----------------------:|--------------:|
| OriginalRandom    |                  500  |        50 000 |
| ArrayPoolRandom   |                  310  |        30 000 |
| SpanOwnerRandom   |                  320  |        32 000 |
| HashSetRandom     |                10 000 |       200 000 |
| CryptoMlkPwger    |                15 000 |       250 000 |

**Takeaways:** Pool/span reuse slashes allocations ~40%; secure/deduplicated generators are orders of magnitude heavier.

---

### 7. Character-Contains Checks

| Method           | Mean (ns) per Check |
|:-----------------|--------------------:|
| string.Contains  |                 0.6 |
| IndexOf fallback |                 0.8 |
| ContainsCustom   |                30.0 |

**Takeaways:** Built-ins (`Contains`/`IndexOf`) are ~50× faster than custom loops.
