using System;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Api.ExternalEvents
{
    public record OwnerVerified(Guid OwnerId) : IEvent;
}