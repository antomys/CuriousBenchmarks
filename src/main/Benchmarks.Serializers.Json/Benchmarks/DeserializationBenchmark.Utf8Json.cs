using Benchmark.Serializers;
using Benchmark.Serializers.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    [BenchmarkCategory(Group.DeserializationString), Benchmark]
    public ICollection<SimpleModel> Utf8JsonString()
    {
        return Serializers.Utf8JsonString<SimpleModel>(_testString);
    }

    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel> Utf8JsonByte()
    {
        return Serializers.Utf8JsonByte<SimpleModel>(_testBytes);
    }
}