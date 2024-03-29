﻿using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="Maverick.Json"/>.
/// </summary>
public static class MaverickJsonService
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="Maverick.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T Deserialize<T>(string testString)
    {
        return Maverick.Json.JsonConvert.Deserialize<T>(testString, JsonServiceExtensions.MaverickSettings);
    }
    
    /// <summary>
    ///     Serialize byte array of TValue using <see cref="Maverick.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string Serialize<T>(T tValue)
    {
        return Maverick.Json.JsonConvert.Serialize(tValue, Maverick.Json.JsonFormat.None, JsonServiceExtensions.MaverickSettings);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Maverick.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T DeserializeBytes<T>(byte[] testByteArray)
    {
        return Maverick.Json.JsonConvert.Deserialize<T>(testByteArray, JsonServiceExtensions.MaverickSettings);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Maverick.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] SerializeBytes<T>(T tValue)
    {
        return System.Text.Encoding.UTF8.GetBytes(Maverick.Json.JsonConvert.Serialize(tValue));
    }
    
    /// <summary>
    ///     Deserialize stream of TValue using <see cref="Maverick.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T DeserializeStream<T>(Stream testStream)
    {
        testStream.Position = 0;
        var buffer = new byte[testStream.Length];
        _ = testStream.Read(buffer);

        return Maverick.Json.JsonConvert.Deserialize<T>(buffer, JsonServiceExtensions.MaverickSettings);
    }
    
    /// <summary>
    ///     Serialize byte array of TValue using <see cref="Maverick.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static MemoryStream SerializeStream<T>(T tValue)
    {
        using var memoryStream = new MemoryStream();
        Maverick.Json.JsonConvert.Serialize(memoryStream, tValue,  Maverick.Json.JsonFormat.None, JsonServiceExtensions.MaverickSettings);

        return memoryStream;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="Maverick.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static async Task<T> DeserializeAsync<T>(Stream testStream)
    {
        testStream.Position = 0;
        var buffer = new byte[testStream.Length];
        _ = await testStream.ReadAsync(buffer);

        return Maverick.Json.JsonConvert.Deserialize<T>(buffer, JsonServiceExtensions.MaverickSettings);
    }
}