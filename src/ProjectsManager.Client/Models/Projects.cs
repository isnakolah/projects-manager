using ProjectsManager.Contracts.Models;

namespace ProjectsManager.Client.Models;

internal record Project(Guid Id, string Name, DateTime StartDate, DateTime EndDate) : IProject;