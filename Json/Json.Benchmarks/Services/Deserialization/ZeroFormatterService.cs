using System.Text;

namespace Json.Benchmarks.Services.Deserialization;

/// <summary>
///     Static methods wrapper of <see cref="ZeroFormatter(string)"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class ZeroFormatterService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="ZeroFormatter(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> ZeroFormatter(string testString)
    {
        var testByteArray = Encoding.UTF8.GetBytes(testString);
        
        return global::ZeroFormatter.ZeroFormatterSerializer.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="ZeroFormatter(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] ZeroFormatterBytes(T tValue)
    {
        return global::ZeroFormatter.ZeroFormatterSerializer.Serialize(tValue);
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="ZeroFormatter(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string ZeroFormatter(T tValue)
    {
        return System.Text.Encoding.UTF8.GetString(global::ZeroFormatter.ZeroFormatterSerializer.Serialize(tValue));
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="ZeroFormatter(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> ZeroFormatter(byte[] testByteArray)
    {
        return global::ZeroFormatter.ZeroFormatterSerializer.Deserialize<ICollection<T>>(testByteArray)!;
    }
    
    public static MemoryStream ZeroFormatterStream(T tValue)
    {
        using var memoryStream = new MemoryStream();
        global::ZeroFormatter.ZeroFormatterSerializer.Serialize(memoryStream, tValue);
        
        return memoryStream;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="ZeroFormatter(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> ZeroFormatter(Stream testStream)
    {
        testStream.Position = 0;
        
        return global::ZeroFormatter.ZeroFormatterSerializer.Deserialize<ICollection<T>>(testStream)!;
    }
}