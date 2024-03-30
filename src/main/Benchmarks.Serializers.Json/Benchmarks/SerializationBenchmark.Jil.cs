using Benchmark.Serializers;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    [BenchmarkCategory(Group.SerializationString), Benchmark]
    public string JilString()
    {
        return Serializers.JilSerialize(_simpleModels);
    }

    [BenchmarkCategory(Group.SerializationByte), Benchmark]
    public byte[] JilBytes()
    {
        return Serializers.JilSerializeBytes(_simpleModels);
    }
}