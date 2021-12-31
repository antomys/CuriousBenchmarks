namespace GroupByOrDistinctBenchmarks.TestModels;

public record TestModel
{
    public string TestModelId { get; set; } = string.Empty;
    public string InnerTestModelId { get; set; } = string.Empty;
    public DateTime DateOnly { get; set; }
    public int Integer { get; set; }
}