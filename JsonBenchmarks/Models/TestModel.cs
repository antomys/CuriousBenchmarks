using System.Runtime.Serialization;
using MessagePack;
using ProtoBuf;
using ZeroFormatter;

namespace JsonBenchmarks.Models;

/// <summary>
///     Test model.
/// </summary>
[ProtoContract]
[ZeroFormattable]
[MessagePackObject(true)]
public sealed class TestModel
{
    /// <summary>
    ///     Test first name.
    /// </summary>
    [ProtoMember(1)]
    [DataMember(Name = "firstName")]
    public string FirstName { get; set; } = default!;
    
    /// <summary>
    ///     Test last name.
    /// </summary>
    [ProtoMember(2)]
    [DataMember(Name = "lastName")]
    public string LastName { get; set; } = default!;

    /// <summary>
    ///     Test date.
    /// </summary>
    [ProtoMember(3, DataFormat = DataFormat.Default)]
    [DataMember(Name = "date")]
    public DateTime Date { get; set; } = DateTime.Now;
    
    /// <summary>
    ///     Test temp.
    /// </summary>
    [ProtoMember(4)]
    [DataMember(Name = "temperatureCelsius")]
    public int TemperatureCelsius { get; set; }
    
    /// <summary>
    ///     Test summary.
    /// </summary>
    [ProtoMember(5)]
    [DataMember(Name = "summary")]
    public string Summary { get; set; } = default!;
}