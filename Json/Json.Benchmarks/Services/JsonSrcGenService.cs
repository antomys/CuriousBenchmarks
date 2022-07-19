using Json.Benchmarks.Models;

namespace Json.Benchmarks.Services;

public static class JsonSrcGenService
{
    private static readonly JsonSrcGen.JsonConverter JsonConverter = new();
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static SimpleSrcGenModel[] JsonSrcGenDeserialize(string testString)
    {
        var result = Array.Empty<SimpleSrcGenModel>();
        
        return JsonConverter.FromJson(result, testString)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static SimpleSrcGenModel[] JsonSrcGenDeserializeBytes(byte[] tBytes)
    {
        var result = Array.Empty<SimpleSrcGenModel>();
        
        return JsonConverter.FromJson(result, tBytes)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string JsonSrcGenSerialize(SimpleSrcGenModel[] tValue)
    {
        return JsonConverter.ToJson(tValue).ToString();
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] JsonSrcGenSerializeBytes(SimpleSrcGenModel[] tValue)
    {
        return JsonConverter.ToJsonUtf8(tValue).ToArray();
    }
}