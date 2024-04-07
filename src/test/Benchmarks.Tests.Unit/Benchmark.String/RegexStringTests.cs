using Benchmarks.String.Services;
using Bogus;

namespace Benchmarks.Tests.Unit.Benchmark.String;

/// <summary>
///     Test of <see cref="RegexStringService" />.
/// </summary>
public sealed class RegexStringTests
{
    private readonly static Faker Faker = new();

    /// <summary>
    ///     Test of 'RegexStringService.ToLinkFormat' method.
    /// </summary>
    [Fact]
    public void ToLinkFormat_Returns_RightLink()
    {
        // Arrange
        var firstValue1 = Faker.Random.String2(10);
        var firstValue2 = Faker.Random.String2(10);
        var secondValue = Faker.Random.String2(10);
        var thirdValue = Faker.Random.String2(10);

        var firstValue = $"{firstValue1} {firstValue2}";

        var expectedString = $"{firstValue1}-{firstValue2}-{secondValue}";
        var expectedCollectionString = $"{firstValue1}-{firstValue2}-{secondValue}-{thirdValue}";

        // Act
        var actualString = RegexStringService.ToLinkFormat(firstValue, secondValue);
        var actualCollectionString = new[] {firstValue, secondValue}.ToLinkFormat(thirdValue);

        // Arrange
        Assert.Equal(expectedString, actualString);
        Assert.Equal(expectedCollectionString, actualCollectionString);
    }

    /// <summary>
    ///     Test of 'RegexStringService.ToDashFormat' method.
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
        var actualString = RegexStringService.ToDashFormat(firstValue, secondValue);
        var actualCollectionString = ((IEnumerable<string>)new[] {firstValue, secondValue, thirdValue}).ToDashFormat();

        // Arrange
        Assert.Equal(expectedString, actualString);
        Assert.Equal(expectedCollectionString, actualCollectionString);
    }

    /// <summary>
    ///     Test of 'RegexStringService.Contains' method when returns 'true' boolean.
    /// </summary>
    [Fact]
    public void Contains_Returns_RightBool()
    {
        // Arrange
        const char existingChar = ' ';
        const char nonExistingChar = '/';

        var inputString = $"{Faker.Random.String2(10)}{existingChar}{Faker.Random.String2(5)}";

        // Act
        var actualExistingResult = RegexStringService.Contains(inputString, c => c is existingChar);
        var actualNonExistingResult = RegexStringService.Contains(inputString, c => c is nonExistingChar);

        // Arrange
        Assert.True(actualExistingResult);
        Assert.False(actualNonExistingResult);
    }

    /// <summary>
    ///     Test of 'RegexStringService.Contains' method when returns 'false' boolean
    /// </summary>
    [Fact]
    public void Contains_ReturnsFalse_WhenEmpty()
    {
        // Arrange
        const char randomChar = ' ';

        var inputString = string.Empty;

        // Act
        var actualStringEmptyResult = RegexStringService.Contains(inputString, c => c is randomChar);

        // Arrange
        Assert.False(actualStringEmptyResult);
    }

    /// <summary>
    ///     Test of 'RegexStringService.Contains' method when throws <see cref="ArgumentNullException" />.
    /// </summary>
    [Fact]
    public void Contains_ThrownArgumentNullException_WhenNullString()
    {
        // Arrange
        const char randomChar = ' ';

        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => RegexStringService.Contains(null, c => c is randomChar));
    }
}