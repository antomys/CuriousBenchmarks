namespace Json.Benchmarks.Services.Deserialization;

/// <summary>
///     Static methods wrapper of <see cref="System.Text.Json"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class SystemTextJsonService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SystemTextJson(string testString)
    {
        return System.Text.Json.JsonSerializer.Deserialize<ICollection<T>>(testString, JsonOptions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string SystemTextJson(T tValue)
    {
        return global::System.Text.Json.JsonSerializer.Serialize(tValue, JsonOptions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SystemTextJson(byte[] testByteArray)
    {
        return global::System.Text.Json.JsonSerializer.Deserialize<ICollection<T>>(testByteArray, JsonOptions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] SystemTextJsonBytes(T tValue)
    {
        return global::System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(tValue, JsonOptions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SystemTextJson(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::System.Text.Json.JsonSerializer.Deserialize<ICollection<T>>(testStream, JsonOptions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static MemoryStream SystemTextJsonStream(T tValue)
    {
        using var memoryStream = new MemoryStream();
        var jsonWriter = new global::System.Text.Json.Utf8JsonWriter(memoryStream);
        global::System.Text.Json.JsonSerializer.Serialize(jsonWriter, tValue, JsonOptions.Options);

        return memoryStream;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static async Task<MemoryStream> SystemTextJsonStreamAsync(T tValue)
    {
        await using var memoryStream = new MemoryStream();
        await global::System.Text.Json.JsonSerializer.SerializeAsync(memoryStream, tValue, JsonOptions.Options);

        return memoryStream;
    }

    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>?> SystemTextJsonAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::System.Text.Json.JsonSerializer.DeserializeAsync<ICollection<T>>(testStream, JsonOptions.Options);
    }
}