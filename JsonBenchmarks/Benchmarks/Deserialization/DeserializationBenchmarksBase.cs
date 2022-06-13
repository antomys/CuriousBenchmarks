using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;
using JsonBenchmarks.Models;

namespace JsonBenchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization benchmarks base.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
public class DeserializationBenchmarksBase
{
    /// <summary>
    ///     Size of collection.
    /// </summary>
    [Params(1000, 10000, 100000, 1000000)]
    public int CollectionSize { get; set; }
    
    /// <summary>
    ///     Default Options for System.Text.Json
    /// </summary>
    protected readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    /// <summary>
    ///     Settings for Maverick Json.
    /// </summary>
    protected readonly Maverick.Json.JsonSettings MaverickSettings = new()
    {
        NamingStrategy = Maverick.Json.JsonNamingStrategy.CamelCase,
        Format = Maverick.Json.JsonFormat.None
    };

    /// <summary>
    ///     Collection of <see cref="TestModel"/> for creating various serialized initial data.
    /// </summary>
    protected List<TestModel> TestModels = null!;

    /// <summary>
    ///     Global setting up private fields.
    /// </summary>
    public void Setup()
    {
        Faker<TestModel> faker = new();
        Randomizer.Seed = new Random(420);
        TestModels = faker
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x=> x.Date, y => y.Date.Past())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int())
            .RuleFor(x => x.Summary, y => y.Random.String2(10))
            .Generate(CollectionSize);
    }
}