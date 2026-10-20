using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymData.Migrations
{
    [DbContext(typeof(GymContextDB))]
    [Migration("20261019143000_AddBillingCycle")]
    public partial class AddBillingCycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationMonths",
                table: "package",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "BillingMonths",
                table: "client",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DurationMonths", table: "package");
            migrationBuilder.DropColumn(name: "BillingMonths", table: "client");
        }
    }
}
