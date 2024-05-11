using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ErrorHandlerandAuthetication.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "MenuCodes",
                columns: table => new
                {
                    FunctionSeq = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainFuncionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailFunctionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCodes", x => x.FunctionSeq);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[,]
                {
                    { "T001", "管理者" },
                    { "T002", "聯徵發查" }
                });

            migrationBuilder.InsertData(
                table: "MenuCodes",
                columns: new[] { "FunctionSeq", "DetailFunctionName", "GroupId", "MainFuncionName" },
                values: new object[,]
                {
                    { 1, "Index1", "T001", "Test" },
                    { 2, "Index1", "T002", "Test" },
                    { 3, "Index2", "T001", "Test" },
                    { 4, "Index1", "T001", "TestApi" },
                    { 5, "Index1", "T001", "Test2" },
                    { 6, "Index2", "T001", "Test2" },
                    { 7, "Index1", "T001", "Test2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Account", "GroupId", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "tnfe01", "T001", "@a0123456789", "chunyu" },
                    { 2, "tnfe02", "T002", "@a0123456789", "dru" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "MenuCodes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
