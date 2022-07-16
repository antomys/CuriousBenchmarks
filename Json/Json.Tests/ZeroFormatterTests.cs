using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests for service <see cref="ZeroFormatterService{T}"/>.
/// </summary>
public sealed class ZeroFormatterTests
{
    /// <summary>
    ///     Unit testing of method <see cref="ZeroFormatterService{T}.ZeroFormatterSerializeBytes"/>.
    /// </summary>
    [Fact]
    public void ZeroFormatterSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = ZeroFormatterService<TestModel>.ZeroFormatterSerializeBytes(expectedModels);
        var actualModels = ZeroFormatterService<TestModel>.ZeroFormatterDeserializeBytes(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ZeroFormatterService{T}.ZeroFormatterDeserializeStream"/>.
    /// </summary>
    [Fact]
    public void ZeroFormatterSerializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = ZeroFormatterService<TestModel>.ZeroFormatterSerializeStream(expectedModels);
        ms.Write(actualMemoryStream.ToArray());
        var actualModels = ZeroFormatterService<TestModel>.ZeroFormatterDeserializeStream(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}