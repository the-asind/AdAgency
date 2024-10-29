using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdAgency.Migrations
{
    /// <inheritdoc />
    public partial class FixDateTimeKinds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SigningDate",
                table: "Contracts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RentEndDate", "RentStartDate" },
                values: new object[] { new DateTime(2024, 10, 30, 4, 17, 45, 390, DateTimeKind.Local).AddTicks(9239), new DateTime(2024, 10, 30, 4, 17, 45, 390, DateTimeKind.Local).AddTicks(9236) });

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RentEndDate", "RentStartDate" },
                values: new object[] { new DateTime(2024, 10, 30, 4, 17, 45, 390, DateTimeKind.Local).AddTicks(9241), new DateTime(2024, 10, 30, 4, 17, 45, 390, DateTimeKind.Local).AddTicks(9240) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                column: "SigningDate",
                value: new DateTime(2024, 10, 30, 4, 17, 45, 390, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                column: "SigningDate",
                value: new DateTime(2024, 10, 30, 4, 17, 45, 390, DateTimeKind.Local).AddTicks(9208));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SigningDate",
                table: "Contracts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RentEndDate", "RentStartDate" },
                values: new object[] { new DateTime(2024, 10, 30, 4, 5, 53, 329, DateTimeKind.Local).AddTicks(5778), new DateTime(2024, 10, 30, 4, 5, 53, 329, DateTimeKind.Local).AddTicks(5777) });

            migrationBuilder.UpdateData(
                table: "ContractBillboards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RentEndDate", "RentStartDate" },
                values: new object[] { new DateTime(2024, 10, 30, 4, 5, 53, 329, DateTimeKind.Local).AddTicks(5781), new DateTime(2024, 10, 30, 4, 5, 53, 329, DateTimeKind.Local).AddTicks(5780) });

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
    }
}
