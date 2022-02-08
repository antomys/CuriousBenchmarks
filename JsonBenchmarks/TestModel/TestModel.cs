using System.Runtime.Serialization;
using MessagePack;

namespace JsonBenchmarks.TestModel;

[MessagePackObject(true)]
public class TestModel
{
    [DataMember(Name = "firstName")]
    public string FirstName { get; set; } = default!;
    
    [DataMember(Name = "lastName")]
    public string LastName { get; set; } = default!;

    [DataMember(Name = "date")]
    public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
    
    [DataMember(Name = "temperatureCelsius")]
    public int TemperatureCelsius { get; set; }
    
    [DataMember(Name = "summary")]
    public string Summary { get; set; } = default!;
}