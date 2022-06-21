using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kol_pop.Mirgrations
{
    public partial class migraje2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrganizationDomain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganiztionId = table.Column<int>(type: "int", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MemmberNickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Member_Organization_OrganiztionId",
                        column: x => x.OrganiztionId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => new { x.FileId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_File_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Membership_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_Team_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "OrganizationId", "OrganizationDomain", "OrganizationName" },
                values: new object[] { 1, "naukowa", "szkola" });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "MemberId", "MemberName", "MemberSurname", "MemmberNickName", "OrganiztionId" },
                values: new object[] { 1, "kuba", "kowal", "Suzin", 1 });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "TeamId", "OrganizationId", "TeamDescription", "TeamName" },
                values: new object[] { 1, 1, "jakies super ludzie", "kozaki" });

            migrationBuilder.InsertData(
                table: "File",
                columns: new[] { "FileId", "TeamId", "FileExtension", "FileName", "FileSize" },
                values: new object[] { 1, 1, "zip", "zaliczenia", 100 });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "MemberId", "MembershipDate", "TeamId" },
                values: new object[] { 1, new DateTime(2022, 6, 21, 10, 3, 7, 935, DateTimeKind.Local).AddTicks(1329), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_File_TeamId",
                table: "File",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_OrganiztionId",
                table: "Member",
                column: "OrganiztionId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_OrganizationId",
                table: "Team",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
