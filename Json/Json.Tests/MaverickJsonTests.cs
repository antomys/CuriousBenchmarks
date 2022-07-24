using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of <see cref="MaverickJsonService"/>.
/// </summary>
public sealed class MaverickJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService.Serialize{T}"/>.
    /// </summary>
    [Fact]
    public void MaverickJsonSerialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = MaverickJsonService.Deserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService.Deserialize{T}"/>.
    /// </summary>
    [Fact]
    public void MaverickJsonDeserialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = MaverickJsonService.Serialize(expectedModels);

        // Assert
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService.DeserializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void MaverickDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = MaverickJsonService.DeserializeBytes<TestModel[]>(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService.SerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void MaverickSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = MaverickJsonService.DeserializeBytes<TestModel[]>(expectedBytes);
        var actualBytes = MaverickJsonService.SerializeBytes(actualModels);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService.DeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void MaverickDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = MaverickJsonService.DeserializeStream<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService.SerializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void MaverickSerializeStream_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = MaverickJsonService.SerializeStream(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="MaverickJsonService.DeserializeAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task MaverickDeserializeAsync_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await MaverickJsonService.DeserializeAsync<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}