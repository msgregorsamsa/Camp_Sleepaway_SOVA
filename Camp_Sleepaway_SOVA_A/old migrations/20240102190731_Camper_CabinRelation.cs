using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    /// <inheritdoc />
    public partial class Camper_CabinRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campers_Cabins_CabinId",
                table: "Campers");

            migrationBuilder.DropIndex(
                name: "IX_Campers_CabinId",
                table: "Campers");

            migrationBuilder.DropColumn(
                name: "CabinId",
                table: "Campers");

            migrationBuilder.AlterColumn<string>(
                name: "CabinName",
                table: "Campers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cabins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Cabins_Name",
                table: "Cabins",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Campers_CabinName",
                table: "Campers",
                column: "CabinName");

            migrationBuilder.AddForeignKey(
                name: "FK_Campers_Cabins_CabinName",
                table: "Campers",
                column: "CabinName",
                principalTable: "Cabins",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campers_Cabins_CabinName",
                table: "Campers");

            migrationBuilder.DropIndex(
                name: "IX_Campers_CabinName",
                table: "Campers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Cabins_Name",
                table: "Cabins");

            migrationBuilder.AlterColumn<string>(
                name: "CabinName",
                table: "Campers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CabinId",
                table: "Campers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cabins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Campers_CabinId",
                table: "Campers",
                column: "CabinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campers_Cabins_CabinId",
                table: "Campers",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "Id");
        }
    }
}
