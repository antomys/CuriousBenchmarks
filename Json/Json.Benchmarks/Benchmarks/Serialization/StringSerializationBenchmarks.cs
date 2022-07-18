using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization;

/// <summary>
///     Serialization benchmarks to string
/// </summary>
public class StringSerializationBenchmarks : JsonBenchmark
{
    /// <summary>
    ///     Global setup of test values.
    /// </summary>
    [GlobalSetup]
    public new void Setup() => base.Setup();
    
    /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark(Baseline = true)]
    public string SystemTextJson()
     {
         return SystemTextJsonService<SimpleModel>.SystemTextJsonSerialize(SimpleModels);
     }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.SystemTextJsonGeneratedSerialize(SimpleModels);
    }

    /// <summary>
    ///     Serializes with Maverick.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Maverick()
    {
        return MaverickJsonService<SimpleModel>.MaverickJsonSerialize(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Newtonsoft.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Newtonsoft()
    {
        return NewtonsoftService<SimpleModel>.NewtonsoftSerialize(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Jil.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Jil()
    {
        return JilService<SimpleModel>.JilSerialize(SimpleModels);
    }

    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Utf8Json()
    {
        return Utf8JsonService<SimpleModel>.Utf8JsonSerialize(SimpleModels);
    }

    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string SpanJson()
    {
        return SpanJsonService<SimpleModel>.SpanJsonSerialize(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string ServiceStack()
    {
        return ServiceStackService<SimpleModel>.ServiceStackSerialize(SimpleModels);
    }
}