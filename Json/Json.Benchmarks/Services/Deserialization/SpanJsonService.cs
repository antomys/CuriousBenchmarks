namespace Json.Benchmarks.Services.Deserialization;

/// <summary>
///     Static methods wrapper of <see cref="SpanJson(string)"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class SpanJsonService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="SpanJson(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SpanJson(string testString)
    {
        return global::SpanJson.JsonSerializer.Generic.Utf16.Deserialize<ICollection<T>>(testString)!;
    }

    public static string SpanJson(T tValue)
    {
        return global::SpanJson.JsonSerializer.Generic.Utf16.Serialize(tValue)!;
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="SpanJson(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SpanJson(byte[] testByteArray)
    {
        return global::SpanJson.JsonSerializer.Generic.Utf8.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    public static ArraySegment<char> SpanJsonArraySegment(T tValue)
    {
        return global::SpanJson.JsonSerializer.Generic.Utf16.SerializeToArrayPool(tValue)!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="SpanJson(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SpanJson(Stream testStream)
    {
        testStream.Position = 0;
        var buffer = new byte[testStream.Length];
        _ = testStream.Read(buffer);
        
        return global::SpanJson.JsonSerializer.Generic.Utf8.Deserialize<ICollection<T>>(buffer)!;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="SpanJson(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>> SpanJsonAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::SpanJson.JsonSerializer.Generic.Utf8.DeserializeAsync<ICollection<T>>(testStream);
    }

    public static async Task<MemoryStream> SpanJsonAsync(T tValue)
    {
        await using var memoryStream = new MemoryStream();
        await global::SpanJson.JsonSerializer.Generic.Utf8.SerializeAsync(tValue, memoryStream);

        return memoryStream;
    }
}