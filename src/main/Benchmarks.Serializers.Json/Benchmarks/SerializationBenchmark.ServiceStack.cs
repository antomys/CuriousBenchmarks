using System.Text;
using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Extensions;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="ServiceStack.Text.JsonSerializer"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string ServiceStackString()
    {
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return ServiceStack.Text.JsonSerializer.SerializeToString(_simpleModels);
        }
    }
    
    /// <summary>
    ///     Serializes with <see cref="ServiceStack.Text.JsonSerializer"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] ServiceStackByte()
    {
        using var writer = new StringWriter();

        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            ServiceStack.Text.JsonSerializer.SerializeToWriter(_simpleModels, writer);
        }
        
        return Encoding.UTF8.GetBytes(writer.ToString());
    }
}