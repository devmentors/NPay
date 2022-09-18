using NPay.Modules.Wallets.Core.Owners.ValueObjects;
using NPay.Modules.Wallets.Core.Wallets.ValueObjects;

namespace NPay.Modules.Wallets.Core.Wallets.Services;

internal sealed class CurrencyResolver : ICurrencyResolver
{
    public Currency Resolve(Nationality nationality)
        => nationality.Value switch
        {
            "PL" => "PLN",
            "DE" => "EUR",
            "FR" => "EUR",
            "ES" => "EUR",
            "GB" => "GBP",
            _ => "EUR"
        };
}