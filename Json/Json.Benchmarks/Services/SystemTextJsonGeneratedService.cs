using Json.Benchmarks.Models;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="System.Text.Json"/>.
/// </summary>
public static class SystemTextJsonGeneratedService
{
    /// <summary>
    ///     Deserialize string of <see cref="SimpleModel"/> using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of <see cref="SimpleModel"/>.</returns>
    public static ICollection<SimpleModel>? SystemTextJsonGeneratedDeserialize(string testString)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testString, SimpleModelJsonContext.Default.ICollectionSimpleModel);
    }
    
    public static string SystemTextJsonGeneratedSerialize(ICollection<SimpleModel> testString)
    {
        return System.Text.Json.JsonSerializer.Serialize(testString, SimpleModelJsonContext.Default.ICollectionSimpleModel);
    }
    
    /// <summary>
    ///     Deserialize byte array of <see cref="SimpleModel"/> using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of <see cref="SimpleModel"/>.</returns>
    public static ICollection<SimpleModel> SystemTextJsonGeneratedDeserializeBytes(byte[] testByteArray)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testByteArray, SimpleModelJsonContext.Default.ICollectionSimpleModel)!;
    }
    
    public static byte[] SystemTextJsonGeneratedSerializeBytes(ICollection<SimpleModel> testString)
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(testString, SimpleModelJsonContext.Default.ICollectionSimpleModel);
    }
    
    /// <summary>
    ///     Deserialize Stream of <see cref="SimpleModel"/> using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of <see cref="SimpleModel"/>.</returns>
    public static ICollection<SimpleModel> SystemTextJsonGeneratedDeserializeStream(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.Deserialize(testStream, SimpleModelJsonContext.Default.ICollectionSimpleModel)!;
    }
    
    public static MemoryStream SystemTextJsonSourceGenSerializeStream(ICollection<SimpleModel> testModels)
    {
        using var memoryStream = new MemoryStream();
        var jsonWriter = new System.Text.Json.Utf8JsonWriter(memoryStream);
        System.Text.Json.JsonSerializer.Serialize(jsonWriter, testModels, SimpleModelJsonContext.Default.ICollectionSimpleModel);

        return memoryStream;
    }
    
    public static async Task<MemoryStream> SystemTextJsonSourceGenSerializeAsync(ICollection<SimpleModel> testModels)
    {
        await using  var memoryStream = new MemoryStream();
        await System.Text.Json.JsonSerializer.SerializeAsync(memoryStream, testModels, SimpleModelJsonContext.Default.ICollectionSimpleModel);

        return memoryStream;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot <see cref="SimpleModel"/> using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of <see cref="SimpleModel"/>.</returns>
    public static ValueTask<ICollection<SimpleModel>?> SystemTextJsonGeneratedDeserializeAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.DeserializeAsync(testStream, SimpleModelJsonContext.Default.ICollectionSimpleModel);
    }
}