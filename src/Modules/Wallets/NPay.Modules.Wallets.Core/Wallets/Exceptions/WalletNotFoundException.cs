using System;
using NPay.Shared.Exceptions;

namespace NPay.Modules.Wallets.Core.Wallets.Exceptions;

internal sealed class WalletNotFoundException : NPayException
{
    public Guid OwnerId { get; }
    public string Currency { get; }
    public Guid WalletId { get; }

    public WalletNotFoundException(Guid walletId) : base($"Wallet with ID: '{walletId}' was not found.")
    {
        WalletId = walletId;
    }
}