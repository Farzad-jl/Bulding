using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BacendBulding.Migrations
{
    public partial class subscribe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Corses",
                table: "Corses");

            migrationBuilder.RenameTable(
                name: "Corses",
                newName: "Corse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Corse",
                table: "Corse",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "subscibes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManageAccountMobile = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CorseId = table.Column<int>(type: "int", nullable: true),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscibes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Corse",
                table: "Corse");

            migrationBuilder.RenameTable(
                name: "Corse",
                newName: "Corses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Corses",
                table: "Corses",
                column: "Id");
        }
    }
}
