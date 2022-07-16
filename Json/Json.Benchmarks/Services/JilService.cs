using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="Jil"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class JilService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="Jil"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> JilDeserialize(string testString)
    {
        return Jil.JSON.Deserialize<ICollection<T>>(testString, JsonServiceExtensions.JilOptions)!;
    }
    
    /// <summary>
    ///     Serialize collection of TValue using <see cref="Jil"/>.
    /// </summary>
    /// <returns>Serialized string.</returns>
    public static string JilSerialize(ICollection<T> tValue)
    {
        return Jil.JSON.Serialize(tValue, JsonServiceExtensions.JilOptions);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Jil"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> JilDeserializeBytes(byte[] testByteArray)
    {
        var testString = System.Text.Encoding.UTF8.GetString(testByteArray);
        
        return Jil.JSON.Deserialize<ICollection<T>>(testString, JsonServiceExtensions.JilOptions)!;
    }
    
    /// <summary>
    ///     Serialize array of TValue using <see cref="Jil"/>.
    /// </summary>
    /// <returns>Serialized byte array.</returns>
    public static byte[] JilSerializeBytes(ICollection<T> tValue)
    {
        return System.Text.Encoding.UTF8.GetBytes(Jil.JSON.Serialize(tValue, JsonServiceExtensions.JilOptions));
    }

    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="Jil"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static async Task<MemoryStream> JilSerializeStreamAsync(ICollection<T> tValue)
    {
        using var memoryStream = new MemoryStream();
        var pipeWriter = System.IO.Pipelines.PipeWriter.Create(memoryStream);

        await Jil.JSON.SerializeAsync(tValue, pipeWriter, System.Text.Encoding.UTF8,
            JsonServiceExtensions.JilOptions);

        return memoryStream;
    }
}