using System;
using NPay.Shared.Events;

namespace NPay.Modules.Wallets.Application.Events
{
    public record OwnerVerified(Guid OwnerId) : IEvent;
}