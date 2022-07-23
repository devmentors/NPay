using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPay.Modules.Wallets.Core.Wallets.Entities;
using NPay.Modules.Wallets.Core.Wallets.ValueObjects;

namespace NPay.Modules.Wallets.Infrastructure.DAL.Configurations;

internal class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.ToTable("Transfers");
            
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new TransferId(x));

        builder.Property(x => x.ReferenceId)
            .HasConversion(x => x.Value, x => new TransferId(x));
            
        builder.Property(x => x.WalletId)
            .IsRequired()
            .HasConversion(x => x.Value, x => new WalletId(x));
            
        builder.Property(x => x.Currency)
            .IsRequired()
            .HasConversion(x => x.Value, x => new Currency(x));
            
        builder.Property(x => x.Amount)
            .IsRequired()
            .HasConversion(x => x.Value, x => new Amount(x));
    }
}