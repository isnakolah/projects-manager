using ProjectsManager.Shared.Models;

namespace ProjectsManager.App.Models;

internal record Project(Guid Id, string Name, DateTime StartDate, DateTime EndDate) : IProject;