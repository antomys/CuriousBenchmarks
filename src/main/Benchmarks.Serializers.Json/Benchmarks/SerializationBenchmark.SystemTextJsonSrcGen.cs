using Benchmarks.Serializers;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    [BenchmarkCategory(Group.SerializationString), Benchmark]
    public string SystemTextJsonSourceGenString()
    {
        return Serializers.SystemTextJsonSourceGenString(_simpleModels);
    }

    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] SystemTextJsonSourceGenByte()
    {
        return Serializers.SystemTextJsonSourceGenByte(_simpleModels);
    }
}