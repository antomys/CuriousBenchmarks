namespace AnyLength.Benchmarks.Services;

public static class AnyLengthService
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

    public static bool CountEnumerable<T>(this IEnumerable<T>? tArray)
    {
        return tArray is not null && tArray.Count() > 0;
    }
    
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