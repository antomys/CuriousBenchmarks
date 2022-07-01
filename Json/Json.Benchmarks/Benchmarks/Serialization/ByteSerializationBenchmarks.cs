using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;

namespace Json.Benchmarks.Benchmarks.Serialization;

/// <summary>
///     Serialization from byte array.
/// </summary>
public class ByteSerializationBenchmarks : SerializationBenchmarksBase
{
    /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Byte), Benchmark(Baseline = true)]
    public byte[] SystemTextJson()
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(Persons, Options);
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Byte), Benchmark]
    public byte[] SystemTextJsonSourceGen()
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(Persons, TestModelJsonContext.Default.ICollectionTestModel);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Byte), Benchmark]
    public byte[] Utf8Json()
    {
        return global::Utf8Json.JsonSerializer.Serialize(Persons)!;
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Byte), Benchmark]
    public byte[] ZeroFormatter()
    {
        var serialized = global::ZeroFormatter.ZeroFormatterSerializer.Serialize(PersonsVirtual)!;

        return serialized;
    }
    
    /// <summary>
    ///     Serializes with SpanJson to byte array.
    /// </summary>
    /// <returns><see cref="byte"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Byte), Benchmark]
    public byte[] SpanJson()
    {
        var serialized = global::SpanJson.JsonSerializer.Generic.Utf8.Serialize(Persons)!;

        return serialized;
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Byte), Benchmark]
    public byte[] MsgPackClassic()
    {
        return MessagePack.MessagePackSerializer.Serialize(Persons)!;
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Byte), Benchmark]
    public byte[] MsgPackLz4Block()
    {
        return MessagePack.MessagePackSerializer.Serialize(
            Persons,
            MessagePack.MessagePackSerializerOptions.Standard.WithCompression(MessagePack.MessagePackCompression.Lz4BlockArray))!;
    }
}