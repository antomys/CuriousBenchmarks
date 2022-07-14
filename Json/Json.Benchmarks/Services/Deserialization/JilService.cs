using System.IO.Pipelines;
using System.Text;

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
        return global::Jil.JSON.Deserialize<ICollection<T>>(testString)!;
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Jil(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Jil(byte[] testByteArray)
    {
        var testString = Encoding.UTF8.GetString(testByteArray);
        
        return global::Jil.JSON.Deserialize<ICollection<T>>(testString)!;
    }

    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="Jil(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>> JilAsync(Stream testStream)
    {
        var reader = PipeReader.Create(testStream);
        testStream.Position = 0;
        
        return global::Jil.JSON.DeserializeAsync<ICollection<T>>(reader, Encoding.UTF8);
    }
}