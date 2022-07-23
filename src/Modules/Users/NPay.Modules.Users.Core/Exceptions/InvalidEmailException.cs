using NPay.Shared.Exceptions;

namespace NPay.Modules.Users.Core.Exceptions;

internal sealed class InvalidEmailException : NPayException
{
    public string Email { get; }

    public InvalidEmailException(string email) : base($"Email: '{email}' is invalid.")
    {
        Email = email;
    }
}