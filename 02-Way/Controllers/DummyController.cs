using Microsoft.AspNetCore.Mvc;

namespace _02_Way.Controllers;

[ApiController]
[Route("[controller]")]
public class DummyController : ControllerBase
{
    private static readonly Random Random = new Random(Guid.NewGuid().GetHashCode());

    [HttpGet("random-strings")]
    public IEnumerable<string> Get()
    {
        return Enumerable.Range(1, 5).Select(_ => Helpers.RandomString()).ToArray();
    }
}