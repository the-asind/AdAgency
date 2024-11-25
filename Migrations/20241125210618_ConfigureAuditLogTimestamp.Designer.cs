﻿// <auto-generated />
using System;
using AdAgency.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdAgency.Migrations
{
    [DbContext(typeof(AdAgencyContext))]
    [Migration("20241125210618_ConfigureAuditLogTimestamp")]
    partial class ConfigureAuditLogTimestamp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AdAgency.Models.AdvertisementWork", b =>
                {
                    b.Property<int>("WorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WorkId"));

                    b.Property<int>("ContractId")
                        .HasColumnType("integer");

                    b.Property<decimal>("WorkCost")
                        .HasColumnType("numeric");

                    b.Property<string>("WorkDescription")
                        .HasColumnType("text");

                    b.HasKey("WorkId");

                    b.HasIndex("ContractId");

                    b.ToTable("AdvertisementWorks");

                    b.HasData(
                        new
                        {
                            WorkId = 1,
                            ContractId = 1,
                            WorkCost = 5000.0m,
                            WorkDescription = "Печать баннера"
                        },
                        new
                        {
                            WorkId = 2,
                            ContractId = 2,
                            WorkCost = 7000.0m,
                            WorkDescription = "Монтаж билборда"
                        },
                        new
                        {
                            WorkId = 3,
                            ContractId = 3,
                            WorkCost = 6000.0m,
                            WorkDescription = "Разработка макета"
                        },
                        new
                        {
                            WorkId = 4,
                            ContractId = 4,
                            WorkCost = 8000.0m,
                            WorkDescription = "Дизайн и изготовление"
                        });
                });

            modelBuilder.Entity("AdAgency.Models.AuditLog", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LogId"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RecordId")
                        .HasColumnType("integer");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("LogId");

                    b.HasIndex("UserId");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("AdAgency.Models.Billboard", b =>
                {
                    b.Property<int>("BillboardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BillboardId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CityDistrict")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LocationDescription")
                        .HasColumnType("text");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("RentAmountPerWeek")
                        .HasColumnType("numeric");

                    b.Property<decimal>("UsefulArea")
                        .HasColumnType("numeric");

                    b.HasKey("BillboardId");

                    b.ToTable("Billboards");

                    b.HasData(
                        new
                        {
                            BillboardId = 1,
                            Address = "г. Москва, Красная площадь, д. 1",
                            CityDistrict = "Центральный",
                            LocationDescription = "Рядом с Кремлем",
                            RegistrationNumber = "AA-1001",
                            RentAmountPerWeek = 10000.0m,
                            UsefulArea = 30.0m
                        },
                        new
                        {
                            BillboardId = 2,
                            Address = "г. Москва, Тверская ул., д. 15",
                            CityDistrict = "Тверской",
                            LocationDescription = "Около метро Маяковская",
                            RegistrationNumber = "AA-1002",
                            RentAmountPerWeek = 8000.0m,
                            UsefulArea = 25.0m
                        },
                        new
                        {
                            BillboardId = 3,
                            Address = "г. Санкт-Петербург, Адмиралтейский пр., д. 3",
                            CityDistrict = "Адмиралтейский",
                            LocationDescription = "Напротив Эрмитажа",
                            RegistrationNumber = "AA-1003",
                            RentAmountPerWeek = 9000.0m,
                            UsefulArea = 28.0m
                        },
                        new
                        {
                            BillboardId = 4,
                            Address = "г. Санкт-Петербург, 8-я линия В.О., д. 42",
                            CityDistrict = "Василеостровский",
                            LocationDescription = "У входа в парк",
                            RegistrationNumber = "AA-1004",
                            RentAmountPerWeek = 7000.0m,
                            UsefulArea = 22.0m
                        },
                        new
                        {
                            BillboardId = 5,
                            Address = "г. Санкт-Петербург, пр. Испытателей, д. 5",
                            CityDistrict = "Приморский",
                            LocationDescription = "Рядом с ТРЦ",
                            RegistrationNumber = "AA-1005",
                            RentAmountPerWeek = 6500.0m,
                            UsefulArea = 20.0m
                        },
                        new
                        {
                            BillboardId = 6,
                            Address = "г. Москва, ул. Большая Ордынка, д. 17",
                            CityDistrict = "Замоскворечье",
                            LocationDescription = "Недалеко от Третьяковской галереи",
                            RegistrationNumber = "AA-1006",
                            RentAmountPerWeek = 7500.0m,
                            UsefulArea = 24.0m
                        });
                });

            modelBuilder.Entity("AdAgency.Models.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ContractId"));

                    b.Property<string>("AdditionalTerms")
                        .HasColumnType("text");

                    b.Property<string>("AgencyResponsible")
                        .HasColumnType("text");

                    b.Property<string>("ContractNumber")
                        .HasColumnType("text");

                    b.Property<string>("PaymentType")
                        .HasColumnType("text");

                    b.Property<int>("RenterId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SigningDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.HasKey("ContractId");

                    b.HasIndex("RenterId");

                    b.ToTable("Contracts");

                    b.HasData(
                        new
                        {
                            ContractId = 1,
                            AdditionalTerms = "Нет",
                            AgencyResponsible = "Иванова Е.А.",
                            ContractNumber = "AA-1001-00001",
                            PaymentType = "Наличные",
                            RenterId = 1,
                            SigningDate = new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            Status = "Активен",
                            TotalAmount = 30000.0m
                        },
                        new
                        {
                            ContractId = 2,
                            AdditionalTerms = "Нет",
                            AgencyResponsible = "Иванова Е.А.",
                            ContractNumber = "AA-1001-00002",
                            PaymentType = "Банковский перевод",
                            RenterId = 1,
                            SigningDate = new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            Status = "Активен",
                            TotalAmount = 25000.0m
                        },
                        new
                        {
                            ContractId = 3,
                            AdditionalTerms = "Нет",
                            AgencyResponsible = "Сидорова А.В.",
                            ContractNumber = "AA-1002-00003",
                            PaymentType = "Постоплата",
                            RenterId = 2,
                            SigningDate = new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            Status = "Активен",
                            TotalAmount = 28000.0m
                        },
                        new
                        {
                            ContractId = 4,
                            AdditionalTerms = "Нет",
                            AgencyResponsible = "Сидорова А.В.",
                            ContractNumber = "AA-1002-00004",
                            PaymentType = "Наличные",
                            RenterId = 2,
                            SigningDate = new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            Status = "Активен",
                            TotalAmount = 35000.0m
                        });
                });

            modelBuilder.Entity("AdAgency.Models.ContractBillboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AdvertisementPhotoLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BillboardId")
                        .HasColumnType("integer");

                    b.Property<int>("ContractId")
                        .HasColumnType("integer");

                    b.Property<decimal>("RentAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("RentEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("RentStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BillboardId");

                    b.HasIndex("ContractId");

                    b.ToTable("ContractBillboards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdvertisementPhotoLink = "https://example.com/ad1.jpg",
                            BillboardId = 1,
                            ContractId = 1,
                            RentAmount = 30000.0m,
                            RentEndDate = new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            AdvertisementPhotoLink = "https://example.com/ad2.jpg",
                            BillboardId = 2,
                            ContractId = 1,
                            RentAmount = 30000.0m,
                            RentEndDate = new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            AdvertisementPhotoLink = "https://example.com/ad3.jpg",
                            BillboardId = 6,
                            ContractId = 2,
                            RentAmount = 25000.0m,
                            RentEndDate = new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 4,
                            AdvertisementPhotoLink = "https://example.com/ad4.jpg",
                            BillboardId = 3,
                            ContractId = 3,
                            RentAmount = 28000.0m,
                            RentEndDate = new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 5,
                            AdvertisementPhotoLink = "https://example.com/ad5.jpg",
                            BillboardId = 4,
                            ContractId = 4,
                            RentAmount = 35000.0m,
                            RentEndDate = new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 6,
                            AdvertisementPhotoLink = "https://example.com/ad6.jpg",
                            BillboardId = 5,
                            ContractId = 4,
                            RentAmount = 35000.0m,
                            RentEndDate = new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            RentStartDate = new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("AdAgency.Models.Renter", b =>
                {
                    b.Property<int>("RenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RenterId"));

                    b.Property<string>("BankAccountNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactPersonName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactPersonPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DirectorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DirectorPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LegalAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RenterId");

                    b.ToTable("Renters");

                    b.HasData(
                        new
                        {
                            RenterId = 1,
                            BankAccountNumber = "40702810900000000001",
                            BankName = "Сбербанк",
                            ContactPersonName = "Петрова Мария Ивановна",
                            ContactPersonPhone = "+79990002233",
                            DirectorName = "Иванов Сергей Павлович",
                            DirectorPhone = "+79990001122",
                            Email = "info@alpha.ru",
                            Inn = "7723456789",
                            LegalAddress = "г. Москва, ул. Пушкина, д. 10",
                            Name = "ООО \"Рекламное Агентство Альфа\"",
                            Status = "Действующий"
                        },
                        new
                        {
                            RenterId = 2,
                            BankAccountNumber = "40702810900000000002",
                            BankName = "Альфа-Банк",
                            ContactPersonName = "Кузнецов Дмитрий Сергеевич",
                            ContactPersonPhone = "+79990004455",
                            DirectorName = "Сидоров Алексей Викторович",
                            DirectorPhone = "+79990003344",
                            Email = "contact@beta.ru",
                            Inn = "7823456789",
                            LegalAddress = "г. Санкт-Петербург, пр. Невский, д. 20",
                            Name = "ЗАО \"Медиа Бета\"",
                            Status = "Действующий"
                        });
                });

            modelBuilder.Entity("AdAgency.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<int?>("RenterId")
                        .HasColumnType("integer");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("RenterId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                            RenterId = 1,
                            Role = "admin",
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            PasswordHash = "87eba76e7f3164534045ba922e7770fb58bbd14ad732bbf5ba6f11cc56989e6e",
                            RenterId = 2,
                            Role = "configurator",
                            Username = "worker"
                        });
                });

            modelBuilder.Entity("AdAgency.Models.AdvertisementWork", b =>
                {
                    b.HasOne("AdAgency.Models.Contract", "Contract")
                        .WithMany("AdvertisementWorks")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("AdAgency.Models.AuditLog", b =>
                {
                    b.HasOne("AdAgency.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AdAgency.Models.Contract", b =>
                {
                    b.HasOne("AdAgency.Models.Renter", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("AdAgency.Models.ContractBillboard", b =>
                {
                    b.HasOne("AdAgency.Models.Billboard", "Billboard")
                        .WithMany()
                        .HasForeignKey("BillboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdAgency.Models.Contract", "Contract")
                        .WithMany("ContractBillboards")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billboard");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("AdAgency.Models.User", b =>
                {
                    b.HasOne("AdAgency.Models.Renter", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId");

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("AdAgency.Models.Contract", b =>
                {
                    b.Navigation("AdvertisementWorks");

                    b.Navigation("ContractBillboards");
                });
#pragma warning restore 612, 618
        }
    }
}
