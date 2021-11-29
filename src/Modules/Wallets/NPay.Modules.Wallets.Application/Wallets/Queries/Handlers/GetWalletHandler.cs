﻿using System.Threading;
using System.Threading.Tasks;
using NPay.Modules.Wallets.Application.Wallets.Storage;
using NPay.Shared.Queries;
using WalletDto = NPay.Modules.Wallets.Application.DTO.WalletDto;

namespace NPay.Modules.Wallets.Application.Wallets.Queries.Handlers
{
    internal sealed class GetWalletHandler : IQueryHandler<GetWallet, WalletDto>
    {
        private readonly IWalletStorage _storage;

        public GetWalletHandler(IWalletStorage storage)
        {
            _storage = storage;
        }

        public async Task<WalletDto> HandleAsync(GetWallet query, CancellationToken cancellationToken = default)
        {
            var wallet = await _storage.FindAsync(x => x.Id == query.WalletId);

            return wallet?.AsDto();
        }
    }
}