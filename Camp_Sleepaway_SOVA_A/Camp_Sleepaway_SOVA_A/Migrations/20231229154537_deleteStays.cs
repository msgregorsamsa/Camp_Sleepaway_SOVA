using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    /// <inheritdoc />
    public partial class deleteStays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stays",
                columns: table => new
                {
                    StayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinId = table.Column<int>(type: "int", nullable: false),
                    CamperId = table.Column<int>(type: "int", nullable: false),
                    CounselorId = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stays", x => x.StayId);
                    table.ForeignKey(
                        name: "FK_Stays_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stays_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stays_Counselors_CounselorId",
                        column: x => x.CounselorId,
                        principalTable: "Counselors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stays_CabinId",
                table: "Stays",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_Stays_CamperId",
                table: "Stays",
                column: "CamperId");

            migrationBuilder.CreateIndex(
                name: "IX_Stays_CounselorId",
                table: "Stays",
                column: "CounselorId");
        }
    }
}
