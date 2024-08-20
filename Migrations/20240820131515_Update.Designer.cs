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
    [Migration("20240820131515_Update")]
    partial class Update
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

                    b.Property<DateTime>("ActionTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("RecordId")
                        .HasColumnType("integer");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

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

                    b.Property<decimal>("UsefulArea")
                        .HasColumnType("numeric");

                    b.HasKey("BillboardId");

                    b.ToTable("Billboards");
                });

            modelBuilder.Entity("AdAgency.Models.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ContractId"));

                    b.Property<string>("AdditionalTerms")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AgencyResponsible")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContractNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RenterId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SigningDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.HasKey("ContractId");

                    b.HasIndex("RenterId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("AdAgency.Models.ContractBillboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("AdvertisementPhoto")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("BillboardId")
                        .HasColumnType("integer");

                    b.Property<int>("ContractId")
                        .HasColumnType("integer");

                    b.Property<decimal>("RentAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("RentEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("RentStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BillboardId");

                    b.HasIndex("ContractId");

                    b.ToTable("ContractBillboards");
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
                });

            modelBuilder.Entity("AdAgency.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RenterId")
                        .HasColumnType("integer");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("RenterId");

                    b.ToTable("Users");
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
