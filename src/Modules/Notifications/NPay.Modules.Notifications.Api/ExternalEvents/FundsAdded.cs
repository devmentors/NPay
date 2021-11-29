using System;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Api.ExternalEvents
{
    public record FundsAdded(Guid WalletId, Guid OwnerId, string Currency, decimal Amount) : IEvent;
}