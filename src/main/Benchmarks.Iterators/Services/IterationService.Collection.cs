namespace Benchmarks.Iterators.Services;

/// <inheritdoc cref="IterationService" />
/// .
public static partial class IterationService
{
    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    public static int Foreach(this ICollection<int> inputCollection)
    {
        var sumResult = 0;

        foreach (var testModel in inputCollection) sumResult += testModel;

        return sumResult;
    }

    /// <summary>
    ///     Testing with 'Linq' methods.
    /// </summary>
    public static int? LinqAggregate(this ICollection<int> inputCollection)
    {
        return inputCollection.Aggregate((a, b) => a + b);
    }

    /// <summary>
    ///     Testing with 'Linq' methods.
    /// </summary>
    public static int? LinqSum(this ICollection<int> inputCollection)
    {
        return inputCollection.Sum();
    }
}