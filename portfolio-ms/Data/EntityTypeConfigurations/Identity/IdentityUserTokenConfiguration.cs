using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using portfolio_ms.Models;

namespace portfolio_ms.Data.EntityTypeConfigurations.Identity;

public class IdentityUserTokenConfiguration  : IEntityTypeConfiguration<IdentityUserToken<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
    {
        builder.ToTable("UserTokens");
        builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        
        builder.Property(t => t.LoginProvider).HasMaxLength(128);
        builder.Property(t => t.Name).HasMaxLength(128);
    }
}