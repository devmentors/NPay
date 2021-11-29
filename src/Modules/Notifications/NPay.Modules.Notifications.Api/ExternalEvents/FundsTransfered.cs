using System;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Api.ExternalEvents
{
    public record FundsTransferred(Guid FromWalletId, Guid ToWalletId, decimal Amount, string Currency) : IEvent;
}