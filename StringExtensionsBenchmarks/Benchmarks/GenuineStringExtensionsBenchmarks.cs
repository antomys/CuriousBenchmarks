using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Bogus;
using StringExtensionsBenchmarks.Models;
using StringExtensionsBenchmarks.StringExtensions;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace StringExtensionsBenchmarks.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class GenuineStringExtensionsBenchmarks
{
   private readonly Consumer _consumer = new();

   private List<StringsTestModel> _testStringArray = null!;
   
   // Intentionally left public for BenchmarkDotNet Params.
   [Params(10, 100, 1000, 10000, 100000, 1000000)]
   public int Count { get; set; }
   
   [GlobalSetup]
   public void Setup()
   {
      //stackalloc is used when sum of chars is less than 64. So we do generate random bigger that 64 to eliminate this behaviour.
      _testStringArray = 
         new Faker<StringsTestModel>()
         .RuleFor(x => x.Values, y => new[] {y.Random.String2(65, 100), y.Random.String2(0, 100)})
         .Generate(Count);
   }

   [BenchmarkCategory("LinkFormat"), Benchmark]
   public void GenerateLinkFormatNewSpanOwner()
   {
      _testStringArray
         .Select(x => SpanOwnerStringExtensions.ToLinkFormat(x.Values))
         .Consume(_consumer);
   }

   [BenchmarkCategory("LinkFormat"), Benchmark]
   public void GenerateLinkFormatArrayPool()
   {
      _testStringArray
         .Select(x => ArrayPoolStringExtensions.ToLinkFormat(x.Values))
         .Consume(_consumer);
   }
   
   [BenchmarkCategory("DashView"), Benchmark]
   public void GenerateDashFormatNativeSpanOwner()
   {
      _testStringArray
         .Select(x => SpanOwnerStringExtensions.ToDashFormat(x.Values))
         .Consume(_consumer);
   }

   [BenchmarkCategory("DashView"), Benchmark]
   public void GenerateDashFormatTwoValuesSpanOwner()
   {
      _testStringArray
         .Select(x => SpanOwnerStringExtensions.ToDashFormat(x.Values))
         .Consume(_consumer);
   }
}