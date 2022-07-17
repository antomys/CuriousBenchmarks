namespace HashCode.Benchmarks.Extensions;

/// <summary>
///     Sixth version of hash code.
/// </summary>
public readonly struct HashCodeV6
{
    private readonly int _value;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="value"><see cref="_value"/>.</param>
    public HashCodeV6(int value) => _value = value;

    /// <summary>
    ///     Start point of getting hashcode
    /// </summary>
    public static HashCodeV6 Start { get; } = new(17);

    /// <summary>
    ///     Implicit conversion from hashcode to int.
    /// </summary>
    /// <param name="hash"><see cref="HashCodeV6"/>.</param>
    /// <returns>int</returns>
    public static implicit operator int(HashCodeV6 hash) => hash._value;

    /// <summary>
    ///     Hashes.
    /// </summary>
    /// <param name="obj">T.</param>
    /// <typeparam name="T">T.</typeparam>
    /// <returns><see cref="HashCodeV6"/>.</returns>
    public HashCodeV6 Hash<T>(T obj)
    {
        var hash = EqualityComparer<T>.Default.GetHashCode(obj!);
        
        return unchecked(new HashCodeV6(_value * 31 + hash));
    }

    /// <summary>
    ///     Gets hash code.
    /// </summary>
    /// <returns>int.</returns>
    public override int GetHashCode() => _value;
}