using Microsoft.EntityFrameworkCore;
using NPay.Modules.Wallets.Core.Owners.Aggregates;
using NPay.Modules.Wallets.Core.Wallets.Aggregates;
using NPay.Modules.Wallets.Core.Wallets.Entities;

namespace NPay.Modules.Wallets.Infrastructure.DAL;

internal class WalletsDbContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Transfer> Transfers { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
        
    public WalletsDbContext(DbContextOptions<WalletsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("wallets");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}