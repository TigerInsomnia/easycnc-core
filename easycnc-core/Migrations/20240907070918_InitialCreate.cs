using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace easycnc_core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    province = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "dept",
                columns: table => new
                {
                    dept_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dept_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parent_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dept", x => x.dept_id);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    permission_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permission_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permission_code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.permission_id);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    post_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    post_code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.post_id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role_code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    realname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_id = table.Column<int>(type: "int", nullable: true),
                    dept_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_users_address_address_id",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK_users_dept_dept_id",
                        column: x => x.dept_id,
                        principalTable: "dept",
                        principalColumn: "dept_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_permission",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false),
                    permission_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_permission", x => new { x.role_id, x.permission_id });
                    table.ForeignKey(
                        name: "FK_role_permission_permission_permission_id",
                        column: x => x.permission_id,
                        principalTable: "permission",
                        principalColumn: "permission_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_permission_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_user_role_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dept",
                columns: new[] { "dept_id", "dept_code", "dept_name", "parent_id" },
                values: new object[,]
                {
                    { 1, null, "张氏工厂", 9999 },
                    { 2, null, "技术部", 1 },
                    { 3, null, "销售部", 1 },
                    { 4, null, "销售1部", 3 },
                    { 5, null, "销售2部", 3 }
                });

            migrationBuilder.InsertData(
                table: "permission",
                columns: new[] { "permission_id", "permission_code", "permission_name" },
                values: new object[,]
                {
                    { 1, "read", "读" },
                    { 2, "write", "写" }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "role_id", "role_code", "role_name" },
                values: new object[,]
                {
                    { 1, "admin", "管理员" },
                    { 2, "user", "用户" }
                });

            migrationBuilder.InsertData(
                table: "role_permission",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address_id", "dept_id", "password", "realname", "username" },
                values: new object[,]
                {
                    { 1, null, 2, "$2a$10$kPaZzYn4dB0oUHwwOQ6Uuuwg48GBcS/3TbCn/CVMzJD70t.hIBgiy", null, "zhangsan" },
                    { 2, null, 3, "$2a$10$kPaZzYn4dB0oUHwwOQ6Uuuwg48GBcS/3TbCn/CVMzJD70t.hIBgiy", null, "lisi" },
                    { 3, null, 4, "$2a$10$kPaZzYn4dB0oUHwwOQ6Uuuwg48GBcS/3TbCn/CVMzJD70t.hIBgiy", null, "wangwu" }
                });

            migrationBuilder.InsertData(
                table: "user_role",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_permission_id",
                table: "role_permission",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_role_id",
                table: "user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_address_id",
                table: "users",
                column: "address_id",
                unique: true,
                filter: "[address_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_users_dept_id",
                table: "users",
                column: "dept_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "role_permission");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "dept");
        }
    }
}
