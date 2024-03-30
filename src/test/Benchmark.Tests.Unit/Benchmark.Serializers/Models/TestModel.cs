using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using NetJSON;
using Newtonsoft.Json;
using ProtoBuf;
using ZeroFormatter;

namespace Benchmark.Tests.Unit.Benchmark.Serializers.Models;

/// <summary>
///     Test model.
/// </summary>
[ProtoContract]
public class TestModel
{
    private const string TestStringFieldName = "testString";

    private const string TestIntFieldName = "testInt";

    private const string TestDoubleFieldName = "testDouble";

    private const string TestFloatFieldName = "testFloat";

    private const string TestUIntFieldName = "testUInt";

    private const string TestCharFieldName = "testChar";

    private const string TestByteFieldName = "testByte";

    private const string TestShortFieldName = "testShort";

    private const string TestUShortFieldName = "testUShort";

    private const string TestLongFieldName = "testLong";

    private const string TestULongFieldName = "testULong";

    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [Index(1), ProtoMember(1), DataMember(Name = TestStringFieldName), JsonPropertyName(TestStringFieldName), JsonProperty(TestStringFieldName),
     NetJSONProperty(TestStringFieldName)]
    public virtual string TestString { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets test int value.
    /// </summary>
    [Index(2), ProtoMember(2), DataMember(Name = TestIntFieldName), JsonPropertyName(TestIntFieldName), JsonProperty(TestIntFieldName),
     NetJSONProperty(TestIntFieldName)]
    public virtual int TestInt { get; set; }

    /// <summary>
    ///     Gets or sets test double value.
    /// </summary>
    [Index(3), ProtoMember(3), DataMember(Name = TestDoubleFieldName), JsonPropertyName(TestDoubleFieldName), JsonProperty(TestDoubleFieldName),
     NetJSONProperty(TestDoubleFieldName)]
    public virtual double TestDouble { get; set; }

    /// <summary>
    ///     Gets or sets test float value.
    /// </summary>
    [Index(4), ProtoMember(4), DataMember(Name = TestFloatFieldName), JsonPropertyName(TestFloatFieldName), JsonProperty(TestFloatFieldName),
     NetJSONProperty(TestFloatFieldName)]
    public virtual float TestFloat { get; set; }

    /// <summary>
    ///     Gets or sets test uint value.
    /// </summary>
    [Index(5), ProtoMember(5), DataMember(Name = TestUIntFieldName), JsonPropertyName(TestUIntFieldName), JsonProperty(TestUIntFieldName),
     NetJSONProperty(TestUIntFieldName)]
    public virtual uint TestUInt { get; set; }

    /// <summary>
    ///     Gets or sets test char value.
    /// </summary>
    [Index(6), ProtoMember(6), DataMember(Name = TestCharFieldName), JsonPropertyName(TestCharFieldName), JsonProperty(TestCharFieldName),
     NetJSONProperty(TestCharFieldName)]
    public virtual char TestChar { get; set; }

    /// <summary>
    ///     Gets or sets test byte value.
    /// </summary>
    [Index(7), ProtoMember(7), DataMember(Name = TestByteFieldName), JsonPropertyName(TestByteFieldName), JsonProperty(TestByteFieldName),
     NetJSONProperty(TestByteFieldName)]
    public virtual byte TestByte { get; set; }

    /// <summary>
    ///     Gets or sets test short value.
    /// </summary>
    [Index(8), ProtoMember(8), DataMember(Name = TestShortFieldName), JsonPropertyName(TestShortFieldName), JsonProperty(TestShortFieldName),
     NetJSONProperty(TestShortFieldName)]
    public virtual short TestShort { get; set; }

    /// <summary>
    ///     Gets or sets test ushort value.
    /// </summary>
    [Index(9), ProtoMember(9), DataMember(Name = TestUShortFieldName), JsonPropertyName(TestUShortFieldName), JsonProperty(TestUShortFieldName),
     NetJSONProperty(TestUShortFieldName)]
    public virtual ushort TestUShort { get; set; }

    /// <summary>
    ///     Gets or sets test long value.
    /// </summary>
    [Index(10), ProtoMember(10), DataMember(Name = TestLongFieldName), JsonPropertyName(TestLongFieldName), JsonProperty(TestLongFieldName),
     NetJSONProperty(TestLongFieldName)]
    public virtual long TestLong { get; set; }

    /// <summary>
    ///     Gets or sets test ulong value.
    /// </summary>
    [Index(11), ProtoMember(11), DataMember(Name = TestULongFieldName), JsonPropertyName(TestULongFieldName), JsonProperty(TestULongFieldName),
     NetJSONProperty(TestULongFieldName)]
    public virtual ulong TestULong { get; set; }

    public override string ToString()
    {
        return "{" +
               $"\"{TestStringFieldName}\":\"{TestString}\"," +
               $"\"{TestIntFieldName}\":{TestInt}," +
               $"\"{TestDoubleFieldName}\":{TestDouble}," +
               $"\"{TestFloatFieldName}\":{TestFloat}," +
               $"\"{TestUIntFieldName}\":{TestUInt}," +
               $"\"{TestCharFieldName}\":\"{TestChar}\"," +
               $"\"{TestByteFieldName}\":{TestByte}," +
               $"\"{TestShortFieldName}\":{TestShort}," +
               $"\"{TestUShortFieldName}\":{TestUShort}," +
               $"\"{TestLongFieldName}\":{TestLong}," +
               $"\"{TestULongFieldName}\":{TestULong}" +
               "}";
    }
}