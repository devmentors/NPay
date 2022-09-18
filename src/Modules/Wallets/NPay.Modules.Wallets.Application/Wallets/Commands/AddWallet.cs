using System;
using NPay.Shared.Commands;

namespace NPay.Modules.Wallets.Application.Wallets.Commands;

public record AddWallet(Guid OwnerId, string Currency) : ICommand
{
    public Guid WalletId { get; init; } = Guid.NewGuid();
}