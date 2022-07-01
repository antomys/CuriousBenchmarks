using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Bogus;
using String.Benchmarks.Models;
using String.Benchmarks.StringExtensions;

namespace String.Benchmarks.Benchmarks;

/// <summary>
///      Original string benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
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
   [BenchmarkCategory(GroupConstants.LinkFormat), Benchmark]
   public void LinkFormatSpanOwner()
   {
      _testStringArray
         .Select(stringsTestModel => SpanOwnerStringExtensions.ToLinkFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }

   /// <summary>
   ///   Generate with arrayPool.
   /// </summary>
   [BenchmarkCategory(GroupConstants.LinkFormat), Benchmark]
   public void LinkFormatArrayPool()
   {
      _testStringArray
         .Select(stringsTestModel => ArrayPoolStringExtensions.ToLinkFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }
   
   /// <summary>
   ///   Dash format with SpanOwner.
   /// </summary>
   [BenchmarkCategory(GroupConstants.DashView), Benchmark]
   public void DashFormatSpanOwner()
   {
      _testStringArray
         .Select(stringsTestModel => SpanOwnerStringExtensions.ToDashFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }

   /// <summary>
   ///   Dash format with arrayPool.
   /// </summary>
   [BenchmarkCategory(GroupConstants.DashView), Benchmark]
   public void DashFormatArrayPool()
   {
      _testStringArray
         .Select(stringsTestModel => ArrayPoolStringExtensions.ToDashFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }
}