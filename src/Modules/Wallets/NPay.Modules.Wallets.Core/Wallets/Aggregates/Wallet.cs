using System;
using System.Collections.Generic;
using System.Linq;
using NPay.Modules.Wallets.Core.SharedKernel;
using NPay.Modules.Wallets.Core.Wallets.Entities;
using NPay.Modules.Wallets.Core.Wallets.Exceptions;
using NPay.Modules.Wallets.Core.Wallets.ValueObjects;

namespace NPay.Modules.Wallets.Core.Wallets.Aggregates;

internal class Wallet : AggregateRoot<WalletId>
{
    private HashSet<Transfer> _transfers = new();

    public OwnerId OwnerId { get; private set; }
    public Currency Currency { get; private set; }

    public IEnumerable<Transfer> Transfers
    {
        get => _transfers;
        set => _transfers = new HashSet<Transfer>(value);
    }

    public DateTime CreatedAt { get; private set; }

    private Wallet()
    {
    }

    private Wallet(WalletId id, OwnerId ownerId, Currency currency, DateTime createdAt)
    {
        Id = id;
        OwnerId = ownerId;
        Currency = currency;
        CreatedAt = createdAt;
    }

    public static Wallet Create(OwnerId ownerId, Currency currency, DateTime createdAt)
        => Create(new WalletId(), ownerId, currency, createdAt);

    public static Wallet Create(WalletId id, OwnerId ownerId, Currency currency, DateTime createdAt)
        => new Wallet(id, ownerId, currency, createdAt);

    public IReadOnlyCollection<Transfer> TransferFunds(Wallet receiver, Amount amount, DateTime createdAt)
    {
        var outTransferId = new TransferId();
        var inTransferId = new TransferId();

        var outTransfer = DeductFunds(outTransferId, amount, createdAt, inTransferId);
        var inTransfer = receiver.AddFunds(inTransferId, amount, createdAt, outTransferId);

        return new[] { outTransfer, inTransfer };
    }
        
    public Transfer AddFunds(TransferId transferId, Amount amount, DateTime createdAt,
        TransferId referenceId = null)
    {
        if (amount <= 0)
        {
            throw new InvalidTransferAmountException(amount);
        }

        var transfer = Transfer.Incoming(transferId, Id, Currency, amount, createdAt, referenceId);
        _transfers.Add(transfer);
        IncrementVersion();

        return transfer;
    }

    public Transfer DeductFunds(TransferId transferId, Amount amount, DateTime createdAt,
        TransferId referenceId = null)
    {
        if (amount <= 0)
        {
            throw new InvalidTransferAmountException(amount);
        }

        if (CurrentAmount() < amount)
        {
            throw new InsufficientWalletFundsException(Id);
        }

        var transfer = Transfer.Outgoing(transferId, Id, Currency, amount, createdAt, referenceId);
        _transfers.Add(transfer);
        IncrementVersion();

        return transfer;
    }

    public Amount CurrentAmount() => SumIncomingAmount() - SumOutgoingAmount();
        
    private Amount SumIncomingAmount()
        => _transfers.Where(x => x.Direction == Transfer.TransferDirection.In).Sum(x => x.Amount);
        
    private Amount SumOutgoingAmount()
        => _transfers.Where(x => x.Direction == Transfer.TransferDirection.Out).Sum(x => x.Amount);
}