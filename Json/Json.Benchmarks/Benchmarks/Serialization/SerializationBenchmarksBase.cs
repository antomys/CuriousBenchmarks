using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;
using Json.Benchmarks.Models;

namespace Json.Benchmarks.Benchmarks.Serialization;

/// <summary>
///     Serialization benchmarks base.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
public class SerializationBenchmarksBase
{
    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1000, 10000, 100000, 1000000)]
    public int CollectionSize { get; set; }
    
    /// <summary>
    ///     System.Text.Json options. <see cref="JsonSerializerOptions"/>.
    /// </summary>
    protected readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    /// <summary>
    ///     Options for <see cref="Maverick.Json.JsonSettings"/>.
    /// </summary>
    protected readonly Maverick.Json.JsonSettings MaverickSettings = new()
    {
        NamingStrategy = Maverick.Json.JsonNamingStrategy.CamelCase,
        Format = Maverick.Json.JsonFormat.None
    };

    /// <summary>
    ///     Collection of testing <see cref="TestModel"/>.
    /// </summary>
    protected List<TestModel> Persons = new();
    
    /// <summary>
    ///     Collection of testing <see cref="TestModelVirtual"/> for ZeroFormatter.
    /// </summary>
    protected IEnumerable<TestModelVirtual> PersonsVirtual = null!;

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        Faker<TestModel> faker = new();
        Randomizer.Seed = new Random(420);
        
        Persons = faker
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.Date, y => y.Date.Past())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int())
            .RuleFor(x => x.Summary, y => y.Random.String2(10))
            .Generate(CollectionSize);
        
        PersonsVirtual = TestModelVirtual.ToTestModelVirtual(Persons);
    }
}