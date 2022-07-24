using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Json.Benchmarks.Extensions;
using Json.Benchmarks.Models;
using Json.Benchmarks.Models.SrcGen;

namespace Json.Benchmarks.Benchmarks;

/// <summary>
///     Serialization benchmarks base.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class JsonSimpleBenchmark
{
    /// <summary>
    ///     Static <see cref="Faker"/> for <see cref="SimpleModel"/>.
    /// </summary>
    private static readonly Bogus.Faker<SimpleModel> Faker = new();
    
    /// <summary>
    ///     Static <see cref="Faker"/> for <see cref="ComplexModel"/>.
    /// </summary>
    private static readonly Bogus.Faker<SimpleSrcGenModel> FakerSrcGen = new();
    
    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1, 100, 1000, 10000)]
    public int CollectionSize { get; set; }
    
    /// <summary>
    ///     Collection of testing <see cref="ComplexModel"/>.
    /// </summary>
    protected List<SimpleModel> SimpleModels = new();
    
    /// <summary>
    ///     Collection of testing <see cref="ComplexModel"/>.
    /// </summary>
    protected SimpleSrcGenModel[] SimpleSrcGenModels = Array.Empty<SimpleSrcGenModel>();

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    public void Setup()
    {
        SimpleModels = Faker
            .RuleFor(x=> x.TestBool, y=> y.Random.Bool())
            .RuleFor(x=> x.TestInt, y=> y.Random.Int())
            .RuleFor(x=>x.TestString, y=> y.Name.FullName())
            .Generate(CollectionSize);
        
        SimpleSrcGenModels = FakerSrcGen
            .RuleFor(x=> x.TestBool, y=> y.Random.Bool())
            .RuleFor(x=> x.TestInt, y=> y.Random.Int())
            .RuleFor(x=>x.TestString, y=> y.Name.FullName())
            .Generate(CollectionSize)
            .ToArray();
    }
}