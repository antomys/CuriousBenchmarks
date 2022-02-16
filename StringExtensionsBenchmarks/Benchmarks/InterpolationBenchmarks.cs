using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Bogus;
using StringExtensionsBenchmarks.Models;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace StringExtensionsBenchmarks.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class InterpolationBenchmarks
{
    private const string TestTemplate = "{0}{1}";
    private readonly Consumer _consumer = new();
    private InterpolationModel _interpolationModel = null!;
    
    // Intentionally left public for BenchmarkDotNet Params.
    [Params(10, 100, 1000, 10000, 100000, 1000000)]
    public int Count { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        _interpolationModel =
            new Faker<InterpolationModel>()
                .RuleFor(x => x.FirstValue, y => y.Random.String2(10))
                .RuleFor(x => x.SecondValue, y => y.Random.String2(10))
                .Generate(1)[0];

    }
    
    [Benchmark]
    public void CombineInterpolation()
    {
        $"{_interpolationModel.FirstValue}{_interpolationModel.SecondValue}".Consume(_consumer);
    }
    
    [Benchmark]
    public void CombineFormat()
    {
        string.Format(TestTemplate, _interpolationModel.FirstValue, _interpolationModel.SecondValue).Consume(_consumer);
    }
    
    [Benchmark]
    public void ConcatString()
    { 
        string.Concat(_interpolationModel.FirstValue, _interpolationModel.SecondValue).Consume(_consumer);
    }
   
    [Benchmark]
    public void CombineStringBuilder()
    {
        var sb = new StringBuilder();
        sb.Append(_interpolationModel.FirstValue);
        sb.Append(_interpolationModel.SecondValue);
        
        sb.ToString().Consume(_consumer);
    }
   
    [Benchmark]
    public void CombineSpan()
    { 
        string.Create(_interpolationModel.FirstValue.Length + _interpolationModel.SecondValue.Length, (_interpolationModel.FirstValue, _interpolationModel.SecondValue),
            (shit, bebe) =>
            {
                var index = 0;
                var (val0, val1) = bebe;

                val0.CopyTo(shit);
                index += val0.Length;

                val1.CopyTo(shit[index..]);
            })
            .Consume(_consumer);
    }
}