using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Bogus;
using LinqVsForVsForeach.Models;

namespace LinqVsForVsForeach;

/// <summary>
///     Linq vs For vs Foreach benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class LinqForForeachBenchmarks
{
    /// <summary>
    ///     Parameter for models count.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(10, 100, 1000, 10000, 100000, 1000000)]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public int ModelsCount { get; set; }

    private readonly Consumer _consumer = new();

    // Remark : hack to shut compiler up
    private static TestModel?[] _testInputModels = default!;
    
    /// <summary>
    ///     Cleans array.
    /// </summary>
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        Array.Clear(_testInputModels);
    }
    
    /// <summary>
    ///     Global setup of private parameters.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker<TestModel>();
        Randomizer.Seed = new Random(420);
        
        var test = faker
            .RuleFor(x=> x.TestInd, y=> y.Random.Int())
            .RuleFor(x=> x.TestString, y=> y.Random.String2(10))
            .RuleFor(x=> x.TestDateTime, y=> y.Date.Past())
            .Generate(ModelsCount);
        
        _testInputModels = test.ToArray();
    }

    /// <summary>
    ///     Testing with `for` method.
    /// </summary>
    [Benchmark(Baseline = true)]
    public void ForMethod()
    {
        var testOutputModels = new string[_testInputModels.Length];

        for (var i = 0; i < _testInputModels.Length; i++)
        {
            if (_testInputModels[i] is null)
                continue;
            
            testOutputModels[i] = JsonSerializer.Serialize(_testInputModels[i]);
        }
        
        _consumer.Consume(testOutputModels);
    }
    
    /// <summary>
    ///     Testing with `Foreach` method.
    /// </summary>
    [Benchmark]
    public void ForeachMethod()
    {
        var testOutputModels = new List<string>(_testInputModels.Length);
        
        foreach (var testModel in _testInputModels)
        {
            if (testModel is null)
                continue;
            
            testOutputModels.Add(JsonSerializer.Serialize(testModel));
        }
        
        _consumer.Consume(testOutputModels);
    }

    /// <summary>
    ///     Testing with `Linq` methods.
    /// </summary>
    [Benchmark]
    public void LinqMethod()
    {
        _testInputModels
            .Where(testModel=> testModel is not null)
            .Select(testModel => JsonSerializer.Serialize(testModel))
            .Consume(_consumer);
    }
}