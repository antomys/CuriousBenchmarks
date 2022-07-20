using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="Newtonsoft"/>.
/// </summary>
public static class NewtonsoftService
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="Newtonsoft"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T NewtonsoftDeserialize<T>(string testString)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(testString, JsonServiceExtensions.NewtonsoftOptions)!;
    }
    
    /// <summary>
    ///     Serializes collection of T using <see cref="Newtonsoft"/>.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static string NewtonsoftSerialize<T>(T tValue)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(tValue, typeof(T), Newtonsoft.Json.Formatting.None, JsonServiceExtensions.NewtonsoftOptions);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Newtonsoft"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T NewtonsoftDeserializeBytes<T>(byte[] testByteArray)
    {
        var testString = System.Text.Encoding.UTF8.GetString(testByteArray);
        
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(testString)!;
    }
}