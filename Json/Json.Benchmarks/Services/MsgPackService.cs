using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of 'MsgPack'.
/// </summary>
public static class MsgPackService
{
    /// <summary>
    ///     Deserialize string of T values using 'MsgPackClassic'.
    /// </summary>
    /// <returns>Collection of T values.</returns>
    public static T ClassicDeserializeBytes<T>(byte[] testByteArray)
    {
        return MessagePack.MessagePackSerializer.Deserialize<T>(testByteArray)!;
    }
    
    /// <summary>
    ///     Deserialize string of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <returns>Collection of T values.</returns>
    public static T Lz4BlockDeserializeBytes<T>(byte[] testByteArray)
    {
        return MessagePack.MessagePackSerializer.Deserialize<T>(testByteArray, JsonServiceExtensions.MsgPackOptions)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackClassic'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static byte[] ClassicSerializeBytes<T>(T tValue)
    {
        return MessagePack.MessagePackSerializer.Serialize(tValue)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static byte[] Lz4BlockSerializeBytes<T>(T tValue)
    {
        return MessagePack.MessagePackSerializer.Serialize(tValue, JsonServiceExtensions.MsgPackOptions)!;
    }
    
    /// <summary>
    ///     Deserialize string of T values using 'MsgPackClassic'.
    /// </summary>
    /// <returns>Collection of T values.</returns>
    public static T ClassicDeserializeStream<T>(Stream testStream)
    {
        testStream.Position = 0;
        
        return MessagePack.MessagePackSerializer.Deserialize<T>(testStream);
    }
    
    /// <summary>
    ///     Deserialize string of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <returns>Collection of T values.</returns>
    public static T Lz4BlockDeserializeStream<T>(Stream testStream)
    {
        testStream.Position = 0;
        
        return MessagePack.MessagePackSerializer.Deserialize<T>(testStream, JsonServiceExtensions.MsgPackOptions);
    }

    /// <summary>
    ///     Serializes collection of T values using 'MsgPackClassic'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized memory stream.</returns>
    public static MemoryStream ClassicSerializeStream<T>(T tValue)
    {
        using var memoryStream = new MemoryStream();
        MessagePack.MessagePackSerializer.Serialize(memoryStream, tValue);

        return memoryStream;
    }

    /// <summary>
    ///     Serializes collection of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized memory stream.</returns>
    public static MemoryStream Lz4BlockSerializeStream<T>(T tValue)
    {
        using var memoryStream = new MemoryStream();
        MessagePack.MessagePackSerializer.Serialize(memoryStream, tValue, JsonServiceExtensions.MsgPackOptions);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackClassic'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized memory stream.</returns>
    public static async Task<MemoryStream> ClassicSerializeAsync<T>(T tValue)
    {
        await using var memoryStream = new MemoryStream();
        await MessagePack.MessagePackSerializer.SerializeAsync(memoryStream, tValue);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized memory stream.</returns>
    public static async Task<MemoryStream> Lz4BlockSerializeAsync<T>(T tValue)
    {
        await using var memoryStream = new MemoryStream();
        await MessagePack.MessagePackSerializer.SerializeAsync(memoryStream, tValue, JsonServiceExtensions.MsgPackOptions);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackClassic'.
    /// </summary>
    /// <param name="stream">Collection of T values.</param>
    /// <returns>Serialized memory stream.</returns>
    public static ValueTask<T> ClassicDeserializeAsync<T>(Stream stream)
    {
        stream.Position = 0;
        return MessagePack.MessagePackSerializer.DeserializeAsync<T>(stream);
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <param name="stream">Collection of T values.</param>
    /// <returns>Serialized memory stream.</returns>
    public static ValueTask<T> Lz4BlockDeserializeAsync<T>(Stream stream)
    {
        stream.Position = 0;
        
        return MessagePack.MessagePackSerializer.DeserializeAsync<T>(stream, JsonServiceExtensions.MsgPackOptions);
    }
}