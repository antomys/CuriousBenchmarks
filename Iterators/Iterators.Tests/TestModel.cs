using System.Text.Json;
using Iterators.Benchmarks.Models;

namespace Iterators.Tests;

/// <summary>
///     Unit test model.
/// </summary>
public sealed class TestModel
{
    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="simpleModel"><see cref="SimpleModel"/>.</param>
    public TestModel(SimpleModel simpleModel)
    {
        SimpleModel = simpleModel;
        JsonModel = JsonSerializer.Serialize(simpleModel);
    }
   
    /// <summary>
    ///     Gets <see cref="SimpleModel"/>.
    /// </summary>
    public SimpleModel SimpleModel { get; }
    
    /// <summary>
    ///     Gets Json string out of <see cref="SimpleModel"/>.
    /// </summary>
    public string JsonModel { get; }
}