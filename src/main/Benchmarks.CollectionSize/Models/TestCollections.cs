namespace Benchmarks.CollectionSize.Models;

/// <summary>
///     Model for storing different collections for benchmarks.
/// </summary>
public sealed class TestCollections
{
    /// <summary>
    ///     Collection of <see cref="Array"/> type.
    /// </summary>
    public string[] TestArray { get; init; }

    /// <summary>
    ///     Collection of <see cref="List{T}"/> type.
    /// </summary>
    public List<string> TestList { get; init; }

    /// <summary>
    ///     Collection of <see cref="ICollection{T}"/> type.
    /// </summary>
    public ICollection<string> TestICollection { get; init; }

    /// <summary>
    ///     Collection of <see cref="IEnumerable{T}"/> type.
    /// </summary>
    public IEnumerable<string> TestIEnumerable { get; init; }
}