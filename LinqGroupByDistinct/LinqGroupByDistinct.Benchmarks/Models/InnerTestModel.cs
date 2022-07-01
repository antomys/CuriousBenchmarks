namespace LinqGroupByDistinct.Benchmarks.Models;

/// <summary>
///     Inner test class of test class.
/// </summary>
public sealed class InnerTestModel
{
    /// <summary>
    ///     Id of inner test model.
    /// </summary>
    public string InnerId { get; set; } = string.Empty;

    /// <summary>
    ///     Date
    /// </summary>
    public DateTime DateOnly { get; set; } = DateTime.Now;

    /// <summary>
    ///     Test int value.
    /// </summary>
    public int Integer { get; set; }
};