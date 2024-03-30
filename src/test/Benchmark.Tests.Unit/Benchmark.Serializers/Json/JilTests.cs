using Benchmark.Tests.Unit.Benchmark.Serializers.Models;
using FluentAssertions;

namespace Benchmark.Tests.Unit.Benchmark.Serializers.Json;

/// <summary>
///     Unit tests of service <see cref="Jil" />.
/// </summary>
public sealed class JilTests
{
    /// <summary>
    ///     Unit testing of method <see cref="Benchmarks.Serializers.Json.Serializers.JilDeserialize{T}" />.
    /// </summary>
    [Fact]
    public void JilDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualModels = Benchmarks.Serializers.Json.Serializers.JilDeserialize<TestModel>(actualString);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="Benchmarks.Serializers.Json.Serializers.JilSerialize{T}" />.
    /// </summary>
    [Fact]
    public void JilSerialize_Returns_ValidModel()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualString = Benchmarks.Serializers.Json.Serializers.JilSerialize(expectedModels);
        var actualModels = Benchmarks.Serializers.Json.Serializers.JilDeserialize<TestModel>(actualString);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="Benchmarks.Serializers.Json.Serializers.JilDeserializeBytes{T}" />.
    /// </summary>
    [Fact]
    public void JilDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualModels = Benchmarks.Serializers.Json.Serializers.JilDeserializeBytes<TestModel>(expectedBytes);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="Benchmarks.Serializers.Json.Serializers.JilSerializeBytes{T}" />.
    /// </summary>
    [Fact]
    public void JilSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualBytes = Benchmarks.Serializers.Json.Serializers.JilSerializeBytes(expectedModels);
        var actualModels = Benchmarks.Serializers.Json.Serializers.JilDeserializeBytes<TestModel>(actualBytes);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}