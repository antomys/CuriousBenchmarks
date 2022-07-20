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
    ///     Unit testing of method <see cref="MsgPackService.MsgPackClassicSerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void MsgPackClassicSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = MsgPackService.MsgPackClassicSerializeBytes(expectedModels);
        var actualModels = MsgPackService.MsgPackClassicDeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
  
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService.MsgPackLz4BlockSerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void MsgPackLz4BlockSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = MsgPackService.MsgPackLz4BlockSerializeBytes(expectedModels);
        var actualModels = MsgPackService.MsgPackLz4BlockDeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService.MsgPackClassicSerializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void MsgPackClassicSerializeStream_Returns_ValidModels()
    {
        // Arrange
        using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = MsgPackService.MsgPackClassicSerializeStream(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = MsgPackService.MsgPackClassicDeserializeStream<TestModel[]>(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService.MsgPackLz4BlockSerializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void MsgPackLz4BlockSerializeStream_Returns_ValidModels()
    {
        // Arrange
        using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = MsgPackService.MsgPackLz4BlockSerializeStream(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = MsgPackService.MsgPackLz4BlockDeserializeStream<TestModel[]>(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService.MsgPackClassicSerializeAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task MsgPackClassicSerializeAsync_Returns_ValidModels()
    {
        // Arrange
        await using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await MsgPackService.MsgPackClassicSerializeAsync(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = await MsgPackService.MsgPackClassicDeserializeAsync<TestModel[]>(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService.MsgPackLz4BlockSerializeAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task MsgPackLz4BlockSerializeAsync_Returns_ValidModels()
    {
        // Arrange
        await using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await MsgPackService.MsgPackLz4BlockSerializeAsync(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = await MsgPackService.MsgPackLz4BlockDeserializeAsync<TestModel[]>(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}