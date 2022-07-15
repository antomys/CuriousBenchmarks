namespace Json.Benchmarks.Services.Deserialization;

/// <summary>
///     Static methods wrapper of <see cref="Jil(string)"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class JilService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="Jil(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Jil(string testString)
    {
        return global::Jil.JSON.Deserialize<ICollection<T>>(testString, global::Jil.Options.CamelCase)!;
    }
    
    public static string Jil(T tValue)
    {
        return global::Jil.JSON.Serialize(tValue, global::Jil.Options.CamelCase);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Jil(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Jil(byte[] testByteArray)
    {
        var testString = System.Text.Encoding.UTF8.GetString(testByteArray);
        
        return global::Jil.JSON.Deserialize<ICollection<T>>(testString, global::Jil.Options.CamelCase)!;
    }
    
    public static byte[] JilBytes(T tValue)
    {
        return System.Text.Encoding.UTF8.GetBytes(global::Jil.JSON.Serialize(tValue, global::Jil.Options.CamelCase));
    }

    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="Jil(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>> JilAsync(Stream testStream)
    {
        var reader = System.IO.Pipelines.PipeReader.Create(testStream);
        testStream.Position = 0;
        
        return global::Jil.JSON.DeserializeAsync<ICollection<T>>(reader, System.Text.Encoding.UTF8, global::Jil.Options.CamelCase);
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="Jil(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static async Task<MemoryStream> JilSerializeAsync(T tValue)
    {
        using var memoryStream = new MemoryStream();
        var pipeWriter = System.IO.Pipelines.PipeWriter.Create(memoryStream);

        await global::Jil.JSON.SerializeAsync(tValue, pipeWriter, System.Text.Encoding.UTF8,
            global::Jil.Options.CamelCase);

        return memoryStream;
    }
}