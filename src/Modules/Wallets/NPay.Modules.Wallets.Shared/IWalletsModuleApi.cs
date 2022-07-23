using System;
using System.Threading.Tasks;
using NPay.Modules.Wallets.Shared.DTO;

namespace NPay.Modules.Wallets.Shared;

public interface IWalletsModuleApi
{
    Task<WalletDto> GetWalletAsync(Guid walletId);
}