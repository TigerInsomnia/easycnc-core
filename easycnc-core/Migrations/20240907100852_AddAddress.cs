using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace easycnc_core.Migrations
{
    /// <inheritdoc />
    public partial class AddAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "county",
                table: "address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "detail",
                table: "address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "address",
                columns: new[] { "address_id", "city", "county", "detail", "province" },
                values: new object[] { 1, "嘉兴市", "嘉善县", "罗星街道", "浙江省" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "address",
                keyColumn: "address_id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "city",
                table: "address");

            migrationBuilder.DropColumn(
                name: "county",
                table: "address");

            migrationBuilder.DropColumn(
                name: "detail",
                table: "address");
        }
    }
}
