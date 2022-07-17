using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using String.Benchmarks.Benchmarks.Abstractions;
using String.Benchmarks.Services;

namespace String.Benchmarks.Benchmarks;

/// <summary>
///     Benchmarking building link.
/// </summary>
public class DashStringBenchmarks : BenchmarkCollectionBase
{
    /// <summary>
    ///     Dash format with SpanOwner.
    /// </summary>
    [BenchmarkCategory(GroupConstants.DashView), Benchmark]
    public void DashFormatSpanOwner()
    {
        TestStringArray
            .Select(stringsTestModel => SpanOwnerStringService.ToDashFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }
    
    /// <summary>
    ///     Dash format with SpanOwner.
    /// </summary>
    [BenchmarkCategory(GroupConstants.DashView), Benchmark]
    public void DashFormatRegex()
    {
        TestStringArray
            .Select(stringsTestModel => RegexStringService.ToDashFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }

    /// <summary>
    ///     Dash format with ArrayPool.
    /// </summary>
    [BenchmarkCategory(GroupConstants.DashView), Benchmark]
    public void DashFormatArrayPool()
    {
        TestStringArray
            .Select(stringsTestModel => ArrayPoolStringService.ToDashFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }
}