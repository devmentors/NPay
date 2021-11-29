using System;
using NPay.Shared.Events;

namespace NPay.Modules.Wallets.Application.Events
{
    public record WalletAdded(Guid WalletId, Guid OwnerId, string Currency) : IEvent;
}