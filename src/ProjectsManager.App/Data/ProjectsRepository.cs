using ProjectsManager.App.Models;
using ProjectsManager.App.Services;
using HttpClientHandler = ProjectsManager.App.Services.Handlers.HttpClientHandler;

namespace ProjectsManager.App.Data;

internal class ProjectsRepository
{
    private readonly CacheService<IEnumerable<Project>> _cache;
    private readonly HttpClientHandler _client;

    public ProjectsRepository(CacheService<IEnumerable<Project>> cache, HttpClientHandler client)
    {
        (_cache, _client) = (cache, client);
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        if (await _cache.GetAsync() is { } cachedProjects)
            return cachedProjects;

        if (await _client.GetAsync<Project[]>("projects") is not { } projects)
            return Enumerable.Empty<Project>();

        await _cache.SetAsync(projects);

        return projects;
    }
}