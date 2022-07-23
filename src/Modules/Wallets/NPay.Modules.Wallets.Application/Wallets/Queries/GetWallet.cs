using System;
using NPay.Modules.Wallets.Shared.DTO;
using NPay.Shared.Queries;

namespace NPay.Modules.Wallets.Application.Wallets.Queries;

public class GetWallet : IQuery<WalletDto>
{
    public Guid WalletId { get; set; }
}