using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="NewtonsoftDeserialize"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class NewtonsoftService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="NewtonsoftDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> NewtonsoftDeserialize(string testString)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<T>>(testString, JsonServiceExtensions.NewtonsoftOptions)!;
    }
    
    /// <summary>
    ///     Serializes collection of T using Newtonsoft.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static string NewtonsoftSerialize(ICollection<T> tValue)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(tValue, typeof(T), Newtonsoft.Json.Formatting.None, JsonServiceExtensions.NewtonsoftOptions);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="NewtonsoftDeserialize"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> NewtonsoftDeserializeBytes(byte[] testByteArray)
    {
        var testString = System.Text.Encoding.UTF8.GetString(testByteArray);
        
        return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<T>>(testString)!;
    }
}