using System;
using NPay.Shared.Events;

namespace NPay.Modules.Users.Shared.Events;

public record UserVerified(Guid UserId, string Email, string Nationality) : IEvent;