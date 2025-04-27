using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace portfolio_ms.Data.EntityTypeConfigurations.Identity;

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(r => r.Id);
        
        builder.HasIndex(r => r.NormalizedName).IsUnique();
        
        builder.Property(r => r.Name).HasMaxLength(250);
        builder.Property(r => r.NormalizedName).HasMaxLength(250);
        builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
    }
}