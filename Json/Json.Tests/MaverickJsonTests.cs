using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of <see cref="MaverickJsonService{T}"/>.
/// </summary>
public sealed class MaverickJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService{T}.MaverickJsonSerialize"/>.
    /// </summary>
    [Fact]
    public void MaverickJsonSerialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = MaverickJsonService<TestModel>.MaverickJsonDeserialize(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService{T}.MaverickJsonDeserialize"/>.
    /// </summary>
    [Fact]
    public void MaverickJsonDeserialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = MaverickJsonService<TestModel>.MaverickJsonSerialize(expectedModels);

        // Assert
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService{T}.MaverickDeserializeBytes"/>.
    /// </summary>
    [Fact]
    public void MaverickDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = MaverickJsonService<TestModel>.MaverickDeserializeBytes(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService{T}.MaverickSerializeBytes"/>.
    /// </summary>
    [Fact]
    public void MaverickSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = MaverickJsonService<TestModel>.MaverickDeserializeBytes(expectedBytes);
        var actualBytes = MaverickJsonService<TestModel>.MaverickSerializeBytes(actualModels);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService{T}.MaverickDeserializeStream"/>.
    /// </summary>
    [Fact]
    public void MaverickDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = MaverickJsonService<TestModel>.MaverickDeserializeStream(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService{T}.MaverickSerializeStream"/>.
    /// </summary>
    [Fact]
    public void MaverickSerializeStream_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = MaverickJsonService<TestModel>.MaverickSerializeStream(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService{T}.MaverickDeserializeAsync"/>.
    /// </summary>
    [Fact]
    public async Task MaverickDeserializeAsync_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await MaverickJsonService<TestModel>.MaverickDeserializeAsync(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}