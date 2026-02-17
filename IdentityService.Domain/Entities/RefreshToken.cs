using IdentityService.Domain.Exceptions;

namespace IdentityService.Domain.Entities;

public class RefreshToken
{
    public Guid Id { get; private set; }

    // public Guid UserId { get; private set; }
    public string Token { get; private set; } = default!;
    private readonly List<RefreshToken> _refreshTokens = new List<RefreshToken>();

    public DateTime ExpiresAt { get; private set; }
    public bool IsRevoked { get; private set; }

    private RefreshToken() { } // Required by EF
    public RefreshToken( string token, DateTime expiresAt)
    {
        Id = Guid.NewGuid();
        // UserId = userId;
        Token = token;
        ExpiresAt = expiresAt;
        IsRevoked = false;
    }

    public void AddRefreshToken(Guid userId, string token, DateTime expiresAt)
    {
        _refreshTokens.Add(new RefreshToken( token, expiresAt));
    }

    public void RevokeRefreshToken(string token)
    {
        var existing = _refreshTokens.FirstOrDefault(t => t.Token == token);

        if (existing == null)
            throw new DomainException("Refresh token not found.");

        existing.Revoke();
    }

    public void Revoke()
    {
        IsRevoked = true;
    }

}