using Benchmarks.Iterators.Services;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Iterators.Benchmarks;

public partial class IteratorBenchmarks
{
    /// <summary>
    ///     Testing with 'for' method.
    /// </summary>
    [BenchmarkCategory(Group.Array), Benchmark(Description = "For")]
    public int ForArray()
    {
        return TestArray.For();
    }

    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    [BenchmarkCategory(Group.Array), Benchmark(Description = "Foreach")]
    public int ForeachArray()
    {
        return TestArray.Foreach();
    }

    /// <summary>
    ///     Testing with 'Linq.Aggregate' methods.
    /// </summary>
    [BenchmarkCategory(Group.Array), Benchmark(Description = "Linq Aggregate")]
    public int? LinqArray()
    {
        return TestArray.LinqAggregate();
    }
    
    /// <summary>
    ///     Testing with 'Linq.Sum' methods.
    /// </summary>
    [BenchmarkCategory(Group.Array), Benchmark(Description = "Linq Sum")]
    public int? SumArray()
    {
        return TestArray.LinqSum();
    }
    
    /// <summary>
    ///     Testing with 'foreach(ref)' methods.
    /// </summary>
    [BenchmarkCategory(Group.Array), Benchmark(Description = "Ref Foreach")]
    public int RefForeachArray()
    {
        return TestArray.RefForeach();
    }
    
    /// <summary>
    ///     Testing with '.AsSpan + for' methods.
    /// </summary>
    [BenchmarkCategory(Group.Array), Benchmark(Description = "AsSpan + For")]
    public int SpanForArray()
    {
        return TestArray.SpanFor();
    }
}