using Benchmark.Serializers;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    [BenchmarkCategory(Group.SerializationString), Benchmark]
    public string Utf8JsonString()
    {
        return Serializers.Utf8JsonString(_simpleModels);
    }

    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] Utf8JsonByte()
    {
        return Serializers.Utf8JsonByte(_simpleModels);
    }
}