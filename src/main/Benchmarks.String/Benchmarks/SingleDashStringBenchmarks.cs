using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Benchmarks.String.Benchmarks.Abstractions;
using Benchmarks.String.Services;

namespace Benchmarks.String.Benchmarks;

/// <summary>
///     Benchmarking building link.
/// </summary>
/// <summary>
///     Base abstraction for benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class SingleDashStringBenchmarks : BenchmarkBase
{
    /// <summary>
    ///     Dash format with SpanOwner.
    /// </summary>
    [BenchmarkCategory(Group.DashView), Benchmark]
    public void DashFormatSpanOwner()
    {
        SpanOwnerStringService.ToDashFormat(TestStringArray.Values).Consume(Consumer);
    }
    
    /// <summary>
    ///     Dash format with SpanOwner.
    /// </summary>
    [BenchmarkCategory(Group.DashView), Benchmark]
    public void DashFormatRegex()
    {
        RegexStringService.ToDashFormat(TestStringArray.Values).Consume(Consumer);
    }

    /// <summary>
    ///     Dash format with ArrayPool.
    /// </summary>
    [BenchmarkCategory(Group.DashView), Benchmark]
    public void DashFormatArrayPool()
    {
        ArrayPoolStringService.ToDashFormat(TestStringArray.Values).Consume(Consumer);
    }
}