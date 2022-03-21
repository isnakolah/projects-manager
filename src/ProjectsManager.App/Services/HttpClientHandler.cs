using System.Net.Http.Json;

namespace ProjectsManager.App.Services;

internal class HttpClientHandler
{
    private readonly HttpClient _client;
    private readonly ILogger<HttpClientHandler> _logger;
    private readonly Uri _configurationUrl;

    public HttpClientHandler(IHttpClientFactory httpClientFactory, ILogger<HttpClientHandler> logger, IConfiguration configuration)
    {
        (_client, _logger) = (httpClientFactory.CreateClient("ProjectsApi") ,logger);
        _configurationUrl = configuration.GetServiceUri("projects-api") ?? new Uri("");
    }

    public async Task<T?> GetAllAsync<T>(string endpoint)
    {
        _logger.LogInformation("Client base address on configuration is: {BaseConfigurationAddress}", _configurationUrl);
        
        _logger.LogInformation("Clients base address is: {ClientBaseAddress}", _client.BaseAddress);
        
        var response = await _client.GetFromJsonAsync<T>(endpoint);

        return response;
    }
}