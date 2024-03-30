using Benchmark.Serializers;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    [BenchmarkCategory(Group.SerializationString), Benchmark]
    public string ServiceStackString()
    {
        return Serializers.ServiceStackString(_simpleModels);
    }

    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] ServiceStackByte()
    {
        return Serializers.ServiceStackByte(_simpleModels);
    }
}