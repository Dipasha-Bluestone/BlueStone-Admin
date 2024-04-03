using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueStoneAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondHome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "HomeModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "HomeModel",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
