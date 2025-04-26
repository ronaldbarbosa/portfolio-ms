using Microsoft.EntityFrameworkCore;
using portfolio_ms.Data;
using portfolio_ms.Handlers.Interfaces;
using portfolio_ms.Models;

namespace portfolio_ms.Handlers.Implementations;

public class ProjectHandler(AppDbContext appDbContext) : IProjectHandler
{
    public async Task<Project?> GetByIdAsync(Guid id)
    {
        return await appDbContext.Projects.FindAsync(id);
    }

    public async Task<List<Project>> GetAllAsync()
    {
        return await appDbContext.Projects.ToListAsync();
    }

    public async Task<Project?> CreateAsync(Project project)
    {
        var result = await appDbContext.Projects.AddAsync(project);
        await appDbContext.SaveChangesAsync();
        return result.Entity;
    }
}