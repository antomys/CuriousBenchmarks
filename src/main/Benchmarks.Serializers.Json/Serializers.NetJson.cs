using System.Text;
using Benchmarks.Serializers.Json.Extensions;

namespace Benchmarks.Serializers.Json;

public partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="NetJSON.NetJSON" /> to string.
    /// </summary>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T> NetJsonString<T>(string testString)
    {
        return NetJSON.NetJSON.Deserialize<ICollection<T>>(testString, JsonServiceExtensions.NetJsonOptions);
    }

    /// <summary>
    ///     Serializes with <see cref="NetJSON.NetJSON" /> to string.
    /// </summary>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T> NetJsonByte<T>(byte[] testBytes)
    {
        return NetJSON.NetJSON.Deserialize<ICollection<T>>(Encoding.UTF8.GetString(testBytes), JsonServiceExtensions.NetJsonOptions);
    }

    /// <summary>
    ///     Serializes with <see cref="NetJSON.NetJSON" /> to string.
    /// </summary>
    /// <returns>
    ///     <see cref="string" />
    /// </returns>
    public static string NetJsonString<T>(T[] array)
    {
        return NetJSON.NetJSON.Serialize(array, JsonServiceExtensions.NetJsonOptions);
    }

    /// <summary>
    ///     Serializes with <see cref="NetJSON.NetJSON" /> to string.
    /// </summary>
    /// <returns>
    ///     <see cref="string" />
    /// </returns>
    public static byte[] NetJsonByte<T>(T[] array)
    {
        using var writer = new StringWriter();

        NetJSON.NetJSON.Serialize(array, writer, JsonServiceExtensions.NetJsonOptions);

        return Encoding.UTF8.GetBytes(writer.ToString());
    }
}