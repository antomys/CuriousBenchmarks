using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Benchmarks.String.Services;
using MlkPwgen;

namespace Benchmarks.String.Benchmarks;

/// <summary>
///     String generation benchmarks.
/// </summary>
[MemoryDiagnoser, CategoriesColumn, AllStatisticsColumn, Orderer(SummaryOrderPolicy.FastestToSlowest),
 GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory), MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, ExcludeFromCodeCoverage]
public class GenerationBenchmarks
{
    private readonly Consumer _consumer = new();

    /// <summary>
    ///     Parameter for models count.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(10, 100, 1000, 10000, 100000)]
    public int GenSize { get; set; }

    /// <summary>
    ///     Gets random string using original method + string.Create.
    /// </summary>
    [Benchmark(Baseline = true)]
    public void OriginalRandom()
    {
        GenerationService.GetUniqueOriginal(GenSize).Consume(_consumer);
    }

    /// <summary>
    ///     Gets random string using new method.
    /// </summary>
    [Benchmark]
    public void HashSetRandom()
    {
        GenerationService.GetUniqueHashSet(GenSize).Consume(_consumer);
    }

    /// <summary>
    ///     Gets random string using new method with SpanOwner.
    /// </summary>
    [Benchmark]
    public void SpanOwnerRandom()
    {
        GenerationService.GetUniqueSpanOwner(GenSize).Consume(_consumer);
    }

    /// <summary>
    ///     Gets random string using new method with ArrayPool.
    /// </summary>
    [Benchmark]
    public void ArrayPoolRandom()
    {
        GenerationService.GetUniqueArrayPool(GenSize).Consume(_consumer);
    }

    /// <summary>
    ///     Gets random string using external library created by MlkPwger.
    /// </summary>
    [Benchmark]
    public void CryptoMlkPwger()
    {
        PasswordGenerator.Generate(GenSize).Consume(_consumer);
    }
}