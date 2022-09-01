using BenchmarkDotNet.Attributes;
using Iterators.Benchmarks.Services;

namespace Iterators.Benchmarks.Benchmarks;

public partial class IteratorBenchmarks
{
    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    [BenchmarkCategory(Categories.Collection), Benchmark(Description = "Foreach. ICollection")]
    public int ForeachICollection()
    {
        return TestCollection.Foreach();
    }

    /// <summary>
    ///     Testing with 'Linq.Aggregate' methods.
    /// </summary>
    [BenchmarkCategory(Categories.Collection), Benchmark(Description = "Ling Aggregate. ICollection")]
    public int? LinqICollection()
    {
        return TestCollection.LinqAggregate();
    }
    
    /// <summary>
    ///     Testing with 'Linq.Sum' methods.
    /// </summary>
    [BenchmarkCategory(Categories.Collection), Benchmark(Description = "Ling Sum. ICollection")]
    public int? SumICollection()
    {
        return TestCollection.LinqSum();
    }
}