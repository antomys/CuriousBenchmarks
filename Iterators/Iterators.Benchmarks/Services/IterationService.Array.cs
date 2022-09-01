namespace Iterators.Benchmarks.Services;

/// <inheritdoc cref="IterationService" />.
public static partial class IterationService
{
    /// <summary>
    ///     Testing with 'for' method.
    /// </summary>
    public static int For(this int[] inputArray)
    {
        var sumResult = 0;
    
        for (var i = 0; i < inputArray.Length; i++)
        {
            sumResult += inputArray[i];
        }
    
        return sumResult;
    }

    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    public static int Foreach(this int[] inputArray)
    {
        var sumResult = 0;

        foreach (var testModel in inputArray)
        {
            sumResult += testModel;
        }

        return sumResult;
    }
    
    /// <summary>
    ///     Testing with 'Linq' methods.
    /// </summary>
    public static int? LinqAggregate(this int[] inputArray)
    {
        return inputArray.Aggregate((a, b) => a + b);
    }
    
    /// <summary>
    ///     Testing with 'Linq' methods.
    /// </summary>
    public static int? LinqSum(this int[] inputArray)
    {
        return inputArray.Sum();
    }
    
    /// <summary>
    ///     Testing with 'Ref Foreach' methods.
    /// </summary>
    public static int RefForeach(this int[] inputArray)
    {
        var sumResult = 0;

        foreach (ref var input in inputArray.AsSpan())
        {
            sumResult += input;
        }

        return sumResult;
    }
    
    /// <summary>
    ///     Testing with 'Span For' methods.
    /// </summary>
    public static int SpanFor(this int[] inputArray)
    {
        var sumResult = 0;

        var array = inputArray.AsSpan();
        
        for (var i = 0; i < array.Length; i++)
        {
            sumResult += inputArray[i];
        }

        return sumResult;
    }
}