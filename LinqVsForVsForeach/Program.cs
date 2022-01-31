// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using LinqVsForVsForeach;

var _ = BenchmarkRunner.Run<LinqForForeachTests>();