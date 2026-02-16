

using IdentityService.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityService.Infrastructure.Persistence.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedNever();

            // Email Value Object Mapping
            builder.OwnsOne(
                u => u.Email,
                emailBuilder =>
                {
                    emailBuilder.Property(e => e.Value)
                                .HasColumnName("Email")
                                .IsRequired()
                                .HasMaxLength(256);

                    emailBuilder.HasIndex(e => e.Value)
                                .IsUnique();
                }
            );

            // Enums
            builder.Property(u => u.userType)
                    .HasConversion<int>()
                    .IsRequired();

            builder.Property(u => u.userStatus)
                    .HasConversion<int>()
                    .IsRequired();

            builder.Property(u => u.PasswordHash)
                    .IsRequired();

            // Private field mapping for roles
            builder.Metadata
                    .FindNavigation(nameof(User.Roles))?
                    .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Ignore(u => u.DomainEvents);

        }
    }
}