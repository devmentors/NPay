using NPay.Shared.Exceptions;

namespace NPay.Modules.Wallets.Core.Wallets.Exceptions;

internal sealed class UnsupportedCurrencyException : NPayException
{
    public string Currency { get; }

    public UnsupportedCurrencyException(string currency) : base($"Currency: '{currency}' is unsupported.")
    {
        Currency = currency;
    }
}