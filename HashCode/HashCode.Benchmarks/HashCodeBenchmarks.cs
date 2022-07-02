using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Bogus;
using HashCode.Benchmarks.Extensions;
using HashCode.Benchmarks.Models;

namespace HashCode.Benchmarks;

/// <summary>
///     Benchmarking different approaches for hash coding.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RPlotExporter, CsvMeasurementsExporter, HtmlExporter, MarkdownExporterAttribute.GitHub]
public class HashCodeBenchmarks
{
    private static readonly Faker Faker = new();
    private SimpleModel _simpleModel = null!;

    /// <summary>
    ///     Setting up a new instance of <see cref="SimpleModel"/>.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        _simpleModel = new SimpleModel(Faker.Random.Int(), Faker.Random.String2(10));
    }

    /// <summary>
    ///     Benchmarking <see cref="HashingExtensions.Default"/>.
    /// </summary>
    /// <returns><see cref="int"/>.</returns>
    [Benchmark(Baseline = true)]
    public int Default()
    {
        return HashingExtensions.Default(_simpleModel);
    }
    
    /// <summary>
    ///     Benchmarking <see cref="HashingExtensions.DefaultCombine"/>.
    /// </summary>
    /// <returns><see cref="int"/>.</returns>
    [Benchmark]
    public int DefaultCombine()
    {
        return HashingExtensions.DefaultCombine(_simpleModel);
    }
    
    /// <summary>
    ///     Benchmarking <see cref="HashingExtensions.Manual"/>.
    /// </summary>
    /// <returns><see cref="int"/>.</returns>
    [Benchmark]
    public int Manual()
    {
        return HashingExtensions.Manual(_simpleModel);
    }
    
    /// <summary>
    ///     Benchmarking <see cref="HashingExtensions.ManualBitwise"/>.
    /// </summary>
    /// <returns><see cref="int"/>.</returns>
    [Benchmark]
    public int ManualBitwise()
    {
        return HashingExtensions.ManualBitwise(_simpleModel);
    }
    
    /// <summary>
    ///     Benchmarking <see cref="HashingExtensions.StructV5"/>.
    /// </summary>
    /// <returns><see cref="int"/>.</returns>
    [Benchmark]
    public int StructV5()
    {
        return HashingExtensions.StructV5(_simpleModel);
    }
    
    /// <summary>
    ///     Benchmarking <see cref="HashingExtensions.StructV6"/>.
    /// </summary>
    /// <returns><see cref="int"/>.</returns>
    [Benchmark]
    public int StructV6()
    {
        return HashingExtensions.StructV6(_simpleModel);
    }
    
    /// <summary>
    ///     Benchmarking <see cref="HashingExtensions.StructV6Ref"/>.
    /// </summary>
    /// <returns><see cref="int"/>.</returns>
    [Benchmark]
    public int StructV6Ref()
    {
        return HashingExtensions.StructV6Ref(_simpleModel);
    }
}