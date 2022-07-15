using Json.Benchmarks.Models;

namespace Json.Benchmarks.Services.Deserialization;

/// <summary>
///     Static methods wrapper of <see cref="System.Text.Json"/>.
/// </summary>
public static class SystemTextJsonGeneratedGeneratedService
{
    /// <summary>
    ///     Deserialize string of <see cref="TestModel"/> using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of <see cref="TestModel"/>.</returns>
    public static ICollection<TestModel>? SystemTextJsonGenerated(string testString)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testString, TestModelJsonContext.Default.ICollectionTestModel);
    }
    
    public static string SystemTextJsonGenerated(ICollection<TestModel> testString)
    {
        return System.Text.Json.JsonSerializer.Serialize(testString, TestModelJsonContext.Default.ICollectionTestModel);
    }
    
    /// <summary>
    ///     Deserialize byte array of <see cref="TestModel"/> using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of <see cref="TestModel"/>.</returns>
    public static ICollection<TestModel> SystemTextJsonGenerated(byte[] testByteArray)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testByteArray, TestModelJsonContext.Default.ICollectionTestModel)!;
    }
    
    public static byte[] SystemTextJsonGeneratedBytes(ICollection<TestModel> testString)
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(testString, TestModelJsonContext.Default.ICollectionTestModel);
    }
    
    /// <summary>
    ///     Deserialize Stream of <see cref="TestModel"/> using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of <see cref="TestModel"/>.</returns>
    public static ICollection<TestModel> SystemTextJsonGenerated(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.Deserialize(testStream, TestModelJsonContext.Default.ICollectionTestModel)!;
    }
    
    public static MemoryStream SystemTextJsonSourceGen(ICollection<TestModel> testModels)
    {
        using  var memoryStream = new MemoryStream();
        var jsonWriter = new System.Text.Json.Utf8JsonWriter(memoryStream);
        System.Text.Json.JsonSerializer.Serialize(jsonWriter, testModels, TestModelJsonContext.Default.ICollectionTestModel);

        return memoryStream;
    }
    
    public static async Task<MemoryStream> SystemTextJsonSourceGenAsync(ICollection<TestModel> testModels)
    {
        using  var memoryStream = new MemoryStream();
        await System.Text.Json.JsonSerializer.SerializeAsync(memoryStream, testModels, TestModelJsonContext.Default.ICollectionTestModel);

        return memoryStream;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot <see cref="TestModel"/> using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns>Collection of <see cref="TestModel"/>.</returns>
    public static ValueTask<ICollection<TestModel>?> SystemTextJsonGeneratedAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.DeserializeAsync(testStream, TestModelJsonContext.Default.ICollectionTestModel);
    }
}