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
                    SigningDate = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    AgencyResponsible = table.Column<string>(type: "text", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: true),
                    AdditionalTerms = table.Column<string>(type: "text", nullable: true),
                    RenterId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
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
                    RentStartDate = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    RentEndDate = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
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
                columns: new[] { "ContractId", "AdditionalTerms", "AgencyResponsible", "ContractNumber", "PaymentType", "RenterId", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, "None", "Agency1", "123456", "Cash", 1, "active", 0m },
                    { 2, "None", "Agency2", "654321", "Credit", 2, "cancelled", 0m }
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
                columns: new[] { "Id", "AdvertisementPhotoLink", "BillboardId", "ContractId", "RentAmount" },
                values: new object[,]
                {
                    { 1, "ftp://AdvertisementPhotoLink", 1, 1, 1000m },
                    { 2, "ftp://AdvertisementPhotoLink", 2, 2, 2000m }
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
