using System.Text;
using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Extensions;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="NetJSON.NetJSON"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string NetJsonString()
    {
        return NetJSON.NetJSON.Serialize(_simpleModels, JsonServiceExtensions.NetJsonOptions);
    }
    
    /// <summary>
    ///     Serializes with <see cref="NetJSON.NetJSON"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] NetJsonByte()
    {
        using var writer = new StringWriter();

        NetJSON.NetJSON.Serialize(_simpleModels,  writer, JsonServiceExtensions.NetJsonOptions);
        
        return Encoding.UTF8.GetBytes(writer.ToString());
    }
}