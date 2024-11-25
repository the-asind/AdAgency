using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdAgency.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataWithUtcDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Billboards",
                keyColumn: "BillboardId",
                keyValue: 4,
                column: "LocationDescription",
                value: "У входа в парк");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Billboards",
                keyColumn: "BillboardId",
                keyValue: 4,
                column: "LocationDescription",
                value: "У входа в п��рк");
        }
    }
}
