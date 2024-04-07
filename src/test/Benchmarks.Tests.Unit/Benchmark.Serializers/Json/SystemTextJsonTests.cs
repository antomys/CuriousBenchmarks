using System.Text.Json;
using Benchmarks.Tests.Unit.Benchmark.Serializers.Models;
using FluentAssertions;

namespace Benchmarks.Tests.Unit.Benchmark.Serializers.Json;

/// <summary>
///     Unit tests of <see cref="SystemTextJsonService" />
/// </summary>
public sealed class SystemTextJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.Deserialize{T}" />.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualModels = JsonSerializer.Deserialize<TestModel[]>(actualString);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.Serialize{T}" />.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualString = JsonSerializer.Serialize(expectedModels);

        // Assert
        actualString.Should().BeEquivalentTo(expectedString);
    }

    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.DeserializeBytes{T}" />.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualModels = JsonSerializer.Deserialize<TestModel[]>(expectedBytes);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.SerializeBytes{T}" />.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualBytes = JsonSerializer.SerializeToUtf8Bytes(expectedModels);

        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
}