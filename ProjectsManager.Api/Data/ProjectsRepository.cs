using ProjectsManager.Api.Models;
using ProjectsManager.Contracts.Models;

namespace ProjectsManager.Api.Data;

internal class ProjectsRepository
{
    private readonly IEnumerable<IProject> projects = new[]
    {
        new Project(Guid.NewGuid(), "Test Project 1", DateTime.Now, DateTime.Today),
        new Project(Guid.NewGuid(), "Test Project 2", DateTime.Now, DateTime.Today),
        new Project(Guid.NewGuid(), "Test Project 3", DateTime.Now, DateTime.Today),
    };

    private readonly ILogger<ProjectsRepository> _logger;

    public ProjectsRepository(ILogger<ProjectsRepository> logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<IProject>> GetAll()
    {
        _logger.LogInformation("Get all projects called, project retrieved");

        return await Task.FromResult(projects);
    }

    public async Task<IProject?> GetSingle(Guid Id)
    {
        _logger.LogInformation("Retrieving single project, project id: {Id}", Id.ToString());
        
        return await Task.FromResult(projects.FirstOrDefault(x => x.Id == Id));
    }
}