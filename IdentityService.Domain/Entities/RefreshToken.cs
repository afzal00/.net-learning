using IdentityService.Domain.Exceptions;
public class RefreshToken
{
    private List<RefreshToken> _refreshTokens = new List<RefreshToken>();
    public string Token { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public bool IsRevoked { get; private set; }

    public RefreshToken(string token, DateTime expiresAt)
    {
        Token = token;
        ExpiresAt = expiresAt;
        IsRevoked = false;
    }

    public void AddRefreshToken(string token, DateTime expiresAt)
    {
        _refreshTokens.Add(new RefreshToken(token, expiresAt));
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