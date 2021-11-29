using System;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Api.ExternalEvents
{
    public record UserCreated(Guid UserId, string Email, string FullName, string Nationality) : IEvent;
}