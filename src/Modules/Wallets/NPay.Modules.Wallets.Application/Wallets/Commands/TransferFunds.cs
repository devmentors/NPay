using System;
using NPay.Shared.Commands;

namespace NPay.Modules.Wallets.Application.Wallets.Commands;

public record TransferFunds(Guid FromWalletId, Guid ToWalletId, decimal Amount) : ICommand;