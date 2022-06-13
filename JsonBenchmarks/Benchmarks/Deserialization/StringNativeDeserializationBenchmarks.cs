using BenchmarkDotNet.Attributes;
using JsonBenchmarks.Models;

namespace JsonBenchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization from string benchmarks.
/// </summary>
public class StringNativeDeserializationBenchmarks : DeserializationBenchmarksBase
{
    private string _testString = string.Empty;
    
    private string _testJilString = string.Empty;

    /// <summary>
    ///     Override of setup.
    /// </summary>
    [GlobalSetup]
    public new void Setup()
    {
        base.Setup();
        
        _testString = System.Text.Json.JsonSerializer.Serialize(TestModels, Options);
        _testJilString = global::Jil.JSON.Serialize(TestModels);
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark(Baseline = true)]
    public ICollection<TestModel> SystemTextJson()
    {
        return System.Text.Json.JsonSerializer.Deserialize<ICollection<TestModel>>(_testString, Options)!;
    }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public ICollection<TestModel> SystemTextJsonSourceGen()
    {
        return System.Text.Json.JsonSerializer.Deserialize(_testString, TestModelJsonContext.Default.ICollectionTestModel)!;
    }
    
    /// <summary>
    ///     Deserialize with Maverick.Json source gen.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public ICollection<TestModel> Maverick()
    {
        return global::Maverick.Json.JsonConvert.Deserialize<TestModel[]>(_testString, MaverickSettings);
    }
    
    /// <summary>
    ///     Deserialize with Newtonsoft.Json.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public ICollection<TestModel> Newtonsoft()
    {
        return global::Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<TestModel>>(_testString)!;
    }
    
    /// <summary>
    ///     Deserialize with Jil.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public ICollection<TestModel> Jil()
    {
        return global::Jil.JSON.Deserialize<ICollection<TestModel>>(_testJilString)!;
    }
    
    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public ICollection<TestModel> Utf8Json()
    {
        return global::Utf8Json.JsonSerializer.Deserialize<ICollection<TestModel>>(_testString)!;
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public ICollection<TestModel> SpanJson()
    {
        return global::SpanJson.JsonSerializer.Generic.Utf16.Deserialize<ICollection<TestModel>>(_testString)!;
    }
}