using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Bogus;
using MessagePack;

namespace JsonBenchmarks;

[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class DeserializationBenchmarks
{
    [Params(1000, 10000, 100000, 1000000)]
    public int CollectionSize { get; set; }
    
    private readonly JsonSerializerOptions _options = new()
    {
        
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private string _personsString = string.Empty;
    private byte[] _personsByteArray = default!;
    private string _personsJilString = string.Empty;

    [GlobalSetup]
    public void Setup()
    {
        Faker<TestModel.TestModel> faker = new();
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

    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public ICollection<TestModel.TestModel> ClassicDeserializer()
    {
        return JsonSerializer.Deserialize<ICollection<TestModel.TestModel>>(_personsString, _options)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel.TestModel> GeneratedDeserializer()
    {
        return JsonSerializer.Deserialize(_personsString, TestModel.TestModelJsonContext.Default.ICollectionTestModel)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel.TestModel> NewtonsoftDeserializer()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<TestModel.TestModel>>(_personsString)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel.TestModel> JilDeserializer()
    {
        return Jil.JSON.Deserialize<ICollection<TestModel.TestModel>>(_personsJilString)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel.TestModel> Utf8Deserializer()
    {
        return Utf8Json.JsonSerializer.Deserialize<ICollection<TestModel.TestModel>>(_personsString)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel.TestModel> SpanJsonDeserializer()
    {
        return SpanJson.JsonSerializer.Generic.Utf16.Deserialize<ICollection<TestModel.TestModel>>(_personsString)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel.TestModel> MsgPackDeserializer()
    {
        return MessagePackSerializer.Deserialize<ICollection<TestModel.TestModel>>(_personsByteArray);
    }
}