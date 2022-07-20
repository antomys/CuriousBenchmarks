using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="ProtobufService"/>.
/// </summary>
public sealed class ProtobufTests
{
    /// <summary>
    ///     Unit testing of method <see cref="ProtobufService.ProtobufSerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void ProtobufSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = ProtobufService.ProtobufSerializeBytes(expectedModels);
        var actualModels = ProtobufService.ProtobufDeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="ProtobufService.ProtobufDeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void ProtobufDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        var expectedBytes = ProtobufService.ProtobufSerializeBytes(expectedModels);
        using var ms = new MemoryStream(expectedBytes);

        // Act
        var actualModels = ProtobufService.ProtobufDeserializeStream<TestModel[]>(ms);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ProtobufService.ProtobufDeserializeAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task ProtobufDeserializeAsync_Returns_ValidModels()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        var expectedBytes = ProtobufService.ProtobufSerializeBytes(expectedModels);
        using var ms = new MemoryStream(expectedBytes);

        // Act
        var actualModels = await ProtobufService.ProtobufDeserializeAsync<TestModel[]>(ms);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}