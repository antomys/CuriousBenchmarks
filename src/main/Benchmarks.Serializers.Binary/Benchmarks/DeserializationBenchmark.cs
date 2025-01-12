using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using Benchmarks.Serializers.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;

namespace Benchmarks.Serializers.Binary.Benchmarks;

[MemoryDiagnoser,
 CategoriesColumn,
 AllStatisticsColumn,
 Orderer(SummaryOrderPolicy.FastestToSlowest),
 GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory), ExcludeFromCodeCoverage]
public partial class DeserializationBenchmark
{
    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1, 100, 1000)]
    public int CollectionSize { get; set; }

    private byte[] _memPackBytes = [];
    private byte[] _msgPackBytes = [];
    private byte[] _protobufBytes = [];
    private byte[] _zeroFormatterBytes = [];

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        var models = new Faker<SimpleModel>()
            .RuleFor(model => model.TestBool, faker => faker.Random.Bool())
            .RuleFor(model => model.TestInt, faker => faker.Random.Int())
            .RuleFor(model => model.TestString, faker => faker.Name.FullName())
            .Generate(CollectionSize)
            .ToArray();

        _memPackBytes = Serializers.MemoryPackSerializeBytes(models);
        _msgPackBytes = Serializers.MessagePackSerializeBytes(models);
        _protobufBytes = Serializers.ProtobufSerializeBytes(models);
        _zeroFormatterBytes = Serializers.ZeroFormatterSerializeBytes(models);
    }
    
    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel> MessagePack()
    {
        return Serializers.MessagePackDeserializeBytes<SimpleModel>(_msgPackBytes);
    }
    
    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel> MsgPackLight()
    {
        return Serializers.MsgPackLightDeserializeBytes(_msgPackBytes);
    }
    
    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel> MemoryPack()
    {
        return Serializers.MemoryPackDeserializeBytes<SimpleModel>(_memPackBytes);
    }
    
    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel> ZeroFormatter()
    {
        return Serializers.ZeroFormatterDeserializeBytes<SimpleModel>(_zeroFormatterBytes);
    }
    
    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel> Protobuf()
    {
        return Serializers.ProtobufDeserializeBytes<SimpleModel>(_protobufBytes);
    }
}