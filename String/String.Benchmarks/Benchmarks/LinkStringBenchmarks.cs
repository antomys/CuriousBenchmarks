using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using String.Benchmarks.Benchmarks.Abstractions;
using String.Benchmarks.Services;

namespace String.Benchmarks.Benchmarks;

/// <summary>
///     Benchmarking building link.
/// </summary>
public class LinkStringBenchmarks : BenchmarkCollectionBase
{
    /// <summary>
    ///   Generates link format with SpanOwner.
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinkFormat), Benchmark]
    public void LinkFormatSpanOwner()
    {
        TestStringArray
            .Select(stringsTestModel => SpanOwnerStringService.ToLinkFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }
    
    /// <summary>
    ///   Generates link format with regex.
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinkFormat), Benchmark]
    public void LinkFormatRegex()
    {
        TestStringArray
            .Select(stringsTestModel => RegexStringService.ToLinkFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }

    /// <summary>
    ///   Generate with ArrayPool.
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinkFormat), Benchmark]
    public void LinkFormatArrayPool()
    {
        TestStringArray
            .Select(stringsTestModel => ArrayPoolStringService.ToLinkFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }
}