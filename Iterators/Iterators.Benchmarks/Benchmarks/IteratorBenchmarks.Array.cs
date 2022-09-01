using BenchmarkDotNet.Attributes;
using Iterators.Benchmarks.Services;

namespace Iterators.Benchmarks.Benchmarks;

public partial class IteratorBenchmarks
{
    /// <summary>
    ///     Testing with 'for' method.
    /// </summary>
    [BenchmarkCategory(Categories.Array), Benchmark(Description = "For. Array")]
    public int ForArray()
    {
        return TestArray.For();
    }

    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    [BenchmarkCategory(Categories.Array), Benchmark(Description = "Foreach. Array")]
    public int ForeachArray()
    {
        return TestArray.Foreach();
    }

    /// <summary>
    ///     Testing with 'Linq.Aggregate' methods.
    /// </summary>
    [BenchmarkCategory(Categories.Array), Benchmark(Description = "Ling Aggregate. Array")]
    public int? LinqArray()
    {
        return TestArray.LinqAggregate();
    }
    
    /// <summary>
    ///     Testing with 'Linq.Sum' methods.
    /// </summary>
    [BenchmarkCategory(Categories.Array), Benchmark(Description = "Ling Sum. Array")]
    public int? SumArray()
    {
        return TestArray.LinqSum();
    }
    
    /// <summary>
    ///     Testing with 'foreach(ref)' methods.
    /// </summary>
    [BenchmarkCategory(Categories.Array), Benchmark(Description = "Ref Foreach. Array")]
    public int RefForeachArray()
    {
        return TestArray.RefForeach();
    }
    
    /// <summary>
    ///     Testing with '.AsSpan + for' methods.
    /// </summary>
    [BenchmarkCategory(Categories.Array), Benchmark(Description = "AsSpan + For. Array")]
    public int SpanForArray()
    {
        return TestArray.SpanFor();
    }
}