using NPay.Shared.Exceptions;

namespace NPay.Modules.Users.Core.Exceptions;

internal sealed class InvalidAddressException : NPayException
{
    public string Address { get; }

    public InvalidAddressException(string address) : base($"Address: '{address}' is invalid.")
    {
        Address = address;
    }
}