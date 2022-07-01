using System.Globalization;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;

namespace TrueEqualsBenchmarks;

[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
public class StringEqualityBenchmarks
{
    private const string SameCase = nameof(SameCase);
    private const string DifferentCase = nameof(DifferentCase);
    
    private string _firstString = null!;
    private string _firstUppercaseString = null!;
    private string _firstOtherString = null!;
    private string _secondString = null!;

    [GlobalSetup]
    public void Setup()
    {
        var bogus = new Faker();
        Randomizer.Seed = Random.Shared;
        
        _firstString = bogus.Random.String2(10, 100);
        _firstUppercaseString = _firstString.ToUpper();
        
        //  In this way i want to eliminate my variable to be just a reference to the '_firstString'.
        _firstOtherString = string.Create(_firstString.Length, _firstString, (span, s) =>
        {
            s.CopyTo(span);
        });
        
        //  In this case, i eliminate cases, where random can generate string that is similar to the first
        //  (rare occasions, but to be completely sure).
        do
        {
            _secondString = bogus.Random.String2(10, 100);
        } while (_secondString.Equals(_firstString, StringComparison.OrdinalIgnoreCase));
    }

    [BenchmarkCategory(SameCase), Benchmark(Baseline = true)]
    public bool SameCaseEqualityOperator()
    {
        return _firstString == _firstOtherString;
    }
    
    [BenchmarkCategory(SameCase), Benchmark]
    public bool SameCaseEqualsMethod()
    {
        return _firstString.Equals(_firstOtherString);
    }
    
    [BenchmarkCategory(SameCase), Benchmark]
    public bool SameCaseEqualsMethodOrdinal()
    {
        return _firstString.Equals(_firstOtherString, StringComparison.Ordinal);
    }

    [BenchmarkCategory(SameCase), Benchmark]
    public bool SameCaseCompareToMethodOrdinal()
    {
        return string.Compare(_firstString, _firstOtherString, StringComparison.Ordinal) is 0;
    }
    
    [BenchmarkCategory(SameCase), Benchmark]
    public bool SameCaseMemoryExtensionsEqualsMethodOrdinal()
    {
        return MemoryExtensions.Equals(_firstString, _firstOtherString, StringComparison.Ordinal);
    }

    [BenchmarkCategory(SameCase), Benchmark]
    public bool SameCaseEqualsMethodInvariantCulture()
    {
        return _firstString.Equals(_firstOtherString, StringComparison.InvariantCulture);
    }

    [BenchmarkCategory(SameCase), Benchmark]
    public bool SameCaseCompareToMethodInvariantCulture()
    {
        return string.Compare(_firstString, _firstOtherString, StringComparison.InvariantCulture) is 0;
    }
    
    [BenchmarkCategory(SameCase), Benchmark]
    public bool SameCaseMemoryExtensionsEqualsMethodInvariantCulture()
    {
        return MemoryExtensions.Equals(_firstString, _firstOtherString, StringComparison.InvariantCulture);
    }
    
    [BenchmarkCategory(DifferentCase), Benchmark(Baseline = true)]
    public bool DifferentCaseEqualityOperatorToLower()
    {
        return _firstString.ToLower() == _firstOtherString.ToLower();
    }
    
    [BenchmarkCategory(DifferentCase), Benchmark]
    public bool DifferentCaseEqualsMethodToLower()
    {
        return _firstString.ToLower().Equals(_firstOtherString.ToLower());
    }
    
    [BenchmarkCategory(DifferentCase), Benchmark]
    public bool DifferentCaseEqualsMethodOrdinal()
    {
        return _firstString.Equals(_firstOtherString, StringComparison.OrdinalIgnoreCase);
    }

    [BenchmarkCategory(DifferentCase), Benchmark]
    public bool DifferentCaseCompareToMethodOrdinal()
    {
        return string.Compare(_firstString, _firstOtherString, StringComparison.OrdinalIgnoreCase) is 0;
    }
    
    [BenchmarkCategory(DifferentCase), Benchmark]
    public bool DifferentCaseMemoryExtensionsEqualsMethodOrdinal()
    {
        return MemoryExtensions.Equals(_firstString, _firstOtherString, StringComparison.OrdinalIgnoreCase);
    }

    [BenchmarkCategory(DifferentCase), Benchmark]
    public bool DifferentCaseEqualsMethodInvariantCulture()
    {
        return _firstString.Equals(_firstOtherString, StringComparison.InvariantCultureIgnoreCase);
    }

    [BenchmarkCategory(DifferentCase), Benchmark]
    public bool DifferentCaseCompareToMethodInvariantCulture()
    {
        return string.Compare(_firstString, _firstOtherString, StringComparison.InvariantCultureIgnoreCase) is 0;
    }
    
    [BenchmarkCategory(DifferentCase), Benchmark]
    public bool DifferentCaseMemoryExtensionsEqualsMethodInvariantCulture()
    {
        return MemoryExtensions.Equals(_firstString, _firstOtherString, StringComparison.InvariantCultureIgnoreCase);
    }
    
    [BenchmarkCategory(DifferentCase), Benchmark]
    public bool DifferentCaseMemoryExtensionsToLowerEqualsStackallocInvariantCulture()
    {
        Span<char> a1 = stackalloc char[_firstString.Length];
        Span<char> a2 = stackalloc char[_secondString.Length];
        
        MemoryExtensions.ToLower(_firstString, a1, CultureInfo.InvariantCulture);
        MemoryExtensions.ToLower(_secondString, a2, CultureInfo.InvariantCulture);

        return MemoryExtensions.Equals(a1, a2, StringComparison.Ordinal);
    }
    
    [BenchmarkCategory(DifferentCase), Benchmark]
    public bool DifferentCaseMemoryExtensionsToLowerEqualsStackallocCurrentCulture()
    {
        Span<char> a1 = stackalloc char[_firstString.Length];
        Span<char> a2 = stackalloc char[_secondString.Length];
        
        MemoryExtensions.ToLower(_firstString, a1, CultureInfo.CurrentCulture);
        MemoryExtensions.ToLower(_secondString, a2, CultureInfo.CurrentCulture);

        return MemoryExtensions.Equals(a1, a2, StringComparison.CurrentCulture);
    }
    
    [BenchmarkCategory(DifferentCase), Benchmark]
    public bool DifferentCaseMemoryExtensionsToLowerToStringStackalloc()
    {
        Span<char> a1 = stackalloc char[_firstString.Length];
        Span<char> a2 = stackalloc char[_secondString.Length];
        
        MemoryExtensions.ToLower(_firstString, a1, CultureInfo.InvariantCulture);
        MemoryExtensions.ToLower(_secondString, a2, CultureInfo.InvariantCulture);

        return a1.ToString().Equals(a2.ToString());
    }
}