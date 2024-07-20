using System.Diagnostics.CodeAnalysis;
using System.Linq.Dynamic.Core;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Bogus;
using PredicateParser;

namespace Benchmarks.DynamicPredicateParser;

/// <summary>
///     Distinct/GroupBy benchmarks.
/// </summary>
[MemoryDiagnoser, CategoriesColumn, AllStatisticsColumn, Orderer(SummaryOrderPolicy.FastestToSlowest),
 GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory), MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter, ExcludeFromCodeCoverage]
public class ParserBenchmarks
{
    private const string Predicate = "Id==\"id\"&&Number==123";

    private readonly Consumer _consumer = new();
    private TestModel[] _testModels = [];

    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(100, 1000, 10000)]
    public int GenerationSize { get; set; }

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker<TestModel>()
            .RuleFor(x => x.Id, faker => faker.Random.String2(10))
            .RuleFor(x => x.Number, faker => faker.Random.Int())
            .Generate(GenerationSize - 1);
        
        faker.Add(new TestModel
        {
            Id = "id",
            Number = 123
        });

        _testModels = faker.ToArray();
    }

    /// <summary>
    ///     Testing GroupBy and Take.
    /// </summary>
    [Benchmark(Baseline = true)]
    public TestModel? DynamicCore()
    {
        var predicate = DynamicExpressionParser
            .ParseLambda<TestModel, bool>(
                ParsingConfig.Default,
                createParameterCtor: true,
                Predicate)
            .Compile();

        return _testModels.FirstOrDefault(predicate);
    }
    
    /// <summary>
    ///     Testing GroupBy and Take.
    /// </summary>
    [Benchmark]
    public TestModel? PredicateParser()
    {
        var predicate = PredicateParser<TestModel>.Parse(Predicate).Compile();

        return _testModels.FirstOrDefault(predicate);
    }
}