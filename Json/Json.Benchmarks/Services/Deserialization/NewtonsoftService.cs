namespace Json.Benchmarks.Services.Deserialization;

/// <summary>
///     Static methods wrapper of <see cref="Newtonsoft(string)"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class NewtonsoftService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="Newtonsoft(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Newtonsoft(string testString)
    {
        return global::Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<T>>(testString, JsonOptions.NewtonsoftOptions)!;
    }
    
    public static string Newtonsoft(T tValue)
    {
        return global::Newtonsoft.Json.JsonConvert.SerializeObject(tValue, typeof(T), global::Newtonsoft.Json.Formatting.None, JsonOptions.NewtonsoftOptions);
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Newtonsoft(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Newtonsoft(byte[] testByteArray)
    {
        var testString = System.Text.Encoding.UTF8.GetString(testByteArray);
        
        return global::Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<T>>(testString)!;
    }
}