namespace ECommerce.Application.Users.Commands.RegisterVendor;

public sealed record RegisterVendorCommand(
    string Email,
    string Password
);