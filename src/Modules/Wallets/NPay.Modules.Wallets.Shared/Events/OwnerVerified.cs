using System;
using NPay.Shared.Events;

namespace NPay.Modules.Wallets.Shared.Events;

public record OwnerVerified(Guid OwnerId) : IEvent;