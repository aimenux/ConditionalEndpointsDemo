using Microsoft.AspNetCore.Mvc;

namespace _01_Way.Controllers;

[ApiController]
[Route("[controller]")]
public class DummyController : ControllerBase
{
    [HttpGet("random-strings")]
    public IEnumerable<string> Get()
    {
        return Enumerable.Range(1, 5).Select(_ => Helpers.RandomString()).ToArray();
    }
}