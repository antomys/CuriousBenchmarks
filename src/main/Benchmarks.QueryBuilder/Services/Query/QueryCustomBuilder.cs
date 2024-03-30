using System.Buffers;
using System.Collections;

namespace Benchmarks.QueryBuilder.Services.Query;

/// <inheritdoc />
public sealed class QueryCustomBuilder : IReadOnlyCollection<KeyValuePair<string, string>>
{
    private readonly IList<KeyValuePair<string, string>> _valuePairs;

    /// <summary>
    ///     Constructor.
    /// </summary>
    public QueryCustomBuilder()
    {
        _valuePairs = new List<KeyValuePair<string, string>>();
    }

    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="parameters">Collection of KeyValuePairs.</param>
    public QueryCustomBuilder(IReadOnlyCollection<KeyValuePair<string, string>> parameters)
    {
        Count += parameters.Sum(pair => pair.Key.Length + pair.Value.Length);

        _valuePairs = new List<KeyValuePair<string, string>>(parameters);
    }

    /// <inheritdoc />
    public int Count { get; private set; }

    /// <inheritdoc />
    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return _valuePairs.GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _valuePairs.GetEnumerator();
    }

    /// <summary>
    ///     Adds key and it's values to the collection.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="values">Collection of values.</param>
    public void Add(string key, IEnumerable<string> values)
    {
        Count += key.Length;

        foreach (var value in values)
        {
            Count += value.Length;

            _valuePairs.Add(KeyValuePair.Create(key, value));
        }
    }

    /// <summary>
    ///     Adds key and it's value to the collection.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="value">Value.</param>
    public void Add(string key, string value)
    {
        Count += key.Length + value.Length;

        _valuePairs.Add(KeyValuePair.Create(key, value));
    }

    /// <inheritdoc />
    public override string ToString()
    {
        if (Count is 0) return string.Empty;

        var queryLength = Count * 2;

        var isStackAlloc = queryLength <= 64;
        var currentPosition = 0;

        var array = isStackAlloc ? null : ArrayPool<char>.Shared.Rent(queryLength);
        var resultSpan = isStackAlloc ? stackalloc char[queryLength] : array;

        try
        {
            var first = true;

            for (var i = 0; i < _valuePairs.Count; i++)
            {
                var pair = _valuePairs[i];
                resultSpan[currentPosition] = first ? '?' : '&';
                first = false;
                currentPosition++;

                var escapeKey = System.Uri.EscapeDataString(pair.Key);
                escapeKey.CopyTo(resultSpan[currentPosition..]);
                currentPosition += escapeKey.Length;

                resultSpan[currentPosition++] = '=';

                var escapedValue = System.Uri.EscapeDataString(pair.Value);
                escapedValue.CopyTo(resultSpan[currentPosition..]);
                currentPosition += escapedValue.Length;
            }

            var endIndex = resultSpan.IndexOf('\0');

            return endIndex is -1
                ? resultSpan[..currentPosition].ToString()
                : resultSpan[..(endIndex > currentPosition ? currentPosition : endIndex)].ToString();
        }
        finally
        {
            if (array is not null) ArrayPool<char>.Shared.Return(array);
        }
    }
}