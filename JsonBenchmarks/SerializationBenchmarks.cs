using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using Bogus;
using MessagePack;

namespace JsonBenchmarks;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class SerializationBenchmarks
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private List<TestModel.TestModel> _persons = new();

    [GlobalSetup]
    public void Setup()
    {
        Faker<TestModel.TestModel> faker = new();
        Randomizer.Seed = new Random(420);
        _persons = faker
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.Date, y => y.Date.Past())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int())
            .RuleFor(x => x.Summary, y => y.Random.String2(5))
            .Generate(100000);
        
        /*Faker<TestModelMessagePack> fakerMsgPack = new();
        _personsMsgPack = fakerMsgPack
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.Date, y => y.Date.Past())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int())
            .RuleFor(x => x.Summary, y => y.Random.String2(5))
            .Generate(1000);*/
    }

    [BenchmarkCategory("Stream"), Benchmark(Baseline = true)]
    public MemoryStream ClassicSerializer()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, _persons, _options);

        return memoryStream;
    }
    
    [BenchmarkCategory("Stream"), Benchmark]
    public MemoryStream GeneratedSerializer()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, _persons, TestModel.TestModelJsonContext.Default.ICollectionTestModel);

        return memoryStream;
    }
    
    [BenchmarkCategory("Stream"), Benchmark]
    public MemoryStream Utf8StreamSerializer()
    {
        var memoryStream = new MemoryStream();
        Utf8Json.JsonSerializer.Serialize(memoryStream, _persons);

        return memoryStream;
    }
    
    [BenchmarkCategory("Stream"), Benchmark]
    public MemoryStream MsgPackStreamSerializer()
    {
        var memoryStream = new MemoryStream();
        MessagePackSerializer.Serialize(memoryStream, _persons);

        return memoryStream;
    }

    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public string ClassicStringSerializer()
    {
        return JsonSerializer.Serialize(_persons, _options);
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public string GeneratedStringSerializer()
    {
        return JsonSerializer.Serialize(_persons, TestModel.TestModelJsonContext.Default.ICollectionTestModel);
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public string NewtonsoftStringSerializer()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(_persons);
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public string JilStringSerializer()
    {
        return Jil.JSON.Serialize(_persons);
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public string Utf8JsonStringSerializer()
    {
        var serialized = Utf8Json.JsonSerializer.Serialize(_persons)!;

        return Encoding.UTF8.GetString(serialized, 0, serialized.Length);
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public string SpanJsonStringFromByteSerializer()
    {
        var serialized = SpanJson.JsonSerializer.Generic.Utf8.Serialize(_persons)!;

        return Encoding.UTF8.GetString(serialized, 0, serialized.Length);
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public string SpanJsonStringSerializer()
    {
        var serialized = SpanJson.JsonSerializer.Generic.Utf16.Serialize(_persons)!;

        return serialized;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public string MsgPackStringSerializer()
    {
        var serialized = MessagePackSerializer.Serialize(_persons)!;

        return MessagePackSerializer.ConvertToJson(serialized);
    }
}