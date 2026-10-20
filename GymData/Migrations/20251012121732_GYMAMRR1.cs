using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymData.Migrations
{
    /// <inheritdoc />
    public partial class GYMAMRR1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CExperience = table.Column<int>(type: "int", nullable: false),
                    CAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Cid);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MShipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MDuration = table.Column<int>(type: "int", nullable: false),
                    MGoal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.MShipId);
                });

            migrationBuilder.CreateTable(
                name: "Receptionists",
                columns: table => new
                {
                    Rsccptid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecepGen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecepDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecepAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecepPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecepPass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionists", x => x.Rsccptid);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Mid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MGen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MTiming = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MMembershipId = table.Column<int>(type: "int", nullable: true),
                    MCoachId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Mid);
                    table.ForeignKey(
                        name: "FK_Members_Coaches_MCoachId",
                        column: x => x.MCoachId,
                        principalTable: "Coaches",
                        principalColumn: "Cid");
                    table.ForeignKey(
                        name: "FK_Members_Memberships_MMembershipId",
                        column: x => x.MMembershipId,
                        principalTable: "Memberships",
                        principalColumn: "MShipId");
                });

            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    BPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Finances_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Mid");
                    table.ForeignKey(
                        name: "FK_Finances_Receptionists_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Receptionists",
                        principalColumn: "Rsccptid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Finances_AgentId",
                table: "Finances",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Finances_MemberId",
                table: "Finances",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MCoachId",
                table: "Members",
                column: "MCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MMembershipId",
                table: "Members",
                column: "MMembershipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finances");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Receptionists");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Memberships");
        }
    }
}
