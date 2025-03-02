using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace Benchmarks.Stopwatch;

[MemoryDiagnoser]
[CategoriesColumn]
[AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[MarkdownExporterAttribute.GitHub]
[CsvMeasurementsExporter]
[ExcludeFromCodeCoverage]
public class TimeBenchmarks
{
    [Benchmark(Description = "Stopwatch.StartNew().Elapsed", Baseline = true)]
    public TimeSpan Old()
    {
        return System.Diagnostics.Stopwatch.StartNew().Elapsed;
    }

    [Benchmark(Description = "Stopwatch.GetElapsedTime(System.Diagnostics.Stopwatch.GetTimestamp()")]
    public TimeSpan New()
    {
        return System.Diagnostics.Stopwatch.GetElapsedTime(System.Diagnostics.Stopwatch.GetTimestamp());
    }
}