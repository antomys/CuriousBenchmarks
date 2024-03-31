using Benchmarks.Serializers;
using Benchmarks.Serializers.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    [BenchmarkCategory(Group.DeserializationString), Benchmark]
    public ICollection<SimpleModel> ServiceStackString()
    {
        return Serializers.ServiceStackString<SimpleModel>(_testString);
    }

    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel> ServiceStackByte()
    {
        return Serializers.ServiceStackByte<SimpleModel>(_testBytes);
    }
}