using Microsoft.EntityFrameworkCore.Migrations;

namespace BacendBulding.Migrations
{
    public partial class complaint7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Residents_ResidentId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ResidentId",
                table: "Complaints");

            migrationBuilder.AlterColumn<int>(
                name: "ResidentId",
                table: "Complaints",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ResidentId",
                table: "Complaints",
                column: "ResidentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Residents_ResidentId",
                table: "Complaints",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Residents_ResidentId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ResidentId",
                table: "Complaints");

            migrationBuilder.AlterColumn<int>(
                name: "ResidentId",
                table: "Complaints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ResidentId",
                table: "Complaints",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Residents_ResidentId",
                table: "Complaints",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
