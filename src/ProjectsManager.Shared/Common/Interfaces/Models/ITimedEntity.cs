namespace ProjectsManager.Shared.Common.Interfaces.Models.Common;

public interface ITimedEntity
{
    DateTime StartDate { get; init; }
    DateTime EndDate { get; init; }
}