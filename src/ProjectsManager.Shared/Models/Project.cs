namespace ProjectsManager.Shared.Common.Interfaces.Models.Models;

public record Project(Guid Id, string Name, DateTime StartDate, DateTime EndDate,  ICollection<Work> Works)
{
    public void Deconstruct(out Guid id, out string name, out string startDate, out string endDate)
    {
        (id, name, startDate, endDate) = (Id, Name, StartDate.ToShortDateString(), EndDate.ToShortDateString());
    }
};