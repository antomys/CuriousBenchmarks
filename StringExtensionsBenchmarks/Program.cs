using BenchmarkDotNet.Running;
using StringExtensionsBenchmarks.Benchmarks;

BenchmarkRunner.Run<GenuineStringExtensionsBenchmarks>();

BenchmarkRunner.Run<StackStringExtensionsBenchmarks>();

BenchmarkRunner.Run<InterpolationBenchmarks>();

BenchmarkRunner.Run<StringGenerationBenchmarks>();
