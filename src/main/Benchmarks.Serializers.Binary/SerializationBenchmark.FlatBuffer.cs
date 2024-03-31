using Benchmarks.Serializers.Models;
using Google.FlatBuffers;

namespace Benchmarks.Serializers.Binary;

public static partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="MemoryPack.MemoryPackSerializer" />.
    /// </summary>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static SimpleFlatBufferModels FlatBufferDeserializeBytes<T>(byte[] bytes)
    {
        var buf = new ByteBuffer(bytes);

        return SimpleFlatBufferModels.GetRootAsSimpleFlatBufferModels(buf);
    }
    
    /// <summary>
    ///     Serializes with <see cref="MemoryPack.MemoryPackSerializer" />.
    /// </summary>
    /// <returns>
    ///     <see cref="byte" />
    /// </returns>
    public static byte[] FlatBufferSerializeBytes(Span<SimpleModel> simpleModels)
    {
        var builder = new FlatBufferBuilder(1024);
        SimpleFlatBufferModels.StartModelsVector(builder, simpleModels.Length);

        for (var i = 0; i < simpleModels.Length; i++)
        {
            SimpleFlatBufferModel.CreateSimpleFlatBufferModel(
                builder,
                simpleModels[i].TestInt,
                builder.CreateString(simpleModels[i].TestString),
                simpleModels[i].TestBool);
        }

        var models = builder.EndVector();

        SimpleFlatBufferModels.StartSimpleFlatBufferModels(builder);
        SimpleFlatBufferModels.AddModels(builder, models);

        var simpleFlatBufferModel = SimpleFlatBufferModels.EndSimpleFlatBufferModels(builder);
        
        builder.Finish(simpleFlatBufferModel.Value);
        
        return builder.SizedByteArray();
    }
}