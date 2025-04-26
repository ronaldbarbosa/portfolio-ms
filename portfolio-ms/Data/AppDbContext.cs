using Microsoft.EntityFrameworkCore;
using portfolio_ms.Models;

namespace portfolio_ms.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Applying all configurations from this project
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}