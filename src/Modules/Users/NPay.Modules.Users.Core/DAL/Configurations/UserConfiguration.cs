using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPay.Modules.Users.Core.Entities;

namespace NPay.Modules.Users.Core.DAL.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Address).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Identity).IsRequired().HasMaxLength(40);
        builder.Property(x => x.Nationality).IsRequired().HasMaxLength(2);
    }
}