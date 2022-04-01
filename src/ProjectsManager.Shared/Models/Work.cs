using ProjectsManager.Shared.Common.Interfaces.Models.Common;

namespace ProjectsManager.Shared.Common.Interfaces.Models.Models;

public record Work(Guid Id, string Name, DateTime StartDate, DateTime EndDate) : ITimedEntity
{
    public Project Project { get; init; } = default!;
};