using System;
using System.Threading.Tasks;
using NPay.Modules.Wallets.Application.Wallets.Queries;
using NPay.Modules.Wallets.Shared;
using NPay.Modules.Wallets.Shared.DTO;
using NPay.Shared.Dispatchers;

namespace NPay.Modules.Wallets.Application.Services;

internal sealed class WalletsModuleApi : IWalletsModuleApi
{
    private readonly IDispatcher _dispatcher;

    public WalletsModuleApi(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public Task<WalletDto> GetWalletAsync(Guid walletId)
        => _dispatcher.QueryAsync(new GetWallet { WalletId = walletId });
}