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
public class StackStringExtensionsBenchmarks
{
   private readonly Consumer _consumer = new();

   private List<StringsTestModel> _testStringArray = null!;
   
   // Intentionally left public for BenchmarkDotNet Params.
   [Params(10, 100, 1000, 10000, 100000, 1000000)]
   public int Count { get; set; }
   
   [GlobalSetup]
   public void Setup()
   {
      // Note : In class we have upper limit for using stackalloc. limit is 64 bytes == 64 symbols.
      _testStringArray = 
         new Faker<StringsTestModel>()
         .RuleFor(x => x.Values, y => new[] {y.Random.String2(0, 31), y.Random.String2(0, 31)})
         .Generate(Count);
   }
   
   [BenchmarkCategory("LinkFormat"), Benchmark(Baseline = true)]
   public void GenerateLinkFormatOld()
   {
      _testStringArray
         .Select(x=> OldStringExtensions.ToLinkFormat(x.Values))
         .Consume(_consumer);
   }
   
   [BenchmarkCategory("LinkFormat"), Benchmark]
   public void GenerateLinkFormatNew()
   {
      _testStringArray
         .Select(x => ArrayPoolStringExtensions.ToLinkFormat(x.Values))
         .Consume(_consumer);
   }

   [BenchmarkCategory("DashView"), Benchmark]
   public void GenerateDashFormatOld()
   {
      _testStringArray
         .Select(x => OldStringExtensions.ToLinkFormat(x.Values))
         .Consume(_consumer);
   }
   
   [BenchmarkCategory("DashView"), Benchmark]
   public void GenerateDashFormatNew()
   {
      _testStringArray
         .Select(x => ArrayPoolStringExtensions.ToDashFormat(x.Values))
         .Consume(_consumer);
   }
}