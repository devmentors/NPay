using System;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Api.ExternalEvents
{
    public record UserVerified(Guid UserId, string Email, string Nationality) : IEvent;
}