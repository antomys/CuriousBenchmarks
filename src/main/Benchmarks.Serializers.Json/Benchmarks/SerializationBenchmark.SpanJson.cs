using Benchmark.Serializers;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    [BenchmarkCategory(Group.SerializationString), Benchmark]
    public string SpanJsonString()
    {
        return Serializers.SpanJsonString(_simpleModels);
    }

    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] SpanJsonByte()
    {
        return Serializers.SpanJsonByte(_simpleModels);
    }
}