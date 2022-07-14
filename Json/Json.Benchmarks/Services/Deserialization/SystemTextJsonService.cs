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
    ///     Deserialize byte array of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SystemTextJson(byte[] testByteArray)
    {
        return System.Text.Json.JsonSerializer.Deserialize<ICollection<T>>(testByteArray, JsonOptions.Options)!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> SystemTextJson(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.Deserialize<ICollection<T>>(testStream, JsonOptions.Options)!;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>?> SystemTextJsonAsync(Stream testStream)
    {
        testStream.Position = 0;
        return System.Text.Json.JsonSerializer.DeserializeAsync<ICollection<T>>(testStream, JsonOptions.Options);
    }
}