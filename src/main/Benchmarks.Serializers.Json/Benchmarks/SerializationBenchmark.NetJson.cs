using Benchmark.Serializers;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    [BenchmarkCategory(Group.SerializationString), Benchmark]
    public string NetJsonString()
    {
        return Serializers.NetJsonString(_simpleModels);
    }

    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] NetJsonByte()
    {
        return Serializers.NetJsonByte(_simpleModels);
    }
}