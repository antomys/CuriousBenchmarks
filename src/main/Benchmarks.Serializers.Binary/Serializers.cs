using Benchmarks.Serializers.Binary.MsgPackLightConverters;
using ProGaudi.MsgPack.Light;

namespace Benchmarks.Serializers.Binary;

public static partial class Serializers
{
    private readonly static MsgPackContext MsgPackContext = new();
   
    static Serializers()
    {
        MsgPackContext.RegisterConverter(new SimpleModelsConverter());
        MsgPackContext.RegisterConverter(new SimpleModelConverter());
    }
}