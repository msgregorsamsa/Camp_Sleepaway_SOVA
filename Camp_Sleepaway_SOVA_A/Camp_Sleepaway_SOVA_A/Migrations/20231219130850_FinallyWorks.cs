using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    /// <inheritdoc />
    public partial class FinallyWorks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Cabins_CabinId",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_CabinId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "CabinId",
                table: "NextOfKins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CabinId",
                table: "NextOfKins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_CabinId",
                table: "NextOfKins",
                column: "CabinId");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Cabins_CabinId",
                table: "NextOfKins",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "Id");
        }
    }
}
