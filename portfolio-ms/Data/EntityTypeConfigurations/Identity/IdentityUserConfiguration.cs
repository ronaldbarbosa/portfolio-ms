using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using portfolio_ms.Models;

namespace portfolio_ms.Data.EntityTypeConfigurations.Identity;

public class IdentityUserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        
        builder.HasIndex(u => u.NormalizedEmail).IsUnique();
        builder.HasIndex(u => u.NormalizedUserName).IsUnique();
        
        builder.Property(u => u.Email).HasMaxLength(100);
        builder.Property(u => u.NormalizedEmail).HasMaxLength(100);
        builder.Property(u => u.UserName).HasMaxLength(100);
        builder.Property(u => u.NormalizedUserName).HasMaxLength(100);
        builder.Property(u => u.PhoneNumber).HasMaxLength(20);
        builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();
        
        builder.HasMany<IdentityUserClaim<Guid>>()
            .WithOne()
            .HasForeignKey(uc => uc.UserId)
            .IsRequired();
        builder.HasMany<IdentityUserRole<Guid>>()
            .WithOne()
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
        builder.HasMany<IdentityUserLogin<Guid>>()
            .WithOne()
            .HasForeignKey(l => l.UserId)
            .IsRequired();
        builder.HasMany<IdentityUserToken<Guid>>()
            .WithOne()
            .HasForeignKey(ut => ut.UserId)
            .IsRequired();
    }
}