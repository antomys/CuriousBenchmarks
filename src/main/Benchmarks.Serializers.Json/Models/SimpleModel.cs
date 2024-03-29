using System.Runtime.Serialization;

namespace Benchmarks.Serializers.Json.Models;

/// <summary>
///     Simple deserialization model. Used for tests.
/// </summary>
[ProtoBuf.ProtoContract]
[ZeroFormatter.ZeroFormattable]
[MessagePack.MessagePackObject(true)]
public class SimpleModel
{
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [ZeroFormatter.Index(1)]
    [ProtoBuf.ProtoMember(1)]
    [DataMember(Name = "testInt")]
    public virtual int TestInt { get; set; }
    
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [ZeroFormatter.Index(2)]
    [ProtoBuf.ProtoMember(2)]
    [DataMember(Name = "testString")]
    public virtual string TestString { get; set; } = string.Empty;
    
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [ZeroFormatter.Index(3)]
    [ProtoBuf.ProtoMember(3)]
    [DataMember(Name = "testBool")]
    public virtual bool TestBool { get; set; }

    public override string ToString()
    {
        return $"/\"testIng\":{TestInt},\"testString\":\"{TestString}\",\"testBool\":{TestBool}";
    }
}