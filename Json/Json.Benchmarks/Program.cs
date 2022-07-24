[assembly: JsonSrcGen.JsonArray(typeof(Json.Benchmarks.Models.SrcGen.ComplexSrcGenModel))]
[assembly: JsonSrcGen.JsonArray(typeof(Json.Benchmarks.Models.SrcGen.SimpleSrcGenModel))]

BenchmarkDotNet.Running.BenchmarkRunner.Run(typeof(Program).Assembly);