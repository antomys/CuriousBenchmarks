using System.Text;
using Utf8Json;

namespace Benchmarks.Serializers.Json;

public partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref=" Utf8Json.JsonSerializer" />.
    /// </summary>
    /// <param name="testString"></param>
    /// <returns>
    ///     <see cref="string" />
    /// </returns>
    public static ICollection<T> Utf8JsonString<T>(string testString)
    {
        return JsonSerializer.Deserialize<ICollection<T>>(testString);
    }

    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns>
    ///     <see cref="string" />
    /// </returns>
    public static ICollection<T> Utf8JsonByte<T>(byte[] testBytes)
    {
        return JsonSerializer.Deserialize<ICollection<T>>(testBytes);
    }

    /// <summary>
    ///     Serializes with <see cref=" Utf8Json.JsonSerializer" />.
    /// </summary>
    /// <param name="models"></param>
    /// <returns>
    ///     <see cref="string" />
    /// </returns>
    public static string Utf8JsonString<T>(T[] models)
    {
        return Encoding.UTF8.GetString(JsonSerializer.Serialize(models));
    }

    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns>
    ///     <see cref="string" />
    /// </returns>
    public static byte[] Utf8JsonByte<T>(T[] models)
    {
        return JsonSerializer.Serialize(models)!;
    }
}