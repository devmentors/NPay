using System;
using NPay.Shared.Events;

namespace NPay.Modules.Wallets.Application.ExternalEvents
{
    public record UserCreated(Guid UserId, string Email, string FullName, string Nationality) : IEvent;
}