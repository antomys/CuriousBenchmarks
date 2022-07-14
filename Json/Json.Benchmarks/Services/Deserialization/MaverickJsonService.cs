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
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Maverick(byte[])"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Maverick(byte[] testByteArray)
    {
        return global::Maverick.Json.JsonConvert.Deserialize<ICollection<T>>(testByteArray, JsonOptions.MaverickSettings);
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