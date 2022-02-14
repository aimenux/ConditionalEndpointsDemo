namespace _01_Way;

public interface IProxy
{
    Task<string> GetAsync();
}

public class Proxy : IProxy
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public Proxy(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> GetAsync()
    {
        var url = _configuration.GetValue<string>("ProxyUrl");
        var response = await _httpClient.GetStringAsync(url);
        return response;
    }
}