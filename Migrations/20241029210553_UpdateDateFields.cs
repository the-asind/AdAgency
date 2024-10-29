using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdAgency.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDateFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SigningDate",
                table: "Contracts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentStartDate",
                table: "ContractBillboards",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentEndDate",
                table: "ContractBillboards",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdvertisementPhotoLink", "RentEndDate", "RentStartDate" },
                values: new object[] { "https://mods.store.gx.me/mod/32027713-3e24-46ea-98d2-708f13991e17/cover/5b8f3267-3ad1-444e-8f75-83bab0a48848/webp-640x360?4b8390341bc39300397de58b9cb17301", new DateTime(2024, 10, 30, 4, 5, 53, 329, DateTimeKind.Local).AddTicks(5778), new DateTime(2024, 10, 30, 4, 5, 53, 329, DateTimeKind.Local).AddTicks(5777) });

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AdvertisementPhotoLink", "RentEndDate", "RentStartDate" },
                values: new object[] { "https://avatars.mds.yandex.net/get-mpic/4880383/img_id745194673364714228.jpeg/orig", new DateTime(2024, 10, 30, 4, 5, 53, 329, DateTimeKind.Local).AddTicks(5781), new DateTime(2024, 10, 30, 4, 5, 53, 329, DateTimeKind.Local).AddTicks(5780) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                column: "SigningDate",
                value: new DateTime(2024, 10, 30, 4, 5, 53, 329, DateTimeKind.Local).AddTicks(5745));

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                column: "SigningDate",
                value: new DateTime(2024, 10, 30, 4, 5, 53, 329, DateTimeKind.Local).AddTicks(5745));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "SigningDate",
                table: "Contracts",
                type: "bytea",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "RentStartDate",
                table: "ContractBillboards",
                type: "bytea",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "RentEndDate",
                table: "ContractBillboards",
                type: "bytea",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdvertisementPhotoLink",
                value: "ftp://AdvertisementPhotoLink");

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdvertisementPhotoLink",
                value: "ftp://AdvertisementPhotoLink");
        }
    }
}
