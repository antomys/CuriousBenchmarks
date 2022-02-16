using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
// ReSharper disable ForCanBeConvertedToForeach

namespace BoxingUnboxingBenchmarks;

[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class EnumUnboxingBenchmarks
{
    private readonly Consumer _consumer = new();

    private static TestEnum[] _testEnums = default!;

    [GlobalSetup]
    public void Setup()
    {
        _testEnums = new []
        {
            TestEnum.First,
            TestEnum.Second,
            TestEnum.Third,
            TestEnum.Fourth,
            TestEnum.Fifth,
            TestEnum.Sixth,
            TestEnum.Seventh,
            TestEnum.Eighth,
            TestEnum.Ninth,
            TestEnum.Tenth,
            TestEnum.Eleventh,
            TestEnum.Twelfth
        };
    }

    [BenchmarkCategory("Int from Enum"), Benchmark]
    public void IntFromEnumOneToString()
    {
        TestEnum.First.ToString("D").Consume(_consumer);
    }
    
    [BenchmarkCategory("Int from Enum"), Benchmark]
    public void IntFromEnumOneCast()
    {
        ((int) TestEnum.First).ToString().Consume(_consumer);
    }
    
    [BenchmarkCategory("String from Enum"), Benchmark]
    public void StringFromEnumOneToString()
    {
        TestEnum.First.ToString().Consume(_consumer);
    }
    
    [BenchmarkCategory("String from Enum"), Benchmark]
    public void StringFromEnumOneGetName()
    {
        Enum.GetName(TestEnum.First).Consume(_consumer);
    }
    
    [BenchmarkCategory("Array. Int from Enum"), Benchmark]
    public void EnumIntByToString()
    {
        for(var i = 0; i < _testEnums.Length; i++)
        {
            _testEnums[i].ToString("D").Consume(_consumer);
        }
    }

    [BenchmarkCategory("Array. Int from Enum"), Benchmark]
    public void EnumIntByCast()
    {
        for(var i = 0; i < _testEnums.Length; i++)
        {
            ((int) _testEnums[i]).ToString().Consume(_consumer);
        }
    }

    [BenchmarkCategory("Array. String from Enum"), Benchmark]
    public void EnumToString()
    {
        for(var i = 0; i < _testEnums.Length; i++)
        {
            _testEnums[i].ToString().Consume(_consumer);
        }
    }
    
    [BenchmarkCategory("Array. String from Enum"), Benchmark]
    public void EnumGetName()
    {
        for(var i = 0; i < _testEnums.Length; i++)
        {
            Enum.GetName(_testEnums[i]).Consume(_consumer);
        }
    }
    
    [BenchmarkCategory("Array. Int from Enum Linq"), Benchmark]
    public void EnumIntByToStringLinq()
    {
        _testEnums.Select(testEnum => testEnum.ToString("D")).Consume(_consumer);
    }

    [BenchmarkCategory("Array. Int from Enum Linq"), Benchmark]
    public void EnumIntByCastLinq()
    {
        _testEnums.Select(testEnum =>  ((int) testEnum).ToString()).Consume(_consumer);
    }
    
    [BenchmarkCategory("Array. String from Enum Linq"), Benchmark]
    public void EnumToStringLinq()
    {
        _testEnums.Select(testEnum =>  testEnum.ToString()).Consume(_consumer);
    }
    
    [BenchmarkCategory("Array. String from Enum Linq"), Benchmark]
    public void EnumGetNameLinq()
    {
        _testEnums.Select(Enum.GetName).Consume(_consumer);
    }
}