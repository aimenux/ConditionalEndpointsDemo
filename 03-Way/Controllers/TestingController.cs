using Microsoft.AspNetCore.Mvc;

namespace _03_Way.Controllers;

[ApiController]
[ConditionalController]
[Route("[controller]")]
public class TestingController : ControllerBase
{
    private readonly IProxy _proxy;

    public TestingController(IProxy proxy)
    {
        _proxy = proxy;
    }

    [HttpGet("check-weather")]
    public Task<string> GetWeather() => _proxy.GetAsync();
}