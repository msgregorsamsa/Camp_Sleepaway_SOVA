using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    /// <inheritdoc />
    public partial class Tomihuvve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CamperNextOfKin");

            migrationBuilder.AddColumn<int>(
                name: "CamperId",
                table: "NextOfKins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinId",
                table: "Campers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CamperNextOfKins",
                columns: table => new
                {
                    CamperId = table.Column<int>(type: "int", nullable: false),
                    NextOfKinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamperNextOfKins", x => new { x.CamperId, x.NextOfKinId });
                    table.ForeignKey(
                        name: "FK_CamperNextOfKins_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CamperNextOfKins_NextOfKins_NextOfKinId",
                        column: x => x.NextOfKinId,
                        principalTable: "NextOfKins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CamperNextOfKins_NextOfKinId",
                table: "CamperNextOfKins",
                column: "NextOfKinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CamperNextOfKins");

            migrationBuilder.DropColumn(
                name: "CamperId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "NextOfKinId",
                table: "Campers");

            migrationBuilder.CreateTable(
                name: "CamperNextOfKin",
                columns: table => new
                {
                    CampersId = table.Column<int>(type: "int", nullable: false),
                    NextOfKinsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamperNextOfKin", x => new { x.CampersId, x.NextOfKinsId });
                    table.ForeignKey(
                        name: "FK_CamperNextOfKin_Campers_CampersId",
                        column: x => x.CampersId,
                        principalTable: "Campers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CamperNextOfKin_NextOfKins_NextOfKinsId",
                        column: x => x.NextOfKinsId,
                        principalTable: "NextOfKins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CamperNextOfKin_NextOfKinsId",
                table: "CamperNextOfKin",
                column: "NextOfKinsId");
        }
    }
}
