using Benchmark.Serializers;
using Benchmark.Serializers.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    [BenchmarkCategory(Group.DeserializationString), Benchmark]
    public ICollection<SimpleModel> NetJsonString()
    {
        return Serializers.NetJsonString<SimpleModel>(_testString);
    }

    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel> NetJsonByte()
    {
        return Serializers.NetJsonByte<SimpleModel>(_testBytes);
    }
}