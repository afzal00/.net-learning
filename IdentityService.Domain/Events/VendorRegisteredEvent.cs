namespace IdentityService.Domain.Events;

public sealed class VendorRegisteredEvent : DomainEvent
{
    public Guid UserId { get; }

    public VendorRegisteredEvent(Guid userId)
    {
        UserId = userId;
    }
}
