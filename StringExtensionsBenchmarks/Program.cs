using BenchmarkDotNet.Running;
using StringExtensionsBenchmarks.Benchmarks;

BenchmarkRunner.Run<GenuineStringExtensionsBenchmarks>();

BenchmarkRunner.Run<InterpolationBenchmarks>();

BenchmarkRunner.Run<StackStringExtensionsBenchmarks>();

BenchmarkRunner.Run<StringGenerationBenchmarks>();
