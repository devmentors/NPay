using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NPay.Modules.Wallets.Application.Wallets.Storage;
using NPay.Modules.Wallets.Core.Wallets.Aggregates;
using NPay.Modules.Wallets.Infrastructure.DAL;

namespace NPay.Modules.Wallets.Infrastructure.Storage;

internal sealed class WalletStorage : IWalletStorage
{
    private readonly DbSet<Wallet> _wallets;

    public WalletStorage(WalletsDbContext dbContext)
    {
        _wallets = dbContext.Wallets;
    }

    public Task<Wallet> FindAsync(Expression<Func<Wallet, bool>> expression)
        => _wallets
            .AsNoTracking()
            .AsQueryable()
            .Where(expression)
            .Include(x => x.Transfers)
            .SingleOrDefaultAsync();
}