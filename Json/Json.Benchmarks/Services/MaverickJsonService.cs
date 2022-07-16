using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="MaverickDeserializeBytes"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class MaverickJsonService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="MaverickDeserializeBytes"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MaverickJsonDeserialize(string testString)
    {
        return Maverick.Json.JsonConvert.Deserialize<ICollection<T>>(testString, JsonServiceExtensions.MaverickSettings);
    }
    
    /// <summary>
    ///     Serialize byte array of TValue using <see cref="MaverickDeserializeBytes"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string MaverickJsonSerialize(ICollection<T> tValue)
    {
        return Maverick.Json.JsonConvert.Serialize(tValue, Maverick.Json.JsonFormat.None, JsonServiceExtensions.MaverickSettings);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="MaverickDeserializeBytes"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MaverickDeserializeBytes(byte[] testByteArray)
    {
        return Maverick.Json.JsonConvert.Deserialize<ICollection<T>>(testByteArray, JsonServiceExtensions.MaverickSettings);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="MaverickDeserializeBytes"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] MaverickSerializeBytes(ICollection<T> tValue)
    {
        return System.Text.Encoding.UTF8.GetBytes(Maverick.Json.JsonConvert.Serialize(tValue));
    }
    
    /// <summary>
    ///     Deserialize stream of TValue using <see cref="MaverickDeserializeBytes"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MaverickDeserializeStream(Stream testStream)
    {
        testStream.Position = 0;
        var buffer = new byte[testStream.Length];
        _ = testStream.Read(buffer);

        return Maverick.Json.JsonConvert.Deserialize<ICollection<T>>(buffer, JsonServiceExtensions.MaverickSettings);
    }
    
    /// <summary>
    ///     Serialize byte array of TValue using <see cref="MaverickDeserializeBytes"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static MemoryStream MaverickSerializeStream(ICollection<T> tValue)
    {
        using var memoryStream = new MemoryStream();
        Maverick.Json.JsonConvert.Serialize(memoryStream, tValue,  Maverick.Json.JsonFormat.None, JsonServiceExtensions.MaverickSettings);

        return memoryStream;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="MaverickDeserializeBytes"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static async Task<ICollection<T>> MaverickDeserializeAsync(Stream testStream)
    {
        testStream.Position = 0;
        var buffer = new byte[testStream.Length];
        _ = await testStream.ReadAsync(buffer);

        return Maverick.Json.JsonConvert.Deserialize<ICollection<T>>(buffer, JsonServiceExtensions.MaverickSettings);
    }
}