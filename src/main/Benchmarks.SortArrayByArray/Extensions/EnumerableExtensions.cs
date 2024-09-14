namespace Benchmarks.SortArrayByArray.Extensions;

public static class EnumerableExtensions
{
    
    public static IList<T> Shuffle<T>(this IEnumerable<T> sequence)
    {
        return sequence.Shuffle(Random.Shared);
    }

    private static IList<T> Shuffle<T>(this IEnumerable<T> sequence, Random randomNumberGenerator)
    {
        if (sequence == null)
        {
            throw new ArgumentNullException(nameof(sequence));
        }

        if (randomNumberGenerator == null)
        {
            throw new ArgumentNullException(nameof(randomNumberGenerator));
        }

        var values = sequence.ToList();
        var currentlySelecting = values.Count;
        while (currentlySelecting > 1)
        {
            var selectedElement = randomNumberGenerator.Next(currentlySelecting);
            --currentlySelecting;
            if (currentlySelecting != selectedElement)
            {
                (values[currentlySelecting], values[selectedElement]) = (values[selectedElement], values[currentlySelecting]);
            }
        }

        return values;
    }
}