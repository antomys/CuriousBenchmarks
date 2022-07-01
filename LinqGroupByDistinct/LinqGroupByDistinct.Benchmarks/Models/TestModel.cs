namespace LinqGroupByDistinct.Benchmarks.Models;

/// <summary>
///     Test model.
/// </summary>
public sealed class TestModel
{
    /// <summary>
    ///     Id of test model.
    /// </summary>
    public string TestModelId { get; set; } = string.Empty;
    /// <summary>
    ///     Id of inner test model.
    /// </summary>
    public string InnerTestModelId { get; set; } = string.Empty;

    /// <summary>
    ///     Test Date.
    /// </summary>
    public DateTime DateOnly { get; set; } = DateTime.Now;

    /// <summary>
    ///     Test int value.
    /// </summary>
    public int Integer { get; set; }
}