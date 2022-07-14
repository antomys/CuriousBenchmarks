using System.Diagnostics.CodeAnalysis;

namespace LinqGroupByDistinct.Benchmarks.Models;

/// <summary>
///     Test model.
/// </summary>
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public sealed class SimpleModel
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