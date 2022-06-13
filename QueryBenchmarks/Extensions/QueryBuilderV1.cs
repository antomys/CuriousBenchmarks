namespace QueryBenchmarks.Extensions;

/// <inheritdoc />
public sealed class QueryBuilderV1 : Dictionary<string, string>
{
    private int _stringCount;

    /// <summary>
    ///     Overload of <see cref="Add"/> dictionary method.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="value">Value.</param>
    public new void Add(string key, string value)
    {
        _stringCount += key.Length + value.Length;

        base.Add(key, value);
    }

    /// <summary>
    ///     Gets length of all entities in a dictionary.
    /// </summary>
    /// <returns>int.</returns>
    public int GetOverallLength() => _stringCount;
}