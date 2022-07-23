using System;
using NPay.Shared.Events;

namespace NPay.Modules.Wallets.Shared.Events;

public record FundsAdded(Guid WalletId, Guid OwnerId, string Currency, decimal Amount) : IEvent;