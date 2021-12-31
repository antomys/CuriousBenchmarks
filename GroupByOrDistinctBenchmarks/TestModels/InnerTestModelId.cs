namespace GroupByOrDistinctBenchmarks.TestModels;

public record InnerTestModelId
{
    public string InnerId { get; set; } = string.Empty;
    public DateTime DateOnly { get; set; }
    public int Integer { get; set; }
};