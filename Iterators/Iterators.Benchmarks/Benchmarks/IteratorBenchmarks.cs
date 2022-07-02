using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Iterators.Benchmarks.Services;

namespace Iterators.Benchmarks.Benchmarks;

/// <inheritdoc />
public class IteratorBenchmarks : BenchmarkBase
{
    /// <summary>
    ///     Testing with 'for' method.
    /// </summary>
    [Benchmark(Baseline = true)]
    public void For()
    {
        TestInputModels.For().Consume(Consumer);
    }
    
    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    [Benchmark]
    public void Foreach()
    {
        TestInputModels.Foreach().Consume(Consumer);
    }

    /// <summary>
    ///     Testing with 'Linq' methods.
    /// </summary>
    [Benchmark]
    public void Linq()
    {
        TestInputModels.Linq().Consume(Consumer);
    }
    
    /// <summary>
    ///     Testing with 'Yield' methods.
    /// </summary>
    [Benchmark]
    public void Yield()
    {
        TestInputModels.Yield().Consume(Consumer);
    }
}