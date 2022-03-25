using System.Net.Http.Json;

namespace ProjectsManager.App.Services;

internal class HttpClientHandler
{
    private const string localhost = "https://localhost:6001";
    private const string production = "https://nw9un0fjc2.execute-api.us-east-1.amazonaws.com/Prod";

    private readonly HttpClient _client;

    public HttpClientHandler()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri($"{production}/api/projects");
    }

    public async Task<T?> GetAllAsync<T>(string endpoint = "")
    {
        var response = await _client.GetFromJsonAsync<T>(endpoint);

        return response;
    }
}