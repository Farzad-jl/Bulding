using Microsoft.EntityFrameworkCore.Migrations;

namespace BacendBulding.Migrations
{
    public partial class complaint13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Residents_AccountMobile",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_AccountMobile",
                table: "Complaints");

            migrationBuilder.AlterColumn<string>(
                name: "AccountMobile",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidentAccountMobile",
                table: "Complaints",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ResidentAccountMobile",
                table: "Complaints",
                column: "ResidentAccountMobile");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Residents_ResidentAccountMobile",
                table: "Complaints",
                column: "ResidentAccountMobile",
                principalTable: "Residents",
                principalColumn: "AccountMobile",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Residents_ResidentAccountMobile",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ResidentAccountMobile",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ResidentAccountMobile",
                table: "Complaints");

            migrationBuilder.AlterColumn<string>(
                name: "AccountMobile",
                table: "Complaints",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_AccountMobile",
                table: "Complaints",
                column: "AccountMobile",
                unique: true,
                filter: "[AccountMobile] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Residents_AccountMobile",
                table: "Complaints",
                column: "AccountMobile",
                principalTable: "Residents",
                principalColumn: "AccountMobile",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
