using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsICE",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "ICE",
                table: "Campers");

            migrationBuilder.AddColumn<string>(
                name: "CabinName",
                table: "Counselors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CabinName",
                table: "Campers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CabinName",
                table: "Counselors");

            migrationBuilder.DropColumn(
                name: "CabinName",
                table: "Campers");

            migrationBuilder.AddColumn<bool>(
                name: "IsICE",
                table: "NextOfKins",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICE",
                table: "Campers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
