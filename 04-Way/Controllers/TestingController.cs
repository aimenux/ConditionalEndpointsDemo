using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace _04_Way.Controllers;

[ApiController]
[Route("[controller]")]
[FeatureGate(FeatureFlags.AwesomeFeature)]
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