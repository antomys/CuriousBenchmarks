namespace Json.Benchmarks.Services.Deserialization;

/// <summary>
///     Static methods wrapper of <see cref="MsgPack(string)"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class MsgPackService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="MsgPack(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MsgPackClassic(string testString)
    {
        var testArray = System.Text.Encoding.UTF8.GetBytes(testString);
        
        return global::MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testArray);
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="MsgPack(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MsgPackLz4Block(string testString)
    {
        var testArray = System.Text.Encoding.UTF8.GetBytes(testString);
        
        return global::MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testArray, JsonOptions.MsgPackOptions);
    }
    
    public static string MsgPackClassic(T tValue)
    {
        var serialized = MessagePack.MessagePackSerializer.Serialize(tValue)!;

        return MessagePack.MessagePackSerializer.ConvertToJson(serialized);
    }
    
    public static string MsgPackLz4Block(T tValue)
    {
        var serialized = MessagePack.MessagePackSerializer.Serialize(tValue, JsonOptions.MsgPackOptions);

        return MessagePack.MessagePackSerializer.ConvertToJson(serialized);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="MsgPack(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MsgPackClassic(byte[] testByteArray)
    {
        return global::MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="MsgPack(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MsgPackLz4Block(byte[] testByteArray)
    {
        return global::MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testByteArray, JsonOptions.MsgPackOptions)!;
    }
    
    public static byte[] MsgPackClassicBytes(T tValue)
    {
        return MessagePack.MessagePackSerializer.Serialize(tValue)!;
    }
    
    public static byte[] MsgPackLz4BlockBytes(T tValue)
    {
        return MessagePack.MessagePackSerializer.Serialize(tValue, JsonOptions.MsgPackOptions)!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="MsgPack(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MsgPackClassic(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testStream);
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="MsgPack(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MsgPackLz4Block(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testStream, JsonOptions.MsgPackOptions);
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="MsgPack(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>> MsgPackClassicAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::MessagePack.MessagePackSerializer.DeserializeAsync<ICollection<T>>(testStream);
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="MsgPack(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>> MsgPackLz4BlockAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::MessagePack.MessagePackSerializer.DeserializeAsync<ICollection<T>>(testStream, JsonOptions.MsgPackOptions);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    public static MemoryStream MsgPackSerializeClassic(T tValue)
    {
        using var memoryStream = new MemoryStream();
        MessagePack.MessagePackSerializer.Serialize(memoryStream, tValue);

        return memoryStream;
    }

    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    public static MemoryStream MsgPackSerializeLz4Block(T tValue)
    {
        using var memoryStream = new MemoryStream();
        MessagePack.MessagePackSerializer.Serialize(memoryStream, tValue, JsonOptions.MsgPackOptions);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    public static async Task<MemoryStream> MsgPackClassicAsync(T tValue)
    {
        await using var memoryStream = new MemoryStream();
        await MessagePack.MessagePackSerializer.SerializeAsync(memoryStream, tValue);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    public static async Task<MemoryStream> MsgPackLz4BlockAsync(T tValue)
    {
        await using var memoryStream = new MemoryStream();
        await MessagePack.MessagePackSerializer.SerializeAsync(memoryStream, tValue, JsonOptions.MsgPackOptions);

        return memoryStream;
    }
}