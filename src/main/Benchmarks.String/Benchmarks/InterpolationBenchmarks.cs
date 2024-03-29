using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Benchmarks.String.Models;
using Benchmarks.String.Services;
using Bogus;

namespace Benchmarks.String.Benchmarks;

/// <summary>
///     Interpolation benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class InterpolationBenchmarks
{
    private readonly Consumer _consumer = new();
    private List<InterpolationModel> _interpolationModel = null!;

    /// <summary>
    ///     Parameter for models count.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(10, 100, 1000, 10000, 100000, 1000000)]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public int OperationsCount { get; set; }
    
    /// <summary>
    ///     Global setup.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        _interpolationModel =
            new Faker<InterpolationModel>()
                .RuleFor(x => x.FirstValue, y => y.Random.String2(10))
                .RuleFor(x => x.SecondValue, y => y.Random.String2(10))
                .Generate(OperationsCount);
    }
    
    /// <summary>
    ///     Combines with interpolation.
    /// </summary>
    [Benchmark(Baseline = true)]
    public void Interpolate()
    {
        _interpolationModel.Select(model => InterpolationService.Interpolate(model.FirstValue, model.SecondValue)).Consume(_consumer);
    }
    
    /// <summary>
    ///     Combines with string.Format.
    /// </summary>
    [Benchmark]
    public void Format()
    {
        _interpolationModel.Select(model => InterpolationService.Format(model.FirstValue, model.SecondValue)).Consume(_consumer);
    }
    
    /// <summary>
    ///     Combines with string.Concat.
    /// </summary>
    [Benchmark]
    public void Concat()
    { 
        _interpolationModel.Select(model => InterpolationService.Concat(model.FirstValue, model.SecondValue)).Consume(_consumer);
    }
   
    /// <summary>
    ///     Combines with StringBuilder.
    /// </summary>
    [Benchmark]
    public void StringBuilderAppend()
    {
        _interpolationModel.Select(model => InterpolationService.StringBuilderAppend(model.FirstValue, model.SecondValue)).Consume(_consumer);
    }
    
    /// <summary>
    ///     Combines with StringBuilder.
    /// </summary>
    [Benchmark]
    public void StaticStringBuilderAppend()
    {
        _interpolationModel.Select(model => InterpolationService.StaticStringBuilderAppend(model.FirstValue, model.SecondValue)).Consume(_consumer);
    }
   
    /// <summary>
    ///     Combines with string.Create.
    /// </summary>
    [Benchmark]
    public void Create()
    { 
        _interpolationModel.Select(model => InterpolationService.Create(model.FirstValue, model.SecondValue)).Consume(_consumer);
    }
}