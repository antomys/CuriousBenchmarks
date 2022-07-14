using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using String.Benchmarks.Benchmarks.Abstractions;
using String.Benchmarks.Services;

namespace String.Benchmarks.Benchmarks;

/// <summary>
///     Benchmarking building link.
/// </summary>
public class SingleLinkStringBenchmarks : BenchmarkBase
{
    /// <summary>
    ///   Generates link format with SpanOwner.
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinkFormat), Benchmark]
    public void LinkFormatSpanOwner()
    {
        SpanOwnerStringService.ToLinkFormat(TestStringArray.Values).Consume(Consumer);
    }
    
    /// <summary>
    ///   Generates link format with regex.
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinkFormat), Benchmark]
    public void LinkFormatRegex()
    {
        RegexStringService.ToLinkFormat(TestStringArray.Values).Consume(Consumer);
    }

    /// <summary>
    ///   Generate with ArrayPool.
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinkFormat), Benchmark]
    public void LinkFormatArrayPool()
    {
        ArrayPoolStringService.ToLinkFormat(TestStringArray.Values).Consume(Consumer);
    }
}