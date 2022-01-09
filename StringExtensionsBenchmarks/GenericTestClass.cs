using BenchmarkDotNet.Attributes;
using StringExtensionsBenchmarks.StringExtensions;

namespace StringExtensionsBenchmarks;

[MemoryDiagnoser]
public class GenericTestClass
{
   private readonly string[] _testStringArray = {
      "TEst string first one 11111",
      "     Test string second one %$*(!@&%*(dsG sdg!!! egkjsdgh  555"
   };
   
   [BenchmarkCategory("LinkFormat_OLD"), Benchmark(Baseline = true)]
   public string GenerateLinkFormatOld()
   {
      return OldStringExtensions.ToLinkFormat(_testStringArray);
   }
   
   [BenchmarkCategory("LinkFormat_New_NoLength"), Benchmark]
   public string GenerateLinkFormatNewNoLength()
   {
      return StringExtensions.StringExtensions.ToLinkFormat(_testStringArray);
   }
   
   [BenchmarkCategory("LinkFormat_New_Length"), Benchmark]
   public string GenerateLinkFormatNewLength()
   {
      return StringExtensions.StringExtensions.ToLinkFormat(_testStringArray, _testStringArray[0].Length + _testStringArray[1].Length);
   }
   
   [BenchmarkCategory("LinkFormat_Aggressive_New_NoLength"), Benchmark]
   public string GenerateLinkFormatAggressiveNewNoLength()
   {
      return StringExtensions.StringExtensions.ToLinkFormatAggressive(_testStringArray);
   }
   
   [BenchmarkCategory("LinkFormat_Aggressive_New_Length"), Benchmark]
   public string GenerateLinkFormatAggressiveNewLength()
   {
      return StringExtensions.StringExtensions.ToLinkFormatAggressive(_testStringArray, _testStringArray[0].Length + _testStringArray[1].Length);
   }
   
   [BenchmarkCategory("DashView_NATIVE"), Benchmark]
   public string GenerateDashFormatNative()
   {
      return StringExtensions.StringExtensions.ToDashFormat(_testStringArray);
   }

   [BenchmarkCategory("DashView_V2"), Benchmark]
   public string GenerateDashFormatV2Length()
   {
      return StringExtensions.StringExtensions.ToDashFormat(_testStringArray, _testStringArray[0].Length + _testStringArray[1].Length);
   }
   
   [BenchmarkCategory("DashView_V2"), Benchmark]
   public string GenerateDashFormatV2TwoValues()
   {
      return StringExtensions.StringExtensions.ToDashFormat(_testStringArray[0], _testStringArray[1]);
   }
}