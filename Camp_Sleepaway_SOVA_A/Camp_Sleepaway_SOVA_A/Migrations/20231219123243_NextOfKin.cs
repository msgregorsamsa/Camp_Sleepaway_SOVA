using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    /// <inheritdoc />
    public partial class NextOfKin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CamperNextOfKin");

            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NextOfKins",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "NumberOfCampers",
                table: "NextOfKins");

            migrationBuilder.RenameTable(
                name: "NextOfKins",
                newName: "NextOfKin");

            migrationBuilder.AlterColumn<bool>(
                name: "IsICE",
                table: "NextOfKin",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "CabinId",
                table: "NextOfKin",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinId",
                table: "NextOfKin",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NextOfKin",
                table: "NextOfKin",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKin_CabinId",
                table: "NextOfKin",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKin_NextOfKinId",
                table: "NextOfKin",
                column: "NextOfKinId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_NextOfKin_CabinId",
                table: "NextOfKin");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKin_NextOfKinId",
                table: "NextOfKin");

            migrationBuilder.DropColumn(
                name: "CabinId",
                table: "NextOfKin");

            migrationBuilder.DropColumn(
                name: "NextOfKinId",
                table: "NextOfKin");

            migrationBuilder.RenameTable(
                name: "NextOfKin",
                newName: "NextOfKins");

            migrationBuilder.AlterColumn<bool>(
                name: "IsICE",
                table: "NextOfKins",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCampers",
                table: "NextOfKins",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                    CabinId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Campers_CabinId",
                table: "Campers",
                column: "CabinId");
        }
    }
}
