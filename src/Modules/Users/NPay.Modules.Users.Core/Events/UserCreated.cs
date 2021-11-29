using System;
using NPay.Shared.Events;

namespace NPay.Modules.Users.Core.Events
{
    public record UserCreated(Guid UserId, string Email, string FullName, string Nationality) : IEvent;
}