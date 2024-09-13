using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace easycnc_core.Migrations
{
    /// <inheritdoc />
    public partial class _3Modeify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "address",
                columns: new[] { "address_id", "city", "county", "detail", "province" },
                values: new object[,]
                {
                    { 2, "嘉兴市", "嘉善县", "罗星街道", "浙江省" },
                    { 3, "嘉兴市", "嘉善县", "罗星街道", "浙江省" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                column: "address_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2,
                column: "address_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 3,
                column: "address_id",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "address",
                keyColumn: "address_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "address",
                keyColumn: "address_id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                column: "address_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2,
                column: "address_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 3,
                column: "address_id",
                value: null);
        }
    }
}
