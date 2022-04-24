namespace GroupByOrDistinctBenchmarks.Models;

/// <summary>
///     Inner test class of test class.
/// </summary>
public sealed class InnerTestModelId
{
    /// <summary>
    ///     Id of inner test model.
    /// </summary>
    public string InnerId { get; set; } = string.Empty;
    
    /// <summary>
    ///     Date
    /// </summary>
    public DateTime DateOnly { get; set; }
    
    /// <summary>
    ///     Test int value.
    /// </summary>
    public int Integer { get; set; }
};