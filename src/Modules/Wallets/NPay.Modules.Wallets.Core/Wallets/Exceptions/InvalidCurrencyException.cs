using NPay.Shared.Exceptions;

namespace NPay.Modules.Wallets.Core.Wallets.Exceptions;

internal sealed class InvalidCurrencyException : NPayException
{
    public string Currency { get; }

    public InvalidCurrencyException(string currency) : base($"Currency: '{currency}' is invalid.")
    {
        Currency = currency;
    }
}