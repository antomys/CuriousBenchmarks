namespace Benchmarks.CollectionSize.Services;

internal static partial class AnyLengthService
{
    public static bool AnyArray<T>(this T[]? tArray)
    {
        return tArray is not null && tArray.Any();
    }

    public static bool AnyList<T>(this List<T>? tArray)
    {
        return tArray is not null && tArray.Any();
    }

    public static bool AnyCollection<T>(this ICollection<T>? tArray)
    {
        return tArray is not null && tArray.Any();
    }

    public static bool AnyEnumerable<T>(this IEnumerable<T>? tArray)
    {
        return tArray is not null && tArray.Any();
    }
}