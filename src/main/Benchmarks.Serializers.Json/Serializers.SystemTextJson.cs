using System.Text.Json;
using Benchmarks.Serializers.Json.Extensions;

namespace Benchmarks.Serializers.Json;

public partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="System.Text.Json" />.
    /// </summary>
    /// <param name="testString"></param>
    /// <returns><see cref="string" />.</returns>
    public static ICollection<T>? SystemTextJsonString<T>(string testString)
    {
        return JsonSerializer.Deserialize<ICollection<T>>(testString, JsonServiceExtensions.Options);
    }

    /// <summary>
    ///     Serializes with <see cref="System.Text.Json" />.
    /// </summary>
    /// <param name="testBytes"></param>
    /// <returns><see cref="string" />.</returns>
    public static ICollection<T>? SystemTextJsonByte<T>(byte[] testBytes)
    {
        return JsonSerializer.Deserialize<ICollection<T>>(testBytes, JsonServiceExtensions.Options);
    }

    public static string SystemTextJsonString<T>(T[] simpleModels)
    {
        return JsonSerializer.Serialize(simpleModels, JsonServiceExtensions.Options);
    }

    public static byte[] SystemTextJsonByte<T>(T[] simpleModels)
    {
        return JsonSerializer.SerializeToUtf8Bytes(simpleModels, JsonServiceExtensions.Options);
    }
}