namespace Benchmarks.CollectionSize.Services;

internal static partial class AnyLengthService
{
    public static bool CountArray<T>(this T[]? tArray)
    {
        return tArray is not null && tArray.Length > 0;
    }

    public static bool CountList<T>(this List<T>? tArray)
    {
        return tArray is not null && tArray.Count > 0;
    }

    public static bool CountCollection<T>(this ICollection<T>? tArray)
    {
        return tArray is not null && tArray.Count > 0;
    }
    
    public static bool CountEnumerable<T>(this IEnumerable<T>? tArray)
    {
        return tArray is not null && tArray.Count() > 0;
    }
}