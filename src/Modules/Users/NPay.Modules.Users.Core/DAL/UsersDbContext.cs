using Microsoft.EntityFrameworkCore;
using NPay.Modules.Users.Core.Entities;

namespace NPay.Modules.Users.Core.DAL;

internal sealed class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
        
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}