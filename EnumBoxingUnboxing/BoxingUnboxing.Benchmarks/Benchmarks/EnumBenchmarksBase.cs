using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace BoxingUnboxing.Benchmarks.Benchmarks;

/// <summary>
///     Enum boxing/unboxing benchmarks base.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub]
[CsvMeasurementsExporter]
[RPlotExporter]
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
        TestEnums = new[]
        {
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
            TestEnum.Twelfth,
        };
    }
}