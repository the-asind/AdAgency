using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdAgency.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Billboards",
                columns: table => new
                {
                    BillboardId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    CityDistrict = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    LocationDescription = table.Column<string>(type: "text", nullable: true),
                    UsefulArea = table.Column<decimal>(type: "numeric", nullable: false),
                    RentAmountPerWeek = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billboards", x => x.BillboardId);
                });

            migrationBuilder.CreateTable(
                name: "Renters",
                columns: table => new
                {
                    RenterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    LegalAddress = table.Column<string>(type: "text", nullable: false),
                    DirectorName = table.Column<string>(type: "text", nullable: false),
                    DirectorPhone = table.Column<string>(type: "text", nullable: false),
                    ContactPersonName = table.Column<string>(type: "text", nullable: false),
                    ContactPersonPhone = table.Column<string>(type: "text", nullable: false),
                    BankName = table.Column<string>(type: "text", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "text", nullable: false),
                    Inn = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renters", x => x.RenterId);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractNumber = table.Column<string>(type: "text", nullable: true),
                    SigningDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AgencyResponsible = table.Column<string>(type: "text", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: true),
                    AdditionalTerms = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    RenterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contracts_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "RenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: false),
                    RenterId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "RenterId");
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementWorks",
                columns: table => new
                {
                    WorkId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    WorkDescription = table.Column<string>(type: "text", nullable: true),
                    WorkCost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementWorks", x => x.WorkId);
                    table.ForeignKey(
                        name: "FK_AdvertisementWorks_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractBillboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    BillboardId = table.Column<int>(type: "integer", nullable: false),
                    RentStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RentEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    AdvertisementPhotoLink = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractBillboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractBillboards_Billboards_BillboardId",
                        column: x => x.BillboardId,
                        principalTable: "Billboards",
                        principalColumn: "BillboardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractBillboards_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    TableName = table.Column<string>(type: "text", nullable: false),
                    RecordId = table.Column<int>(type: "integer", nullable: true),
                    Version = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_AuditLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Billboards",
                columns: new[] { "BillboardId", "Address", "CityDistrict", "LocationDescription", "RegistrationNumber", "RentAmountPerWeek", "UsefulArea" },
                values: new object[,]
                {
                    { 1, "Address 1", "District 1", "Location 1", "RN1", 100m, 100m },
                    { 2, "Address 2", "District 2", "Location 2", "RN2", 200m, 200m }
                });

            migrationBuilder.InsertData(
                table: "Renters",
                columns: new[] { "RenterId", "BankAccountNumber", "BankName", "ContactPersonName", "ContactPersonPhone", "DirectorName", "DirectorPhone", "Email", "Inn", "LegalAddress", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Account1", "Bank1", "Contact1", "Phone1", "Director1", "Phone1", "email@1.com", "Inn1", "Address1", "Renter1", "Status1" },
                    { 2, "Account2", "Bank2", "Contact2", "Phone2", "Director2", "Phone2", null, "Inn2", "Address2", "Renter2", "Status2" }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ContractId", "AdditionalTerms", "AgencyResponsible", "ContractNumber", "PaymentType", "RenterId", "SigningDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, "None", "Agency1", "123456", "Cash", 1, new DateTime(2024, 10, 29, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8005), "active", 0m },
                    { 2, "None", "Agency2", "654321", "Credit", 2, new DateTime(2024, 10, 29, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8005), "cancelled", 0m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "PasswordHash", "RenterId", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", 1, "admin", "admin" },
                    { 2, "87eba76e7f3164534045ba922e7770fb58bbd14ad732bbf5ba6f11cc56989e6e", 2, "configurator", "worker" }
                });

            migrationBuilder.InsertData(
                table: "AdvertisementWorks",
                columns: new[] { "WorkId", "ContractId", "WorkCost", "WorkDescription" },
                values: new object[,]
                {
                    { 1, 1, 1000m, "Work 1" },
                    { 2, 2, 2000m, "Work 2" }
                });

            migrationBuilder.InsertData(
                table: "AuditLogs",
                columns: new[] { "LogId", "Action", "RecordId", "TableName", "UserId" },
                values: new object[,]
                {
                    { 1, "Action 1", 1, "Table 1", 1 },
                    { 2, "Action 2", 2, "Table 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "ContractBillboards",
                columns: new[] { "Id", "AdvertisementPhotoLink", "BillboardId", "ContractId", "RentAmount", "RentEndDate", "RentStartDate" },
                values: new object[,]
                {
                    { 1, "https://mods.store.gx.me/mod/32027713-3e24-46ea-98d2-708f13991e17/cover/5b8f3267-3ad1-444e-8f75-83bab0a48848/webp-640x360?4b8390341bc39300397de58b9cb17301", 1, 1, 1000m, new DateTime(2024, 11, 19, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8036), new DateTime(2024, 10, 29, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8034) },
                    { 2, "https://avatars.mds.yandex.net/get-mpic/4880383/img_id745194673364714228.jpeg/orig", 2, 2, 2000m, new DateTime(2024, 11, 12, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8042), new DateTime(2024, 10, 29, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8041) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementWorks_ContractId",
                table: "AdvertisementWorks",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_UserId",
                table: "AuditLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractBillboards_BillboardId",
                table: "ContractBillboards",
                column: "BillboardId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractBillboards_ContractId",
                table: "ContractBillboards",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RenterId",
                table: "Contracts",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RenterId",
                table: "Users",
                column: "RenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementWorks");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "ContractBillboards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Billboards");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Renters");
        }
    }
}
