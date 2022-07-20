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
    public static T MsgPackClassicDeserializeBytes<T>(byte[] testByteArray)
    {
        return MessagePack.MessagePackSerializer.Deserialize<T>(testByteArray)!;
    }
    
    /// <summary>
    ///     Deserialize string of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <returns>Collection of T values.</returns>
    public static T MsgPackLz4BlockDeserializeBytes<T>(byte[] testByteArray)
    {
        return MessagePack.MessagePackSerializer.Deserialize<T>(testByteArray, JsonServiceExtensions.MsgPackOptions)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackClassic'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static byte[] MsgPackClassicSerializeBytes<T>(T tValue)
    {
        return MessagePack.MessagePackSerializer.Serialize(tValue)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static byte[] MsgPackLz4BlockSerializeBytes<T>(T tValue)
    {
        return MessagePack.MessagePackSerializer.Serialize(tValue, JsonServiceExtensions.MsgPackOptions)!;
    }
    
    /// <summary>
    ///     Deserialize string of T values using 'MsgPackClassic'.
    /// </summary>
    /// <returns>Collection of T values.</returns>
    public static T MsgPackClassicDeserializeStream<T>(Stream testStream)
    {
        testStream.Position = 0;
        
        return MessagePack.MessagePackSerializer.Deserialize<T>(testStream);
    }
    
    /// <summary>
    ///     Deserialize string of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <returns>Collection of T values.</returns>
    public static T MsgPackLz4BlockDeserializeStream<T>(Stream testStream)
    {
        testStream.Position = 0;
        
        return MessagePack.MessagePackSerializer.Deserialize<T>(testStream, JsonServiceExtensions.MsgPackOptions);
    }

    /// <summary>
    ///     Serializes collection of T values using 'MsgPackClassic'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized memory stream.</returns>
    public static MemoryStream MsgPackClassicSerializeStream<T>(T tValue)
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
    public static MemoryStream MsgPackLz4BlockSerializeStream<T>(T tValue)
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
    public static async Task<MemoryStream> MsgPackClassicSerializeAsync<T>(T tValue)
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
    public static async Task<MemoryStream> MsgPackLz4BlockSerializeAsync<T>(T tValue)
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
    public static ValueTask<T> MsgPackClassicDeserializeAsync<T>(Stream stream)
    {
        stream.Position = 0;
        return MessagePack.MessagePackSerializer.DeserializeAsync<T>(stream);
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <param name="stream">Collection of T values.</param>
    /// <returns>Serialized memory stream.</returns>
    public static ValueTask<T> MsgPackLz4BlockDeserializeAsync<T>(Stream stream)
    {
        stream.Position = 0;
        
        return MessagePack.MessagePackSerializer.DeserializeAsync<T>(stream, JsonServiceExtensions.MsgPackOptions);
    }
}