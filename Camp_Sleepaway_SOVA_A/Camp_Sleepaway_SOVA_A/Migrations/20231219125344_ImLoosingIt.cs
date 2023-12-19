using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    /// <inheritdoc />
    public partial class ImLoosingIt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKin_Cabins_CabinId",
                table: "NextOfKin");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKin_NextOfKin_NextOfKinId",
                table: "NextOfKin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NextOfKin",
                table: "NextOfKin");

            migrationBuilder.RenameTable(
                name: "NextOfKin",
                newName: "NextOfKins");

            migrationBuilder.RenameIndex(
                name: "IX_NextOfKin_NextOfKinId",
                table: "NextOfKins",
                newName: "IX_NextOfKins_NextOfKinId");

            migrationBuilder.RenameIndex(
                name: "IX_NextOfKin_CabinId",
                table: "NextOfKins",
                newName: "IX_NextOfKins_CabinId");

            migrationBuilder.AddColumn<int>(
                name: "CamperId",
                table: "NextOfKins",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NextOfKins",
                table: "NextOfKins",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabinId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campers_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_CamperId",
                table: "NextOfKins",
                column: "CamperId");

            migrationBuilder.CreateIndex(
                name: "IX_Campers_CabinId",
                table: "Campers",
                column: "CabinId");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Cabins_CabinId",
                table: "NextOfKins",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Cabins_CabinId",
                table: "NextOfKins");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Campers_CamperId",
                table: "NextOfKins");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_NextOfKins_NextOfKinId",
                table: "NextOfKins");

            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NextOfKins",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_CamperId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "CamperId",
                table: "NextOfKins");

            migrationBuilder.RenameTable(
                name: "NextOfKins",
                newName: "NextOfKin");

            migrationBuilder.RenameIndex(
                name: "IX_NextOfKins_NextOfKinId",
                table: "NextOfKin",
                newName: "IX_NextOfKin_NextOfKinId");

            migrationBuilder.RenameIndex(
                name: "IX_NextOfKins_CabinId",
                table: "NextOfKin",
                newName: "IX_NextOfKin_CabinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NextOfKin",
                table: "NextOfKin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKin_Cabins_CabinId",
                table: "NextOfKin",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKin_NextOfKin_NextOfKinId",
                table: "NextOfKin",
                column: "NextOfKinId",
                principalTable: "NextOfKin",
                principalColumn: "Id");
        }
    }
}
