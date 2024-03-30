using SpanJson;

namespace Benchmarks.Serializers.Json;

public partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="SpanJson.JsonSerializer" /> to string.
    /// </summary>
    /// <param name="testString"></param>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T> SpanJsonString<T>(string testString)
    {
        return JsonSerializer.Generic.Utf16.Deserialize<ICollection<T>>(testString)!;
    }

    /// <summary>
    ///     Serializes with <see cref="SpanJson.JsonSerializer" /> to string.
    /// </summary>
    /// <param name="testBytes"></param>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T> SpanJsonByte<T>(byte[] testBytes)
    {
        return JsonSerializer.Generic.Utf8.Deserialize<ICollection<T>>(testBytes)!;
    }

    public static string SpanJsonString<T>(T[] simpleModels)
    {
        return JsonSerializer.Generic.Utf16.Serialize(simpleModels)!;
    }

    public static byte[] SpanJsonByte<T>(T[] simpleModels)
    {
        return JsonSerializer.Generic.Utf8.Serialize(simpleModels)!;
    }
}