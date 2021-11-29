using System;
using NPay.Shared.Events;

namespace NPay.Modules.Wallets.Application.Events
{
    public record FundsAdded(Guid WalletId, Guid OwnerId, string Currency, decimal Amount) : IEvent;
}