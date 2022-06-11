
#if DEBUG
var test = new HashCodeBenchmarks.HashCodeBenchmarks();

test.GetHashCodeDefault();

test.GetHashCodeHashCombine();

test.GetHashCodeV1();

test.GetHashCodeV2();

test.GetHashCodeV3();

test.GetHashCodeV4();
#else
BenchmarkDotNet.Running.BenchmarkRunner.Run(typeof(Program).Assembly);
#endif