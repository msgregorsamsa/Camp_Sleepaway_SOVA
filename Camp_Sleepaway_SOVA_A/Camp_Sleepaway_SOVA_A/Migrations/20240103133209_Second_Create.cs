using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    /// <inheritdoc />
    public partial class Second_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CamperId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "NextOfKinId",
                table: "Campers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CamperId",
                table: "NextOfKins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinId",
                table: "Campers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
