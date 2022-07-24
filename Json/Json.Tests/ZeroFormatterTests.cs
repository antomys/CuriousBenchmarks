using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests for service <see cref="ZeroFormatterService"/>.
/// </summary>
public sealed class ZeroFormatterTests
{
    /// <summary>
    ///     Unit testing of method <see cref="ZeroFormatterService.SerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void ZeroFormatterSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = ZeroFormatterService.SerializeBytes(expectedModels);
        var actualModels = ZeroFormatterService.DeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ZeroFormatterService.DeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void ZeroFormatterSerializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = ZeroFormatterService.SerializeStream(expectedModels);
        ms.Write(actualMemoryStream.ToArray());
        var actualModels = ZeroFormatterService.DeserializeStream<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}