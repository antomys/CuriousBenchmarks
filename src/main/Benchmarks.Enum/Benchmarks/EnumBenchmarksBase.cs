using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace Benchmarks.Enum.Benchmarks;

/// <summary>
///     Enum boxing/unboxing benchmarks base.
/// </summary>
[MemoryDiagnoser]
[MarkdownExporter]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class EnumBenchmarksBase
{
    /// <summary>
    ///     Gets collection of enums.
    /// </summary>
    protected static TestEnum[] TestEnums { get; private set; } = default!;

    /// <summary>
    ///     Global setup of private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        TestEnums =
        [
            TestEnum.First,
            TestEnum.Second,
            TestEnum.Third,
            TestEnum.Fourth,
            TestEnum.Fifth,
            TestEnum.Sixth,
            TestEnum.Seventh,
            TestEnum.Eighth,
            TestEnum.Ninth,
            TestEnum.Tenth,
            TestEnum.Eleventh,
            TestEnum.Twelfth
        ];
    }
}