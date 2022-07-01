namespace HashCode.Benchmarks.Extensions;

public readonly struct HashCodeV6
{
    private readonly int _value;

    public HashCodeV6(int value) => _value = value;

    public static HashCodeV6 Start { get; } = new(17);

    public static implicit operator int(HashCodeV6 hash) => hash._value;

    public HashCodeV6 Hash<T>(T obj)
    {
        var hash = EqualityComparer<T>.Default.GetHashCode(obj!);
        
        return unchecked(new HashCodeV6(_value * 31 + hash));
    }

    public override int GetHashCode() => _value;
}