using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace portfolio_ms.Data.EntityTypeConfigurations.Identity;

public class IdentityUserRoleConfiguration  : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.ToTable("UserRole");
        builder.HasKey(r => new { r.UserId, r.RoleId });
    }
}