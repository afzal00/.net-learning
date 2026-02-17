using Microsoft.EntityFrameworkCore;
using IdentityService.Domain.Aggregates;
using IdentityService.Domain.Entities;

namespace IdentityService.Infrastructure.Persistence
{
    public sealed class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        // Tables
        public DbSet<User> Users => Set<User>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
            // User
            // modelBuilder.Entity<User>(entity =>
            // {
            //     entity.HasKey(u => u.Id);

            //     entity.Property(u => u.Email)
            //             .IsRequired()
            //             .HasMaxLength(256);

            //     entity.HasIndex(u => u.Email)
            //             .IsUnique();

            //     entity.Property(u => u.PasswordHash)
            //         .IsRequired();
            // });

            // Refresh Token
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(rt => rt.Id);
                entity.Property(rt => rt.Token)
                        .IsRequired();
                // entity.HasOne<User>()
                //         .WithMany()
                //         .HasForeignKey(rt => rt.UserId);
            });
        }
    }
}