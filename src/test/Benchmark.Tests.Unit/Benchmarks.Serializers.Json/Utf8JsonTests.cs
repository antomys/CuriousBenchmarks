using Benchmark.Tests.Unit.Benchmarks.Serializers.Json.Models;
using FluentAssertions;
using Utf8Json.Resolvers;

namespace Benchmark.Tests.Unit.Benchmarks.Serializers.Json;

/// <summary>
///     Unit tests for service <see cref="Utf8JsonService"/>.
/// </summary>
public sealed class Utf8JsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.Deserialize{T}"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestUtf8String();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = Utf8Json.JsonSerializer.Deserialize<TestModel[]>(actualString)!;
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.Serialize{T}"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestUtf8String();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = System.Text.Encoding.UTF8.GetString(Utf8Json.JsonSerializer.Serialize(expectedModels));
        
        // Assert
        Assert.Equal(expectedString, actualString);
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.DeserializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestUtf8Bytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = Utf8Json.JsonSerializer.Deserialize<TestModel[]>(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.SerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonBytesSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestUtf8Bytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = Utf8Json.JsonSerializer.Serialize(expectedModels);
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
}