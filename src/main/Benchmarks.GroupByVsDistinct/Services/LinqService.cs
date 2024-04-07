using Benchmarks.GroupByVsDistinct.Models;

namespace Benchmarks.GroupByVsDistinct.Services;

/// <summary>
///     Linq methods testing service.
/// </summary>
public static class LinqService
{
    /// <summary>
    ///     Gets collection of <see cref="InnerModel" /> using GroupBy and Select methods.
    /// </summary>
    /// <param name="testModelsList"><see cref="SimpleModel" /> collection.</param>
    /// <param name="innerTestModels">Dictionary of value <see cref="InnerModel" /> with key as string.</param>
    /// <param name="innerTestModelConstId">Specific string id, to be retrieved by.</param>
    /// <returns>Collection of <see cref="InnerModel" />.</returns>
    public static IEnumerable<InnerModel> GroupByTake(
        this IEnumerable<SimpleModel> testModelsList, Dictionary<string, InnerModel> innerTestModels, string innerTestModelConstId)
    {
        return testModelsList
            .GroupBy(x => x.InnerTestModelId)
            .Select(_ => innerTestModels[innerTestModelConstId]);
    }

    /// <summary>
    ///     Gets collection of <see cref="InnerModel" /> using DistinctBy and Select methods.
    /// </summary>
    /// <param name="testModelsList"><see cref="SimpleModel" /> collection.</param>
    /// <param name="innerTestModels">Dictionary of value <see cref="InnerModel" /> with key as string.</param>
    /// <param name="innerTestModelConstId">Specific string id, to be retrieved by.</param>
    /// <returns>Collection of <see cref="InnerModel" />.</returns>
    public static IEnumerable<InnerModel> DistinctByTake(
        this IEnumerable<SimpleModel> testModelsList, Dictionary<string, InnerModel> innerTestModels, string innerTestModelConstId)
    {
        return testModelsList
            .DistinctBy(x => x.InnerTestModelId)
            .Select(_ => innerTestModels[innerTestModelConstId]);
    }

    /// <summary>
    ///     Gets collection of <see cref="InnerModel" /> using Select, then Distinct and then Select methods.
    /// </summary>
    /// <param name="testModelsList"><see cref="SimpleModel" /> collection.</param>
    /// <param name="innerTestModels">Dictionary of value <see cref="InnerModel" /> with key as string.</param>
    /// <param name="innerTestModelConstId">Specific string id, to be retrieved by.</param>
    /// <returns>Collection of <see cref="InnerModel" />.</returns>
    public static IEnumerable<InnerModel> DistinctTake(
        this IEnumerable<SimpleModel> testModelsList, Dictionary<string, InnerModel> innerTestModels, string innerTestModelConstId)
    {
        return testModelsList
            .Select(x => x.InnerTestModelId)
            .Distinct()
            .Select(_ => innerTestModels[innerTestModelConstId]);
    }
}