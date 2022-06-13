using ZeroFormatter;

namespace JsonBenchmarks.Models;

/// <summary>
///     Test model.
/// </summary>
[ZeroFormattable]
public class TestModelVirtual
{
    /// <summary>
    ///     Test first name.
    /// </summary>
    [Index(0)]
    public virtual string FirstName { get; set; } = default!;
    
    /// <summary>
    ///     Test last name.
    /// </summary>
    [Index(1)]
    public virtual string LastName { get; set; } = default!;

    /// <summary>
    ///     Test date.
    /// </summary>
    [Index(2)]
    public virtual DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
    
    /// <summary>
    ///     Test temp.
    /// </summary>
    [Index(3)]
    public virtual int TemperatureCelsius { get; set; }

    /// <summary>
    ///     Test summary.
    /// </summary>
    [Index(4)]
    public virtual string Summary { get; set; } = default!;
    
    /// <summary>
    ///     Converts <see cref="TestModel"/> to <see cref="TestModelVirtual"/>.
    /// </summary>
    /// <param name="testModels"></param>
    /// <returns></returns>
    public static List<TestModelVirtual> ToTestModelVirtual(IEnumerable<TestModel> testModels)
    {
        return testModels
            .Select(testModel => new TestModelVirtual 
                {
                    FirstName = testModel.FirstName,
                    LastName = testModel.LastName,
                    Date = testModel.Date,
                    TemperatureCelsius = testModel.TemperatureCelsius,
                    Summary = testModel.Summary
                })
            .ToList();
    }
}