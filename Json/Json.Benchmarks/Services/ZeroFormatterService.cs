namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="ZeroFormatter"/>.
/// </summary>
public static class ZeroFormatterService
{
    /// <summary>
    ///     Serialize string of TValue using <see cref="ZeroFormatter"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] SerializeBytes<T>(T tValue)
    {
        return ZeroFormatter.ZeroFormatterSerializer.Serialize(tValue);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="ZeroFormatter"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T DeserializeBytes<T>(byte[] testByteArray)
    {
        return ZeroFormatter.ZeroFormatterSerializer.Deserialize<T>(testByteArray)!;
    }
    
    /// <summary>
    ///     Serialize string of TValue using <see cref="ZeroFormatter"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static MemoryStream SerializeStream<T>(T tValue)
    {
        using var memoryStream = new MemoryStream();
        ZeroFormatter.ZeroFormatterSerializer.Serialize(memoryStream, tValue);
        
        return memoryStream;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="ZeroFormatter"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T DeserializeStream<T>(Stream testStream)
    {
        testStream.Position = 0;
        
        return ZeroFormatter.ZeroFormatterSerializer.Deserialize<T>(testStream)!;
    }
}