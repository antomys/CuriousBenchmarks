namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="ZeroFormatterDeserialize"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class ZeroFormatterService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="ZeroFormatterDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string ZeroFormatterSerialize(ICollection<T> tValue)
    {
        return System.Text.Encoding.UTF8.GetString(ZeroFormatter.ZeroFormatterSerializer.Serialize(tValue));
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="ZeroFormatterDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> ZeroFormatterDeserialize(string testString)
    {
        var testByteArray = System.Text.Encoding.UTF8.GetBytes(testString);
        
        return ZeroFormatter.ZeroFormatterSerializer.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    /// <summary>
    ///     Serialize string of TValue using <see cref="ZeroFormatterDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] ZeroFormatterSerializeBytes(ICollection<T> tValue)
    {
        return ZeroFormatter.ZeroFormatterSerializer.Serialize(tValue);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="ZeroFormatterDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> ZeroFormatterDeserializeBytes(byte[] testByteArray)
    {
        return ZeroFormatter.ZeroFormatterSerializer.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    /// <summary>
    ///     Serialize string of TValue using <see cref="ZeroFormatterDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static MemoryStream ZeroFormatterSerializeStream(ICollection<T> tValue)
    {
        using var memoryStream = new MemoryStream();
        ZeroFormatter.ZeroFormatterSerializer.Serialize(memoryStream, tValue);
        
        return memoryStream;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="ZeroFormatterDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> ZeroFormatterDeserializeStream(Stream testStream)
    {
        testStream.Position = 0;
        
        return ZeroFormatter.ZeroFormatterSerializer.Deserialize<ICollection<T>>(testStream)!;
    }
}