using Benchmark.Serializers.Models;
using FastSerialization;
using ProGaudi.MsgPack.Light;

namespace Benchmark.Serializers.Binary.MsgPackLightConverters;

sealed internal class SimpleModelConverter : IMsgPackConverter<SimpleModel>
{
    private IMsgPackConverter<string> _stringConverter;
    private IMsgPackConverter<int> _intConverter;
    private IMsgPackConverter<bool> _boolConverter;
    private MsgPackContext _context;

    public void Write(SimpleModel value, IMsgPackWriter writer)
    {
        if (value == null)
        {
            _context.NullConverter.Write(null, writer);
            return;
        }

        writer.WriteMapHeader(3);
        
        _stringConverter.Write(nameof(value.TestInt), writer);
        _intConverter.Write(value.TestInt, writer);
        
        _stringConverter.Write(nameof(value.TestString), writer);
        _stringConverter.Write(value.TestString, writer);

        _stringConverter.Write(nameof(value.TestBool), writer);
        _boolConverter.Write(value.TestBool, writer);
    }
    
    public SimpleModel Read(IMsgPackReader reader)
    {
        var length = reader.ReadMapLength();
        if (length == null)
        {
            return null!;
        }

        if (length != 3)
        {
            throw new SerializationException("Bad format");
        }

        var result = new SimpleModel();
        for (var i = 0; i < length.Value; i++)
        {
            var propertyName = _stringConverter.Read(reader);
            
            switch (propertyName)
            {
                case nameof(result.TestInt):
                    result.TestInt = _intConverter.Read(reader);
                    break;
                case nameof(result.TestString):
                    result.TestString = _stringConverter.Read(reader);
                    break;
                case nameof(result.TestBool):
                    result.TestBool = _boolConverter.Read(reader);
                    break;
                default:
                    throw new SerializationException("Bad format");
            }
        }

        return result;
    }

    public void Initialize(MsgPackContext context)
    {
        _stringConverter = context.GetConverter<string>();
        _intConverter = context.GetConverter<int>();
        _boolConverter = context.GetConverter<bool>();
        _context = context;
    }
}