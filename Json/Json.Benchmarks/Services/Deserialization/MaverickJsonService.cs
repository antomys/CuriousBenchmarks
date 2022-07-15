namespace Json.Benchmarks.Services.Deserialization;

/// <summary>
///     Static methods wrapper of <see cref="Maverick(byte[])"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class MaverickJsonService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="Maverick(byte[])"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> MaverickJson(string testString)
    {
        return global::Maverick.Json.JsonConvert.Deserialize<ICollection<T>>(testString, JsonOptions.MaverickSettings);
    }
    
    public static string MaverickJson(T tValue)
    {
        return global::Maverick.Json.JsonConvert.Serialize(tValue, global::Maverick.Json.JsonFormat.None, JsonOptions.MaverickSettings);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Maverick(byte[])"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Maverick(byte[] testByteArray)
    {
        return global::Maverick.Json.JsonConvert.Deserialize<ICollection<T>>(testByteArray, JsonOptions.MaverickSettings);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Maverick(byte[])"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] Maverick(T tValue)
    {
        return System.Text.Encoding.UTF8.GetBytes(global::Maverick.Json.JsonConvert.Serialize(tValue));
    }
    
    /// <summary>
    ///     Deserialize stream of TValue using <see cref="Maverick(byte[])"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Maverick(Stream testStream)
    {
        testStream.Position = 0;
        var buffer = new byte[testStream.Length];
        _ = testStream.Read(buffer);

        return global::Maverick.Json.JsonConvert.Deserialize<ICollection<T>>(buffer, JsonOptions.MaverickSettings);
    }
    
    public static MemoryStream MaverickStream(T tValue)
    {
        using var memoryStream = new MemoryStream();
        global::Maverick.Json.JsonConvert.Serialize(memoryStream, tValue,  global::Maverick.Json.JsonFormat.None, JsonOptions.MaverickSettings);

        return memoryStream;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="Maverick(byte[])"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static async Task<ICollection<T>> MaverickAsync(Stream testStream)
    {
        testStream.Position = 0;
        var buffer = new byte[testStream.Length];
        _ = await testStream.ReadAsync(buffer);

        return global::Maverick.Json.JsonConvert.Deserialize<ICollection<T>>(buffer, JsonOptions.MaverickSettings);
    }
}