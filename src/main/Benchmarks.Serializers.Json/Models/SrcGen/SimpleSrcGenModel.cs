namespace Benchmarks.Serializers.Json.Models.SrcGen;

/// <summary>
///     Simple deserialization model. Used for tests.
/// </summary>
[JsonSrcGen.Json]
public class SimpleSrcGenModel
{
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [JsonSrcGen.JsonName("testInt")]
    public virtual int TestInt { get; set; }
    
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [JsonSrcGen.JsonName("testString")]
    public virtual string TestString { get; set; } = string.Empty;
    
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [JsonSrcGen.JsonName("testBool")]
    public virtual bool TestBool { get; set; }
}