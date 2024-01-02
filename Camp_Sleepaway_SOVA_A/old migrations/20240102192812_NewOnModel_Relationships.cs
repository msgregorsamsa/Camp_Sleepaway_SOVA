using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    /// <inheritdoc />
    public partial class NewOnModel_Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counselors_Cabins_CabinId",
                table: "Counselors");

            migrationBuilder.DropIndex(
                name: "IX_Counselors_CabinId",
                table: "Counselors");

            migrationBuilder.DropColumn(
                name: "CabinId",
                table: "Counselors");

            migrationBuilder.AlterColumn<string>(
                name: "CabinName",
                table: "Counselors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_CabinName",
                table: "Counselors",
                column: "CabinName",
                unique: true,
                filter: "[CabinName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Counselors_Cabins_CabinName",
                table: "Counselors",
                column: "CabinName",
                principalTable: "Cabins",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counselors_Cabins_CabinName",
                table: "Counselors");

            migrationBuilder.DropIndex(
                name: "IX_Counselors_CabinName",
                table: "Counselors");

            migrationBuilder.AlterColumn<string>(
                name: "CabinName",
                table: "Counselors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CabinId",
                table: "Counselors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_CabinId",
                table: "Counselors",
                column: "CabinId",
                unique: true,
                filter: "[CabinId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Counselors_Cabins_CabinId",
                table: "Counselors",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "Id");
        }
    }
}
