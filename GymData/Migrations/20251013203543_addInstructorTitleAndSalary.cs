using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymData.Migrations
{
    /// <inheritdoc />
    public partial class addInstructorTitleAndSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ins_name",
                table: "instructors",
                newName: "ins_title");

            migrationBuilder.AddColumn<string>(
                name: "ins_FName",
                table: "instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ins_LName",
                table: "instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ins_salary",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ins_FName",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "ins_LName",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "ins_salary",
                table: "instructors");

            migrationBuilder.RenameColumn(
                name: "ins_title",
                table: "instructors",
                newName: "ins_name");
        }
    }
}
