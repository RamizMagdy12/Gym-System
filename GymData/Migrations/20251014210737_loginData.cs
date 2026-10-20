using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymData.Migrations
{
    /// <inheritdoc />
    public partial class loginData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "employees");
        }
    }
}
