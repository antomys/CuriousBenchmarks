using Benchmarks.Serializers;
using Benchmarks.Serializers.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    [BenchmarkCategory(Group.DeserializationString), Benchmark]
    public ICollection<SimpleModel> JilString()
    {
        return Serializers.JilDeserialize<SimpleModel>(_testString);
    }

    [BenchmarkCategory(Group.DeserializationByte), Benchmark]
    public ICollection<SimpleModel> JilBytes()
    {
        return Serializers.JilDeserializeBytes<SimpleModel>(_testBytes);
    }
}