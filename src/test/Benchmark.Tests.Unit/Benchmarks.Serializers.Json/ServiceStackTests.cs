using Benchmark.Tests.Unit.Benchmarks.Serializers.Json.Models;
using Benchmarks.Serializers.Json.Extensions;
using FluentAssertions;

namespace Benchmark.Tests.Unit.Benchmarks.Serializers.Json;

/// <summary>
///     Unit tests of service <see cref="ServiceStack"/>
/// </summary>
public sealed class ServiceStackTests
{
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStack.Text.JsonSerializer"/>.
    /// </summary>
    [Fact]
    public void ServiceStackDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        TestModel[] actualModels;
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            actualModels = ServiceStack.Text.JsonSerializer.DeserializeFromSpan<TestModel[]>(actualString);
        }
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStack.Text.JsonSerializer"/>.
    /// </summary>
    [Fact]
    public void ServiceStackDeserialize_Returns_ValidStringModels()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        TestModel[] actualModels;
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            var actualString = ServiceStack.Text.JsonSerializer.SerializeToString(expectedModels);
            actualModels = ServiceStack.Text.JsonSerializer.DeserializeFromSpan<TestModel[]>(actualString);
        }
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}