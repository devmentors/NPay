using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NPay.Modules.Wallets.Core.SharedKernel;
using NPay.Modules.Wallets.Core.Wallets.Aggregates;
using NPay.Modules.Wallets.Core.Wallets.Repositories;
using NPay.Modules.Wallets.Core.Wallets.ValueObjects;

namespace NPay.Modules.Wallets.Infrastructure.DAL.Repositories;

internal class WalletRepository : IWalletRepository
{
    private readonly WalletsDbContext _context;
    private readonly DbSet<Wallet> _wallets;
        
    public WalletRepository(WalletsDbContext context)
    {
        _context = context;
        _wallets = _context.Wallets;
    }
        
    public Task<Wallet> GetAsync(WalletId id)
        => _wallets
            .Include(x => x.Transfers)
            .SingleOrDefaultAsync(x => x.Id.Equals(id));

    public Task<Wallet> GetAsync(OwnerId ownerId, Currency currency)
        => _wallets
            .Include(x => x.Transfers)
            .SingleOrDefaultAsync(x => x.OwnerId.Equals(ownerId) && x.Currency.Value.Equals(currency.Value));

    public async Task AddAsync(Wallet wallet)
    {
        await _wallets.AddAsync(wallet);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Wallet wallet)
    {
        _wallets.Update(wallet);
        await _context.SaveChangesAsync();
    }
}