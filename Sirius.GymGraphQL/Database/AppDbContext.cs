using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Sqlite;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Database;

public sealed class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Gym> Gyms { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Purchase>()
            .HasOne(_ => _.Customer)
            .WithMany(_ => _.Purchases)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Gym>()
            .HasMany(_ => _.Trainings)
            .WithOne(_ => _.Gym)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Customer>()
            .HasMany(_ => _.Purchases)
            .WithOne(_ => _.Customer)
            .OnDelete(DeleteBehavior.Cascade);
    }
}