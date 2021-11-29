using System;
using NPay.Shared.Events;

namespace NPay.Modules.Wallets.Application.Events
{
    public record FundsTransferred(Guid FromWalletId, Guid ToWalletId, decimal Amount, string Currency) : IEvent;
}