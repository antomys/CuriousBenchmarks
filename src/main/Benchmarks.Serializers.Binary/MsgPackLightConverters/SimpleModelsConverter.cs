﻿using Benchmarks.Serializers.Models;
using FastSerialization;
using ProGaudi.MsgPack.Light;

namespace Benchmarks.Serializers.Binary.MsgPackLightConverters;

sealed internal class SimpleModelsConverter : IMsgPackConverter<ICollection<SimpleModel>>
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

    public void Write(ICollection<SimpleModel> value, IMsgPackWriter writer)
    {
        if (value == null)
        {
            _context.NullConverter.Write(null, writer);
            return;
        }

        writer.WriteArrayHeader((uint)value.Count);

        foreach (var model in value)
        {
            Write(model, writer);
        }
    }

    ICollection<SimpleModel> IMsgPackConverter<ICollection<SimpleModel>>.Read(IMsgPackReader reader)
    {
        var length = reader.ReadArrayLength();
        if (length is null)
        {
            return null!;
        }

        if (length is 0)
        {
            throw new SerializationException("Bad format");
        }

        var result = new List<SimpleModel>((int)length);
        for (int i = 0; i < length; i++)
        {
            result.Add(Read(reader));
        }


        return result;
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