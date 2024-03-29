using System.Text;
using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Extensions;
using Benchmarks.Serializers.Json.Models;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="ServiceStack.Text.JsonSerializer"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public ICollection<SimpleModel> ServiceStackString()
    {
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<ICollection<SimpleModel>>(_testString);
        }
    }
    
    /// <summary>
    ///     Serializes with <see cref="ServiceStack.Text.JsonSerializer"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public ICollection<SimpleModel> ServiceStackByte()
    {
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromSpan<ICollection<SimpleModel>>(Encoding.UTF8.GetString(_testBytes));
        }
    }
}