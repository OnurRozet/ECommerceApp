using IdentityService.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Context;

public sealed class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker.Entries();
        foreach (var entry in entries)
        {
            if(entry.State == EntityState.Added) entry.Property("CreatedDate").CurrentValue = DateTime.Now;
            if(entry.State == EntityState.Modified) entry.Property("ModifiedDate").CurrentValue = DateTime.Now;
            if(entry.State == EntityState.Deleted) entry.Property("DeletedDate").CurrentValue = DateTime.Now;
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<User> Users { get; set; }
};