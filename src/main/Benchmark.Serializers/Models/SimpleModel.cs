using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MemoryPack;
using MessagePack;
using NetJSON;
using Newtonsoft.Json;
using ProtoBuf;
using ZeroFormatter;

namespace Benchmark.Serializers.Models;

/// <summary>
///     Simple deserialization model. Used for tests.
/// </summary>
[ProtoContract, ZeroFormattable, MessagePackObject(true), MemoryPackable]
public partial class SimpleModel
{
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [Index(1), ProtoMember(1), DataMember(Name = Fields.TestIntField), JsonPropertyName(Fields.TestIntField), JsonProperty(Fields.TestIntField),
     NetJSONProperty(Fields.TestIntField)]
    public virtual int TestInt { get; set; }

    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [Index(2), ProtoMember(2), DataMember(Name = Fields.TestStringField), JsonPropertyName(Fields.TestStringField), JsonProperty(Fields.TestStringField),
     NetJSONProperty(Fields.TestStringField)]
    public virtual string TestString { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [Index(3), ProtoMember(3), DataMember(Name = Fields.TestBoolField), JsonPropertyName(Fields.TestBoolField), JsonProperty(Fields.TestBoolField),
     NetJSONProperty(Fields.TestBoolField)]
    public virtual bool TestBool { get; set; }

    public override string ToString()
    {
        var boolValue = TestBool ? "true" : "false";

        return "{" +
               $"\"{Fields.TestIntField}\":{TestInt}," +
               $"\"{Fields.TestStringField}\":\"{TestString}\"," +
               $"\"{Fields.TestBoolField}\":{boolValue}" +
               "}";
    }
}