using Benchmark.Serializers;
using Benchmark.Serializers.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    [BenchmarkCategory(Group.DeserializationString), Benchmark]
    public ICollection<SimpleModel>? NewtonsoftString()
    {
        return Serializers.NewtonsoftString<SimpleModel>(_testString);
    }

    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel>? NewtonsoftBytes()
    {
        return Serializers.NewtonsoftBytes<SimpleModel>(_testBytes);
    }
}