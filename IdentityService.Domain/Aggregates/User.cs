using IdentityService.Domain.Events;
using IdentityService.Domain.ValueObjects;
using IdentityService.Domain.Enums;

namespace IdentityService.Domain.Aggregates;

public sealed class User
{
    private readonly List<string> _roles = new();
    private readonly List<RefreshToken> _refreshToken = new();
    private readonly List<DomainEvent> _domainEvent = new();

    public Guid Id { get; private set; }
    public Email? Email { get; private set; }
    public string? PasswordHash { get; private set; }
    public UserType userType { get; private set; }
    public UserStatus userStatus { get; private set; }

    public IReadOnlyCollection<string> Roles => _roles.AsReadOnly();
    public IReadOnlyCollection<RefreshToken> RefreshToken => _refreshToken.AsReadOnly();
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvent.AsReadOnly();

    private User() { }

    private User(Guid id, Email email, string passwordHash, UserType userType)
    {
        Id = id;
        Email = email;
        PasswordHash = passwordHash;
        this.userType = userType;
        if (userType == UserType.Vendor)
        {
            userStatus = UserStatus.Pending;
        }
        else
        {
            userStatus = UserStatus.Active;
        }

        _roles.Add(userType.ToString());
    }

    public static User RegisterCustomer(string email, string passwordHash)
    {
        return new User(
            Guid.NewGuid(),
            Email.Create(email),
            passwordHash,
            UserType.Customer
        );
    }

    public static User RegisterVendor(string email, string passwordHash)
    {
        var user = new User(
            Guid.NewGuid(),
            Email.Create(email),
            passwordHash,
            UserType.Vendor
        );
        user.AddDomainEvent(new VendorRegisteredEvent(user.Id));

        return user;
    }

    private void AddDomainEvent(DomainEvent @event)
    {
        _domainEvent.Add(@event);
    }

    public void ClearDomainEvents()
    {
        _domainEvent.Clear();
    }


}