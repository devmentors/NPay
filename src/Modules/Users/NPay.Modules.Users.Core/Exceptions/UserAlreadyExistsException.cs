using NPay.Shared.Exceptions;

namespace NPay.Modules.Users.Core.Exceptions;

internal sealed class UserAlreadyExistsException : NPayException
{
    public string Email { get; }

    public UserAlreadyExistsException(string email) : base($"User with email: '{email}' already exists.")
    {
        Email = email;
    }
}