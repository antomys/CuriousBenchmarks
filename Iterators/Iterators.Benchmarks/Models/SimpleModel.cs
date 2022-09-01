using System.Diagnostics.CodeAnalysis;

namespace Iterators.Benchmarks.Models;

/// <summary>
///     Test model class.
/// </summary>
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public sealed class SimpleModel
{
    /// <summary>
    ///     Test id.
    /// </summary>
    public int? TestInd { get; set; }
    
    /// <summary>
    ///     Test string.
    /// </summary>
    public string? TestString { get; set; }
    
    /// <summary>
    ///     Test date time.
    /// </summary>
    public DateTime? TestDateTime { get; set; }
}