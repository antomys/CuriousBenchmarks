using System.Buffers;
using System.Text.Json;
using Benchmarks.Iterators.Models;

namespace Benchmarks.Iterators.Services;

/// <summary>
///     Iteration service. Made static for faster development
/// </summary>
public static partial class IterationService
{
    /// <summary>
    ///     Testing with 'for' method.
    /// </summary>
    /// <param name="testInputModels"></param>
    public static string[] For(this List<SimpleModel> testInputModels)
    {
        var testOutputModels = new string[testInputModels.Count];

        for (var i = 0; i < testInputModels.Count; i++)
        {
            if (testInputModels[i] is null)
            {
                continue;
            }
            
            testOutputModels[i] = JsonSerializer.Serialize(testInputModels[i]);
        }

        return testOutputModels;
    }
    
    /// <summary>
    ///     Testing with 'for' method.
    /// </summary>
    /// <param name="testInputModels"></param>
    public static string[] ForArrayPool(this List<SimpleModel> testInputModels)
    {
        var pooledArray = ArrayPool<string>.Shared.Rent(testInputModels.Count);
        try
        {
            Span<string> spanArray = pooledArray;

            var index = 0;

            while (index < testInputModels.Count)
            {
                if (testInputModels[index] is null)
                {
                    index++;
                    continue;
                }

                spanArray[index] = JsonSerializer.Serialize(testInputModels[index]);
                index++;
            }

            return spanArray[..index].ToArray();
        }
        finally
        {
            ArrayPool<string>.Shared.Return(pooledArray);
        }
    }
    
    /// <summary>
    ///     Testing with 'for' method.
    /// </summary>
    /// <param name="testInputModels"></param>
    public static IEnumerable<string> Yield(this List<SimpleModel> testInputModels)
    {
        foreach (var testModel in testInputModels)
        {
            if (testModel is null)
            {
                continue;
            }
            
            yield return JsonSerializer.Serialize(testModel);
        }
    }
    
    /// <summary>
    ///     Testing with 'Foreach' method.
    /// </summary>
    public static List<string> Foreach(this List<SimpleModel> testInputModels)
    {
        var testOutputModels = new List<string>(testInputModels.Count);
        
        foreach (var testModel in testInputModels)
        {
            if (testModel is null)
            {
                continue;
            }
            
            testOutputModels.Add(JsonSerializer.Serialize(testModel));
        }

        return testOutputModels;
    }

    /// <summary>
    ///     Testing with 'Linq' methods.
    /// </summary>
    public static IEnumerable<string> Linq(this IEnumerable<SimpleModel> testInputModels)
    {
        return testInputModels
            .Where(testModel => testModel is not null)
            .Select(testModel => JsonSerializer.Serialize(testModel));
    }
}