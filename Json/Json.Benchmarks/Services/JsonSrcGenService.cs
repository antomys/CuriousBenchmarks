using Json.Benchmarks.Models.SrcGen;

namespace Json.Benchmarks.Services;

public static class JsonSrcGenService
{
    private static readonly JsonSrcGen.JsonConverter JsonConverter = new();

    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static SimpleSrcGenModel SimpleDeserialize(string testString)
    {
        var result = new SimpleSrcGenModel();
        
        JsonConverter.FromJson(result, testString);

        return result;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static SimpleSrcGenModel?[]? SimpleDeserializeArray(string testString)
    {
        var result = Array.Empty<SimpleSrcGenModel>();
        
        return JsonConverter.FromJson(result, testString)!;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ComplexSrcGenModel ComplexDeserialize(string testString)
    {
        var result = new ComplexSrcGenModel();
        
        JsonConverter.FromJson(result, testString);

        return result;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ComplexSrcGenModel[] ComplexDeserializeArray(string testString)
    {
        var result = Array.Empty<ComplexSrcGenModel>();
        
        return JsonConverter.FromJson(result, testString)!;
    }

    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static SimpleSrcGenModel SimpleDeserializeBytes(byte[] tBytes)
    {
        var result = new SimpleSrcGenModel();
        
        JsonConverter.FromJson(result, tBytes);

        return result;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static SimpleSrcGenModel[] SimpleDeserializeBytesArray(byte[] tBytes)
    {
        var result = Array.Empty<SimpleSrcGenModel>();
        
        return JsonConverter.FromJson(result, tBytes)!;
    }

    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ComplexSrcGenModel ComplexDeserializeBytes(byte[] tBytes)
    {
        var result = new ComplexSrcGenModel();
        
        JsonConverter.FromJson(result, tBytes);

        return result;
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ComplexSrcGenModel[] ComplexDeserializeBytesArray(byte[] tBytes)
    {
        var result = Array.Empty<ComplexSrcGenModel>();
        
        return JsonConverter.FromJson(result, tBytes)!;
    }

    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string SimpleSerialize(SimpleSrcGenModel simpleSrcGenModel)
    {
        return JsonConverter.ToJson(simpleSrcGenModel).ToString();
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string SimpleSerializeArray(SimpleSrcGenModel[] tValue)
    {
        return JsonConverter.ToJson(tValue).ToString();
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string ComplexSerialize(ComplexSrcGenModel tValue)
    {
        return JsonConverter.ToJson(tValue).ToString();
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static string ComplexSerializeArray(ComplexSrcGenModel[] tValue)
    {
        return JsonConverter.ToJson(tValue).ToString();
    }

    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] SimpleSerializeBytes(SimpleSrcGenModel tValue)
    {
        return JsonConverter.ToJsonUtf8(tValue).ToArray();
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] SimpleSerializeBytesArray(SimpleSrcGenModel[] tValue)
    {
        return JsonConverter.ToJsonUtf8(tValue).ToArray();
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] ComplexSerializeBytes(ComplexSrcGenModel tValue)
    {
        return JsonConverter.ToJsonUtf8(tValue).ToArray();
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static byte[] ComplexSerializeBytesArray(ComplexSrcGenModel[] tValue)
    {
        return JsonConverter.ToJsonUtf8(tValue).ToArray();
    }
}