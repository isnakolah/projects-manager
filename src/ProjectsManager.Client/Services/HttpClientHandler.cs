using System.Net.Http.Json;

namespace ProjectsManager.Client.Services;

internal class HttpClientHandler
{
    private readonly HttpClient _client;
    private readonly ILogger<HttpClientHandler> _logger;

    public HttpClientHandler(IHttpClientFactory httpClientFactory, ILogger<HttpClientHandler> logger)
    {
        (_client, _logger) = (httpClientFactory.CreateClient() ,logger);
    }

    public async Task<T?> GetAllAsync<T>(string endpoint)
    {
        _logger.LogInformation("Clients base address is: {ClientBaseAddress}", _client.BaseAddress);
        
        var response = await _client.GetFromJsonAsync<T>(endpoint);

        return response;
    }
}