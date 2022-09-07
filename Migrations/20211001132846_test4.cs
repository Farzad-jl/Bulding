using Microsoft.EntityFrameworkCore.Migrations;

namespace BacendBulding.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    AccountMobile = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitNumber = table.Column<int>(type: "int", nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.AccountMobile);
                    table.ForeignKey(
                        name: "FK_Buildings_Manages_AccountMobile",
                        column: x => x.AccountMobile,
                        principalTable: "Manages",
                        principalColumn: "AccountMobile",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
