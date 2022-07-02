namespace HashCode.Benchmarks.Extensions;

/// <summary>
///     Fifth version of getting hash code.
/// </summary>
public readonly struct HashCodeV5 : IEquatable<HashCodeV5>
{
    private const int EmptyCollectionPrimeNumber = 19;
    private readonly int _value;

    private HashCodeV5(int value) => _value = value;

    /// <summary>
    ///     Implicit converting to int.
    /// </summary>
    /// <param name="hashCode"></param>
    /// <returns></returns>
    public static implicit operator int(HashCodeV5 hashCode) => hashCode._value;

    /// <summary>
    ///     Override of == operator.
    /// </summary>
    /// <param name="left">left <see cref="HashCodeV5"/></param>
    /// <param name="right">right <see cref="HashCodeV5"/></param>
    /// <returns>Bool</returns>
    public static bool operator ==(HashCodeV5 left, HashCodeV5 right) => left.Equals(right);

    /// <summary>
    ///     Override of != operator.
    /// </summary>
    /// <param name="left">left <see cref="HashCodeV5"/></param>
    /// <param name="right">right <see cref="HashCodeV5"/></param>
    /// <returns>Bool</returns>
    public static bool operator !=(HashCodeV5 left, HashCodeV5 right) => !(left == right);

    public static HashCodeV5 Of<T>(T item) => new(GetHashCode(item));

    public static HashCodeV5 OfEach<T>(IEnumerable<T>? items) =>
        items is null ? new HashCodeV5(0) : new HashCodeV5(GetHashCode(items, 0));

    public HashCodeV5 And<T>(T item) => new(CombineHashCodes(_value, GetHashCode(item)));

    public HashCodeV5 AndEach<T>(IEnumerable<T>? items)
    {
        return items is null ? new HashCodeV5(_value) : new HashCodeV5(GetHashCode(items, _value));
    }

    public bool Equals(HashCodeV5 other) => _value.Equals(other._value);

    public override bool Equals(object? obj)
    {
        if (obj is HashCodeV5 code)
        {
            return Equals(code);
        }

        return false;
    }

    public override int GetHashCode() => _value.GetHashCode();

    private static int CombineHashCodes(int h1, int h2)
    {
        unchecked
        {
            // Code copied from System.Tuple a good way to combine hashes.
            return ((h1 << 5) + h1) ^ h2;
        }
    }

    //Possible boxing allocation: inherited 'System.Object' virtual method call on value type instance
    private static int GetHashCode<T>(T item) => item?.GetHashCode() ?? 0;

    private static int GetHashCode<T>(IEnumerable<T>? items, int startHashCode)
    {
        var temp = startHashCode;

        if (items is null)
        {
            throw new ArgumentNullException(nameof(items));
        }
        
        using var enumerator = items.GetEnumerator();
        
        if (enumerator.MoveNext())
        {
            temp = CombineHashCodes(temp, GetHashCode(enumerator.Current));

            while (enumerator.MoveNext())
            {
                temp = CombineHashCodes(temp, GetHashCode(enumerator.Current));
            }
        }
        else
        {
            temp = CombineHashCodes(temp, EmptyCollectionPrimeNumber);
        }

        return temp;
    }
}