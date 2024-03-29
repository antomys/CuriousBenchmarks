using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Models;
using Benchmarks.Serializers.Json.Models.SrcGen;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="System.Text.Json"/> source gen.
    /// </summary>
    /// <returns><see cref="string"/>.</returns>
    [Benchmark]
    public ICollection<SimpleModel>? SystemTextJsonSourceGenString()
    {
        return System.Text.Json.JsonSerializer.Deserialize(_testString, ModelsJsonContext.Default.ICollectionSimpleModel);
    }
    
    /// <summary>
    ///     Serializes with <see cref="System.Text.Json"/> source gen.
    /// </summary>
    /// <returns><see cref="byte"/>.</returns>
    [Benchmark]
    public ICollection<SimpleModel>? SystemTextJsonSourceGenByte()
    {
        return System.Text.Json.JsonSerializer.Deserialize(_testBytes, ModelsJsonContext.Default.ICollectionSimpleModel);
    }
}