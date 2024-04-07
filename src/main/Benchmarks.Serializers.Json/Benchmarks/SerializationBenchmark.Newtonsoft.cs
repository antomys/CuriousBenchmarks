using Benchmarks.Serializers;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    [BenchmarkCategory(Group.SerializationString), Benchmark]
    public string NewtonsoftString()
    {
        return Serializers.NewtonsoftString(_simpleModels);
    }

    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] NewtonsoftBytes()
    {
        return Serializers.NewtonsoftBytes(_simpleModels);
    }
}