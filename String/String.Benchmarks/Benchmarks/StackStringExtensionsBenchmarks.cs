using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Bogus;
using String.Benchmarks.Models;
using String.Benchmarks.StringExtensions;

namespace String.Benchmarks.Benchmarks;

/// <summary>
///      New set of benchmarks with new extensions.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
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
   [BenchmarkCategory(GroupConstants.LinkFormat), Benchmark(Baseline = true)]
   public void LinkFormat()
   {
      _testStringArray
         .Select(stringsTestModel=> RegexStringExtensions.ToLinkFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }
   
   /// <summary>
   ///   New method to generate link (ex: asd-ada).
   /// </summary>
   [BenchmarkCategory(GroupConstants.LinkFormat), Benchmark]
   public void LinkFormatV1()
   {
      _testStringArray
         .Select(stringsTestModel => ArrayPoolStringExtensions.ToLinkFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }

   /// <summary>
   ///   Old method to generate dashed view (ex: asd - ada).
   /// </summary>
   [BenchmarkCategory(GroupConstants.DashView), Benchmark]
   public void DashFormat()
   {
      _testStringArray
         .Select(stringsTestModel => RegexStringExtensions.ToDashedView(stringsTestModel.Values))
         .Consume(_consumer);
   }
   
   /// <summary>
   ///   Old method to generate dashed view (ex: asd - ada).
   /// </summary>
   [BenchmarkCategory(GroupConstants.DashView), Benchmark]
   public void DashFormatV1()
   {
      _testStringArray
         .Select(stringsTestModel => ArrayPoolStringExtensions.ToDashFormat(stringsTestModel.Values))
         .Consume(_consumer);
   }
}