using NPay.Modules.Wallets.Core.Owners.ValueObjects;
using NPay.Modules.Wallets.Core.Wallets.ValueObjects;

namespace NPay.Modules.Wallets.Core.Wallets.Services;

internal interface ICurrencyResolver
{
    Currency Resolve(Nationality nationality);
}