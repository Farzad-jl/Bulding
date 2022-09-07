using Microsoft.EntityFrameworkCore.Migrations;

namespace BacendBulding.Migrations
{
    public partial class complaint12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Residents_ResidentAccountMobile",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ResidentAccountMobile",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "ResidentAccountMobile",
                table: "Complaints",
                newName: "AccountMobile");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Residents_AccountMobile",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_AccountMobile",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "AccountMobile",
                table: "Complaints",
                newName: "ResidentAccountMobile");

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
    }
}
