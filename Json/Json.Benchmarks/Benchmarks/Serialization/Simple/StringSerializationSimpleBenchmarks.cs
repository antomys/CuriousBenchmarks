using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization.Simple;

/// <summary>
///     Serialization benchmarks to string
/// </summary>
public class StringSerializationSimpleBenchmarks : JsonSimpleBenchmark
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
         return SystemTextJsonService.Serialize(SimpleModels);
     }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string SystemTextJsonSourceGen()
    {
        if (SimpleModels.Count is 1)
        {
            return SystemTextJsonGeneratedService.SimpleSerialize(SimpleModels[0]);
        }
        
        return SystemTextJsonGeneratedService.SimpleSerializeArray(SimpleModels);
    }

    /// <summary>
    ///     Serializes with Maverick.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Maverick()
    {
        return MaverickJsonService.Serialize(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Newtonsoft.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Newtonsoft()
    {
        return NewtonsoftService.Serialize(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Jil.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Jil()
    {
        return JilService.Serialize(SimpleModels);
    }

    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Utf8Json()
    {
        return Utf8JsonService.Serialize(SimpleModels);
    }

    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string SpanJson()
    {
        return SpanJsonService.Serialize(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string ServiceStack()
    {
        return ServiceStackService.Serialize(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string NetJson()
    {
        return NetJsonService.Serialize(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string JsonSrcGen()
    {
        if (CollectionSize is 1)
        {
            return JsonSrcGenService.SimpleSerialize(SimpleSrcGenModels[0]);
        }
        
        return JsonSrcGenService.SimpleSerializeArray(SimpleSrcGenModels);
    }
}