using Benchmarks.Serializers;
using Benchmarks.Serializers.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    [BenchmarkCategory(Group.DeserializationString), Benchmark]
    public ICollection<SimpleModel>? SystemTextJsonSourceGenString()
    {
        return Serializers.SystemTextJsonSourceGenSimpleString(_testString);
    }

    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel>? SystemTextJsonSourceGenByte()
    {
        return Serializers.SystemTextJsonSourceGenSimpleByte(_testBytes);
    }
}