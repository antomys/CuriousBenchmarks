using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks.String.Benchmarks.Abstractions;
using Benchmarks.String.Services;

namespace Benchmarks.String.Benchmarks;

/// <summary>
///     Benchmarking building link.
/// </summary>
[ExcludeFromCodeCoverage]
public class LinkStringBenchmarks : BenchmarkCollectionBase
{
    /// <summary>
    ///     Generates link format with SpanOwner.
    /// </summary>
    [BenchmarkCategory(Group.LinkFormat), Benchmark]
    public void LinkFormatSpanOwner()
    {
        TestStringArray
            .Select(stringsTestModel => SpanOwnerStringService.ToLinkFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }

    /// <summary>
    ///     Generates link format with regex.
    /// </summary>
    [BenchmarkCategory(Group.LinkFormat), Benchmark]
    public void LinkFormatRegex()
    {
        TestStringArray
            .Select(stringsTestModel => RegexStringService.ToLinkFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }

    /// <summary>
    ///     Generate with ArrayPool.
    /// </summary>
    [BenchmarkCategory(Group.LinkFormat), Benchmark]
    public void LinkFormatArrayPool()
    {
        TestStringArray
            .Select(stringsTestModel => ArrayPoolStringService.ToLinkFormat(stringsTestModel.Values))
            .Consume(Consumer);
    }
}