using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using MlkPwgen;
using String.Benchmarks.StringExtensions;

namespace String.Benchmarks.Benchmarks;

/// <summary>
///     String generation benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
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
    ///     Gets random string using original method + string.Create.
    /// </summary>
    [Benchmark(Baseline = true)]
    public void OriginalRandomString()
    {
        UniqueStringGeneration.GetUniqueOriginal(Size).Consume(_consumer);
    }
    
    /// <summary>
    ///     Gets random string using new method.
    /// </summary>
    [Benchmark]
    public void UniqueRandomV1()
    {
        UniqueStringGeneration.GetUniqueHashSet(Size).Consume(_consumer);
    }
    
    /// <summary>
    ///     Gets random string using new method with SpanOwner.
    /// </summary>
    [Benchmark]
    public void UniqueRandomV1SpanOwner()
    {
        UniqueStringGeneration.GetUniqueSpanOwner(Size).Consume(_consumer);
    }
    
    /// <summary>
    ///     Gets random string using new method with ArrayPool.
    /// </summary>
    [Benchmark]
    public void UniqueRandomV1ArrayPool()
    {
        UniqueStringGeneration.GetUniqueKeyNewArrayPool(Size).Consume(_consumer);
    }
    
    /// <summary>
    ///     Gets random string using external library created by MlkPwger.
    /// </summary>
    [Benchmark]
    public void CryptoMlkPwger()
    {
        PasswordGenerator.Generate(Size).Consume(_consumer);
    }
}