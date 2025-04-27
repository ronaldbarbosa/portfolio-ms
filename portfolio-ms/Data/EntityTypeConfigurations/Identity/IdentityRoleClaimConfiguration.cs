using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace portfolio_ms.Data.EntityTypeConfigurations.Identity;

public class IdentityRoleClaimConfiguration  : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
    {
        builder.ToTable("RoleClaims");
        builder.HasKey(rc => rc.Id);
        
        builder.Property(rc => rc.ClaimType).HasMaxLength(250);
        builder.Property(rc => rc.ClaimValue).HasMaxLength(250);
    }
}