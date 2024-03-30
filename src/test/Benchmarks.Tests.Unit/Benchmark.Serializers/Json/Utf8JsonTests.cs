using System.Text;
using Benchmarks.Tests.Unit.Benchmark.Serializers.Models;
using FluentAssertions;
using Utf8Json;

namespace Benchmarks.Tests.Unit.Benchmark.Serializers.Json;

/// <summary>
///     Unit tests for service <see cref="Utf8JsonService" />.
/// </summary>
public sealed class Utf8JsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.Deserialize{T}" />.
    /// </summary>
    [Fact]
    public void Utf8JsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualModels = JsonSerializer.Deserialize<TestModel[]>(actualString)!;

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.Serialize{T}" />.
    /// </summary>
    [Fact]
    public void Utf8JsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualString = Encoding.UTF8.GetString(JsonSerializer.Serialize(expectedModels));

        // Assert
        Assert.Equal(expectedString, actualString);
        actualString.Should().BeEquivalentTo(expectedString);
    }

    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.DeserializeBytes{T}" />.
    /// </summary>
    [Fact]
    public void Utf8JsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualModels = JsonSerializer.Deserialize<TestModel[]>(expectedBytes);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.SerializeBytes{T}" />.
    /// </summary>
    [Fact]
    public void Utf8JsonBytesSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualBytes = JsonSerializer.Serialize(expectedModels);

        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
}