﻿using BenchmarkDotNet.Attributes;
using Benchmarks.Iterators.Services;

namespace Benchmarks.Iterators.Benchmarks;

public partial class IteratorBenchmarks
{
    /// <summary>
    ///     Testing with 'for' method.
    /// </summary>
    [BenchmarkCategory(Group.List), Benchmark(Description = "For", Baseline = true)]
    public int ForList()
    {
        return TestList.For();
    }

    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    [BenchmarkCategory(Group.List), Benchmark(Description = "Foreach")]
    public int ForeachList()
    {
        return TestList.Foreach();
    }

    /// <summary>
    ///     Testing with 'Linq.Aggregate' methods.
    /// </summary>
    [BenchmarkCategory(Group.List), Benchmark(Description = "Linq Aggregate")]
    public int? LinqList()
    {
        return TestList.LinqAggregate();
    }

    /// <summary>
    ///     Testing with 'Linq.Sum' methods.
    /// </summary>
    [BenchmarkCategory(Group.List), Benchmark(Description = "Linq Sum")]
    public int? SumList()
    {
        return TestList.LinqSum();
    }

    /// <summary>
    ///     Testing with 'foreach(ref)' methods.
    /// </summary>
    [BenchmarkCategory(Group.List), Benchmark(Description = "Ref Foreach")]
    public int RefForeachList()
    {
        return TestList.RefForeach();
    }

    /// <summary>
    ///     Testing with '.AsSpan + for' methods.
    /// </summary>
    [BenchmarkCategory(Group.List), Benchmark(Description = "AsSpan + For")]
    public int SpanForList()
    {
        return TestList.SpanFor();
    }
}