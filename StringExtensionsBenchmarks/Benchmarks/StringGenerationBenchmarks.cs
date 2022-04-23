using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using MlkPwgen;
using StringExtensionsBenchmarks.StringExtensions;

namespace StringExtensionsBenchmarks.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[RankColumn, MinColumn, MaxColumn, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class StringGenerationBenchmarks
{
    [Params(10, 100, 1000, 10000, 100000)]
    public int Size { get; set; }

    private readonly Consumer _consumer = new();
    
    [Benchmark(Baseline = true)]
    public void GetRandomStringOriginal()
    {
        UniqueStringGeneration.GetUniqueStringOriginal(Size).Consume(_consumer);
    }
    
    [Benchmark]
    public void GetUniqueKeyOriginalStringCreate()
    {
        UniqueStringGeneration.GetUniqueKeyOriginalStringCreate(Size).Consume(_consumer);
    }
    
    [Benchmark]
    public void GetUniqueKeyNew()
    {
        UniqueStringGeneration.GetUniqueKeyNew(Size).Consume(_consumer);
    }
    
    [Benchmark]
    public void GetUniqueKeyNewSpanOwner()
    {
        UniqueStringGeneration.GetUniqueKeyNewSpanOwner(Size).Consume(_consumer);
    }
    
    [Benchmark]
    public void GetUniqueKeyNewArrayPool()
    {
        UniqueStringGeneration.GetUniqueKeyNewArrayPool(Size).Consume(_consumer);
    }
    
    [Benchmark]
    public void GenerateCryptoMlkPwger()
    {
        PasswordGenerator.Generate(Size).Consume(_consumer);
    }
}