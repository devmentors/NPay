using System;
using NPay.Shared.Queries;
using WalletDto = NPay.Modules.Wallets.Application.DTO.WalletDto;

namespace NPay.Modules.Wallets.Application.Wallets.Queries
{
    public class GetWallet : IQuery<WalletDto>
    {
        public Guid WalletId { get; set; }
    }
}