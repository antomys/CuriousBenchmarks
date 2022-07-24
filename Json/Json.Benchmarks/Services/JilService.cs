using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="Jil"/>.
/// </summary>
public static class JilService
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="Jil"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T Deserialize<T>(string testString)
    {
        return Jil.JSON.Deserialize<T>(testString, JsonServiceExtensions.JilOptions)!;
    }
    
    /// <summary>
    ///     Serialize collection of TValue using <see cref="Jil"/>.
    /// </summary>
    /// <returns>Serialized string.</returns>
    public static string Serialize<T>(T tValue)
    {
        return Jil.JSON.Serialize(tValue, JsonServiceExtensions.JilOptions);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Jil"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T DeserializeBytes<T>(byte[] testByteArray)
    {
        var testString = System.Text.Encoding.UTF8.GetString(testByteArray);
        
        return Jil.JSON.Deserialize<T>(testString, JsonServiceExtensions.JilOptions)!;
    }
    
    /// <summary>
    ///     Serialize array of TValue using <see cref="Jil"/>.
    /// </summary>
    /// <returns>Serialized byte array.</returns>
    public static byte[] SerializeBytes<T>(T tValue)
    {
        return System.Text.Encoding.UTF8.GetBytes(Jil.JSON.Serialize(tValue, JsonServiceExtensions.JilOptions));
    }

    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="Jil"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static async Task<MemoryStream> SerializeStreamAsync<T>(T tValue)
    {
        using var memoryStream = new MemoryStream();
        var pipeWriter = System.IO.Pipelines.PipeWriter.Create(memoryStream);

        await Jil.JSON.SerializeAsync(tValue, pipeWriter, System.Text.Encoding.UTF8,
            JsonServiceExtensions.JilOptions);

        return memoryStream;
    }
}