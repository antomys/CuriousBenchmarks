using Benchmark.Serializers;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    [BenchmarkCategory(Group.SerializationString), Benchmark]
    public string JsonSrcGenString()
    {
        return Serializers.JsonSrcGenSerializeSimpleString(_simpleSrcGenModels);
    }

    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] JsonSrcGenByte()
    {
        return Serializers.JsonSrcGenSerializeSimpleByte(_simpleSrcGenModels);
    }
}