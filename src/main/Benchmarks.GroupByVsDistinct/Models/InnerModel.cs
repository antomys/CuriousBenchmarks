using System.Diagnostics.CodeAnalysis;

namespace Benchmarks.GroupByVsDistinct.Models;

/// <summary>
///     Inner test class of test class.
/// </summary>
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public sealed class InnerModel
{
    /// <summary>
    ///     Id of inner test model.
    /// </summary>
    public string InnerId { get; init; } = string.Empty;

    /// <summary>
    ///     Date
    /// </summary>
    public DateTime DateOnly { get; init; } = DateTime.Now;

    /// <summary>
    ///     Test int value.
    /// </summary>
    public int Integer { get; init; }
}