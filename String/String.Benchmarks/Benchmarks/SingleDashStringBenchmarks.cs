using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Bogus;
using String.Benchmarks.Benchmarks.Abstractions;
using String.Benchmarks.Models;
using String.Benchmarks.Services;

namespace String.Benchmarks.Benchmarks;

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
    [BenchmarkCategory(GroupConstants.DashView), Benchmark]
    public void DashFormatSpanOwner()
    {
        SpanOwnerStringService.ToDashFormat(TestStringArray.Values).Consume(Consumer);
    }
    
    /// <summary>
    ///     Dash format with SpanOwner.
    /// </summary>
    [BenchmarkCategory(GroupConstants.DashView), Benchmark]
    public void DashFormatRegex()
    {
        RegexStringService.ToDashFormat(TestStringArray.Values).Consume(Consumer);
    }

    /// <summary>
    ///     Dash format with ArrayPool.
    /// </summary>
    [BenchmarkCategory(GroupConstants.DashView), Benchmark]
    public void DashFormatArrayPool()
    {
        ArrayPoolStringService.ToDashFormat(TestStringArray.Values).Consume(Consumer);
    }
}