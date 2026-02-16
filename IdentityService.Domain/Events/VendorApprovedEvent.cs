using IdentityService.Domain.Enums;
using IdentityService.Domain.Exceptions;

namespace IdentityService.Domain.Events;

public sealed class VendorApprovedEvent : DomainEvent
{
    public Guid UserId { get; }

    public VendorApprovedEvent(Guid userId)
    {
        UserId = userId;
    }
    public void ApproveVendor()
    {
        // if (userType != UserType.Vendor)
        // {
        //     throw new DomainException("Only Vendor can be approved.");
        // }

        // if (Status != UserStatus.Pending)
        // {
        //     throw new DomainException("Vendor must be pending to approve.");
        // }

        // Status = UserStatus.Active;

        // AddDomainEvent(new VendorApprovedEvent(Id));
    }
}
