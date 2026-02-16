using ECommerce.Application.Users.Commands.RegisterVendor;
using IdentityService.Application.Abstractions.Persistence;
using IdentityService.Application.Abstractions.Security;
using IdentityService.Application.Common;
using IdentityService.Domain.Aggregates;

namespace IdentityService.Application.Users.Commands.RegisterVendor;

public sealed class RegisterVendorCommandHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterVendorCommandHandler(
        IUserRepository userREpository,
        IPasswordHasher passwordHasher
    )
    {
        _userRepository = userREpository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result> Handle(
        RegisterVendorCommand command,
        CancellationToken cancellationToken
    )
    {
        if (await _userRepository.ExistsByEmailAsync(command.Email, cancellationToken))
            return Result.Failure("Email Already Exits.");

        var passwordHash = _passwordHasher.Hash(command.Password);
        var user = User.RegisterVendor(command.Email, passwordHash);
        await _userRepository.AddAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}