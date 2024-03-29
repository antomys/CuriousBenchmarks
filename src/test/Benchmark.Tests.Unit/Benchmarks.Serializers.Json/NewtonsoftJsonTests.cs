using System.Text;
using Benchmark.Tests.Unit.Benchmarks.Serializers.Json.Models;
using Benchmarks.Serializers.Json.Extensions;
using FluentAssertions;

namespace Benchmark.Tests.Unit.Benchmarks.Serializers.Json;

/// <summary>
///     Unit tests of service <see cref="Newtonsoft.Json"/>.
/// </summary>
public sealed class NewtonsoftJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="Newtonsoft.Json.JsonConvert"/>.
    /// </summary>
    [Fact]
    public void NewtonsoftDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = Newtonsoft.Json.JsonConvert.DeserializeObject<TestModel[]>(actualString, JsonServiceExtensions.NewtonsoftOptions);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Newtonsoft.Json.JsonConvert"/>.
    /// </summary>
    [Fact]
    public void NewtonsoftSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = Newtonsoft.Json.JsonConvert.SerializeObject(expectedModels, Newtonsoft.Json.Formatting.None, JsonServiceExtensions.NewtonsoftOptions);
        
        // Assert
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Newtonsoft.Json.JsonConvert"/>.
    /// </summary>
    [Fact]
    public void NewtonsoftDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var actualBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = Newtonsoft.Json.JsonConvert.DeserializeObject<TestModel[]>(Encoding.UTF8.GetString(actualBytes), JsonServiceExtensions.NewtonsoftOptions);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}