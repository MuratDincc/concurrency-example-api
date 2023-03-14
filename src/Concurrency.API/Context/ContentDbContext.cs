using Concurrency.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Concurrency.API.Context;

public class ContentDbContext : DbContext
{
    public ContentDbContext(DbContextOptions options) : base(options) { }

    public DbSet<ContentConcurrency> ContentConcurrency { get; set; }
    public DbSet<ContentRowVersion> ContentRowVersion { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContentConcurrency>()
               .Property(a => a.Title)
               .IsConcurrencyToken();

        modelBuilder.Entity<ContentRowVersion>()
              .Property(a => a.RowVersion)
              .IsRowVersion();
    }
}