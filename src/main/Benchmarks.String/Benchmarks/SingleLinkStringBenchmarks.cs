using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks.String.Benchmarks.Abstractions;
using Benchmarks.String.Services;

namespace Benchmarks.String.Benchmarks;

/// <summary>
///     Benchmarking building link.
/// </summary>
public class SingleLinkStringBenchmarks : BenchmarkBase
{
    /// <summary>
    ///   Generates link format with SpanOwner.
    /// </summary>
    [BenchmarkCategory(Group.LinkFormat), Benchmark]
    public void LinkFormatSpanOwner()
    {
        SpanOwnerStringService.ToLinkFormat(TestStringArray.Values).Consume(Consumer);
    }
    
    /// <summary>
    ///   Generates link format with regex.
    /// </summary>
    [BenchmarkCategory(Group.LinkFormat), Benchmark]
    public void LinkFormatRegex()
    {
        RegexStringService.ToLinkFormat(TestStringArray.Values).Consume(Consumer);
    }

    /// <summary>
    ///   Generate with ArrayPool.
    /// </summary>
    [BenchmarkCategory(Group.LinkFormat), Benchmark]
    public void LinkFormatArrayPool()
    {
        ArrayPoolStringService.ToLinkFormat(TestStringArray.Values).Consume(Consumer);
    }
}