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

    // Property to hold the current user's ID
    public int? CurrentUserId { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "secret.txt"));
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

        var now = DateTime.UtcNow;

        // Define Renters
        var renter1 = new Renter
        {
            RenterId = 1,
            Name = "ООО \"Рекламное Агентство Альфа\"",
            Status = "Действующий",
            LegalAddress = "г. Москва, ул. Пушкина, д. 10",
            DirectorName = "Иванов Сергей Павлович",
            DirectorPhone = "+79990001122",
            ContactPersonName = "Петрова Мария Ивановна",
            ContactPersonPhone = "+79990002233",
            BankName = "Сбербанк",
            BankAccountNumber = "40702810900000000001",
            Inn = "7723456789",
            Email = "info@alpha.ru"
        };
        var renter2 = new Renter
        {
            RenterId = 2,
            Name = "ЗАО \"Медиа Бета\"",
            Status = "Действующий",
            LegalAddress = "г. Санкт-Петербург, пр. Невский, д. 20",
            DirectorName = "Сидоров Алексей Викторович",
            DirectorPhone = "+79990003344",
            ContactPersonName = "Кузнецов Дмитрий Сергеевич",
            ContactPersonPhone = "+79990004455",
            BankName = "Альфа-Банк",
            BankAccountNumber = "40702810900000000002",
            Inn = "7823456789",
            Email = "contact@beta.ru"
        };

        // Define Billboards
        var billboard1 = new Billboard
        {
            BillboardId = 1,
            RegistrationNumber = "AA-1001",
            CityDistrict = "Центральный",
            Address = "г. Москва, Красная площадь, д. 1",
            LocationDescription = "Рядом с Кремлем",
            UsefulArea = 30.0m,
            RentAmountPerWeek = 10000.0m
        };
        var billboard2 = new Billboard
        {
            BillboardId = 2,
            RegistrationNumber = "AA-1002",
            CityDistrict = "Тверской",
            Address = "г. Москва, Тверская ул., д. 15",
            LocationDescription = "Около метро Маяковская",
            UsefulArea = 25.0m,
            RentAmountPerWeek = 8000.0m
        };
        var billboard3 = new Billboard
        {
            BillboardId = 3,
            RegistrationNumber = "AA-1003",
            CityDistrict = "Адмиралтейский",
            Address = "г. Санкт-Петербург, Адмиралтейский пр., д. 3",
            LocationDescription = "Напротив Эрмитажа",
            UsefulArea = 28.0m,
            RentAmountPerWeek = 9000.0m
        };
        var billboard4 = new Billboard
        {
            BillboardId = 4,
            RegistrationNumber = "AA-1004",
            CityDistrict = "Василеостровский",
            Address = "г. Санкт-Петербург, 8-я линия В.О., д. 42",
            LocationDescription = "У входа в парк",
            UsefulArea = 22.0m,
            RentAmountPerWeek = 7000.0m
        };
        var billboard5 = new Billboard
        {
            BillboardId = 5,
            RegistrationNumber = "AA-1005",
            CityDistrict = "Приморский",
            Address = "г. Санкт-Петербург, пр. Испытателей, д. 5",
            LocationDescription = "Рядом с ТРЦ",
            UsefulArea = 20.0m,
            RentAmountPerWeek = 6500.0m
        };
        var billboard6 = new Billboard
        {
            BillboardId = 6,
            RegistrationNumber = "AA-1006",
            CityDistrict = "Замоскворечье",
            Address = "г. Москва, ул. Большая Ордынка, д. 17",
            LocationDescription = "Недалеко от Третьяковской галереи",
            UsefulArea = 24.0m,
            RentAmountPerWeek = 7500.0m
        };

        // Define Contracts
        var contract1 = new Contract
        {
            ContractId = 1,
            ContractNumber = "AA-1001-00001",
            SigningDate = new DateTime(2024, 11, 26, 0, 0, 0, DateTimeKind.Utc), // Updated to UTC
            AgencyResponsible = "Иванова Е.А.",
            TotalAmount = 30000.0m,
            PaymentType = "Наличные",
            AdditionalTerms = "Нет",
            Status = "Активен",
            RenterId = renter1.RenterId
        };
        var contract2 = new Contract
        {
            ContractId = 2,
            ContractNumber = "AA-1001-00002",
            SigningDate = new DateTime(2024, 11, 26, 0, 0, 0, DateTimeKind.Utc), // Updated to UTC
            AgencyResponsible = "Иванова Е.А.",
            TotalAmount = 25000.0m,
            PaymentType = "Банковский перевод",
            AdditionalTerms = "Нет",
            Status = "Активен",
            RenterId = renter1.RenterId
        };
        var contract3 = new Contract
        {
            ContractId = 3,
            ContractNumber = "AA-1002-00003",
            SigningDate = new DateTime(2024, 11, 26, 0, 0, 0, DateTimeKind.Utc), // Updated to UTC
            AgencyResponsible = "Сидорова А.В.",
            TotalAmount = 28000.0m,
            PaymentType = "Постоплата",
            AdditionalTerms = "Нет",
            Status = "Активен",
            RenterId = renter2.RenterId
        };
        var contract4 = new Contract
        {
            ContractId = 4,
            ContractNumber = "AA-1002-00004",
            SigningDate = new DateTime(2024, 11, 26, 0, 0, 0, DateTimeKind.Utc), // Updated to UTC
            AgencyResponsible = "Сидорова А.В.",
            TotalAmount = 35000.0m,
            PaymentType = "Наличные",
            AdditionalTerms = "Нет",
            Status = "Активен",
            RenterId = renter2.RenterId
        };

        // Define ContractBillboards
        var contractBillboard1 = new ContractBillboard
        {
            Id = 1,
            ContractId = contract1.ContractId,
            BillboardId = billboard1.BillboardId,
            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, DateTimeKind.Utc), // Updated to UTC
            RentEndDate = new DateTime(2025, 1, 26, 0, 0, 0, DateTimeKind.Utc),   // Updated to UTC
            RentAmount = 30000.0m,
            AdvertisementPhotoLink = "https://example.com/ad1.jpg"
        };
        var contractBillboard2 = new ContractBillboard
        {
            Id = 2,
            ContractId = contract1.ContractId,
            BillboardId = billboard2.BillboardId,
            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, DateTimeKind.Utc), // Updated to UTC
            RentEndDate = new DateTime(2025, 1, 26, 0, 0, 0, DateTimeKind.Utc),   // Updated to UTC
            RentAmount = 30000.0m,
            AdvertisementPhotoLink = "https://example.com/ad2.jpg"
        };
        var contractBillboard3 = new ContractBillboard
        {
            Id = 3,
            ContractId = contract2.ContractId,
            BillboardId = billboard6.BillboardId,
            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, DateTimeKind.Utc), // Updated to UTC
            RentEndDate = new DateTime(2025, 2, 26, 0, 0, 0, DateTimeKind.Utc),   // Updated to UTC
            RentAmount = 25000.0m,
            AdvertisementPhotoLink = "https://example.com/ad3.jpg"
        };
        var contractBillboard4 = new ContractBillboard
        {
            Id = 4,
            ContractId = contract3.ContractId,
            BillboardId = billboard3.BillboardId,
            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, DateTimeKind.Utc), // Updated to UTC
            RentEndDate = new DateTime(2025, 3, 26, 0, 0, 0, DateTimeKind.Utc),   // Updated to UTC
            RentAmount = 28000.0m,
            AdvertisementPhotoLink = "https://example.com/ad4.jpg"
        };
        var contractBillboard5 = new ContractBillboard
        {
            Id = 5,
            ContractId = contract4.ContractId,
            BillboardId = billboard4.BillboardId,
            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, DateTimeKind.Utc), // Updated to UTC
            RentEndDate = new DateTime(2025, 4, 26, 0, 0, 0, DateTimeKind.Utc),   // Updated to UTC
            RentAmount = 35000.0m,
            AdvertisementPhotoLink = "https://example.com/ad5.jpg"
        };
        var contractBillboard6 = new ContractBillboard
        {
            Id = 6,
            ContractId = contract4.ContractId,
            BillboardId = billboard5.BillboardId,
            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, DateTimeKind.Utc), // Updated to UTC
            RentEndDate = new DateTime(2025, 4, 26, 0, 0, 0, DateTimeKind.Utc),   // Updated to UTC
            RentAmount = 35000.0m,
            AdvertisementPhotoLink = "https://example.com/ad6.jpg"
        };

        // Define AdvertisementWorks
        var work1 = new AdvertisementWork
        {
            WorkId = 1,
            ContractId = contract1.ContractId,
            WorkDescription = "Печать баннера",
            WorkCost = 5000.0m
        };
        var work2 = new AdvertisementWork
        {
            WorkId = 2,
            ContractId = contract2.ContractId,
            WorkDescription = "Монтаж билборда",
            WorkCost = 7000.0m
        };
        var work3 = new AdvertisementWork
        {
            WorkId = 3,
            ContractId = contract3.ContractId,
            WorkDescription = "Разработка макета",
            WorkCost = 6000.0m
        };
        var work4 = new AdvertisementWork
        {
            WorkId = 4,
            ContractId = contract4.ContractId,
            WorkDescription = "Дизайн и изготовление",
            WorkCost = 8000.0m
        };

        // Define Users
        var user1 = new User
        {
            UserId = 1,
            Username = "admin",
            PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
            Role = "admin",
            RenterId = renter1.RenterId
        };
        var user2 = new User
        {
            UserId = 2,
            Username = "worker",
            PasswordHash = "87eba76e7f3164534045ba922e7770fb58bbd14ad732bbf5ba6f11cc56989e6e",
            Role = "configurator",
            RenterId = renter2.RenterId
        };

        // Apply HasData with object references
        modelBuilder.Entity<Renter>().HasData(renter1, renter2);
        modelBuilder.Entity<Billboard>().HasData(billboard1, billboard2, billboard3, billboard4, billboard5, billboard6);
        modelBuilder.Entity<Contract>().HasData(contract1, contract2, contract3, contract4);
        modelBuilder.Entity<ContractBillboard>().HasData(contractBillboard1, contractBillboard2, contractBillboard3, contractBillboard4, contractBillboard5, contractBillboard6);
        modelBuilder.Entity<AdvertisementWork>().HasData(work1, work2, work3, work4);
        modelBuilder.Entity<User>().HasData(user1, user2);
    }

    public override int SaveChanges()
    {
        AddAuditLogs();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddAuditLogs();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AddAuditLogs()
    {
        if (CurrentUserId == null) return;

        var auditEntries = (from entry in ChangeTracker.Entries()
                            where entry.Entity is not AuditLog && entry.State != EntityState.Detached && entry.State != EntityState.Unchanged
                            select new AuditLog
                            {
                                UserId = CurrentUserId.Value,
                                Action = entry.State.ToString(),
                                TableName = entry.Entity.GetType().Name,
                                // Use the primary key directly instead of accessing properties
                                RecordId = entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue != null ? 
                                           Convert.ToInt32(entry.Properties.First(p => p.Metadata.IsPrimaryKey()).CurrentValue) : 
                                           (int?)null,
                                Timestamp = DateTime.UtcNow
                            }).ToList();

        if (auditEntries.Count != 0) AuditLogs.AddRange(auditEntries);
    }
}