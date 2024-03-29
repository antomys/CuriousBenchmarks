using Benchmarks.String.Services;
using Bogus;

namespace Benchmark.Tests.Unit.Benchmark.String;

/// <summary>
///     Test of <see cref="SpanOwnerStringService"/>.
/// </summary>
public sealed class SpanOwnerStringTests
{
    private static readonly Faker Faker = new();
    
    /// <summary>
    ///     Test of 'SpanOwnerStringService.ToDashFormat' method.
    /// </summary>
    [Fact]
    public void ToDashFormat_Returns_RightDashedView()
    {
        // Arrange
        var firstValue = $"{Faker.Random.String2(10)} {Faker.Random.String2(5)}";
        var secondValue = Faker.Random.String2(10);
        var thirdValue = Faker.Random.String2(10);
        
        var expectedString = $"{firstValue} - {secondValue}";
        var expectedCollectionString = $"{firstValue} - {secondValue} - {thirdValue}";
        
        // Act
        var actualString = SpanOwnerStringService.ToDashFormat(firstValue, secondValue);
        var actualCollectionString = SpanOwnerStringService.ToDashFormat(new[] {firstValue, secondValue, thirdValue});
        
        // Arrange
        Assert.Equal(expectedString, actualString);
        Assert.Equal(expectedCollectionString, actualCollectionString);
    }
    
    /// <summary>
    ///     Test of 'SpanOwnerStringService.ToLinkFormat' method.
    /// </summary>
    [Fact]
    public void ToLinkFormat_Returns_RightLink()
    {
        // Arrange
        var firstValue1 = Faker.Random.String2(10);
        var firstValue2 = Faker.Random.String2(10);
        var secondValue = Faker.Random.String2(10);
        var thirdValue = Faker.Random.String2(10);

        var additionalString = Faker.Random.String2(60);
        var firstValue = $"{firstValue1} {firstValue2}";

        var expectedOneValue = $"{firstValue1}-{firstValue2}";
        var expectedStackString = $"{firstValue1}-{firstValue2}-{secondValue}";
        var expectedCollectionString = $"{firstValue1}-{firstValue2}-{secondValue}-{thirdValue}";
        
        var expectedArrayPoolString = $"{firstValue1}-{additionalString}";
        additionalString = $"{additionalString}          ";
        
        // Act
        var actualOneValue = SpanOwnerStringService.ToLinkFormat(firstValue);
        var actualStackString = SpanOwnerStringService.ToLinkFormat(firstValue, secondValue);
        var actualArrayPoolString = SpanOwnerStringService.ToLinkFormat(firstValue1, additionalString);
        var actualThreeStrings = SpanOwnerStringService.ToLinkFormat(firstValue, secondValue, thirdValue);
        var actualCollectionString = SpanOwnerStringService.ToLinkFormat(new[] {firstValue, secondValue, thirdValue});
        
        // Arrange
        Assert.Equal(expectedOneValue, actualOneValue);
        Assert.Equal(expectedStackString, actualStackString);
        Assert.Equal(expectedCollectionString, actualThreeStrings);
        Assert.Equal(expectedArrayPoolString, actualArrayPoolString);
        Assert.Equal(expectedCollectionString, actualCollectionString);
    }
    
    /// <summary>
    ///     Test of 'SpanOwnerStringService.Contains' method when returns 'true' boolean.
    /// </summary>
    [Fact]
    public void Contains_Returns_RightBool()
    {
        // Arrange
        const char existingChar = ' ';
        const char nonExistingChar = '/';
        
        var inputString = $"{Faker.Random.String2(10)}{existingChar}{Faker.Random.String2(5)}";
        
        // Act
        var actualExistingResult = SpanOwnerStringService.Contains(inputString, c => c is existingChar);
        var actualNonExistingResult = SpanOwnerStringService.Contains(inputString, c => c is nonExistingChar);
        
        // Arrange
        Assert.True(actualExistingResult);
        Assert.False(actualNonExistingResult);
    }
    
    /// <summary>
    ///     Test of 'SpanOwnerStringService.Contains' method when returns 'false' boolean
    /// </summary>
    [Fact]
    public void Contains_ReturnsFalse_WhenEmpty()
    {
        // Arrange
        const char randomChar = ' ';

        var inputString = string.Empty;

        // Act
        var actualStringEmptyResult = SpanOwnerStringService.Contains(inputString, c => c is randomChar);

        // Arrange
        Assert.False(actualStringEmptyResult);
    }
    
    /// <summary>
    ///     Test of 'SpanOwnerStringService.Contains' method when throws <see cref="ArgumentNullException"/>.
    /// </summary>
    [Fact]
    public void Contains_ThrownArgumentNullException_WhenNullString()
    {
        // Arrange
        const char randomChar = ' ';

        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => SpanOwnerStringService.Contains(null, c => c is randomChar));
    }
}