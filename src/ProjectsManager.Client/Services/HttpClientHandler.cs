using System.Net.Http.Json;

namespace ProjectsManager.Client.Services;

internal class HttpClientHandler
{
    private readonly HttpClient _client;

    public HttpClientHandler(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("WebApi");
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        var response = await _client.GetAsync(endpoint);

        var data = await response.Content.ReadFromJsonAsync<T>();

        return data;
    }
}