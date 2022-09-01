using BenchmarkDotNet.Attributes;
using Iterators.Benchmarks.Services;

namespace Iterators.Benchmarks.Benchmarks;

public partial class IteratorBenchmarks
{
    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    [BenchmarkCategory(Categories.Collection), Benchmark(Description = "Foreach. Array as ICollection")]
    public int ForeachICollectionArray()
    {
        return TestCollectionArray.Foreach();
    }

    /// <summary>
    ///     Testing with 'Linq.Aggregate' methods.
    /// </summary>
    [BenchmarkCategory(Categories.Collection), Benchmark(Description = "Ling Aggregate. Array as ICollection")]
    public int? LinqICollectionArray()
    {
        return TestCollectionArray.LinqAggregate();
    }
    
    /// <summary>
    ///     Testing with 'Linq.Sum' methods.
    /// </summary>
    [BenchmarkCategory(Categories.Collection), Benchmark(Description = "Ling Sum. Array as ICollection")]
    public int? SumICollectionArray()
    {
        return TestCollectionArray.LinqSum();
    }
    
    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    [BenchmarkCategory(Categories.Collection), Benchmark(Description = "Foreach. List as ICollection")]
    public int ForeachICollectionList()
    {
        return TestCollectionList.Foreach();
    }

    /// <summary>
    ///     Testing with 'Linq.Aggregate' methods.
    /// </summary>
    [BenchmarkCategory(Categories.Collection), Benchmark(Description = "Ling Aggregate. List as ICollection")]
    public int? LinqICollectionList()
    {
        return TestCollectionList.LinqAggregate();
    }
    
    /// <summary>
    ///     Testing with 'Linq.Sum' methods.
    /// </summary>
    [BenchmarkCategory(Categories.Collection), Benchmark(Description = "Ling Sum. List as ICollection")]
    public int? SumICollectionList()
    {
        return TestCollectionList.LinqSum();
    }
}