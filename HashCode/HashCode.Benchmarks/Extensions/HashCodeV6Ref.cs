namespace HashCode.Benchmarks.Extensions;

/// <summary>
///     Sixth version of hash code with ref.
/// </summary>
public readonly ref struct HashCodeV6Ref
{
    private static int _value = 17;
    
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="value"><see cref="_value"/>.</param>
    public HashCodeV6Ref(int value) => _value = value;
    
    /// <summary>
    ///     Implicit conversion from hashcode to int.
    /// </summary>
    /// <param name="hash"><see cref="HashCodeV6"/>.</param>
    /// <returns>int</returns>
    public static implicit operator int(HashCodeV6Ref hash) => _value;

    /// <summary>
    ///     Hashes.
    /// </summary>
    /// <param name="obj">T.</param>
    /// <typeparam name="T">T.</typeparam>
    /// <returns><see cref="HashCodeV6"/>.</returns>
    public static HashCodeV6Ref Hash<T>(T obj)
    {
        var hash = EqualityComparer<T>.Default.GetHashCode(obj!);
        
        return unchecked(new HashCodeV6Ref(_value * 31 + hash));
    }

    /// <summary>
    ///     Gets hash code.
    /// </summary>
    /// <returns>int.</returns>
    public override int GetHashCode() => _value;
}