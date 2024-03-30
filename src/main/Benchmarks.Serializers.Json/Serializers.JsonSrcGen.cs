using Benchmarks.Serializers.Json.Models;
using JsonSrcGen;

namespace Benchmarks.Serializers.Json;

public partial class Serializers
{
    private readonly static JsonConverter JsonConverter = new();

    /// <summary>
    ///     Serializes with <see cref="JsonConverter" /> to string.
    /// </summary>
    /// <returns>
    ///     <see cref="SimpleSrcGenModel" />
    /// </returns>
    public static SimpleSrcGenModel?[]? JsonSrcGenDeserializeSimpleString(string testString)
    {
        return JsonConverter.FromJson(new List<SimpleSrcGenModel>().ToArray(), testString);
    }

    /// <summary>
    ///     Serializes with <see cref="JsonConverter" />.
    /// </summary>
    /// <returns>
    ///     <see cref="SimpleSrcGenModel" />
    /// </returns>
    public static SimpleSrcGenModel?[]? JsonSrcGenDeserializeSimpleByte(byte[] testBytes)
    {
        return JsonConverter.FromJson(new List<SimpleSrcGenModel>().ToArray(), testBytes);
    }

    /// <summary>
    ///     Serializes with <see cref="JsonConverter" /> to string.
    /// </summary>
    /// <param name="simpleSrcGenModels"></param>
    /// <returns>
    ///     <see cref="string" />
    /// </returns>
    public static string JsonSrcGenSerializeSimpleString(SimpleSrcGenModel[] simpleSrcGenModels)
    {
        return JsonConverter.ToJson(simpleSrcGenModels).ToString();
    }

    /// <summary>
    ///     Serializes with <see cref="JsonConverter" />.
    /// </summary>
    /// <returns>
    ///     <see cref="string" />
    /// </returns>
    public static byte[] JsonSrcGenSerializeSimpleByte(SimpleSrcGenModel[] simpleSrcGenModels)
    {
        return JsonConverter.ToJsonUtf8(simpleSrcGenModels).ToArray();
    }
}