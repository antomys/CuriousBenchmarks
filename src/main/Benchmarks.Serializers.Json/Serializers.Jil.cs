using System.Text;
using Benchmarks.Serializers.Json.Extensions;
using Jil;

namespace Benchmarks.Serializers.Json;

public static partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="Jil.JSON" />.
    /// </summary>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T> JilDeserialize<T>(string input)
    {
        return JSON.Deserialize<ICollection<T>>(input, JsonServiceExtensions.JilOptions);
    }

    /// <summary>
    ///     Serializes with <see cref="Jil.JSON" />.
    /// </summary>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T> JilDeserializeBytes<T>(byte[] bytes)
    {
        return JSON.Deserialize<ICollection<T>>(Encoding.UTF8.GetString(bytes), JsonServiceExtensions.JilOptions);
    }

    /// <summary>
    ///     Serializes with <see cref="Jil.JSON" />.
    /// </summary>
    /// <param name="simpleModels"></param>
    /// <returns>
    ///     <see cref="string" />
    /// </returns>
    public static string JilSerialize<T>(T simpleModels)
    {
        return JSON.Serialize(simpleModels, JsonServiceExtensions.JilOptions);
    }

    /// <summary>
    ///     Serializes with <see cref="Jil.JSON" />.
    /// </summary>
    /// <returns>
    ///     <see cref="byte" />
    /// </returns>
    public static byte[] JilSerializeBytes<T>(T simpleModels)
    {
        using var writer = new StringWriter();

        JSON.Serialize(simpleModels, writer, JsonServiceExtensions.JilOptions);

        return Encoding.UTF8.GetBytes(writer.ToString());
    }
}