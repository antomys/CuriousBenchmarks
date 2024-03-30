using Benchmark.Serializers.Models;
using ProGaudi.MsgPack.Light;

namespace Benchmark.Serializers.Binary;

public static partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="MessagePack.MessagePackSerializer" />.
    /// </summary>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<SimpleModel> MsgPackLightDeserializeBytes(byte[] bytes)
    {
        return MsgPackSerializer.Deserialize<ICollection<SimpleModel>>(bytes, MsgPackContext);
    }
    /// <summary>
    ///     Serializes with <see cref="MessagePack.MessagePackSerializer" />.
    /// </summary>
    /// <returns>
    ///     <see cref="byte" />
    /// </returns>
    public static byte[] MsgPackLightSerializeBytes(SimpleModel[] simpleModels)
    {
        return MsgPackSerializer.Serialize(simpleModels, MsgPackContext);
    }
}