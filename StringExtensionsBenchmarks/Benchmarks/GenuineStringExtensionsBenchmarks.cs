using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Bogus;
using StringExtensionsBenchmarks.Models;
using StringExtensionsBenchmarks.StringExtensions;

namespace StringExtensionsBenchmarks.Benchmarks;

/// <summary>
///      Original string benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class GenuineStringExtensionsBenchmarks
{
   private readonly Consumer _consumer = new();

   private List<StringsTestModel> _testStringArray = null!;
   
   /// <summary>
   ///     Parameter for models count.
   ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
   /// </summary>
   [Params(10, 100, 1000, 10000, 100000, 1000000)]
   // ReSharper disable once UnusedAutoPropertyAccessor.Global
   public int Count { get; set; }
   
   /// <summary>
   ///   Global setup.
   /// </summary>
   [GlobalSetup]
   public void Setup()
   {
      //stackalloc is used when sum of chars is less than 64. So we do generate random bigger that 64 to eliminate this behaviour.
      _testStringArray = 
         new Faker<StringsTestModel>()
         .RuleFor(x => x.Values, y => new[] {y.Random.String2(65, 100), y.Random.String2(0, 100)})
         .Generate(Count);
   }

   /// <summary>
   ///   Generates link format
   /// </summary>
   [BenchmarkCategory("LinkFormat"), Benchmark]
   public void GenerateLinkFormatSpanOwner()
   {
      _testStringArray
         .Select(stringsTestModel => SpanOwnerStringExtensions.ToLinkFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }

   /// <summary>
   ///   Generate with arrayPool.
   /// </summary>
   [BenchmarkCategory("LinkFormat"), Benchmark]
   public void GenerateLinkFormatArrayPool()
   {
      _testStringArray
         .Select(stringsTestModel => ArrayPoolStringExtensions.ToLinkFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }
   
   /// <summary>
   ///   Dash format with SpanOwner.
   /// </summary>
   [BenchmarkCategory("DashView"), Benchmark]
   public void GenerateDashFormatSpanOwner()
   {
      _testStringArray
         .Select(stringsTestModel => SpanOwnerStringExtensions.ToDashFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }

   /// <summary>
   ///   Dash format with arrayPool.
   /// </summary>
   [BenchmarkCategory("DashView"), Benchmark]
   public void GenerateDashFormatArrayPool()
   {
      _testStringArray
         .Select(stringsTestModel => ArrayPoolStringExtensions.ToDashFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }
}