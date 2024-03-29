using Benchmarks.QueryBuilder.Services.Uri;

namespace Benchmark.Tests.Unit.Benchmark.QueryBuilder;

/// <summary>
///     Tests of <see cref="UriCombineService"/>.
/// </summary>
public sealed class UriUrlTests
{
    private readonly static Uri BaseUri = new("https://localhost");
    private readonly static Uri BaseUriDelimiter = new("https://localhost/");

    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.NewUri"/>.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory]
    [InlineData("api/v1", "https://localhost/api/v1")]
    [InlineData("/api/v1", "https://localhost/api/v1")]
    public void NewUri_Returns_RightConstructedUri(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);
        
        // Act
        var actualUriCommon = UriCombineService.NewUri(BaseUri, relativePath);
        var actualUriWithDelimiter = UriCombineService.NewUri(BaseUriDelimiter, relativePath);
        
        // Assert
        Assert.Equal(expectedUri, actualUriCommon);
        Assert.Equal(expectedUri, actualUriWithDelimiter);
    }
    
    /// <summary>
    ///     Testing exceptions throwing of method <see cref="UriCombineService.NewUri"/>.
    /// </summary>
    /// <param name="relativePath">Invalid relative path to be thrown exception at.</param>
    [Theory]
    [InlineData("//////api/v1")]
    public void NewUri_ThrowsException_InvalidRelativePath(string relativePath)
    {
        // Act
        // Assert
        Assert.Throws<UriFormatException>(() => UriCombineService.NewUri(BaseUri, relativePath));
    }
    
    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.UriSpan"/>.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory]
    [InlineData("api/v1", "https://localhost/api/v1")]
    [InlineData("/api/v1", "https://localhost/api/v1")]
    public void UriSpan_Returns_RightConstructedUri(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);
        
        // Act
        var actualUriCommon = UriCombineService.UriSpan(BaseUri, relativePath);
        var actualUriWithDelimiter = UriCombineService.UriSpan(BaseUriDelimiter, relativePath);
        
        // Assert
        Assert.Equal(expectedUri, actualUriCommon);
        Assert.Equal(expectedUri, actualUriWithDelimiter);
    }
    
    /// <summary>
    ///     Testing exceptions throwing of method <see cref="UriCombineService.UriSpan"/>.
    /// </summary>
    /// <param name="relativePath">Invalid relative path to be thrown exception at.</param>
    [Theory]
    [InlineData("//////api/v1")]
    public void UriSpan_ThrowsException_InvalidRelativePath(string relativePath)
    {
        // Act
        // Assert
        Assert.Throws<UriFormatException>(() => UriCombineService.UriSpan(BaseUri, relativePath));
        Assert.Throws<UriFormatException>(() => UriCombineService.UriSpan(BaseUriDelimiter, relativePath));
    }
    
    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.UriCombine"/>.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory]
    [InlineData("api/v1", "https://localhost/api/v1")]
    [InlineData("/api/v1", "https://localhost/api/v1")]
    [InlineData("//////api/v1", "https://localhost/api/v1")]
    public void UriCombine_Returns_RightConstructedUri(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);
        
        // Act
        var actualUriCommon = UriCombineService.UriCombine(BaseUri, relativePath);
        var actualUriWithDelimiter = UriCombineService.UriCombine(BaseUriDelimiter, relativePath);
        
        // Assert
        Assert.Equal(expectedUri, actualUriCommon);
        Assert.Equal(expectedUri, actualUriWithDelimiter);
    }
    
    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.UriFastAppend"/>.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory]
    [InlineData("api/v1", "https://localhost/api/v1")]
    [InlineData("/api/v1", "https://localhost/api/v1")]
    public void UriFastAppend_Returns_RightConstructedUri(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);
        
        // Act
        var actualUriCommon = UriCombineService.UriFastAppend(BaseUri, relativePath);
        var actualUriWithDelimiter = UriCombineService.UriFastAppend(BaseUriDelimiter, relativePath);
        
        // Assert
        Assert.Equal(expectedUri, actualUriCommon);
        Assert.Equal(expectedUri, actualUriWithDelimiter);
    }
    
    /// <summary>
    ///     Testing exceptions throwing of method <see cref="UriCombineService.UriFastAppend"/>.
    /// </summary>
    /// <param name="relativePath">Invalid relative path to be thrown exception at.</param>
    [Theory]
    [InlineData("//////api/v1")]
    public void UriFastAppend_ThrowsException_InvalidRelativePath(string relativePath)
    {
        // Act
        // Assert
        Assert.Throws<UriFormatException>(() => UriCombineService.UriFastAppend(BaseUri, relativePath));
        Assert.Throws<UriFormatException>(() => UriCombineService.UriFastAppend(BaseUriDelimiter, relativePath));
    }
    
    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.UriAppend"/>.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory]
    [InlineData("api/v1", "https://localhost/api/v1")]
    [InlineData("/api/v1", "https://localhost/api/v1")]
    public void UriAppend_Returns_RightConstructedUri(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);
        
        // Act
        var actualUriCommon = UriCombineService.UriAppend(BaseUri, relativePath);
        var actualUriWithDelimiter = UriCombineService.UriAppend(BaseUriDelimiter, relativePath);
        
        // Assert
        Assert.Equal(expectedUri, actualUriCommon);
        Assert.Equal(expectedUri, actualUriWithDelimiter);
    }
    
    /// <summary>
    ///     Testing exceptions throwing of method <see cref="UriCombineService.UriAppend"/>.
    /// </summary>
    /// <param name="relativePath">Invalid relative path to be thrown exception at.</param>
    [Theory]
    [InlineData("//////api/v1")]
    public void UriAppend_ThrowsException_InvalidRelativePath(string relativePath)
    {
        // Act
        // Assert
        Assert.Throws<UriFormatException>(() => UriCombineService.UriAppend(BaseUri, relativePath));
        Assert.Throws<UriFormatException>(() => UriCombineService.UriAppend(BaseUriDelimiter, relativePath));
    }
    
    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.UriBuilderTryCreate"/>.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory]
    [InlineData("api/v1", "https://localhost/api/v1")]
    [InlineData("/api/v1", "https://localhost/api/v1")]
    public void UriBuilderTryCreate_Returns_RightConstructedUri(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);
        
        // Act
        var actualUriCommon = UriCombineService.UriBuilderTryCreate(BaseUri, relativePath);
        var actualUriWithDelimiter = UriCombineService.UriBuilderTryCreate(BaseUriDelimiter, relativePath);
        
        // Assert
        Assert.Equal(expectedUri, actualUriCommon);
        Assert.Equal(expectedUri, actualUriWithDelimiter);
    }
    
    /// <summary>
    ///     Testing exceptions throwing of method <see cref="UriCombineService.UriBuilderTryCreate"/>.
    /// </summary>
    /// <param name="relativePath">Invalid relative path to be thrown exception at.</param>
    [Theory]
    [InlineData("//////api/v1")]
    public void UriBuilderTryCreate_ThrowsException_InvalidRelativePath(string relativePath)
    {
        // Act
        // Assert
        Assert.Throws<UriFormatException>(() => UriCombineService.UriBuilderTryCreate(BaseUri, relativePath));
        Assert.Throws<UriFormatException>(() => UriCombineService.UriBuilderTryCreate(BaseUriDelimiter, relativePath));
    }
}