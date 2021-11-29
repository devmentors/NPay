using System;
using NPay.Shared.Events;

namespace NPay.Modules.Wallets.Application.ExternalEvents
{
    public record UserVerified(Guid UserId, string Email, string Nationality) : IEvent;
}