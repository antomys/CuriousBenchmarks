using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Benchmarks.Serializers.Json.Models;
using Benchmarks.Serializers.Json.Models.SrcGen;

namespace Benchmarks.Serializers.Json.Benchmarks;

[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public partial class SerializationBenchmark
{
    /// <summary>
    ///     Static <see cref="Faker"/> for <see cref="SimpleModel"/>.
    /// </summary>
    private readonly static Bogus.Faker<SimpleModel> Faker = new();
    
    /// <summary>
    ///     Static <see cref="Faker"/> for <see cref="ComplexModel"/>.
    /// </summary>
    private readonly static Bogus.Faker<SimpleSrcGenModel> FakerSrcGen = new();
    
    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1, 100, 1000)]
    public int CollectionSize { get; set; }
    
    /// <summary>
    ///     Collection of testing <see cref="ComplexModel"/>.
    /// </summary>
    private SimpleModel[] _simpleModels = [];
    
    /// <summary>
    ///     Collection of testing <see cref="ComplexModel"/>.
    /// </summary>
    private SimpleSrcGenModel[] _simpleSrcGenModels =[];

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        _simpleModels = Faker
            .RuleFor(model=> model.TestBool, faker=> faker.Random.Bool())
            .RuleFor(model=> model.TestInt, faker=> faker.Random.Int())
            .RuleFor(model=> model.TestString, faker=> faker.Name.FullName())
            .Generate(CollectionSize)
            .ToArray();
        
        _simpleSrcGenModels = FakerSrcGen
            .RuleFor(model=> model.TestBool, faker=> faker.Random.Bool())
            .RuleFor(model=> model.TestInt, faker=> faker.Random.Int())
            .RuleFor(model=> model.TestString, faker=> faker.Name.FullName())
            .Generate(CollectionSize)
            .ToArray();
    }
}