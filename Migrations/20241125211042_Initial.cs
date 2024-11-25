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
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    { 1, "г. Москва, Красная площадь, д. 1", "Центральный", "Рядом с Кремлем", "AA-1001", 10000.0m, 30.0m },
                    { 2, "г. Москва, Тверская ул., д. 15", "Тверской", "Около метро Маяковская", "AA-1002", 8000.0m, 25.0m },
                    { 3, "г. Санкт-Петербург, Адмиралтейский пр., д. 3", "Адмиралтейский", "Напротив Эрмитажа", "AA-1003", 9000.0m, 28.0m },
                    { 4, "г. Санкт-Петербург, 8-я линия В.О., д. 42", "Василеостровский", "У входа в парк", "AA-1004", 7000.0m, 22.0m },
                    { 5, "г. Санкт-Петербург, пр. Испытателей, д. 5", "Приморский", "Рядом с ТРЦ", "AA-1005", 6500.0m, 20.0m },
                    { 6, "г. Москва, ул. Большая Ордынка, д. 17", "Замоскворечье", "Недалеко от Третьяковской галереи", "AA-1006", 7500.0m, 24.0m }
                });

            migrationBuilder.InsertData(
                table: "Renters",
                columns: new[] { "RenterId", "BankAccountNumber", "BankName", "ContactPersonName", "ContactPersonPhone", "DirectorName", "DirectorPhone", "Email", "Inn", "LegalAddress", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "40702810900000000001", "Сбербанк", "Петрова Мария Ивановна", "+79990002233", "Иванов Сергей Павлович", "+79990001122", "info@alpha.ru", "7723456789", "г. Москва, ул. Пушкина, д. 10", "ООО \"Рекламное Агентство Альфа\"", "Действующий" },
                    { 2, "40702810900000000002", "Альфа-Банк", "Кузнецов Дмитрий Сергеевич", "+79990004455", "Сидоров Алексей Викторович", "+79990003344", "contact@beta.ru", "7823456789", "г. Санкт-Петербург, пр. Невский, д. 20", "ЗАО \"Медиа Бета\"", "Действующий" }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ContractId", "AdditionalTerms", "AgencyResponsible", "ContractNumber", "PaymentType", "RenterId", "SigningDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, "Нет", "Иванова Е.А.", "AA-1001-00001", "Наличные", 1, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Активен", 30000.0m },
                    { 2, "Нет", "Иванова Е.А.", "AA-1001-00002", "Банковский перевод", 1, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Активен", 25000.0m },
                    { 3, "Нет", "Сидорова А.В.", "AA-1002-00003", "Постоплата", 2, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Активен", 28000.0m },
                    { 4, "Нет", "Сидорова А.В.", "AA-1002-00004", "Наличные", 2, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Активен", 35000.0m }
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
                    { 1, 1, 5000.0m, "Печать баннера" },
                    { 2, 2, 7000.0m, "Монтаж билборда" },
                    { 3, 3, 6000.0m, "Разработка макета" },
                    { 4, 4, 8000.0m, "Дизайн и изготовление" }
                });

            migrationBuilder.InsertData(
                table: "ContractBillboards",
                columns: new[] { "Id", "AdvertisementPhotoLink", "BillboardId", "ContractId", "RentAmount", "RentEndDate", "RentStartDate" },
                values: new object[,]
                {
                    { 1, "https://example.com/ad1.jpg", 1, 1, 30000.0m, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "https://example.com/ad2.jpg", 2, 1, 30000.0m, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "https://example.com/ad3.jpg", 6, 2, 25000.0m, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "https://example.com/ad4.jpg", 3, 3, 28000.0m, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "https://example.com/ad5.jpg", 4, 4, 35000.0m, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, "https://example.com/ad6.jpg", 5, 4, 35000.0m, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc) }
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
