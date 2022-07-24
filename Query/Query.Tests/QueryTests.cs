using System.Collections.Specialized;
using Bogus;
using Microsoft.AspNetCore.Http.Extensions;
using Query.Benchmarks.Services.Query;
using Xunit;

namespace Query.Tests;

/// <summary>
///     Testing of query service (<see cref="QueryService"/>).
/// </summary>
public sealed class QueryTests
{
    private const string DefaultUrl = "http://localhost";

    private static readonly Faker Faker = new();

    /// <summary>
    ///     Testing of method <see cref="QueryService.QueryDictionary"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void QueryDictionary_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupDictionaryQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);

        // Act
        var actualQuery = new Uri(QueryService.QueryDictionary(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.QueryNvcStringBuilder"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void QueryNvcStringBuilder_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupNvcQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);

        // Act
        var actualQuery = new Uri(QueryService.QueryNvcStringBuilder(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.QueryNvcStaticStringBuilder"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void QueryNvcStaticStringBuilder_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupNvcQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);

        // Act
        var actualQuery = new Uri(QueryService.QueryNvcStaticStringBuilder(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.QueryAspNetCore"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void QueryAspNetCore_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupQueryBuilderQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);

        // Act
        var actualQuery = new Uri(QueryService.QueryAspNetCore(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.QueryAspNetCore"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void QueryCustomBuilder_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupQueryCustomBuilderQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);

        // Act
        var actualQuery = new Uri(QueryService.QueryCustomBuilder(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.QueryAspNetCore"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void QueryValueStringBuilder_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupQueryValueStringBuilderQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);

        // Act
        var actualQuery = new Uri(QueryService.QueryValueStringBuilder(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.LinqSelectJoin"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void LinqSelectJoin_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupDictionaryQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);

        // Act
        var actualQuery = new Uri(QueryService.LinqSelectJoin(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.QueryConcatString"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void QueryConcatString_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupDictionaryQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);

        // Act
        var actualQuery = new Uri(QueryService.QueryConcatString(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.QueryStringCreateConcat"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void QueryStringCreateConcat_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupDictionaryQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);
        
        // Act
        var actualQuery = new Uri(QueryService.QueryStringCreateConcat(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.QueryStringCreate"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void QueryStringCreate_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupDictionaryQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);
        
        // Act
        var actualQuery = new Uri(QueryService.QueryStringCreate(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.QueryStringCreateStack"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void QueryStringCreateStack_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupQueryDictionaryQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);

        // Act
        var actualQuery = new Uri(QueryService.QueryStringCreateStack(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.LinqQuerySpanVer2"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void LinqQuerySpanVer2_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupQueryDictionaryQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);
        
        // Act
        var actualQuery = new Uri(QueryService.LinqQuerySpanVer2(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.LinqQueryAggregate"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void LinqQueryAggregate_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupQueryDictionaryQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);
 
        // Act
        var actualQuery = new Uri(QueryService.LinqQueryAggregate(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }
    
    /// <summary>
    ///     Testing of method <see cref="QueryService.QueryFormUrlEncodedContent"/>.
    /// </summary>
    /// <param name="pairsCount">Count of query pairs.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void QueryFormUrlEncodedContent_Returns_RightQuery(int pairsCount)
    {
        // Arrange
        var dictionary = SetupQueryDictionaryQuery(pairsCount);
        var expectedQuery = SetupExpectedUri(dictionary);

        // Act
        var actualQuery = new Uri(QueryService.QueryFormUrlEncodedContent(DefaultUrl, dictionary));
        
        // Assert
        Assert.Equal(expectedQuery, actualQuery);
    }

    private static Dictionary<string, string> SetupDictionaryQuery(int size)
    {
        var dictionary = new Dictionary<string, string>(size);

        for (var i = 0; i < size; i++)
        {
             var (testKey, testValue) = (Faker.Name.FirstName(),Faker.Name.LastName());

            dictionary.TryAdd(testKey, testValue);
        }

        return dictionary;
    }

    private static QueryDictionary SetupQueryDictionaryQuery(int size)
    {
        var dictionary = new QueryDictionary(size);

        for (var i = 0; i < size; i++)
        {
             var (testKey, testValue) = (Faker.Name.FirstName(), Faker.Name.LastName());

            dictionary.TryAdd(testKey, testValue);
        }

        return dictionary;
    }
    
    private static NameValueCollection SetupNvcQuery(int size)
    {
        var nameValueCollection = new NameValueCollection(size);

        for (var i = 0; i < size; i++)
        {
             var (testKey, testValue) = (Faker.Name.FirstName(),Faker.Name.LastName());

            if (nameValueCollection.Get(testKey) is not null)
            {
                continue;
            }
            nameValueCollection.Add(testKey, testValue);
        }

        return nameValueCollection;
    }
    
    private static QueryBuilder SetupQueryBuilderQuery(int size)
    {
        var dictionary = new Dictionary<string, string>(size);
      
        for (var i = 0; i < size; i++)
        {
            var (testKey, testValue) = (Faker.Name.FirstName(),Faker.Name.LastName());

            dictionary.TryAdd(testKey, testValue);
        }

        return new QueryBuilder(dictionary);
    }
    
    private static QueryCustomBuilder SetupQueryCustomBuilderQuery(int size)
    {
        var dictionary = new Dictionary<string, string>(size);
      
        for (var i = 0; i < size; i++)
        {
            var (testKey, testValue) = (Faker.Name.FirstName(),Faker.Name.LastName());

            dictionary.TryAdd(testKey, testValue);
        }

        return new QueryCustomBuilder(dictionary);
    }
    
    private static QueryValueStringBuilder SetupQueryValueStringBuilderQuery(int size)
    {
        var dictionary = new Dictionary<string, string>(size);
      
        for (var i = 0; i < size; i++)
        {
            var (testKey, testValue) = (Faker.Name.FirstName(),Faker.Name.LastName());

            dictionary.TryAdd(testKey, testValue);
        }

        return new QueryValueStringBuilder(dictionary);
    }
    
    private static Uri SetupExpectedUri(Dictionary<string, string> dictionary)
    {
        if (dictionary.Count is 0)
        {
            return new Uri(DefaultUrl);
        }
        
        var resultString = string.Empty;
        var count = 0;
        
        foreach (var (testKey, testValue) in dictionary)
        {
            resultString += count++ is 0
                ? $"{DefaultUrl}?{Uri.EscapeDataString(testKey)}={Uri.EscapeDataString(testValue)}"
                : $"&{Uri.EscapeDataString(testKey)}={Uri.EscapeDataString(testValue)}";
        }

        return new Uri(resultString);
    }
    
    private static Uri SetupExpectedUri(QueryDictionary queryDictionary)
    {
        if (queryDictionary.Count is 0)
        {
            return new Uri(DefaultUrl);
        }
        
        var resultString = string.Empty;
        var count = 0;
        
        foreach (var (testKey, testValue) in queryDictionary)
        {
            resultString += count++ is 0
                ? $"{DefaultUrl}?{Uri.EscapeDataString(testKey)}={Uri.EscapeDataString(testValue)}"
                : $"&{Uri.EscapeDataString(testKey)}={Uri.EscapeDataString(testValue)}";
        }

        return new Uri(resultString);
    }
    
    private static Uri SetupExpectedUri(NameValueCollection nameValueCollection)
    {
        if (nameValueCollection.Count is 0)
        {
            return new Uri(DefaultUrl);
        }
        
        var resultString = string.Empty;
        var count = 0;
        
        foreach (var testKey in nameValueCollection.AllKeys)
        {
            resultString += count++ is 0
                ? $"{DefaultUrl}?{Uri.EscapeDataString(testKey!)}={Uri.EscapeDataString(nameValueCollection[testKey]!)}"
                : $"&{Uri.EscapeDataString(testKey!)}={Uri.EscapeDataString(nameValueCollection[testKey]!)}";
        }

        return new Uri(resultString);
    }
    
    private static Uri SetupExpectedUri(QueryBuilder queryBuilder)
    {
        if (!queryBuilder.Any())
        {
            return new Uri(DefaultUrl);
        }
        
        var resultString = string.Empty;
        var count = 0;
        
        foreach (var (testKey, testValue) in queryBuilder)
        {
            resultString += count++ is 0
                ? $"{DefaultUrl}?{Uri.EscapeDataString(testKey)}={Uri.EscapeDataString(testValue)}"
                : $"&{Uri.EscapeDataString(testKey)}={Uri.EscapeDataString(testValue)}";
        }

        return new Uri(resultString);
    }
    
    private static Uri SetupExpectedUri(QueryCustomBuilder queryBuilder)
    {
        if (!queryBuilder.Any())
        {
            return new Uri(DefaultUrl);
        }
        
        var resultString = string.Empty;
        var count = 0;
        
        foreach (var (testKey, testValue) in queryBuilder)
        {
            resultString += count++ is 0
                ? $"{DefaultUrl}?{Uri.EscapeDataString(testKey)}={Uri.EscapeDataString(testValue)}"
                : $"&{Uri.EscapeDataString(testKey)}={Uri.EscapeDataString(testValue)}";
        }

        return new Uri(resultString);
    }
    
    private static Uri SetupExpectedUri(QueryValueStringBuilder queryBuilder)
    {
        if (!queryBuilder.Any())
        {
            return new Uri(DefaultUrl);
        }
        
        var resultString = string.Empty;
        var count = 0;
        
        foreach (var (testKey, testValue) in queryBuilder)
        {
            resultString += count++ is 0
                ? $"{DefaultUrl}?{Uri.EscapeDataString(testKey)}={Uri.EscapeDataString(testValue)}"
                : $"&{Uri.EscapeDataString(testKey)}={Uri.EscapeDataString(testValue)}";
        }

        return new Uri(resultString);
    }
}