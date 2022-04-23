using System.Runtime.Serialization;
using MessagePack;

namespace JsonBenchmarks.Models;

/// <summary>
///     Test model.
/// </summary>
[MessagePackObject(true)]
public sealed class TestModel
{
    /// <summary>
    ///     Test first name.
    /// </summary>
    [DataMember(Name = "firstName")]
    public string FirstName { get; set; } = default!;
    
    /// <summary>
    ///     Test last name.
    /// </summary>
    [DataMember(Name = "lastName")]
    public string LastName { get; set; } = default!;

    /// <summary>
    ///     Test date.
    /// </summary>
    [DataMember(Name = "date")]
    public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
    
    /// <summary>
    ///     Test temp.
    /// </summary>
    [DataMember(Name = "temperatureCelsius")]
    public int TemperatureCelsius { get; set; }
    
    /// <summary>
    ///     Test summary.
    /// </summary>
    [DataMember(Name = "summary")]
    public string Summary { get; set; } = default!;
}