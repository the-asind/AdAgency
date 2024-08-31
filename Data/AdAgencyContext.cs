using System.IO;
using AdAgency.Models;
using Microsoft.EntityFrameworkCore;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = File.ReadAllText("D:\\Projects\\Repos\\AdAgency\\Resources\\secret.txt");
        optionsBuilder.UseNpgsql(connectionString);
    }

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

        var now = DateTime.Now;
        var longTime = now.ToBinary();
        var bytes = BitConverter.GetBytes(longTime);

        var renter1 = new Renter
        {
            RenterId = 1, Name = "Renter1", Status = "Status1", LegalAddress = "Address1", DirectorName = "Director1",
            DirectorPhone = "Phone1", ContactPersonName = "Contact1", ContactPersonPhone = "Phone1", BankName = "Bank1",
            BankAccountNumber = "Account1", Inn = "Inn1", Email = "email@1.com"
        };
        var renter2 = new Renter
        {
            RenterId = 2, Name = "Renter2", Status = "Status2", LegalAddress = "Address2", DirectorName = "Director2",
            DirectorPhone = "Phone2", ContactPersonName = "Contact2", ContactPersonPhone = "Phone2", BankName = "Bank2",
            BankAccountNumber = "Account2", Inn = "Inn2"
        };

        var contract1 = new Contract
        {
            ContractId = 1, RenterId = renter1.RenterId, SigningDate = bytes, PaymentType = "Cash",
            ContractNumber = "123456", AgencyResponsible = "Agency1", AdditionalTerms = "None", Status = "active"
        };
        var contract2 = new Contract
        {
            ContractId = 2, RenterId = renter2.RenterId, SigningDate = bytes, PaymentType = "Credit",
            ContractNumber = "654321", AgencyResponsible = "Agency2", AdditionalTerms = "None", Status = "cancelled"
        };

        var work1 = new AdvertisementWork
            { WorkId = 1, ContractId = contract1.ContractId, WorkDescription = "Work 1", WorkCost = 1000 };
        var work2 = new AdvertisementWork
            { WorkId = 2, ContractId = contract2.ContractId, WorkDescription = "Work 2", WorkCost = 2000 };

        var log1 = new AuditLog
            { LogId = 1, UserId = 1, Action = "Action 1", TableName = "Table 1", RecordId = 1, Version = new byte[0] };
        var log2 = new AuditLog
            { LogId = 2, UserId = 2, Action = "Action 2", TableName = "Table 2", RecordId = 2, Version = new byte[0] };

        var billboard1 = new Billboard
        {
            BillboardId = 1, RegistrationNumber = "RN1", CityDistrict = "District 1", Address = "Address 1",
            LocationDescription = "Location 1", UsefulArea = 100, RentAmountPerWeek = 100
        };
        var billboard2 = new Billboard
        {
            BillboardId = 2, RegistrationNumber = "RN2", CityDistrict = "District 2", Address = "Address 2",
            LocationDescription = "Location 2", UsefulArea = 200, RentAmountPerWeek = 200
        };
        var user1 = new User
        {
            UserId = 1, Username = "admin",
            PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", Role = "admin",
            RenterId = renter1.RenterId
        };
        var user2 = new User
        {
            UserId = 2, Username = "worker",
            PasswordHash = "87eba76e7f3164534045ba922e7770fb58bbd14ad732bbf5ba6f11cc56989e6e", Role = "configurator",
            RenterId = renter2.RenterId
        };

        var contractBillboard1 = new ContractBillboard
        {
            Id = 1, ContractId = contract1.ContractId, BillboardId = billboard1.BillboardId,
            RentStartDate = new byte[0], RentEndDate = new byte[0], RentAmount = 1000,
            AdvertisementPhotoLink = "ftp://AdvertisementPhotoLink"
        };
        var contractBillboard2 = new ContractBillboard
        {
            Id = 2, ContractId = contract2.ContractId, BillboardId = billboard2.BillboardId,
            RentStartDate = new byte[0], RentEndDate = new byte[0], RentAmount = 2000,
            AdvertisementPhotoLink = "ftp://AdvertisementPhotoLink"
        };

        modelBuilder.Entity<Renter>().HasData(renter1, renter2);
        modelBuilder.Entity<User>().HasData(user1, user2);
        modelBuilder.Entity<AuditLog>().HasData(log1, log2);
        modelBuilder.Entity<Contract>().HasData(contract1, contract2);
        modelBuilder.Entity<AdvertisementWork>().HasData(work1, work2);
        modelBuilder.Entity<Billboard>().HasData(billboard1, billboard2);
        modelBuilder.Entity<ContractBillboard>().HasData(contractBillboard1, contractBillboard2);
    }
}