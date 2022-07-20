namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="SpanJson"/>.
/// </summary>
public static class SpanJsonService
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="SpanJson"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T SpanJsonDeserialize<T>(string testString)
    {
        return SpanJson.JsonSerializer.Generic.Utf16.Deserialize<T>(testString)!;
    }

    /// <summary>
    ///     Serializes collection of T using 'SpanJson' to string.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static string SpanJsonSerialize<T>(T tValue)
    {
        return SpanJson.JsonSerializer.Generic.Utf16.Serialize(tValue)!;
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="SpanJson"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T SpanJsonDeserializeBytes<T>(byte[] testByteArray)
    {
        return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<T>(testByteArray)!;
    }
    
    /// <summary>
    ///     Serializes collection of T using 'SpanJson' to string.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static byte[] SpanJsonSerializeBytes<T>(T tValue)
    {
        return SpanJson.JsonSerializer.Generic.Utf8.Serialize(tValue)!;
    }

    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="SpanJson"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T SpanJsonDeserializeStream<T>(Stream testStream)
    {
        testStream.Position = 0;
        var buffer = new byte[testStream.Length];
        _ = testStream.Read(buffer);
        
        return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<T>(buffer)!;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="SpanJson"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<T> SpanJsonDeserializeAsync<T>(Stream testStream)
    {
        testStream.Position = 0;
        
        return SpanJson.JsonSerializer.Generic.Utf8.DeserializeAsync<T>(testStream);
    }

    /// <summary>
    ///     Asynchronously serialize collection of TValue using <see cref="SpanJson"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static async Task<MemoryStream> SpanJsonSerializeStreamAsync<T>(T tValue)
    {
        await using var memoryStream = new MemoryStream();
        await SpanJson.JsonSerializer.Generic.Utf8.SerializeAsync(tValue, memoryStream);

        return memoryStream;
    }
}