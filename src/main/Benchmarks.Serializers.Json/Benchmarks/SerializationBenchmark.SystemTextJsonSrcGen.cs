using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Models.SrcGen;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="System.Text.Json"/> source gen.
    /// </summary>
    /// <returns><see cref="string"/>.</returns>
    [Benchmark]
    public string SystemTextJsonSourceGenString()
    {
        return _simpleModels.Length is 1 
            ? System.Text.Json.JsonSerializer.Serialize(_simpleModels[0], ModelsJsonContext.Default.SimpleModel) 
            : System.Text.Json.JsonSerializer.Serialize(_simpleModels, ModelsJsonContext.Default.ICollectionSimpleModel);
    }
    
    /// <summary>
    ///     Serializes with <see cref="System.Text.Json"/> source gen.
    /// </summary>
    /// <returns><see cref="string"/>.</returns>
    [Benchmark]
    public byte[] SystemTextJsonSourceGenByte()
    {
        return _simpleModels.Length is 1 
            ? System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_simpleModels[0], ModelsJsonContext.Default.SimpleModel) 
            : System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_simpleModels, ModelsJsonContext.Default.ICollectionSimpleModel);
    }
}