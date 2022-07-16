using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of 'MsgPack'.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class MsgPackService<T>
{
    /// <summary>
    ///     Deserialize string of T values using 'MsgPackClassic'.
    /// </summary>
    /// <returns>Collection of T values.</returns>
    public static ICollection<T> MsgPackClassicDeserializeByte(byte[] testByteArray)
    {
        return MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    /// <summary>
    ///     Deserialize string of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <returns>Collection of T values.</returns>
    public static ICollection<T> MsgPackLz4BlockDeserializeByte(byte[] testByteArray)
    {
        return MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testByteArray, JsonServiceExtensions.MsgPackOptions)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackClassic'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static byte[] MsgPackClassicSerializeBytes(ICollection<T> tValue)
    {
        return MessagePack.MessagePackSerializer.Serialize(tValue)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static byte[] MsgPackLz4BlockSerializeBytes(ICollection<T> tValue)
    {
        return MessagePack.MessagePackSerializer.Serialize(tValue, JsonServiceExtensions.MsgPackOptions)!;
    }
    
    /// <summary>
    ///     Deserialize string of T values using 'MsgPackClassic'.
    /// </summary>
    /// <returns>Collection of T values.</returns>
    public static ICollection<T> MsgPackClassicDeserializeStream(Stream testStream)
    {
        testStream.Position = 0;
        
        return MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testStream);
    }
    
    /// <summary>
    ///     Deserialize string of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <returns>Collection of T values.</returns>
    public static ICollection<T> MsgPackLz4BlockDeserializeStream(Stream testStream)
    {
        testStream.Position = 0;
        
        return MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testStream, JsonServiceExtensions.MsgPackOptions);
    }

    /// <summary>
    ///     Serializes collection of T values using 'MsgPackClassic'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized memory stream.</returns>
    public static MemoryStream MsgPackClassicSerializeStream(ICollection<T> tValue)
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
    public static MemoryStream MsgPackLz4BlockSerializeStream(ICollection<T> tValue)
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
    public static async Task<MemoryStream> MsgPackClassicSerializeAsync(ICollection<T> tValue)
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
    public static async Task<MemoryStream> MsgPackLz4BlockSerializeAsync(ICollection<T> tValue)
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
    public static ValueTask<ICollection<T>> MsgPackClassicDeserializeAsync(Stream stream)
    {
        stream.Position = 0;
        return MessagePack.MessagePackSerializer.DeserializeAsync<ICollection<T>>(stream);
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'MsgPackLz4Block'.
    /// </summary>
    /// <param name="stream">Collection of T values.</param>
    /// <returns>Serialized memory stream.</returns>
    public static ValueTask<ICollection<T>> MsgPackLz4BlockDeserializeAsync(Stream stream)
    {
        stream.Position = 0;
        
        return MessagePack.MessagePackSerializer.DeserializeAsync<ICollection<T>>(stream, JsonServiceExtensions.MsgPackOptions);
    }
}