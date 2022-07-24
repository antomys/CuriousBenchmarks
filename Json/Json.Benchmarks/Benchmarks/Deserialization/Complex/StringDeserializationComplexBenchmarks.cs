using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;
using Json.Benchmarks.Models.SrcGen;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Deserialization.Complex;

/// <summary>
///     Deserialization from string benchmarks.
/// </summary>
public class StringDeserializationComplexBenchmarks: JsonComplexBenchmark
{
    private string _testString = string.Empty;
    private string _testJilString = string.Empty;
    private string _testServiceStackString = string.Empty;

    /// <summary>
    ///     Override of setup.
    /// </summary>
    [GlobalSetup]
    public new void Setup()
    {
        base.Setup();

        _testServiceStackString = ServiceStackService.Serialize(ComplexModels);
        _testString = SystemTextJsonService.Serialize(ComplexModels);
        _testJilString = JilService.Serialize(ComplexModels);
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
     [Benchmark(Baseline = true)]
    public ICollection<ComplexModel> SystemTextJson()
     {
         return SystemTextJsonService.Deserialize<ICollection<ComplexModel>>(_testString);
     }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.ComplexDeserializeArray(_testString)!;
    }
    
    /// <summary>
    ///     Deserialize with Maverick.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> Maverick()
    {
        return MaverickJsonService.Deserialize<ICollection<ComplexModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with Newtonsoft.Json.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> Newtonsoft()
    {
        return NewtonsoftService.Deserialize<ICollection<ComplexModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with Jil.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> Jil()
    {
        return JilService.Deserialize<ICollection<ComplexModel>>(_testJilString);
    }
    
    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> Utf8Json()
    {
        return Utf8JsonService.Deserialize<ICollection<ComplexModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>

    [Benchmark]
    public ICollection<ComplexModel> SpanJson()
    {
        return SpanJsonService.Deserialize<ICollection<ComplexModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> ServiceStack()
    {
        return ServiceStackService.Deserialize<ICollection<ComplexModel>>(_testServiceStackString);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> NetJson()
    {
        return NetJsonService.Deserialize<ICollection<ComplexModel>>(_testServiceStackString);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public ComplexSrcGenModel[] JsonSrcGen()
    {
        return JsonSrcGenService.ComplexDeserializeArray(_testString);
    }
}