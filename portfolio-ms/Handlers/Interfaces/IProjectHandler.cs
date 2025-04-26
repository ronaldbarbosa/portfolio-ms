using portfolio_ms.Models;

namespace portfolio_ms.Handlers.Interfaces;

public interface IProjectHandler
{
    Task<Project?> GetByIdAsync(Guid id);
    Task<List<Project>> GetAllAsync();
    Task<Project?> CreateAsync(Project project);
}