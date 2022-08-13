using Bogus;
using CuriousBenchmarks.Common;
using Json.Benchmarks.Models;
using Microsoft.AspNetCore.Mvc;

namespace Json.Benchmarks.Server.Controllers;

[ApiController]
public sealed class JsonController : ControllerBase
{
    private static readonly List<SimpleModel> SimpleModels = new Faker<SimpleModel>()
        .RuleFor(x=> x.TestBool, y=> y.Random.Bool())
        .RuleFor(x=> x.TestInt, y=> y.Random.Int())
        .RuleFor(x=>x.TestString, y=> y.Name.FullName())
        .Generate(100);
    
    private static readonly List<ComplexModel> ComplexModels = new Faker<ComplexModel>()
        .RuleFor(complexModel => complexModel.TestByte, fakerSetter => fakerSetter.Random.Byte())
        .RuleFor(complexModel => complexModel.TestChar, fakerSetter => fakerSetter.Random.Char('a', 'z'))
        .RuleFor(complexModel => complexModel.TestDate, fakerSetter => fakerSetter.Date.Past().ToUniversalTime())
        .RuleFor(complexModel => complexModel.TestDouble, fakerSetter => fakerSetter.Random.Double())
        .RuleFor(complexModel => complexModel.TestFloat, fakerSetter => fakerSetter.Random.Float())
        .RuleFor(complexModel => complexModel.TestInt, fakerSetter => fakerSetter.Random.Int())
        .RuleFor(complexModel => complexModel.TestLong, fakerSetter => fakerSetter.Random.Long())
        .RuleFor(complexModel => complexModel.TestShort, fakerSetter => fakerSetter.Random.Short())
        .RuleFor(complexModel => complexModel.TestString, fakerSetter => fakerSetter.Random.String2(5, 10))
        .RuleFor(complexModel => complexModel.TestUInt, fakerSetter => fakerSetter.Random.UInt())
        .RuleFor(complexModel => complexModel.TestUShort, fakerSetter => fakerSetter.Random.UShort())
        .RuleFor(complexModel => complexModel.TestULong, fakerSetter => fakerSetter.Random.ULong())
        .RuleFor(complexModel => complexModel.TestTimeSpan, fakerSetter => fakerSetter.Date.Timespan())
        .RuleFor(complexModel => complexModel.TestCharArray, fakerSetter => fakerSetter.Random.Chars('a', 'z', count: 10))
        .RuleFor(complexModel => complexModel.TestDoubleArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Double(), count: 10))
        .RuleFor(complexModel => complexModel.TestFloatArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Float(), count: 10))
        .RuleFor(complexModel => complexModel.TestIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Int(), count: 10))
        .RuleFor(complexModel => complexModel.TestUIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UInt(), count: 10))
        .RuleFor(complexModel => complexModel.TestLongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Long(), count: 10))
        .RuleFor(complexModel => complexModel.TestShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Short(), count: 10))
        .RuleFor(complexModel => complexModel.TestStringArray, fakerSetter => fakerSetter.GetArray(func => func.Random.String2(5, 10), count: 10))
        .RuleFor(complexModel => complexModel.TestUShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UShort(), count: 10))
        .RuleFor(complexModel => complexModel.TestULongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.ULong(), count: 10))
        .Generate(100);

    [HttpGet("serialize/simple/100")]
    public object JsonSimple()
    {
        return SimpleModels;
    }

    [HttpPost("deserialize/simple/100")]
    public ActionResult JsonSimple([FromBody] List<SimpleModel> entry) => Ok();
    
    [HttpGet("serialize/complex/100")]
    public object JsonComplex()
    {
        return ComplexModels;
    }

    [HttpPost("deserialize/complex/100")]
    public ActionResult JsonComplex([FromBody] List<ComplexModel> entry) => Ok();
}