using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BacendBulding.Migrations
{
    public partial class subscribe1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscibes");

            migrationBuilder.DropTable(
                name: "Corse");

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: true),
                    ResidentAccountMobile = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    SubscribeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscribes_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscribes_Residents_ResidentAccountMobile",
                        column: x => x.ResidentAccountMobile,
                        principalTable: "Residents",
                        principalColumn: "AccountMobile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_BuildingId",
                table: "Subscribes",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_ResidentAccountMobile",
                table: "Subscribes",
                column: "ResidentAccountMobile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.CreateTable(
                name: "Corse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Praticaltime = table.Column<int>(type: "int", nullable: false),
                    TheoryTime = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subscibes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorseId = table.Column<int>(type: "int", nullable: true),
                    ManageAccountMobile = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    SubscribeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscibes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subscibes_Corse_CorseId",
                        column: x => x.CorseId,
                        principalTable: "Corse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subscibes_Manages_ManageAccountMobile",
                        column: x => x.ManageAccountMobile,
                        principalTable: "Manages",
                        principalColumn: "AccountMobile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subscibes_CorseId",
                table: "subscibes",
                column: "CorseId");

            migrationBuilder.CreateIndex(
                name: "IX_subscibes_ManageAccountMobile",
                table: "subscibes",
                column: "ManageAccountMobile");
        }
    }
}
