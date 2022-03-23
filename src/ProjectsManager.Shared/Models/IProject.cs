namespace ProjectsManager.Shared.Models;

public interface IProject
{
    Guid Id { get; init; }
    string Name { get; init; }
    DateTime StartDate { get; init; }
    DateTime EndDate { get; init; }

    void Deconstruct(out Guid id, out string name, out DateTime startDate, out DateTime endDate)
    {
        (id, name, startDate, endDate) = (Id, Name, StartDate, EndDate);
    }
}