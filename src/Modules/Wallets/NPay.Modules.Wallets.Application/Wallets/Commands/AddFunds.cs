using System;
using NPay.Shared.Commands;

namespace NPay.Modules.Wallets.Application.Wallets.Commands;

public record AddFunds(Guid WalletId, decimal Amount) : ICommand;