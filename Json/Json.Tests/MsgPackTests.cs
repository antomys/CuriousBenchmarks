using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="MsgPackService{T}"/>.
/// </summary>
public sealed class MsgPackTests
{
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService{T}.MsgPackClassicSerializeBytes"/>.
    /// </summary>
    [Fact]
    public void MsgPackClassicSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = MsgPackService<TestModel>.MsgPackClassicSerializeBytes(expectedModels);
        var actualModels = MsgPackService<TestModel>.MsgPackClassicDeserializeByte(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
  
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService{T}.MsgPackLz4BlockSerializeBytes"/>.
    /// </summary>
    [Fact]
    public void MsgPackLz4BlockSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = MsgPackService<TestModel>.MsgPackLz4BlockSerializeBytes(expectedModels);
        var actualModels = MsgPackService<TestModel>.MsgPackLz4BlockDeserializeByte(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService{T}.MsgPackClassicSerializeStream"/>.
    /// </summary>
    [Fact]
    public void MsgPackClassicSerializeStream_Returns_ValidModels()
    {
        // Arrange
        using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = MsgPackService<TestModel>.MsgPackClassicSerializeStream(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = MsgPackService<TestModel>.MsgPackClassicDeserializeStream(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService{T}.MsgPackLz4BlockSerializeStream"/>.
    /// </summary>
    [Fact]
    public void MsgPackLz4BlockSerializeStream_Returns_ValidModels()
    {
        // Arrange
        using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = MsgPackService<TestModel>.MsgPackLz4BlockSerializeStream(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = MsgPackService<TestModel>.MsgPackLz4BlockDeserializeStream(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService{T}.MsgPackClassicSerializeAsync"/>.
    /// </summary>
    [Fact]
    public async Task MsgPackClassicSerializeAsync_Returns_ValidModels()
    {
        // Arrange
        await using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await MsgPackService<TestModel>.MsgPackClassicSerializeAsync(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = await MsgPackService<TestModel>.MsgPackClassicDeserializeAsync(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MsgPackService{T}.MsgPackLz4BlockSerializeAsync"/>.
    /// </summary>
    [Fact]
    public async Task MsgPackLz4BlockSerializeAsync_Returns_ValidModels()
    {
        // Arrange
        await using var memoryStream = new MemoryStream();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await MsgPackService<TestModel>.MsgPackLz4BlockSerializeAsync(expectedModels);
        memoryStream.Write(actualMemoryStream.ToArray());
        var actualModels = await MsgPackService<TestModel>.MsgPackLz4BlockDeserializeAsync(memoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}