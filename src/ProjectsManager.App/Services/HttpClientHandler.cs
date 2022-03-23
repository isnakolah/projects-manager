using System.Net.Http.Json;

namespace ProjectsManager.App.Services;

internal class HttpClientHandler
{
    private readonly HttpClient _client;

    public HttpClientHandler()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://localhost:6001/api/projects");
    }

    public async Task<T?> GetAllAsync<T>(string endpoint = "")
    {
        var response = await _client.GetFromJsonAsync<T>(endpoint);

        return response;
    }
}