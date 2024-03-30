using Benchmarks.QueryBuilder.Services.Uri;

namespace Benchmark.Tests.Unit.Benchmark.QueryBuilder;

/// <summary>
///     Testing of methods from <see cref="StringUriCombineService" />.
/// </summary>
public sealed class StringUriTests
{
    private readonly static Uri BaseUri = new("https://localhost");

    private readonly static Uri BaseUriDelimiter = new("https://localhost/");

    private readonly static string BaseUriString = BaseUri.AbsoluteUri;

    private readonly static string BaseUriDelimiterString = BaseUriDelimiter.AbsoluteUri;

    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.NewUri" />.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory, InlineData("api/v1", "https://localhost/api/v1"), InlineData("/api/v1", "https://localhost/api/v1")]
    public void UriSpan_Returns_ConstructedString(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);

        // Act
        var actualBaseConcat = StringUriCombineService.UriSpan(BaseUriString, relativePath);
        var actualBaseDelimiterConcat = StringUriCombineService.UriSpan(BaseUriDelimiterString, relativePath);

        // Assert
        Assert.Equal(expectedUri, actualBaseConcat);
        Assert.Equal(expectedUri, actualBaseDelimiterConcat);
    }

    /// <summary>
    ///     Testing exceptions throwing of method <see cref="UriCombineService.UriSpan" />.
    /// </summary>
    /// <param name="relativePath">Invalid relative path to be thrown exception at.</param>
    [Theory, InlineData("//////api/v1")]
    public void UriSpan_ThrowsException_InvalidRelativePath(string relativePath)
    {
        // Act
        // Assert
        Assert.Throws<UriFormatException>(() => StringUriCombineService.UriSpan(BaseUriString, relativePath));
        Assert.Throws<UriFormatException>(() => StringUriCombineService.UriSpan(BaseUriDelimiterString, relativePath));
    }

    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.NewUri" />.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory, InlineData("api/v1", "https://localhost/api/v1"), InlineData("/api/v1", "https://localhost/api/v1")]
    public void UriAppend_Returns_ConstructedString(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);

        // Act
        var actualBaseConcat = StringUriCombineService.UriAppend(BaseUriString, relativePath);
        var actualBaseDelimiterConcat = StringUriCombineService.UriAppend(BaseUriDelimiterString, relativePath);

        // Assert
        Assert.Equal(expectedUri, actualBaseConcat);
        Assert.Equal(expectedUri, actualBaseDelimiterConcat);
    }

    /// <summary>
    ///     Testing exceptions throwing of method <see cref="UriCombineService.UriSpan" />.
    /// </summary>
    /// <param name="relativePath">Invalid relative path to be thrown exception at.</param>
    [Theory, InlineData("//////api/v1")]
    public void UriAppend_ThrowsException_InvalidRelativePath(string relativePath)
    {
        // Act
        // Assert
        Assert.Throws<UriFormatException>(() => StringUriCombineService.UriAppend(BaseUriString, relativePath));
        Assert.Throws<UriFormatException>(() => StringUriCombineService.UriAppend(BaseUriDelimiterString, relativePath));
    }

    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.NewUri" />.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory, InlineData("api/v1", "https://localhost/api/v1"), InlineData("/api/v1", "https://localhost/api/v1"),
     InlineData("//////api/v1", "https://localhost/api/v1")]
    public void UriCombine_Returns_ConstructedString(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);

        // Act
        var actualBaseConcat = StringUriCombineService.UriCombine(BaseUriString, relativePath);
        var actualBaseDelimiterConcat = StringUriCombineService.UriCombine(BaseUriDelimiterString, relativePath);

        // Assert
        Assert.Equal(expectedUri, actualBaseConcat);
        Assert.Equal(expectedUri, actualBaseDelimiterConcat);
    }

    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.NewUri" />.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory, InlineData("api/v1", "https://localhost/api/v1"), InlineData("/api/v1", "https://localhost/api/v1"),
     InlineData("//////api/v1", "https://localhost/api/v1")]
    public void UriSwitch_Returns_ConstructedString(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);

        // Act
        var actualBaseConcat = StringUriCombineService.UriSwitch(BaseUriString, relativePath);
        var actualBaseDelimiterConcat = StringUriCombineService.UriSwitch(BaseUriDelimiterString, relativePath);

        // Assert
        Assert.Equal(expectedUri, actualBaseConcat);
        Assert.Equal(expectedUri, actualBaseDelimiterConcat);
    }

    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.NewUri" />.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory, InlineData("api/v1", "https://localhost/api/v1"), InlineData("/api/v1", "https://localhost/api/v1")]
    public void UriCombineCached_Returns_ConstructedString(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);

        // Act
        var actualBaseConcat = StringUriCombineService.UriCombineCached(BaseUriString, relativePath);
        var actualBaseDelimiterConcat = StringUriCombineService.UriCombineCached(BaseUriDelimiterString, relativePath);

        // Assert
        Assert.Equal(expectedUri, actualBaseConcat);
        Assert.Equal(expectedUri, actualBaseDelimiterConcat);
    }

    /// <summary>
    ///     Testing exceptions throwing of method <see cref="UriCombineService.UriSpan" />.
    /// </summary>
    /// <param name="relativePath">Invalid relative path to be thrown exception at.</param>
    [Theory, InlineData("//////api/v1")]
    public void UriCombineCached_ThrowsException_InvalidRelativePath(string relativePath)
    {
        // Act
        // Assert
        Assert.Throws<UriFormatException>(() => StringUriCombineService.UriCombineCached(BaseUriString, relativePath));
        Assert.Throws<UriFormatException>(() => StringUriCombineService.UriCombineCached(BaseUriDelimiterString, relativePath));
    }

    /// <summary>
    ///     Testing actual work of method <see cref="UriCombineService.NewUri" />.
    /// </summary>
    /// <param name="relativePath">Relative path to be added to base uri.</param>
    /// <param name="expectedStringUri">Expected combination output.</param>
    [Theory, InlineData("api/v1", "https://localhost/api/v1"), InlineData("/api/v1", "https://localhost/api/v1")]
    public void UriBuilderTryCreate_Returns_ConstructedString(string relativePath, string expectedStringUri)
    {
        // Arrange
        var expectedUri = new Uri(expectedStringUri);

        // Act
        var actualBaseConcat = StringUriCombineService.UriBuilderTryCreate(BaseUriString, relativePath);
        var actualBaseDelimiterConcat = StringUriCombineService.UriBuilderTryCreate(BaseUriDelimiterString, relativePath);

        // Assert
        Assert.Equal(expectedUri, actualBaseConcat);
        Assert.Equal(expectedUri, actualBaseDelimiterConcat);
    }

    /// <summary>
    ///     Testing exceptions throwing of method <see cref="UriCombineService.UriSpan" />.
    /// </summary>
    /// <param name="relativePath">Invalid relative path to be thrown exception at.</param>
    [Theory, InlineData("//////api/v1")]
    public void UriBuilderTryCreate_ThrowsException_InvalidRelativePath(string relativePath)
    {
        // Act
        // Assert
        Assert.Throws<UriFormatException>(() => StringUriCombineService.UriBuilderTryCreate(BaseUriString, relativePath));
        Assert.Throws<UriFormatException>(() => StringUriCombineService.UriBuilderTryCreate(BaseUriDelimiterString, relativePath));
    }
}