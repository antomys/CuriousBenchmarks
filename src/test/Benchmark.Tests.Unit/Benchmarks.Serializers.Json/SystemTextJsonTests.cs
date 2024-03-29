using Benchmark.Tests.Unit.Benchmarks.Serializers.Json.Models;
using FluentAssertions;

namespace Benchmark.Tests.Unit.Benchmarks.Serializers.Json;

/// <summary>
///     Unit tests of <see cref="SystemTextJsonService"/>
/// </summary>
public sealed class SystemTextJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.Deserialize{T}"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = System.Text.Json.JsonSerializer.Deserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.Serialize{T}"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = System.Text.Json.JsonSerializer.Serialize(expectedModels);
        
        // Assert
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.DeserializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = System.Text.Json.JsonSerializer.Deserialize<TestModel[]>(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.SerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(expectedModels);
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.DeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = System.Text.Json.JsonSerializer.Deserialize<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.DeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public async Task SystemTextJsonDeserializeAsync_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await System.Text.Json.JsonSerializer.DeserializeAsync<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}