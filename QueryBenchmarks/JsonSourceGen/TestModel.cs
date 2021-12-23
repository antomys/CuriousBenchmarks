namespace QueryBenchmarks.JsonSourceGen;

public class TestModel
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string Summary { get; set; } = default!;
}