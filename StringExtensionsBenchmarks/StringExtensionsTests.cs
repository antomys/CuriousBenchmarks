using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Bogus;
using StringExtensionsBenchmarks.StringExtensions;

namespace StringExtensionsBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class StringExtensionsTests
{
   // Intentionally left public for BenchmarkDotNet Params.
   [Params(10, 100, 1000, 10000, 100000, 1000000)]
   public int Count { get; set; }
   
   private readonly Consumer _consumer = new();

   private List<StringsTestModel> _testStringArray = null!;
   
   [GlobalSetup]
   public void Setup()
   {
      _testStringArray = 
         new Faker<StringsTestModel>()
         .RuleFor(x => x.Values, y => new[] {y.Random.String2(0, 100), y.Random.String2(0, 100)})
         .Generate(Count);
   }

   [BenchmarkCategory("Concatenation"), Benchmark]
   public void ConcatString()
   {
      string.Concat(_testStringArray[0].Values[0], _testStringArray[0].Values[1]).Consume(_consumer);
   }
   
   [BenchmarkCategory("Concatenation"), Benchmark]
   public string ConcatStringBuilder()
   {
      return $"{_testStringArray[0].Values[0]}{_testStringArray[0].Values[1]}";
   }
   
   [BenchmarkCategory("Concatenation"), Benchmark]
   public string ConcatSpan()
   {
      return string.Create(_testStringArray[0].Values[0].Length + _testStringArray[0].Values[1].Length, (_testStringArray[0].Values[0], _testStringArray[0].Values[1]),
         (shit, bebe) =>
         {
            var index = 0;
            var (val0, val1) = bebe;

            val0.CopyTo(shit);
            index += val0.Length;

            val1.CopyTo(shit[index..]);
         });
   }

   [BenchmarkCategory("LinkFormat"), Benchmark(Baseline = true)]
   public void GenerateLinkFormatOld()
   {
      _testStringArray
         .Select(x=> OldStringExtensions.ToLinkFormat(x.Values))
         .Consume(_consumer);
   }
   
   [BenchmarkCategory("LinkFormat"), Benchmark]
   public void GenerateLinkFormatNewNoLength()
   {
      _testStringArray
         .Select(x => StringExtensions.StringExtensions.ToLinkFormat(x.Values))
         .Consume(_consumer);
   }

   [BenchmarkCategory("DashView"), Benchmark]
   public void GenerateDashFormatNative()
   {
      _testStringArray
         .Select(x => StringExtensions.StringExtensions.ToDashFormat(x.Values))
         .Consume(_consumer);
   }

   [BenchmarkCategory("DashView"), Benchmark]
   public void GenerateDashFormatV2TwoValues()
   {
      _testStringArray
         .Select(x => StringExtensions.StringExtensions.ToDashFormat(x.Values))
         .Consume(_consumer);
   }
}