using NPay.Shared.Exceptions;

namespace NPay.Modules.Wallets.Application.Owners.Exceptions;

internal sealed class UserNotFoundException : NPayException
{
    public string Email { get; }

    public UserNotFoundException(string email) : base($"User with email: '{email}' was not found.")
    {
        Email = email;
    }
}