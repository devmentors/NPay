using System.Linq;
using NPay.Modules.Wallets.Core.Wallets.Aggregates;
using NPay.Modules.Wallets.Core.Wallets.Entities;
using NPay.Modules.Wallets.Shared.DTO;

namespace NPay.Modules.Wallets.Application.Wallets.Queries.Handlers;

internal static class Extensions
{
    public static WalletDto AsDto(this Wallet wallet)
        => new()
        {
            WalletId = wallet.Id,
            OwnerId = wallet.OwnerId,
            Currency = wallet.Currency,
            CreatedAt = wallet.CreatedAt,
            Amount = wallet.CurrentAmount(),
            Transfers = wallet.Transfers.Select(x => x.AsDto())
                .OrderByDescending(x => x.CreatedAt)
                .ToList()
        };
        
    public static TransferDto AsDto(this Transfer transfer)
        => new()
        {
            TransferId = transfer.Id,
            ReferenceId = transfer.ReferenceId,
            WalletId = transfer.WalletId,
            Amount = transfer.Amount,
            Currency = transfer.Currency,
            Direction = transfer.Direction.ToString().ToLowerInvariant(),
            CreatedAt = transfer.CreatedAt
        };
}