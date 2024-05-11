using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErrorHandlerandAuthetication.Migrations
{
    /// <inheritdoc />
    public partial class update_DbData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuCodes",
                keyColumn: "FunctionSeq",
                keyValue: 7,
                column: "GroupId",
                value: "T002");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuCodes",
                keyColumn: "FunctionSeq",
                keyValue: 7,
                column: "GroupId",
                value: "T001");
        }
    }
}
