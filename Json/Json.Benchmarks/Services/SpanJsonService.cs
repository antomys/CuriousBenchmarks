namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="SpanJson"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class SpanJsonService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="SpanJson"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SpanJsonDeserialize(string testString)
    {
        return SpanJson.JsonSerializer.Generic.Utf16.Deserialize<ICollection<T>>(testString)!;
    }

    /// <summary>
    ///     Serializes collection of T using 'SpanJson' to string.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static string SpanJsonSerialize(ICollection<T> tValue)
    {
        return SpanJson.JsonSerializer.Generic.Utf16.Serialize(tValue)!;
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="SpanJson"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SpanJsonDeserializeBytes(byte[] testByteArray)
    {
        return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<ICollection<T>>(testByteArray)!;
    }

    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="SpanJson"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SpanJsonDeserializeStream(Stream testStream)
    {
        testStream.Position = 0;
        var buffer = new byte[testStream.Length];
        _ = testStream.Read(buffer);
        
        return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<ICollection<T>>(buffer)!;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="SpanJson"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>> SpanJsonDeserializeAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return SpanJson.JsonSerializer.Generic.Utf8.DeserializeAsync<ICollection<T>>(testStream);
    }

    /// <summary>
    ///     Asynchronously serialize collection of TValue using <see cref="SpanJson"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static async Task<MemoryStream> SpanJsonSerializeStreamAsync(ICollection<T> tValue)
    {
        await using var memoryStream = new MemoryStream();
        await SpanJson.JsonSerializer.Generic.Utf8.SerializeAsync(tValue, memoryStream);

        return memoryStream;
    }
}