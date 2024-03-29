using Benchmarks.Iterators.Services;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks.Iterators.Models;

namespace Benchmarks.Iterators.Benchmarks;

/// <inheritdoc />
public partial class IteratorBenchmarks
{
    /// <summary>
    ///     Testing with 'for' method.
    /// </summary>
    [BenchmarkCategory(Group.Serializing), Benchmark(Description = $"For serialization {nameof(SimpleModel)}", Baseline = true)]
    public void For()
    {
        TestInputModels.For().Consume(Consumer);
    }
    
    /// <summary>
    ///     Testing with 'for' method.
    /// </summary>
    [BenchmarkCategory(Group.Serializing), Benchmark(Description = $"ArrayPool + For serialization {nameof(SimpleModel)}")]
    public void ForArrayPool()
    {
        TestInputModels.ForArrayPool().Consume(Consumer);
    }
    
    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    [BenchmarkCategory(Group.Serializing), Benchmark(Description = $"Foreach serialization {nameof(SimpleModel)}")]
    public void Foreach()
    {
        TestInputModels.Foreach().Consume(Consumer);
    }

    /// <summary>
    ///     Testing with 'Linq' methods.
    /// </summary>
    [BenchmarkCategory(Group.Serializing), Benchmark(Description = $"Linq serialization {nameof(SimpleModel)}")]
    public void Linq()
    {
        TestInputModels.Linq().Consume(Consumer);
    }
    
    /// <summary>
    ///     Testing with 'Yield' methods.
    /// </summary>
    [BenchmarkCategory(Group.Serializing), Benchmark(Description = $"Yield serialization {nameof(SimpleModel)}")]
    public void Yield()
    {
        TestInputModels.Yield().Consume(Consumer);
    }
}