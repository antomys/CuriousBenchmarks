namespace Json.Benchmarks.Services.Deserialization;

/// <summary>
///     Static methods wrapper of <see cref="Utf8Json(string)"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class Utf8JsonService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="Utf8Json(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Utf8Json(string testString)
    {
        return global::Utf8Json.JsonSerializer.Deserialize<ICollection<T>>(testString)!;
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Utf8Json(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Utf8Json(byte[] testByteArray)
    {
        return global::Utf8Json.JsonSerializer.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="Utf8Json(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Utf8Json(Stream testStream)
    {
        testStream.Position = 0;

        return global::Utf8Json.JsonSerializer.Deserialize<ICollection<T>>(testStream)!;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="Utf8Json(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static Task<ICollection<T>> Utf8JsonAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::Utf8Json.JsonSerializer.DeserializeAsync<ICollection<T>>(testStream);
    }
}