using System.Text.Json;
using Benchmarks.Serializers.Models;
using ModelsJsonContext = Benchmarks.Serializers.ModelsJsonContext;

namespace Benchmarks.Serializers.Json;

public partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="System.Text.Json" /> source gen.
    /// </summary>
    /// <param name="testString"></param>
    /// <returns><see cref="string" />.</returns>
    public static ICollection<SimpleModel>? SystemTextJsonSourceGenSimpleString(string testString)
    {
        return JsonSerializer.Deserialize(testString, ModelsJsonContext.Default.ICollectionSimpleModel);
    }

    /// <summary>
    ///     Serializes with <see cref="System.Text.Json" /> source gen.
    /// </summary>
    /// <param name="testBytes"></param>
    /// <returns><see cref="byte" />.</returns>
    public static ICollection<SimpleModel>? SystemTextJsonSourceGenSimpleByte(byte[] testBytes)
    {
        return JsonSerializer.Deserialize(testBytes, ModelsJsonContext.Default.ICollectionSimpleModel);
    }

    /// <summary>
    ///     Serializes with <see cref="System.Text.Json" /> source gen.
    /// </summary>
    /// <param name="models"></param>
    /// <returns><see cref="string" />.</returns>
    public static string SystemTextJsonSourceGenString<T>(T[] models)
    {
        return JsonSerializer.Serialize(models, ModelsJsonContext.Default.ICollectionSimpleModel);
    }

    /// <summary>
    ///     Serializes with <see cref="System.Text.Json" /> source gen.
    /// </summary>
    /// <param name="models"></param>
    /// <returns><see cref="byte" />.</returns>
    public static byte[] SystemTextJsonSourceGenByte<T>(T[] models)
    {
        return JsonSerializer.SerializeToUtf8Bytes(models, ModelsJsonContext.Default.ICollectionSimpleModel);
    }
}