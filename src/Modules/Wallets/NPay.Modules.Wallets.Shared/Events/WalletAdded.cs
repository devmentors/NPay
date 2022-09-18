using System;
using NPay.Shared.Events;

namespace NPay.Modules.Wallets.Shared.Events;

public record WalletAdded(Guid WalletId, Guid OwnerId, string Currency) : IEvent;