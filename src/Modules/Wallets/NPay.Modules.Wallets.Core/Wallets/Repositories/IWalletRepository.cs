using System.Threading.Tasks;
using NPay.Modules.Wallets.Core.SharedKernel;
using NPay.Modules.Wallets.Core.Wallets.Aggregates;
using NPay.Modules.Wallets.Core.Wallets.ValueObjects;

namespace NPay.Modules.Wallets.Core.Wallets.Repositories;

internal interface IWalletRepository
{
    Task<Wallet> GetAsync(WalletId id);
    Task<Wallet> GetAsync(OwnerId ownerId, Currency currency);
    Task AddAsync(Wallet wallet);
    Task UpdateAsync(Wallet wallet);
}