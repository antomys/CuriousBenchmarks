﻿namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="Utf8Json"/>.
/// </summary>
public static class Utf8JsonService
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="Utf8Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T Deserialize<T>(string testString)
    {
        return Utf8Json.JsonSerializer.Deserialize<T>(testString)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'Utf8Json' into string.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static string Serialize<T>(T tValue)
    {
        var serialized = Utf8Json.JsonSerializer.Serialize(tValue)!;

        return System.Text.Encoding.UTF8.GetString(serialized, 0, serialized.Length);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Utf8Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T DeserializeBytes<T>(byte[] testByteArray)
    {
        return Utf8Json.JsonSerializer.Deserialize<T>(testByteArray)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'Utf8Json' into byte array.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized byte array.</returns>
    public static byte[] SerializeBytes<T>(T tValue)
    {
        return Utf8Json.JsonSerializer.Serialize(tValue)!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="Utf8Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T DeserializeStream<T>(Stream testStream)
    {
        testStream.Position = 0;

        return Utf8Json.JsonSerializer.Deserialize<T>(testStream)!;
    }
    
    /// <summary>
    ///     Serializes collection of T values using 'Utf8Json' into stream.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized stream.</returns>
    public static async Task<MemoryStream> SerializeStreamAsync<T>(T tValue)
    {
        using var memoryStream = new MemoryStream();
        await Utf8Json.JsonSerializer.SerializeAsync(memoryStream, tValue);

        return memoryStream;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="Utf8Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static Task<T> DeserializeStreamAsync<T>(Stream testStream)
    {
        testStream.Position = 0;
        
        return Utf8Json.JsonSerializer.DeserializeAsync<T>(testStream);
    }
}