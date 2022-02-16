using BenchmarkDotNet.Running;
using JsonBenchmarks;
using JsonBenchmarks.Benchmarks;

BenchmarkRunner.Run<DeserializationBenchmarks>();

BenchmarkRunner.Run<SerializationBenchmarks>();