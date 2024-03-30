using Benchmark.Serializers;
using Benchmark.Serializers.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    [BenchmarkCategory(Group.DeserializationString), Benchmark]
    public ICollection<SimpleModel> SpanJsonString()
    {
        return Serializers.SpanJsonString<SimpleModel>(_testString);
    }

    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel> SpanJsonByte()
    {
        return Serializers.SpanJsonByte<SimpleModel>(_testBytes);
    }
}