
using IdentityService.Application.Abstractions.Persistence;
using IdentityService.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;


namespace IdentityService.Infrastructure.Persistence.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        public readonly IdentityDbContext _context;
        public UserRepository(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AnyAsync(u => u.Email != null && u.Email.Value == email.ToLower(),
                                cancellationToken
                                );
        }
        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
        }

        public async Task AddAsync(Guid id, CancellationToken cancellationToken)
        {
            // Implement the required interface method
            await Task.CompletedTask;
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}