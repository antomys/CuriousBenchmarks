using Benchmark.Serializers.Models;
using Benchmarks.Serializers.OutputFormatters.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarks.Serializers.OutputFormatters.Controllers;

[ApiController]
public sealed class JsonController : ControllerBase
{
    [HttpGet("serialize/simple/100")]
    public ICollection<SimpleModel> JsonSimple()
    {
        return SimpleModelGenerator.SimpleModels;
    }

    [HttpPost("deserialize/simple/100")]
    public ActionResult JsonSimple([FromBody] IEnumerable<SimpleModel> entry) => Ok();
}