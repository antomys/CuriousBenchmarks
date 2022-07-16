using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="ProtobufService{T}"/>.
/// </summary>
public sealed class ProtobufTests
{
    /// <summary>
    ///     Unit testing of method <see cref="ProtobufService{T}.ProtobufSerializeBytes"/>.
    /// </summary>
    [Fact]
    public void ProtobufSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = ProtobufService<TestModel>.ProtobufSerializeBytes(expectedModels);
        var actualModels = ProtobufService<TestModel>.ProtobufDeserializeBytes(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="ProtobufService{T}.ProtobufDeserializeStream"/>.
    /// </summary>
    [Fact]
    public void ProtobufDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        var expectedBytes = ProtobufService<TestModel>.ProtobufSerializeBytes(expectedModels);
        using var ms = new MemoryStream(expectedBytes);

        // Act
        var actualModels = ProtobufService<TestModel>.ProtobufDeserializeStream(ms);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ProtobufService{T}.ProtobufDeserializeAsync"/>.
    /// </summary>
    [Fact]
    public async Task ProtobufDeserializeAsync_Returns_ValidModels()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        var expectedBytes = ProtobufService<TestModel>.ProtobufSerializeBytes(expectedModels);
        using var ms = new MemoryStream(expectedBytes);

        // Act
        var actualModels = await ProtobufService<TestModel>.ProtobufDeserializeAsync(ms);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}