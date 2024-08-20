using Microsoft.EntityFrameworkCore;
using AdAgency.Models;

namespace AdAgency.Data;

public class AdAgencyContext : DbContext
{
    public DbSet<Billboard> Billboards { get; set; }
    public DbSet<Renter> Renters { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<ContractBillboard> ContractBillboards { get; set; }
    public DbSet<AdvertisementWork> AdvertisementWorks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseNpgsql("Host=localhost;Database=AdAgencyDB;Username=postgres;Password=secret");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContractBillboard>()
            .HasOne(cb => cb.Contract)
            .WithMany(c => c.ContractBillboards)
            .HasForeignKey(cb => cb.ContractId);

        modelBuilder.Entity<ContractBillboard>()
            .HasOne(cb => cb.Billboard)
            .WithMany()
            .HasForeignKey(cb => cb.BillboardId);

        modelBuilder.Entity<AdvertisementWork>()
            .HasOne(aw => aw.Contract)
            .WithMany(c => c.AdvertisementWorks)
            .HasForeignKey(aw => aw.ContractId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Renter)
            .WithMany()
            .HasForeignKey(u => u.RenterId);
    }
}