using Benchmarks.Serializers;
using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Models;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    [BenchmarkCategory(Group.DeserializationString), Benchmark]
    public SimpleSrcGenModel?[]? JsonSrcGenString()
    {
        return Serializers.JsonSrcGenDeserializeSimpleString(_testString);
    }

    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public SimpleSrcGenModel?[]? JsonSrcGenByte()
    {
        return Serializers.JsonSrcGenDeserializeSimpleByte(_testBytes);
    }
}