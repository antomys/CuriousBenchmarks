using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using MlkPwgen;
using StringExtensionsBenchmarks.StringExtensions;

namespace StringExtensionsBenchmarks.Benchmarks;

/// <summary>
///     String generation benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class StringGenerationBenchmarks
{
    /// <summary>
    ///     Parameter for models count.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(10, 100, 1000, 10000, 100000)]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public int Size { get; set; }

    private readonly Consumer _consumer = new();
    
    /// <summary>
    ///     Gets random string using original method.
    /// </summary>
    [Benchmark(Baseline = true)]
    public void GetRandomStringOriginal()
    {
        UniqueStringGeneration.GetUniqueStringOriginal(Size).Consume(_consumer);
    }
    
    /// <summary>
    ///     Gets random string using original method + string.Create.
    /// </summary>
    [Benchmark]
    public void GetUniqueKeyOriginalStringCreate()
    {
        UniqueStringGeneration.GetUniqueKeyOriginalStringCreate(Size).Consume(_consumer);
    }
    
    /// <summary>
    ///     Gets random string using new method.
    /// </summary>
    [Benchmark]
    public void GetUniqueKeyNew()
    {
        UniqueStringGeneration.GetUniqueKeyNew(Size).Consume(_consumer);
    }
    
    /// <summary>
    ///     Gets random string using new method with SpanOwner.
    /// </summary>
    [Benchmark]
    public void GetUniqueKeyNewSpanOwner()
    {
        UniqueStringGeneration.GetUniqueKeyNewSpanOwner(Size).Consume(_consumer);
    }
    
    /// <summary>
    ///     Gets random string using new method with ArrayPool.
    /// </summary>
    [Benchmark]
    public void GetUniqueKeyNewArrayPool()
    {
        UniqueStringGeneration.GetUniqueKeyNewArrayPool(Size).Consume(_consumer);
    }
    
    /// <summary>
    ///     Gets random string using external library created by MlkPwger.
    /// </summary>
    [Benchmark]
    public void GenerateCryptoMlkPwger()
    {
        PasswordGenerator.Generate(Size).Consume(_consumer);
    }
}