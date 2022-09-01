using System.Runtime.InteropServices;

namespace Iterators.Benchmarks.Services;

/// <inheritdoc cref="IterationService" />.
public static partial class IterationService
{
    /// <summary>
    ///     Testing with 'for' method.
    /// </summary>
    public static int For(this List<int?> inputList)
    {
        var sumResult = 0;
    
        for (var i = 0; i < inputList.Count; i++)
        {
            sumResult += inputList[i].GetValueOrDefault();
        }
    
        return sumResult;
    }

    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    public static int Foreach(this List<int?> inputList)
    {
        var sumResult = 0;

        foreach (var testModel in inputList)
        {
            sumResult += testModel.GetValueOrDefault();
        }

        return sumResult;
    }
    
    /// <summary>
    ///     Testing with 'Linq' methods.
    /// </summary>
    public static int? LinqAggregate(this List<int?> inputList)
    {
        return inputList.Aggregate((a, b) => a.GetValueOrDefault() + b.GetValueOrDefault());
    }
    
    /// <summary>
    ///     Testing with 'Linq' methods.
    /// </summary>
    public static int? LinqSum(this List<int?> inputList)
    {
        return inputList.Sum();
    }
    
    /// <summary>
    ///     Testing with 'Ref Foreach' methods.
    /// </summary>
    public static int RefForeach(this List<int?> inputList)
    {
        var sumResult = 0;

        foreach (ref var input in CollectionsMarshal.AsSpan(inputList))
        {
            sumResult += input.GetValueOrDefault();
        }

        return sumResult;
    }
    
    /// <summary>
    ///     Testing with 'Span For' methods.
    /// </summary>
    public static int SpanFor(this List<int?> inputList)
    {
        var sumResult = 0;

        var array = CollectionsMarshal.AsSpan(inputList);
        
        for (var i = 0; i < array.Length; i++)
        {
            sumResult += inputList[i].GetValueOrDefault();
        }

        return sumResult;
    }
}