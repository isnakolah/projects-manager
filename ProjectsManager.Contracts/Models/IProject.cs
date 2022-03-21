namespace ProjectsManager.Contracts.Models;

public interface IProject
{
    Guid Id { get; init; }
    string Name { get; init; }
    DateTime StartDate { get; init; }
    DateTime EndDate { get; init; }
}