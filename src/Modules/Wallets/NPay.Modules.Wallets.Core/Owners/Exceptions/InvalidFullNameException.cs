using NPay.Shared.Exceptions;

namespace NPay.Modules.Wallets.Core.Owners.Exceptions;

internal sealed class InvalidFullNameException : NPayException
{
    public string FullName { get; }

    public InvalidFullNameException(string fullName) : base($"Full name: '{fullName}' is invalid.")
    {
        FullName = fullName;
    }
}