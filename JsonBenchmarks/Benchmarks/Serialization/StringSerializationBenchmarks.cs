using System.Text;
using BenchmarkDotNet.Attributes;
using JsonBenchmarks.Models;

namespace JsonBenchmarks.Benchmarks.Serialization;

/// <summary>
///     Serialization benchmarks to string
/// </summary>
public class StringSerializationBenchmarks : SerializationBenchmarksBase
{
     /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark(Baseline = true)]
    public string Classic()
    {
        return System.Text.Json.JsonSerializer.Serialize(Persons, Options);
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public string ClassicGenerated()
    {
        return System.Text.Json.JsonSerializer.Serialize(Persons, TestModelJsonContext.Default.ICollectionTestModel);
    }

    /// <summary>
    ///     Serializes with Maverick.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public string Maverick()
    {
        return global::Maverick.Json.JsonConvert.Serialize(Persons, global::Maverick.Json.JsonFormat.None, MaverickSettings);
    }
    
    /// <summary>
    ///     Serializes with Newtonsoft.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public string Newtonsoft()
    {
        return global::Newtonsoft.Json.JsonConvert.SerializeObject(Persons);
    }
    
    /// <summary>
    ///     Serializes with Jil.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public string Jil()
    {
        return global::Jil.JSON.Serialize(Persons);
    }

    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public string Utf8Json()
    {
        var serialized = global::Utf8Json.JsonSerializer.Serialize(Persons)!;

        return Encoding.UTF8.GetString(serialized, 0, serialized.Length);
    }
    
    /// <summary>
    ///     Serializes with SpanJson to bytes.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public string SpanJsonFromByte()
    {
        var serialized = SpanJson.JsonSerializer.Generic.Utf8.Serialize(Persons)!;

        return Encoding.UTF8.GetString(serialized, 0, serialized.Length);
    }
    
    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public string SpanJsonString()
    {
        var serialized = SpanJson.JsonSerializer.Generic.Utf16.Serialize(Persons)!;

        return serialized;
    }

    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public string MsgPackClassic()
    {
        var serialized = MessagePack.MessagePackSerializer.Serialize(Persons)!;

        return MessagePack.MessagePackSerializer.ConvertToJson(serialized);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.StringNative), Benchmark]
    public string MsgPackLz4Block()
    {
        var serialized = MessagePack.MessagePackSerializer.Serialize(
            Persons,
            MessagePack.MessagePackSerializerOptions.Standard.WithCompression(MessagePack.MessagePackCompression.Lz4BlockArray));

        return MessagePack.MessagePackSerializer.ConvertToJson(serialized);
    }
}