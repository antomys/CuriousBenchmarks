namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="Utf8JsonDeserialize"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class Utf8JsonService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="Utf8JsonDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Utf8JsonDeserialize(string testString)
    {
        return Utf8Json.JsonSerializer.Deserialize<ICollection<T>>(testString)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'Utf8Json' into string.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static string Utf8JsonSerialize(ICollection<T> tValue)
    {
        var serialized = Utf8Json.JsonSerializer.Serialize(tValue)!;

        return System.Text.Encoding.UTF8.GetString(serialized, 0, serialized.Length);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Utf8JsonDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Utf8JsonDeserializeBytes(byte[] testByteArray)
    {
        return Utf8Json.JsonSerializer.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'Utf8Json' into byte array.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized byte array.</returns>
    public static byte[] Utf8JsonBytesSerializeBytes(ICollection<T> tValue)
    {
        return Utf8Json.JsonSerializer.Serialize(tValue)!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="Utf8JsonDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Utf8JsonDeserializeStream(Stream testStream)
    {
        testStream.Position = 0;

        return Utf8Json.JsonSerializer.Deserialize<ICollection<T>>(testStream)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'Utf8Json' into stream.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized stream.</returns>
    public static async Task<MemoryStream> Utf8JsonSerializeStreamAsync(ICollection<T> tValue)
    {
        using var memoryStream = new MemoryStream();
        await Utf8Json.JsonSerializer.SerializeAsync(memoryStream, tValue);

        return memoryStream;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="Utf8JsonDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static Task<ICollection<T>> Utf8JsonDeserializeAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return Utf8Json.JsonSerializer.DeserializeAsync<ICollection<T>>(testStream);
    }
}