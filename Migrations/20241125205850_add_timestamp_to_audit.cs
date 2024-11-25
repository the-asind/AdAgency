using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdAgency.Migrations
{
    /// <inheritdoc />
    public partial class add_timestamp_to_audit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "LogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "LogId",
                keyValue: 2);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "AuditLogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AdvertisementWorks",
                keyColumn: "WorkId",
                keyValue: 1,
                columns: new[] { "WorkCost", "WorkDescription" },
                values: new object[] { 5000.0m, "Печать баннера" });

            migrationBuilder.UpdateData(
                table: "AdvertisementWorks",
                keyColumn: "WorkId",
                keyValue: 2,
                columns: new[] { "WorkCost", "WorkDescription" },
                values: new object[] { 7000.0m, "Монтаж билборда" });

            migrationBuilder.UpdateData(
                table: "Billboards",
                keyColumn: "BillboardId",
                keyValue: 1,
                columns: new[] { "Address", "CityDistrict", "LocationDescription", "RegistrationNumber", "RentAmountPerWeek", "UsefulArea" },
                values: new object[] { "г. Москва, Красная площадь, д. 1", "Центральный", "Рядом с Кремлем", "AA-1001", 10000.0m, 30.0m });

            migrationBuilder.UpdateData(
                table: "Billboards",
                keyColumn: "BillboardId",
                keyValue: 2,
                columns: new[] { "Address", "CityDistrict", "LocationDescription", "RegistrationNumber", "RentAmountPerWeek", "UsefulArea" },
                values: new object[] { "г. Москва, Тверская ул., д. 15", "Тверской", "Около метро Маяковская", "AA-1002", 8000.0m, 25.0m });

            migrationBuilder.InsertData(
                table: "Billboards",
                columns: new[] { "BillboardId", "Address", "CityDistrict", "LocationDescription", "RegistrationNumber", "RentAmountPerWeek", "UsefulArea" },
                values: new object[,]
                {
                    { 3, "г. Санкт-Петербург, Адмиралтейский пр., д. 3", "Адмиралтейский", "Напротив Эрмитажа", "AA-1003", 9000.0m, 28.0m },
                    { 4, "г. Санкт-Петербург, 8-я линия В.О., д. 42", "Василеостровский", "У входа в п��рк", "AA-1004", 7000.0m, 22.0m },
                    { 5, "г. Санкт-Петербург, пр. Испытателей, д. 5", "Приморский", "Рядом с ТРЦ", "AA-1005", 6500.0m, 20.0m },
                    { 6, "г. Москва, ул. Большая Ордынка, д. 17", "Замоскворечье", "Недалеко от Третьяковской галереи", "AA-1006", 7500.0m, 24.0m }
                });

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdvertisementPhotoLink", "RentAmount", "RentEndDate", "RentStartDate" },
                values: new object[] { "https://example.com/ad1.jpg", 30000.0m, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AdvertisementPhotoLink", "ContractId", "RentAmount", "RentEndDate", "RentStartDate" },
                values: new object[] { "https://example.com/ad2.jpg", 1, 30000.0m, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "AdditionalTerms", "AgencyResponsible", "ContractNumber", "PaymentType", "SigningDate", "Status", "TotalAmount" },
                values: new object[] { "Нет", "Иванова Е.А.", "AA-1001-00001", "Наличные", new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активен", 30000.0m });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "AdditionalTerms", "AgencyResponsible", "ContractNumber", "PaymentType", "RenterId", "SigningDate", "Status", "TotalAmount" },
                values: new object[] { "Нет", "Иванова Е.А.", "AA-1001-00002", "Банковский перевод", 1, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активен", 25000.0m });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ContractId", "AdditionalTerms", "AgencyResponsible", "ContractNumber", "PaymentType", "RenterId", "SigningDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 3, "Нет", "Сидорова А.В.", "AA-1002-00003", "Постоплата", 2, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активен", 28000.0m },
                    { 4, "Нет", "Сидорова А.В.", "AA-1002-00004", "Наличные", 2, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активен", 35000.0m }
                });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                columns: new[] { "BankAccountNumber", "BankName", "ContactPersonName", "ContactPersonPhone", "DirectorName", "DirectorPhone", "Email", "Inn", "LegalAddress", "Name", "Status" },
                values: new object[] { "40702810900000000001", "Сбербанк", "Петрова Мария Ивановна", "+79990002233", "Иванов Сергей Павлович", "+79990001122", "info@alpha.ru", "7723456789", "г. Москва, ул. Пушкина, д. 10", "ООО \"Рекламное Агентство Альфа\"", "Действующий" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                columns: new[] { "BankAccountNumber", "BankName", "ContactPersonName", "ContactPersonPhone", "DirectorName", "DirectorPhone", "Email", "Inn", "LegalAddress", "Name", "Status" },
                values: new object[] { "40702810900000000002", "Альфа-Банк", "Кузнецов Дмитрий Сергеевич", "+79990004455", "Сидоров Алексей Викторович", "+79990003344", "contact@beta.ru", "7823456789", "г. Санкт-Петербург, пр. Невский, д. 20", "ЗАО \"Медиа Бета\"", "Действующий" });

            migrationBuilder.InsertData(
                table: "AdvertisementWorks",
                columns: new[] { "WorkId", "ContractId", "WorkCost", "WorkDescription" },
                values: new object[,]
                {
                    { 3, 3, 6000.0m, "Разработка макета" },
                    { 4, 4, 8000.0m, "Дизайн и изготовление" }
                });

            migrationBuilder.InsertData(
                table: "ContractBillboards",
                columns: new[] { "Id", "AdvertisementPhotoLink", "BillboardId", "ContractId", "RentAmount", "RentEndDate", "RentStartDate" },
                values: new object[,]
                {
                    { 3, "https://example.com/ad3.jpg", 6, 2, 25000.0m, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "https://example.com/ad4.jpg", 3, 3, 28000.0m, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "https://example.com/ad5.jpg", 4, 4, 35000.0m, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "https://example.com/ad6.jpg", 5, 4, 35000.0m, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdvertisementWorks",
                keyColumn: "WorkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AdvertisementWorks",
                keyColumn: "WorkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Billboards",
                keyColumn: "BillboardId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Billboards",
                keyColumn: "BillboardId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Billboards",
                keyColumn: "BillboardId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Billboards",
                keyColumn: "BillboardId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "AuditLogs");

            migrationBuilder.UpdateData(
                table: "AdvertisementWorks",
                keyColumn: "WorkId",
                keyValue: 1,
                columns: new[] { "WorkCost", "WorkDescription" },
                values: new object[] { 1000m, "Work 1" });

            migrationBuilder.UpdateData(
                table: "AdvertisementWorks",
                keyColumn: "WorkId",
                keyValue: 2,
                columns: new[] { "WorkCost", "WorkDescription" },
                values: new object[] { 2000m, "Work 2" });

            migrationBuilder.InsertData(
                table: "AuditLogs",
                columns: new[] { "LogId", "Action", "RecordId", "TableName", "UserId" },
                values: new object[,]
                {
                    { 1, "Action 1", 1, "Table 1", 1 },
                    { 2, "Action 2", 2, "Table 2", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Billboards",
                keyColumn: "BillboardId",
                keyValue: 1,
                columns: new[] { "Address", "CityDistrict", "LocationDescription", "RegistrationNumber", "RentAmountPerWeek", "UsefulArea" },
                values: new object[] { "Address 1", "District 1", "Location 1", "RN1", 100m, 100m });

            migrationBuilder.UpdateData(
                table: "Billboards",
                keyColumn: "BillboardId",
                keyValue: 2,
                columns: new[] { "Address", "CityDistrict", "LocationDescription", "RegistrationNumber", "RentAmountPerWeek", "UsefulArea" },
                values: new object[] { "Address 2", "District 2", "Location 2", "RN2", 200m, 200m });

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdvertisementPhotoLink", "RentAmount", "RentEndDate", "RentStartDate" },
                values: new object[] { "https://mods.store.gx.me/mod/32027713-3e24-46ea-98d2-708f13991e17/cover/5b8f3267-3ad1-444e-8f75-83bab0a48848/webp-640x360?4b8390341bc39300397de58b9cb17301", 1000m, new DateTime(2024, 11, 19, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8036), new DateTime(2024, 10, 29, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8034) });

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AdvertisementPhotoLink", "ContractId", "RentAmount", "RentEndDate", "RentStartDate" },
                values: new object[] { "https://avatars.mds.yandex.net/get-mpic/4880383/img_id745194673364714228.jpeg/orig", 2, 2000m, new DateTime(2024, 11, 12, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8042), new DateTime(2024, 10, 29, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8041) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "AdditionalTerms", "AgencyResponsible", "ContractNumber", "PaymentType", "SigningDate", "Status", "TotalAmount" },
                values: new object[] { "None", "Agency1", "123456", "Cash", new DateTime(2024, 10, 29, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8005), "active", 0m });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "AdditionalTerms", "AgencyResponsible", "ContractNumber", "PaymentType", "RenterId", "SigningDate", "Status", "TotalAmount" },
                values: new object[] { "None", "Agency2", "654321", "Credit", 2, new DateTime(2024, 10, 29, 21, 39, 37, 265, DateTimeKind.Utc).AddTicks(8005), "cancelled", 0m });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                columns: new[] { "BankAccountNumber", "BankName", "ContactPersonName", "ContactPersonPhone", "DirectorName", "DirectorPhone", "Email", "Inn", "LegalAddress", "Name", "Status" },
                values: new object[] { "Account1", "Bank1", "Contact1", "Phone1", "Director1", "Phone1", "email@1.com", "Inn1", "Address1", "Renter1", "Status1" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                columns: new[] { "BankAccountNumber", "BankName", "ContactPersonName", "ContactPersonPhone", "DirectorName", "DirectorPhone", "Email", "Inn", "LegalAddress", "Name", "Status" },
                values: new object[] { "Account2", "Bank2", "Contact2", "Phone2", "Director2", "Phone2", null, "Inn2", "Address2", "Renter2", "Status2" });
        }
    }
}
