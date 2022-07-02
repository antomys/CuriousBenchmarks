namespace HashCode.Benchmarks.Models;

/// <summary>
///     Testing model for hash coding.
/// </summary>
public sealed class SimpleModel
{
    /// <summary>
    ///     .ctor
    /// </summary>
    /// <param name="id"><see cref="Id"/>.</param>
    /// <param name="value"><see cref="Value"/>.</param>
    public SimpleModel(int id, string value)
    {
        Id = id;
        Value = value;
    }

    /// <summary>
    ///     Gets or sets random int id.
    /// </summary>
    public int Id { get; }

    /// <summary>
    ///     Gets or sets random string value.
    /// </summary>
    public string Value { get; }
}