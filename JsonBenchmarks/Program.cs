using BenchmarkDotNet.Running;
using JsonBenchmarks.Benchmarks;

BenchmarkRunner.Run<DeserializationBenchmarks>();

BenchmarkRunner.Run<SerializationBenchmarks>();