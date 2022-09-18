using System;
using NPay.Modules.Wallets.Core.Wallets.ValueObjects;

namespace NPay.Modules.Wallets.Core.Wallets.Entities;

internal class Transfer
{
    public TransferId Id { get; private set; }
    public TransferId ReferenceId { get; private set; }
    public WalletId WalletId { get; private set; }
    public Currency Currency { get; private set; }
    public Amount Amount { get; private set; }
    public TransferDirection Direction { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Transfer()
    {
    }

    private Transfer(TransferId id, WalletId walletId, Currency currency, Amount amount,
        TransferDirection direction, DateTime createdAt, TransferId referenceId = null)
    {
        Id = id;
        WalletId = walletId;
        Currency = currency;
        Amount = amount;
        Direction = direction;
        CreatedAt = createdAt;
        ReferenceId = referenceId;
    }

    public static Transfer Incoming(TransferId id, WalletId walletId, Currency currency, Amount amount,
        DateTime createdAt, TransferId referenceId = null)
        => new(id, walletId, currency, amount, TransferDirection.In, createdAt, referenceId);

    public static Transfer Outgoing(TransferId id, WalletId walletId, Currency currency, Amount amount,
        DateTime createdAt, TransferId referenceId = null)
        => new(id, walletId, currency, amount, TransferDirection.Out, createdAt, referenceId);

    internal enum TransferDirection
    {
        In,
        Out
    }
}