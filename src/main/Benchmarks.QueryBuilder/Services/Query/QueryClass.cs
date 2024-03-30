namespace Benchmarks.QueryBuilder.Services.Query;

/// <summary>
///     Override of <see cref="Dictionary{TKey,TValue}" /> with length.
/// </summary>
public sealed class QueryDictionary : Dictionary<string, string>
{
    /// <inheritdoc />
    public QueryDictionary(int size) : base(size)
    {
    }

    /// <summary>
    ///     Gets overall length of all keys and values by chars.
    /// </summary>
    public int QueryLength { get; private set; }

    /// <summary>
    ///     Override of <see cref="Add" /> of dictionary with adding length of key and value.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="value">Value.</param>
    public new void Add(string key, string value)
    {
        QueryLength += key.Length + value.Length;

        base.Add(key, value);
    }

    /// <summary>
    ///     Override of <see cref="Add" /> of dictionary with adding length of key and value.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="value">Value.</param>
    public new bool TryAdd(string key, string value)
    {
        QueryLength += key.Length + value.Length;

        return base.TryAdd(key, value);
    }
}