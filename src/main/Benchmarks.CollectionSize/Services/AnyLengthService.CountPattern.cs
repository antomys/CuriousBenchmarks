namespace Benchmarks.CollectionSize.Services;

internal static partial class AnyLengthService
{
    public static bool CountArrayPattern<T>(this T[]? tArray)
    {
        return tArray is {Length: > 0};
    }

    public static bool CountListPattern<T>(this List<T>? tArray)
    {
        return tArray is {Count: > 0};
    }

    public static bool CountCollectionPattern<T>(this ICollection<T>? tArray)
    {
        return tArray is {Count: > 0};
    }
}