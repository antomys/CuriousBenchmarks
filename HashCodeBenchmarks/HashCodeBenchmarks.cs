using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Bogus;
using HashCodeBenchmarks.Extensions;

namespace HashCodeBenchmarks;

[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class HashCodeBenchmarks
{
    private static readonly Faker Faker = new();
    private readonly TestModel _testModel = new(Faker.Random.Int(), Faker.Random.String2(10));

    [Benchmark(Baseline = true)]
    public int GetHashCodeDefault()
    {
        return HashingExtensions.GetHashCodeV1(_testModel);
    }
    
    [Benchmark]
    public int GetHashCodeHashCombine()
    {
        return HashingExtensions.GetHashCodeV2(_testModel.Id, _testModel.Value);
    }
    
    [Benchmark]
    public int GetHashCodeV1()
    {
        return HashingExtensions.GetHashCodeV3(_testModel.Id, _testModel.Value);
    }
    
    [Benchmark]
    public int GetHashCodeV2()
    {
        return HashingExtensions.GetHashCodeV4(_testModel.Id, _testModel.Value);
    }
    
    [Benchmark]
    public int GetHashCodeV3()
    {
        return HashingExtensions.GetHashCodeV5(_testModel.Id, _testModel.Value);
    }
    
    [Benchmark]
    public int GetHashCodeV4()
    {
        return HashingExtensions.GetHashCodeV6(_testModel.Id, _testModel.Value);
    }
}