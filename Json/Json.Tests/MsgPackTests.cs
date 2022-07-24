using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="MsgPackService"/>.
/// </summary>
public sealed class MsgPackTests
{
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService.ClassicSerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void MsgPackClassicSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = MsgPackService.ClassicSerializeBytes(expectedModels);
        var actualModels = MsgPackService.ClassicDeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
  
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService.Lz4BlockSerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void MsgPackLz4BlockSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = MsgPackService.Lz4BlockSerializeBytes(expectedModels);
        var actualModels = MsgPackService.Lz4BlockDeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService.ClassicSerializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void MsgPackClassicSerializeStream_Returns_ValidModels()
    {
        // Arrange
        using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = MsgPackService.ClassicSerializeStream(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = MsgPackService.ClassicDeserializeStream<TestModel[]>(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService.Lz4BlockSerializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void MsgPackLz4BlockSerializeStream_Returns_ValidModels()
    {
        // Arrange
        using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = MsgPackService.Lz4BlockSerializeStream(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = MsgPackService.Lz4BlockDeserializeStream<TestModel[]>(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService.ClassicSerializeAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task MsgPackClassicSerializeAsync_Returns_ValidModels()
    {
        // Arrange
        await using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await MsgPackService.ClassicSerializeAsync(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = await MsgPackService.ClassicDeserializeAsync<TestModel[]>(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService.Lz4BlockSerializeAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task MsgPackLz4BlockSerializeAsync_Returns_ValidModels()
    {
        // Arrange
        await using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await MsgPackService.Lz4BlockSerializeAsync(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = await MsgPackService.Lz4BlockDeserializeAsync<TestModel[]>(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}