using ProjectsManager.Contracts.Models;

namespace ProjectsManager.Api.Models;

public record Project(Guid Id, string Name, DateTime StartDate, DateTime EndDate) : IProject;