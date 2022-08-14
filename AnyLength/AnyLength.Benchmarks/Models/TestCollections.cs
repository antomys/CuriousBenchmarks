namespace AnyLength.Benchmarks.Models;

/// <summary>
///     Model for storing different collections for benchmarks.
/// </summary>
public sealed class TestCollections
{
    /// <summary>
    ///     Collection of <see cref="Array"/> type.
    /// </summary>
    public string[] TestArray { get; set; } = null!;

    /// <summary>
    ///     Collection of <see cref="List{T}"/> type.
    /// </summary>
    public List<string> TestList { get; set; } = null!;

    /// <summary>
    ///     Collection of <see cref="ICollection{T}"/> type.
    /// </summary>
    public ICollection<string> TestICollection { get; set; } = null!;

    /// <summary>
    ///     Collection of <see cref="IEnumerable{T}"/> type.
    /// </summary>
    public IEnumerable<string> TestIEnumerable { get; set; } = null!;
}