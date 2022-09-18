using NPay.Shared.Exceptions;

namespace NPay.Modules.Wallets.Application.Owners.Exceptions;

internal sealed class OwnerAlreadyExistsException : NPayException
{
    public string Email { get; }

    public OwnerAlreadyExistsException(string email) : base($"Owner with email: '{email}' already exists.")
    {
        Email = email;
    }
}