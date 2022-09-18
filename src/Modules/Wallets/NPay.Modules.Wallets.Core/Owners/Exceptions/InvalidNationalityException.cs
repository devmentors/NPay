using NPay.Shared.Exceptions;

namespace NPay.Modules.Wallets.Core.Owners.Exceptions;

internal sealed class InvalidNationalityException : NPayException
{
    public string Nationality { get; }

    public InvalidNationalityException(string nationality)
        : base($"Nationality: '{nationality}' is invalid.")
    {
        Nationality = nationality;
    }
}