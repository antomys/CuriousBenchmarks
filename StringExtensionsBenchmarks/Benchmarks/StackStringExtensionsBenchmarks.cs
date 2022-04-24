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
///      New set of benchmarks with new extensions.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class StackStringExtensionsBenchmarks
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
      // Note : In class we have upper limit for using stackalloc. limit is 64 bytes == 64 symbols.
      _testStringArray = 
         new Faker<StringsTestModel>()
         .RuleFor(x => x.Values, y => new[] {y.Random.String2(0, 31), y.Random.String2(0, 31)})
         .Generate(Count);
   }
   
   /// <summary>
   ///   Old method to generate link (ex: asd-ada).
   /// </summary>
   [BenchmarkCategory("Link Format"), Benchmark(Baseline = true)]
   public void GenerateLinkFormatOld()
   {
      _testStringArray
         .Select(stringsTestModel=> OldStringExtensions.ToLinkFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }
   
   /// <summary>
   ///   New method to generate link (ex: asd-ada).
   /// </summary>
   [BenchmarkCategory("Link Format"), Benchmark]
   public void GenerateLinkFormatNew()
   {
      _testStringArray
         .Select(stringsTestModel => ArrayPoolStringExtensions.ToLinkFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }

   /// <summary>
   ///   Old method to generate dashed view (ex: asd - ada).
   /// </summary>
   [BenchmarkCategory("Dash View"), Benchmark]
   public void GenerateDashFormatOld()
   {
      _testStringArray
         .Select(stringsTestModel => OldStringExtensions.ToDashedView(stringsTestModel.Values))
         .Consume(_consumer);
   }
   
   /// <summary>
   ///   Old method to generate dashed view (ex: asd - ada).
   /// </summary>
   [BenchmarkCategory("Dash View"), Benchmark]
   public void GenerateDashFormatNew()
   {
      _testStringArray
         .Select(stringsTestModel => ArrayPoolStringExtensions.ToDashFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }
}