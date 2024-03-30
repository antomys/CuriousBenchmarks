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
[MemoryDiagnoser, CategoriesColumn, AllStatisticsColumn, Orderer(SummaryOrderPolicy.FastestToSlowest),
 GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams), MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter, ExcludeFromCodeCoverage]
public class BenchmarkBase
{
    /// <summary>
    ///     Benchmark Consumer.
    /// </summary>
    protected readonly Consumer Consumer = new();

    /// <summary>
    ///     Collection of <see cref="StringsTestModel" /> for benchmarks.
    /// </summary>
    protected StringsTestModel TestStringArray = null!;

    /// <summary>
    ///     Gets or sets flag whether stack should be triggered or other collections.
    /// </summary>
    [Params(true, false)]
    public bool IsStack { get; set; }

    /// <summary>
    ///     Global setup.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        //stackalloc is used when sum of chars is less than 64. So we do generate random bigger that 64 to eliminate this behaviour.

        var from = IsStack ? 65 : 5;
        var to = IsStack ? 100 : 20;

        TestStringArray = new Faker<StringsTestModel>()
            .RuleFor(x => x.Values, y => [y.Random.String2(from, to), y.Random.String2(from, to)])
            .Generate(1)[0];
    }
}