using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Benchmarks.String.Models;
using Bogus;

namespace Benchmarks.String.Benchmarks.Abstractions;

/// <summary>
///     Base abstraction for benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class BenchmarkBase
{
    /// <summary>
    ///     Gets or sets flag whether stack should be triggered or other collections.
    /// </summary>
    [Params(true, false)]
    public bool IsStack { get; set; }

    /// <summary>
    ///     Collection of <see cref="StringsTestModel"/> for benchmarks.
    /// </summary>
    protected StringsTestModel TestStringArray = null!;

    /// <summary>
    ///     Benchmark Consumer.
    /// </summary>
    protected readonly Consumer Consumer = new();

    /// <summary> 
    ///   Global setup.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        //stackalloc is used when sum of chars is less than 64. So we do generate random bigger that 64 to eliminate this behaviour.
        TestStringArray = IsStack
            ? new Faker<StringsTestModel>()
                .RuleFor(x => x.Values, y => new[] {y.Random.String2(5, 20), y.Random.String2(5, 20)})
                .Generate(1)[0]
            : new Faker<StringsTestModel>()
                .RuleFor(x => x.Values, y => new[] {y.Random.String2(65, 100), y.Random.String2(40, 100)})
                .Generate(1)[0];
    }
}