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
    public static ICollection<T> MsgPack(string testString)
    {
        var testArray = System.Text.Encoding.UTF8.GetBytes(testString);
        
        return global::MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testArray);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="MsgPack(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MsgPack(byte[] testByteArray)
    {
        return global::MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="MsgPack(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MsgPack(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(testStream);
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="MsgPack(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>> MsgPackAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::MessagePack.MessagePackSerializer.DeserializeAsync<ICollection<T>>(testStream);
    }
}