using Benchmarks.Serializers;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    [BenchmarkCategory(Group.SerializationString), Benchmark]
    public string SystemTextJsonString()
    {
        return Serializers.SystemTextJsonString(_simpleModels);
    }

    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] SystemTextJsonByte()
    {
        return Serializers.SystemTextJsonByte(_simpleModels);
    }
}