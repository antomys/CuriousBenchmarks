using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;
using String.Benchmarks.Services;

namespace String.Benchmarks.Benchmarks;

/// <summary>
///     Method that tests 'contains' methods.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
public class ContainsCharBenchmarks
{
    private const char ExistingChar = ';';
    private const char NonExistingChar = '-';
    
    private string _testString = null!;

    /// <summary>
    ///     Global setup.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker();
       
        _testString = $"{faker.Random.String2(faker.Random.Int(1, 50))}{ExistingChar}{faker.Random.String2(faker.Random.Int(1, 50))}";
    }

    /// <summary>
    ///     Benchmark of method 'string.IndexOf' where getting existing char.
    /// </summary>
    /// <returns>
    ///     <c>true</c> - when exists
    ///     <c>false</c> - when does not exist
    /// </returns>
    [Benchmark]
    public bool IndexOfExists()
    {
        return _testString.IndexOf(ExistingChar) is not -1;
    }
    
    /// <summary>
    ///     Benchmark of method 'string.IndexOf' where getting non-existing char.
    /// </summary>
    /// <returns>
    ///     <c>true</c> - when exists
    ///     <c>false</c> - when does not exist
    /// </returns>
    [Benchmark]
    public bool IndexOfNotExists()
    {
        return _testString.IndexOf(NonExistingChar) is not -1;
    }
    
    /// <summary>
    ///     Benchmark of method 'string.Contains' where getting existing char.
    /// </summary>
    /// <returns>
    ///     <c>true</c> - when exists
    ///     <c>false</c> - when does not exist
    /// </returns>
    [Benchmark(Baseline = true)]
    public bool ContainsExists()
    {
        return _testString.Contains(ExistingChar);
    }   
    
    /// <summary>
    ///     Benchmark of method 'string.Contains' where getting non-existing char.
    /// </summary>
    /// <returns>
    ///     <c>true</c> - when exists
    ///     <c>false</c> - when does not exist
    /// </returns>
    [Benchmark]
    public bool ContainsNotExists()
    {
        return _testString.Contains(NonExistingChar);
    }
    
    /// <summary>
    ///     Benchmark of method <see cref="RegexStringService.Contains"/> where getting existing char.
    /// </summary>
    /// <returns>
    ///     <c>true</c> - when exists
    ///     <c>false</c> - when does not exist
    /// </returns>
    [Benchmark]
    public bool ContainsCustomExists()
    {
        return RegexStringService.Contains(_testString, c => c is ExistingChar);
    }   
    
    /// <summary>
    ///     Benchmark of method <see cref="RegexStringService.Contains"/> where getting non-existing char.
    /// </summary>
    /// <returns>
    ///     <c>true</c> - when exists
    ///     <c>false</c> - when does not exist
    /// </returns>
    [Benchmark]
    public bool ContainsCustomNotExists()
    {
        return RegexStringService.Contains(_testString, c => c is NonExistingChar);
    }
}