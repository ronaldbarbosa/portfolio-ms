using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using portfolio_ms.Models;

namespace portfolio_ms.Data.EntityTypeConfigurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(p => p.Description)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(250)
            .IsRequired();
        builder.Property(p => p.ImgUrl)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(p => p.DeployUrl)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(p => p.ProjectType).IsRequired();
    }
}