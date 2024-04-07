using Benchmarks.Serializers;
using Benchmarks.Serializers.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    [BenchmarkCategory(Group.DeserializationString), Benchmark]
    public ICollection<SimpleModel>? SystemTextJsonString()
    {
        return Serializers.SystemTextJsonString<SimpleModel>(_testString);
    }

    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel>? SystemTextJsonByte()
    {
        return Serializers.SystemTextJsonByte<SimpleModel>(_testBytes);
    }
}