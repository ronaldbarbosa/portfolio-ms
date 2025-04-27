using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using portfolio_ms.Models;

namespace portfolio_ms.Data.EntityTypeConfigurations.Identity;

public class IdentityUserLoginConfiguration  : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
    {
        builder.ToTable("UserLogins");
        builder.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        
        builder.Property(l => l.LoginProvider).HasMaxLength(128);
        builder.Property(l => l.ProviderKey).HasMaxLength(128);
        builder.Property(l => l.ProviderDisplayName).HasMaxLength(128);
    }
}