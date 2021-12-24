using MessagePack;

namespace QueryBenchmarks.JsonSourceGen;

public class TestModel
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string Summary { get; set; } = default!;
}

[MessagePackObject]
public class TestModelMessagePack
{
    [Key(0)]
    public string FirstName { get; set; } = default!;
    
    [Key(1)]
    public string LastName { get; set; } = default!;
    
    [Key(2)]
    public DateTime Date { get; set; }
    
    [Key(3)]
    public int TemperatureCelsius { get; set; }
    
    [Key(4)]
    public string Summary { get; set; } = default!;
}