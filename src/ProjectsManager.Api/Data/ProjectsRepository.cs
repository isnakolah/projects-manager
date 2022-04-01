using ProjectsManager.Shared.Common.Interfaces.Models.Models;

namespace ProjectsManager.Api.Data;

internal class ProjectsRepository
{
    private readonly IEnumerable<Project> projects = new[]
    {
        new Project(Guid.NewGuid(), "Test Project 1", DateTime.Now, DateTime.Today, new List<Work>()),
        new Project(Guid.NewGuid(), "Test Project 2", DateTime.Now, DateTime.Today, new List<Work>()),
        new Project(Guid.NewGuid(), "Test Project 3", DateTime.Now, DateTime.Today, new List<Work>()),
    };

    private readonly ILogger<ProjectsRepository> _logger;

    public ProjectsRepository(ILogger<ProjectsRepository> logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await Task.FromResult(projects);
    }

    public async Task<Project?> GetSingleAsync(Guid Id)
    {
        return await Task.FromResult(projects.FirstOrDefault(x => x.Id == Id));
    }
}