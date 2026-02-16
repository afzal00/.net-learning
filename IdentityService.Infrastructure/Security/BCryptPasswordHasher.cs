using BCrypt.Net;
using IdentityService.Application.Abstractions.Security;

namespace IdentityService.Infrastructure.Security
{
    public sealed class BCryptPasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string hash)
        {

            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}