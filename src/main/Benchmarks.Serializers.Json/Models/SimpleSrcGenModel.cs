using Benchmarks.Serializers;
using JsonSrcGen;

namespace Benchmarks.Serializers.Json.Models;

/// <summary>
///     Simple deserialization model. Used for tests.
/// </summary>
[Json]
public class SimpleSrcGenModel
{
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [JsonName(Fields.TestIntField)]
    public virtual int TestInt { get; set; }

    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [JsonName(Fields.TestStringField)]
    public virtual string TestString { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [JsonName(Fields.TestBoolField)]
    public virtual bool TestBool { get; set; }
}