using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymData.Migrations
{
    /// <inheritdoc />
    public partial class GYMAMRR2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    rep_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rep_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rep_gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rep_birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rep_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rep_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rep_pass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.rep_id);
                });

            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    ins_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ins_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ins_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ins_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ins_gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ins_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ins_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ins_pass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.ins_id);
                });

            migrationBuilder.CreateTable(
                name: "package",
                columns: table => new
                {
                    pack_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ins_id = table.Column<int>(type: "int", nullable: false),
                    pack_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pack_price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    pack_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pack_sessionsCount = table.Column<int>(type: "int", nullable: false),
                    pack_img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_package", x => x.pack_id);
                    table.ForeignKey(
                        name: "FK_package_instructors_ins_id",
                        column: x => x.ins_id,
                        principalTable: "instructors",
                        principalColumn: "ins_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pack_id = table.Column<int>(type: "int", nullable: false),
                    ispaid = table.Column<bool>(type: "bit", nullable: false),
                    client_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    client_gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.client_id);
                    table.ForeignKey(
                        name: "FK_client_package_pack_id",
                        column: x => x.pack_id,
                        principalTable: "package",
                        principalColumn: "pack_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    payment_status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_payment_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_pack_id",
                table: "client",
                column: "pack_id");

            migrationBuilder.CreateIndex(
                name: "IX_package_ins_id",
                table: "package",
                column: "ins_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_client_id",
                table: "payment",
                column: "client_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "package");

            migrationBuilder.DropTable(
                name: "instructors");

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CExperience = table.Column<int>(type: "int", nullable: false),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    MCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MDuration = table.Column<int>(type: "int", nullable: false),
                    MGoal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    RecepAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecepDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecepGen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecepPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecepPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    MCoachId = table.Column<int>(type: "int", nullable: true),
                    MMembershipId = table.Column<int>(type: "int", nullable: true),
                    MDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MGen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MTiming = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    BAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
