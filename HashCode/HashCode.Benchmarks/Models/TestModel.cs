namespace HashCode.Benchmarks.Models;

public sealed class TestModel
{
    public TestModel(int id, string value)
    {
        Id = id;
        Value = value;
    }

    public int Id { get; }

    public string Value { get; }
}