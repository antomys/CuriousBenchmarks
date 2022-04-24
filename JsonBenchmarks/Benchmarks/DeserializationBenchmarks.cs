using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Bogus;
using JsonBenchmarks.Models;
using MessagePack;

namespace JsonBenchmarks.Benchmarks;

/// <summary>
///     Deserialization benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class DeserializationBenchmarks
{
    /// <summary>
    ///     Size of collection.
    /// </summary>
    [Params(1000, 10000, 100000, 1000000)]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public int CollectionSize { get; set; }
    
    private readonly JsonSerializerOptions _options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    private string _personsString = string.Empty;
    private byte[] _personsByteArray = default!;
    private string _personsJilString = string.Empty;

    /// <summary>
    ///     Global setting up private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        Faker<TestModel> faker = new();
        Randomizer.Seed = new Random(420);
        var persons = faker
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x=> x.Date, y => y.Date.PastOffset())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int(0))
            .RuleFor(x => x.Summary, y => y.Random.String2(5))
            .Generate(CollectionSize);

        _personsByteArray = MessagePackSerializer.Serialize(persons);
        _personsString = JsonSerializer.Serialize(persons, _options);
        _personsJilString = Jil.JSON.Serialize(persons);
    }

    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public ICollection<TestModel> ClassicDeserializer()
    {
        return JsonSerializer.Deserialize<ICollection<TestModel>>(_personsString, _options)!;
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel> GeneratedDeserializer()
    {
        return JsonSerializer.Deserialize(_personsString, TestModelJsonContext.Default.ICollectionTestModel)!;
    }
    
    /// <summary>
    ///     Deserialize with Newtonsoft.Json.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel> NewtonsoftDeserializer()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<TestModel>>(_personsString)!;
    }
    
    /// <summary>
    ///     Deserialize with Jil.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel> JilDeserializer()
    {
        return Jil.JSON.Deserialize<ICollection<TestModel>>(_personsJilString)!;
    }
    
    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel> Utf8Deserializer()
    {
        return Utf8Json.JsonSerializer.Deserialize<ICollection<TestModel>>(_personsString)!;
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel> SpanJsonDeserializer()
    {
        return SpanJson.JsonSerializer.Generic.Utf16.Deserialize<ICollection<TestModel>>(_personsString)!;
    }
    
    /// <summary>
    ///     Deserialize with MessagePack.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel> MsgPackDeserializer()
    {
        return MessagePackSerializer.Deserialize<ICollection<TestModel>>(_personsByteArray);
    }
}