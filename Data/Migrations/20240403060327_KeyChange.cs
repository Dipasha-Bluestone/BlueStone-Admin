using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueStoneAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class KeyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeModel",
                table: "HomeModel");

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "HomeModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeModel",
                table: "HomeModel",
                column: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeModel",
                table: "HomeModel");

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "HomeModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeModel",
                table: "HomeModel",
                column: "EmailId");
        }
    }
}
