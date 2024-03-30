using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks.String.Benchmarks.Abstractions;
using Benchmarks.String.Services;

namespace Benchmarks.String.Benchmarks;

/// <summary>
///     Benchmarking building link.
/// </summary>
[ExcludeFromCodeCoverage]
public class DashStringBenchmarks : BenchmarkCollectionBase
{
    /// <summary>
    ///     Dash format with SpanOwner.
    /// </summary>
    [BenchmarkCategory(Group.DashView), Benchmark]
    public void DashFormatSpanOwner()
    {
        TestStringArray
            .Select(stringsTestModel => SpanOwnerStringService.ToDashFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }

    /// <summary>
    ///     Dash format with SpanOwner.
    /// </summary>
    [BenchmarkCategory(Group.DashView), Benchmark]
    public void DashFormatRegex()
    {
        TestStringArray
            .Select(stringsTestModel => RegexStringService.ToDashFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }

    /// <summary>
    ///     Dash format with ArrayPool.
    /// </summary>
    [BenchmarkCategory(Group.DashView), Benchmark]
    public void DashFormatArrayPool()
    {
        TestStringArray
            .Select(stringsTestModel => ArrayPoolStringService.ToDashFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }
}