using Json.Benchmarks.Models;
using Json.Benchmarks.Models.SrcGen;

namespace Json.Benchmarks.Services;

public static class SystemTextJsonGeneratedService
{
    public static string SimpleSerialize(SimpleModel simpleModel)
    {
        return System.Text.Json.JsonSerializer.Serialize(simpleModel, ModelsJsonContext.Default.SimpleModel);
    }
    
    public static string SimpleSerializeArray(ICollection<SimpleModel> simpleModels)
    {
        return System.Text.Json.JsonSerializer.Serialize(simpleModels, ModelsJsonContext.Default.ICollectionSimpleModel);
    }
    
    public static string ComplexSerialize(ComplexModel complexModel)
    {
        return System.Text.Json.JsonSerializer.Serialize(complexModel, ModelsJsonContext.Default.ComplexModel);
    }
    
    public static string ComplexSerializeArray(ICollection<ComplexModel> complexModels)
    {
        return System.Text.Json.JsonSerializer.Serialize(complexModels, ModelsJsonContext.Default.ICollectionComplexModel);
    }

    public static byte[] SimpleSerializeBytes(SimpleModel testString)
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(testString, ModelsJsonContext.Default.SimpleModel);
    }
    
    public static byte[] SimpleSerializeBytesArray(ICollection<SimpleModel> testString)
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(testString, ModelsJsonContext.Default.ICollectionSimpleModel);
    }
    
    public static byte[] ComplexSerializeBytes(ComplexModel testString)
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(testString, ModelsJsonContext.Default.ComplexModel);
    }
    
    public static byte[] ComplexSerializeBytesArray(ICollection<ComplexModel> testString)
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(testString, ModelsJsonContext.Default.ICollectionComplexModel);
    }

    public static MemoryStream SimpleSerializeStream(SimpleModel testModels)
    {
        using var memoryStream = new MemoryStream();
        var jsonWriter = new System.Text.Json.Utf8JsonWriter(memoryStream);
        System.Text.Json.JsonSerializer.Serialize(jsonWriter, testModels, ModelsJsonContext.Default.SimpleModel);

        return memoryStream;
    }
    
    public static MemoryStream SimpleSerializeStreamArray(ICollection<SimpleModel> testModels)
    {
        using var memoryStream = new MemoryStream();
        var jsonWriter = new System.Text.Json.Utf8JsonWriter(memoryStream);
        System.Text.Json.JsonSerializer.Serialize(jsonWriter, testModels, ModelsJsonContext.Default.ICollectionSimpleModel);

        return memoryStream;
    }
    
    public static MemoryStream ComplexSerializeStream(ComplexModel testModels)
    {
        using var memoryStream = new MemoryStream();
        var jsonWriter = new System.Text.Json.Utf8JsonWriter(memoryStream);
        System.Text.Json.JsonSerializer.Serialize(jsonWriter, testModels, ModelsJsonContext.Default.ComplexModel);

        return memoryStream;
    }
    
    public static MemoryStream ComplexSerializeStreamArray(ICollection<ComplexModel> testModels)
    {
        using var memoryStream = new MemoryStream();
        var jsonWriter = new System.Text.Json.Utf8JsonWriter(memoryStream);
        System.Text.Json.JsonSerializer.Serialize(jsonWriter, testModels, ModelsJsonContext.Default.ICollectionComplexModel);

        return memoryStream;
    }

    public static async Task<MemoryStream> SimpleSerializeAsync(SimpleModel testModels)
    {
        await using  var memoryStream = new MemoryStream();
        await System.Text.Json.JsonSerializer.SerializeAsync(memoryStream, testModels, ModelsJsonContext.Default.SimpleModel);

        return memoryStream;
    }
    
    public static async Task<MemoryStream> SimpleSerializeArrayAsync(ICollection<SimpleModel> testModels)
    {
        await using  var memoryStream = new MemoryStream();
        await System.Text.Json.JsonSerializer.SerializeAsync(memoryStream, testModels, ModelsJsonContext.Default.ICollectionSimpleModel);

        return memoryStream;
    }
    
    public static async Task<MemoryStream> ComplexSerializeAsync(ComplexModel testModels)
    {
        await using  var memoryStream = new MemoryStream();
        await System.Text.Json.JsonSerializer.SerializeAsync(memoryStream, testModels, ModelsJsonContext.Default.ComplexModel);

        return memoryStream;
    }
    
    public static async Task<MemoryStream> ComplexSerializeArrayAsync(ICollection<ComplexModel> testModels)
    {
        await using  var memoryStream = new MemoryStream();
        await System.Text.Json.JsonSerializer.SerializeAsync(memoryStream, testModels, ModelsJsonContext.Default.ICollectionComplexModel);

        return memoryStream;
    }

    public static SimpleModel? SimpleDeserialize(string testString)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testString, ModelsJsonContext.Default.SimpleModel);
    }
    
    public static ICollection<SimpleModel>? SimpleDeserializeArray(string testString)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testString, ModelsJsonContext.Default.ICollectionSimpleModel);
    }
    
    public static ComplexModel? ComplexDeserialize(string testString)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testString, ModelsJsonContext.Default.ComplexModel);
    }
    
    public static ICollection<ComplexModel>? ComplexDeserializeArray(string testString)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testString, ModelsJsonContext.Default.ICollectionComplexModel);
    }

    public static SimpleModel SimpleDeserializeBytes(byte[] testByteArray)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testByteArray, ModelsJsonContext.Default.SimpleModel)!;
    }
    
    public static ICollection<SimpleModel> SimpleDeserializeBytesArray(byte[] testByteArray)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testByteArray, ModelsJsonContext.Default.ICollectionSimpleModel)!;
    }
    
    public static ComplexModel ComplexDeserializeBytes(byte[] testByteArray)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testByteArray, ModelsJsonContext.Default.ComplexModel)!;
    }
    
    public static ICollection<ComplexModel> ComplexDeserializeBytesArray(byte[] testByteArray)
    {
        return System.Text.Json.JsonSerializer.Deserialize(testByteArray, ModelsJsonContext.Default.ICollectionComplexModel)!;
    }

    public static SimpleModel SimpleDeserializeStream(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.Deserialize(testStream, ModelsJsonContext.Default.SimpleModel)!;
    }
    
    public static ICollection<SimpleModel> SimpleDeserializeStreamArray(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.Deserialize(testStream, ModelsJsonContext.Default.ICollectionSimpleModel)!;
    }
    
    public static ComplexModel ComplexDeserializeStream(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.Deserialize(testStream, ModelsJsonContext.Default.ComplexModel)!;
    }
    
    public static ICollection<ComplexModel> ComplexDeserializeStreamArray(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.Deserialize(testStream, ModelsJsonContext.Default.ICollectionComplexModel)!;
    }

    public static ValueTask<SimpleModel?> SimpleDeserializeAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.DeserializeAsync(testStream, ModelsJsonContext.Default.SimpleModel);
    }
        
    public static ValueTask<ICollection<SimpleModel>?> SimpleDeserializeArrayAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.DeserializeAsync(testStream, ModelsJsonContext.Default.ICollectionSimpleModel);
    }
    
    public static ValueTask<ComplexModel?> ComplexDeserializeAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.DeserializeAsync(testStream, ModelsJsonContext.Default.ComplexModel);
    }
        
    public static ValueTask<ICollection<ComplexModel>?> ComplexDeserializeArrayAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.DeserializeAsync(testStream, ModelsJsonContext.Default.ICollectionComplexModel);
    }
}