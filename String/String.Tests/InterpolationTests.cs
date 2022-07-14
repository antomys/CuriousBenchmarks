using Bogus;
using String.Benchmarks.Services;
using Xunit;

namespace String.Tests;

/// <summary>
///     Test of <see cref="InterpolationService"/>.
/// </summary>
public sealed class InterpolationTests
{
    private static readonly Faker Faker = new();
    
    /// <summary>
    ///     Test of 'InterpolationService.Interpolate' method.
    /// </summary>
    [Fact]
    public void Interpolate_Returns_RightString()
    {
        // Arrange
        var firstValue = Faker.Random.String2(20);
        var secondValue = Faker.Random.String2(20);
        var expectedString = $"{firstValue}{secondValue}";
        
        // Act
        var actualString = InterpolationService.Interpolate(firstValue, secondValue);
        
        // Arrange
        Assert.Equal(expectedString, actualString);
    }
    
    /// <summary>
    ///     Test of 'InterpolationService.Concat' method.
    /// </summary>
    [Fact]
    public void Concat_Returns_RightString()
    {
        // Arrange
        var firstValue = Faker.Random.String2(20);
        var secondValue = Faker.Random.String2(20);
        var expectedString = $"{firstValue}{secondValue}";
        
        // Act
        var actualString = InterpolationService.Concat(firstValue, secondValue);
        
        // Arrange
        Assert.Equal(expectedString, actualString);
    }
    
    /// <summary>
    ///     Test of 'InterpolationService.Concat' method.
    /// </summary>
    [Fact]
    public void Create_Returns_RightString()
    {
        // Arrange
        var firstValue = Faker.Random.String2(20);
        var secondValue = Faker.Random.String2(20);
        var expectedString = $"{firstValue}{secondValue}";
        
        // Act
        var actualString = InterpolationService.Create(firstValue, secondValue);
        
        // Arrange
        Assert.Equal(expectedString, actualString);
    }
    
    /// <summary>
    ///     Test of 'InterpolationService.Format' method.
    /// </summary>
    [Fact]
    public void Format_Returns_RightString()
    {
        // Arrange
        var firstValue = Faker.Random.String2(20);
        var secondValue = Faker.Random.String2(20);
        var expectedString = $"{firstValue}{secondValue}";
        
        // Act
        var actualString = InterpolationService.Format(firstValue, secondValue);
        
        // Arrange
        Assert.Equal(expectedString, actualString);
    }
    
    /// <summary>
    ///     Test of 'InterpolationService.StringBuilderAppend' method.
    /// </summary>
    [Fact]
    public void StringBuilderAppend_Returns_RightString()
    {
        // Arrange
        var firstValue = Faker.Random.String2(20);
        var secondValue = Faker.Random.String2(20);
        var expectedString = $"{firstValue}{secondValue}";
        
        // Act
        var actualString = InterpolationService.StringBuilderAppend(firstValue, secondValue);
        
        // Arrange
        Assert.Equal(expectedString, actualString);
    }
    
    /// <summary>
    ///     Test of 'InterpolationService.StaticStringBuilderAppend' method.
    /// </summary>
    [Fact]
    public void StaticStringBuilderAppend_Returns_RightString()
    {
        // Arrange
        var firstValue = Faker.Random.String2(20);
        var secondValue = Faker.Random.String2(20);
        var expectedString = $"{firstValue}{secondValue}";
        
        // Act
        var actualString = InterpolationService.StaticStringBuilderAppend(firstValue, secondValue);
        
        // Arrange
        Assert.Equal(expectedString, actualString);
    }
}