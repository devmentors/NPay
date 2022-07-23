using NPay.Shared.Exceptions;

namespace NPay.Modules.Wallets.Core.Owners.Exceptions;

internal sealed class UnsupportedNationalityException : NPayException
{
    public string Nationality { get; }

    public UnsupportedNationalityException(string nationality)
        : base($"Nationality: '{nationality}' is unsupported.")
    {
        Nationality = nationality;
    }
}