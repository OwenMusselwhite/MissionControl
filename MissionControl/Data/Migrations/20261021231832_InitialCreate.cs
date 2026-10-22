using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    MissionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MissionName = table.Column<string>(type: "TEXT", nullable: false),
                    DestinationPlanet = table.Column<string>(type: "TEXT", nullable: false),
                    LaunchDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MissionStatus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.MissionId);
                });

            migrationBuilder.CreateTable(
                name: "CrewMembers",
                columns: table => new
                {
                    CrewMemberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    ExperienceYears = table.Column<int>(type: "INTEGER", nullable: false),
                    MissionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewMembers", x => x.CrewMemberId);
                    table.ForeignKey(
                        name: "FK_CrewMembers_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_MissionId",
                table: "CrewMembers",
                column: "MissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrewMembers");

            migrationBuilder.DropTable(
                name: "Missions");
        }
    }
}
