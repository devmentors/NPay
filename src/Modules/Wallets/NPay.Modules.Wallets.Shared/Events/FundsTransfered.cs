using System;
using NPay.Shared.Events;

namespace NPay.Modules.Wallets.Shared.Events;

public record FundsTransferred(Guid FromWalletId, Guid ToWalletId, decimal Amount, string Currency) : IEvent;