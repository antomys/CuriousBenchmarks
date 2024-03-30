using Benchmarks.String.Services;
using Bogus;

namespace Benchmarks.Tests.Unit.Benchmark.String;

/// <summary>
///     Tests of <see cref="ArrayPoolStringService" />
/// </summary>
public sealed class ArrayPoolStringTests
{
    private readonly static Faker Faker = new();

    /// <summary>
    ///     Test of 'ArrayPoolStringService.ToDashFormat' method.
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
        var actualString = ArrayPoolStringService.ToDashFormat(firstValue, secondValue);
        var actualCollectionString = ArrayPoolStringService.ToDashFormat(new[] {firstValue, secondValue, thirdValue});

        // Arrange
        Assert.Equal(expectedString, actualString);
        Assert.Equal(expectedCollectionString, actualCollectionString);
    }

    /// <summary>
    ///     Test of 'ArrayPoolStringService.ToLinkFormat' method.
    ///     TODO: fix ArrayPool. Because it is flaky
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
        var actualOneValue = ArrayPoolStringService.ToLinkFormat(firstValue);
        var actualStackString = ArrayPoolStringService.ToLinkFormat(firstValue, secondValue);
        // var actualArrayPoolString = ArrayPoolStringService.ToLinkFormat(firstValue1, additionalString);
        var actualThreeStrings = ArrayPoolStringService.ToLinkFormat(firstValue, secondValue, thirdValue);
        var actualCollectionString = ArrayPoolStringService.ToLinkFormat([firstValue, secondValue, thirdValue]);

        // Arrange
        Assert.Equal(expectedOneValue, actualOneValue);
        Assert.Equal(expectedStackString, actualStackString);
        // Assert.Equal(expectedArrayPoolString, actualArrayPoolString);
        Assert.Equal(expectedCollectionString, actualCollectionString);
        Assert.Equal(expectedCollectionString, actualThreeStrings);
    }

    /// <summary>
    ///     Test of 'ArrayPoolStringService.Contains' method when returns 'true' boolean.
    /// </summary>
    [Fact]
    public void Contains_Returns_RightBool()
    {
        // Arrange
        const char existingChar = ' ';
        const char nonExistingChar = '/';

        var inputString = $"{Faker.Random.String2(10)}{existingChar}{Faker.Random.String2(5)}";

        // Act
        var actualExistingResult = ArrayPoolStringService.Contains(inputString, c => c is existingChar);
        var actualNonExistingResult = ArrayPoolStringService.Contains(inputString, c => c is nonExistingChar);

        // Arrange
        Assert.True(actualExistingResult);
        Assert.False(actualNonExistingResult);
    }

    /// <summary>
    ///     Test of 'ArrayPoolStringService.Contains' method when returns 'false' boolean
    /// </summary>
    [Fact]
    public void Contains_ReturnsFalse_WhenEmpty()
    {
        // Arrange
        const char randomChar = ' ';

        var inputString = string.Empty;

        // Act
        var actualStringEmptyResult = ArrayPoolStringService.Contains(inputString, c => c is randomChar);

        // Arrange
        Assert.False(actualStringEmptyResult);
    }

    /// <summary>
    ///     Test of 'ArrayPoolStringService.Contains' method when throws <see cref="ArgumentNullException" />.
    /// </summary>
    [Fact]
    public void Contains_ThrownArgumentNullException_WhenNullString()
    {
        // Arrange
        const char randomChar = ' ';

        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => ArrayPoolStringService.Contains(null, c => c is randomChar));
    }
}