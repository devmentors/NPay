using System;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Api.ExternalEvents
{
    public record WalletAdded(Guid WalletId, Guid OwnerId, string Currency) : IEvent;
}