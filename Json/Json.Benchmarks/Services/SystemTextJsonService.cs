using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="System.Text.Json"/>.
/// </summary>
public static class SystemTextJsonService
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T Deserialize<T>(string testString)
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(testString, JsonServiceExtensions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string Serialize<T>(T tValue)
    {
        return System.Text.Json.JsonSerializer.Serialize(tValue, JsonServiceExtensions.Options);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T DeserializeBytes<T>(byte[] testByteArray)
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(testByteArray, JsonServiceExtensions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] SerializeBytes<T>(T tValue)
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(tValue, JsonServiceExtensions.Options);
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T DeserializeStream<T>(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.Deserialize<T>(testStream, JsonServiceExtensions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static MemoryStream SerializeStream<T>(T tValue)
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
    public static async Task<MemoryStream> SerializeStreamAsync<T>(T tValue)
    {
        await using var memoryStream = new MemoryStream();
        await System.Text.Json.JsonSerializer.SerializeAsync(memoryStream, tValue, JsonServiceExtensions.Options);

        return memoryStream;
    }

    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<T?> DeserializeAsync<T>(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.DeserializeAsync<T>(testStream, JsonServiceExtensions.Options);
    }
}