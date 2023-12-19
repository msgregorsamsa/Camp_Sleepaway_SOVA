using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    /// <inheritdoc />
    public partial class sos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Campers_CamperId",
                table: "NextOfKins");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_NextOfKins_NextOfKinId",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_CamperId",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_NextOfKinId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "CamperId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "NextOfKinId",
                table: "NextOfKins");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "NextOfKins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_CamperId",
                table: "NextOfKins",
                column: "CamperId");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_NextOfKinId",
                table: "NextOfKins",
                column: "NextOfKinId");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Campers_CamperId",
                table: "NextOfKins",
                column: "CamperId",
                principalTable: "Campers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_NextOfKins_NextOfKinId",
                table: "NextOfKins",
                column: "NextOfKinId",
                principalTable: "NextOfKins",
                principalColumn: "Id");
        }
    }
}
