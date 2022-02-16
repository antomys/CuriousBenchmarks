using BenchmarkDotNet.Running;
using StringExtensionsBenchmarks.Benchmarks;
using StringExtensionsBenchmarks.StringExtensions;


// BenchmarkRunner.Run<GenuineStringExtensionsBenchmarks>();
//
// BenchmarkRunner.Run<StackStringExtensionsBenchmarks>();
//
// BenchmarkRunner.Run<InterpolationBenchmarks>();

BenchmarkRunner.Run<StringGenerationBenchmarks>();
