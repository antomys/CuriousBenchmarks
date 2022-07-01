using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Bogus;
using HashCode.Benchmarks.Extensions;
using HashCode.Benchmarks.Models;

namespace HashCode.Benchmarks;

[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RPlotExporter, CsvMeasurementsExporter, HtmlExporter, MarkdownExporterAttribute.GitHub]
public class HashCodeBenchmarks
{
    private static readonly Faker Faker = new();
    private readonly TestModel _testModel = new(Faker.Random.Int(), Faker.Random.String2(10));

    [Benchmark]
    public int Default()
    {
        return HashingExtensions.GetHashCodeV1(_testModel);
    }
    
    [Benchmark]
    public int HashCombine()
    {
        return HashingExtensions.GetHashCodeV2(_testModel.Id, _testModel.Value);
    }
    
    [Benchmark]
    public int V1()
    {
        return HashingExtensions.GetHashCodeV3(_testModel.Id, _testModel.Value);
    }
    
    [Benchmark]
    public int V2()
    {
        return HashingExtensions.GetHashCodeV4(_testModel.Id, _testModel.Value);
    }
    
    [Benchmark]
    public int V3()
    {
        return HashingExtensions.GetHashCodeV5(_testModel.Id, _testModel.Value);
    }
    
    [Benchmark]
    public int V4()
    {
        return HashingExtensions.GetHashCodeV6(_testModel.Id, _testModel.Value);
    }
}