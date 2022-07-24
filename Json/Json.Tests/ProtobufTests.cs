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
    ///     Unit testing of method <see cref="ProtobufService.SerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void ProtobufSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = ProtobufService.SerializeBytes(expectedModels);
        var actualModels = ProtobufService.DeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="ProtobufService.DeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void ProtobufDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        var expectedBytes = ProtobufService.SerializeBytes(expectedModels);
        using var ms = new MemoryStream(expectedBytes);

        // Act
        var actualModels = ProtobufService.DeserializeStream<TestModel[]>(ms);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ProtobufService.DeserializeStreamAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task ProtobufDeserializeAsync_Returns_ValidModels()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        var expectedBytes = ProtobufService.SerializeBytes(expectedModels);
        using var ms = new MemoryStream(expectedBytes);

        // Act
        var actualModels = await ProtobufService.DeserializeStreamAsync<TestModel[]>(ms);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}