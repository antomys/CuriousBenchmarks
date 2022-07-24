using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization.Complex;

/// <summary>
///     Serialization benchmarks to string
/// </summary>
public class StringSerializationComplexBenchmarks : JsonComplexBenchmark
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
         return SystemTextJsonService.Serialize(ComplexModels);
     }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string SystemTextJsonSourceGen()
    {
        if (ComplexModels.Count is 1)
        {
            return SystemTextJsonGeneratedService.ComplexSerialize(ComplexModels[0]);
        }
        
        return SystemTextJsonGeneratedService.ComplexSerializeArray(ComplexModels);
    }

    /// <summary>
    ///     Serializes with Maverick.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Maverick()
    {
        return MaverickJsonService.Serialize(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with Newtonsoft.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Newtonsoft()
    {
        return NewtonsoftService.Serialize(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with Jil.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Jil()
    {
        return JilService.Serialize(ComplexModels);
    }

    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Utf8Json()
    {
        return Utf8JsonService.Serialize(ComplexModels);
    }

    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string SpanJson()
    {
        return SpanJsonService.Serialize(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string ServiceStack()
    {
        return ServiceStackService.Serialize(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string NetJson()
    {
        return NetJsonService.Serialize(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string JsonSrcGen()
    {
        if (ComplexModels.Count is 1)
        {
            return JsonSrcGenService.ComplexSerialize(ComplexSrcGenModels[0]);
        }
        
        return JsonSrcGenService.ComplexSerializeArray(ComplexSrcGenModels);
    }
}