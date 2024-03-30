using System.Diagnostics.CodeAnalysis;
using Benchmark.Serializers.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;

namespace Benchmark.Serializers.Binary.Benchmarks;

[MemoryDiagnoser, CategoriesColumn, AllStatisticsColumn, Orderer(SummaryOrderPolicy.FastestToSlowest),
 GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory), ExcludeFromCodeCoverage]
public class SerializationBenchmark
{
    /// <summary>
    ///     Collection of testing <see cref="ComplexModel" />.
    /// </summary>
    private SimpleModel[] _simpleModels = [];

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
        _simpleModels = new Faker<SimpleModel>()
            .RuleFor(model => model.TestBool, faker => faker.Random.Bool())
            .RuleFor(model => model.TestInt, faker => faker.Random.Int())
            .RuleFor(model => model.TestString, faker => faker.Name.FullName())
            .Generate(CollectionSize)
            .ToArray();
    }
    
    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] MessagePack()
    {
        return Serializers.MessagePackSerializeBytes(_simpleModels);
    }
    
    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] MemoryPack()
    {
        return Serializers.MemoryPackSerializeBytes(_simpleModels);
    }
    
    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] ZeroFormatter()
    {
        return Serializers.ZeroFormatterSerializeBytes(_simpleModels);
    }
    
    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] Protobuf()
    {
        return Serializers.ProtobufSerializeBytes(_simpleModels);
    }
    
    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] FlatBuffers()
    {
        return Serializers.FlatBufferSerializeBytes(_simpleModels);
    }
}