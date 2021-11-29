using System;
using NPay.Shared.Events;

namespace NPay.Modules.Users.Core.Events
{
    public record UserVerified(Guid UserId, string Email, string Nationality) : IEvent;
}