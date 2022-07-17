using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

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
    public static ICollection<T> SystemTextJsonDeserialize(string testString)
    {
        return System.Text.Json.JsonSerializer.Deserialize<ICollection<T>>(testString, JsonServiceExtensions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string SystemTextJsonSerialize(ICollection<T> tValue)
    {
        return System.Text.Json.JsonSerializer.Serialize(tValue, JsonServiceExtensions.Options);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SystemTextJsonDeserializeBytes(byte[] testByteArray)
    {
        return System.Text.Json.JsonSerializer.Deserialize<ICollection<T>>(testByteArray, JsonServiceExtensions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] SystemTextJsonSerializeBytes(ICollection<T> tValue)
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(tValue, JsonServiceExtensions.Options);
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SystemTextJsonDeserializeStream(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.Deserialize<ICollection<T>>(testStream, JsonServiceExtensions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static MemoryStream SystemTextJsonSerializeStream(ICollection<T> tValue)
    {
        using var memoryStream = new MemoryStream();
        var jsonWriter = new System.Text.Json.Utf8JsonWriter(memoryStream);
        System.Text.Json.JsonSerializer.Serialize(jsonWriter, tValue, JsonServiceExtensions.Options);

        return memoryStream;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static async Task<MemoryStream> SystemTextJsonSerializeStreamAsync(ICollection<T> tValue)
    {
        await using var memoryStream = new MemoryStream();
        await System.Text.Json.JsonSerializer.SerializeAsync(memoryStream, tValue, JsonServiceExtensions.Options);

        return memoryStream;
    }

    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>?> SystemTextJsonDeserializeAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.DeserializeAsync<ICollection<T>>(testStream, JsonServiceExtensions.Options);
    }
}