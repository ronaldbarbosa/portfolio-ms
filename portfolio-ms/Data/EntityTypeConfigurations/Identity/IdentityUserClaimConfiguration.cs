using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace portfolio_ms.Data.EntityTypeConfigurations.Identity;

public class IdentityUserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
    {
        builder.ToTable("UserClaims");
        builder.HasKey(uc => uc.Id);
        
        builder.Property(uc => uc.ClaimType).HasMaxLength(250);
        builder.Property(uc => uc.ClaimValue).HasMaxLength(250);
    }
}