using FluentAssertions;
using Json.Benchmarks.Services.Deserialization;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of <see cref="SystemTextJsonService{T}"/>
/// </summary>
public sealed class SystemTextJsonTests : IClassFixture<TestsBase>
{
    private readonly TestsBase _testsBase;
    
    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="testsBase">Test base class. <see cref="TestsBase"/>.</param>
    public SystemTextJsonTests(TestsBase testsBase)
    {
        _testsBase = testsBase ?? throw new ArgumentNullException(nameof(testsBase));
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonDeserialize"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = _testsBase.GetTestString();
        var expectedModels = _testsBase.GetTestModels();
        
        // Act
        var actualModels = SystemTextJsonService<TestModel>.SystemTextJsonDeserialize(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonSerialize"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = _testsBase.GetTestString();
        var expectedModels = _testsBase.GetTestModels();
        
        // Act
        var actualString = SystemTextJsonService<TestModel>.SystemTextJsonSerialize(expectedModels);
        
        // Assert
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonDeserializeBytes"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = _testsBase.GetTestBytes();
        var expectedModels = _testsBase.GetTestModels();
        
        // Act
        var actualModels = SystemTextJsonService<TestModel>.SystemTextJsonDeserializeBytes(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonSerializeBytes"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = _testsBase.GetTestBytes();
        var expectedModels = _testsBase.GetTestModels();
        
        // Act
        var actualBytes = SystemTextJsonService<TestModel>.SystemTextJsonSerializeBytes(expectedModels);
        
        // Assert
        Assert.Equal(expectedBytes, actualBytes);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonDeserializeStream"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(_testsBase.GetTestBytes());
        
        var expectedModels = _testsBase.GetTestModels();
        
        // Act
        var actualModels = SystemTextJsonService<TestModel>.SystemTextJsonDeserializeStream(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonSerializeStream"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerializeStream_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = _testsBase.GetTestBytes();
        var expectedModels = _testsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = SystemTextJsonService<TestModel>.SystemTextJsonSerializeStream(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
}