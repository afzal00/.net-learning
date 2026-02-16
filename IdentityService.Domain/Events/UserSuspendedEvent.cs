using IdentityService.Domain.Enums;
using IdentityService.Domain.Exceptions;

namespace IdentityService.Domain.Events;

public sealed class VendorSuspendedEvent : DomainEvent
{
    public Guid UserId { get; }

    public VendorSuspendedEvent(Guid userId)
    {
        UserId = userId;
    }
    public void Suspend()
    {
        // if (Status != UserStatus.Active)
        //     throw new DomainException("Only active users can be suspended.");

        // Status = UserStatus.Suspended;
    }

}
