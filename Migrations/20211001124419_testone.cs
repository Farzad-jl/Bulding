using Microsoft.EntityFrameworkCore.Migrations;

namespace BacendBulding.Migrations
{
    public partial class testone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Mobile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Mobile);
                });

            migrationBuilder.CreateTable(
                name: "Manages",
                columns: table => new
                {
                    AccountMobile = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manages", x => x.AccountMobile);
                    table.ForeignKey(
                        name: "FK_Manages_Accounts_AccountMobile",
                        column: x => x.AccountMobile,
                        principalTable: "Accounts",
                        principalColumn: "Mobile",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manages");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
