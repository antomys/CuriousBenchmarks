using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;

namespace StringExtensionsBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class InterpolationTests
{
    private const string TestTemplate = "{0}:{1}";
    private readonly Consumer _consumer = new();

    [Benchmark]
    public void CombineInterpolation()
    {
        $"{nameof(InterpolationTests)}:{nameof(Program)}".Consume(_consumer);
    }
    
    [Benchmark]
    public void CombineFormat()
    {
        string.Format(TestTemplate, nameof(InterpolationTests), nameof(Program)).Consume(_consumer);
    }
}