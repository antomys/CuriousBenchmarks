using System.Diagnostics.CodeAnalysis;
using Benchmark.Serializers.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Benchmarks.Serializers.Json.Models;
using Bogus;

namespace Benchmarks.Serializers.Json.Benchmarks;

[MemoryDiagnoser, CategoriesColumn, AllStatisticsColumn, Orderer(SummaryOrderPolicy.FastestToSlowest),
 GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory), ExcludeFromCodeCoverage]
public partial class SerializationBenchmark
{
    /// <summary>
    ///     Static <see cref="Faker" /> for <see cref="SimpleModel" />.
    /// </summary>
    private readonly static Faker<SimpleModel> Faker = new();

    /// <summary>
    ///     Static <see cref="Faker" /> for <see cref="ComplexModel" />.
    /// </summary>
    private readonly static Faker<SimpleSrcGenModel> FakerSrcGen = new();

    /// <summary>
    ///     Collection of testing <see cref="ComplexModel" />.
    /// </summary>
    private SimpleModel[] _simpleModels = [];

    /// <summary>
    ///     Collection of testing <see cref="ComplexModel" />.
    /// </summary>
    private SimpleSrcGenModel[] _simpleSrcGenModels = [];

    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1, 100, 1000)]
    public int CollectionSize { get; set; }

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        _simpleModels = Faker
            .RuleFor(model => model.TestBool, faker => faker.Random.Bool())
            .RuleFor(model => model.TestInt, faker => faker.Random.Int())
            .RuleFor(model => model.TestString, faker => faker.Name.FullName())
            .Generate(CollectionSize)
            .ToArray();

        _simpleSrcGenModels = FakerSrcGen
            .RuleFor(model => model.TestBool, faker => faker.Random.Bool())
            .RuleFor(model => model.TestInt, faker => faker.Random.Int())
            .RuleFor(model => model.TestString, faker => faker.Name.FullName())
            .Generate(CollectionSize)
            .ToArray();
    }
}