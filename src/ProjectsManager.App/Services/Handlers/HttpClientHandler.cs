using System.Net.Http.Json;

namespace ProjectsManager.App.Services.Handlers;

internal class HttpClientHandler
{
    private const string localhost = "https://localhost:6001/api";
    private const string production = "https://nw9un0fjc2.execute-api.us-east-1.amazonaws.com/api";

    private readonly HttpClient _client;

    public HttpClientHandler()
    {
        _client = new HttpClient();
    }

    public async Task<T?> GetAsync<T>(string endpoint = "")
    {
        var response = await _client.GetFromJsonAsync<T>($"{localhost}/projects/{endpoint}");

        return response;
    }
}