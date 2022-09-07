using Microsoft.EntityFrameworkCore.Migrations;

namespace BacendBulding.Migrations
{
    public partial class complaint11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Residents_ResidentId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Accounts_AccountMobile",
                table: "Residents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Residents",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_AccountMobile",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ResidentId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "Complaints");

            migrationBuilder.AlterColumn<string>(
                name: "AccountMobile",
                table: "Residents",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidentAccountMobile",
                table: "Complaints",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Residents",
                table: "Residents",
                column: "AccountMobile");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Accounts_AccountMobile",
                table: "Residents",
                column: "AccountMobile",
                principalTable: "Accounts",
                principalColumn: "Mobile",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Residents_ResidentAccountMobile",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Accounts_AccountMobile",
                table: "Residents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Residents",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ResidentAccountMobile",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ResidentAccountMobile",
                table: "Complaints");

            migrationBuilder.AlterColumn<string>(
                name: "AccountMobile",
                table: "Residents",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Residents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "Complaints",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Residents",
                table: "Residents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_AccountMobile",
                table: "Residents",
                column: "AccountMobile",
                unique: true,
                filter: "[AccountMobile] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Accounts_AccountMobile",
                table: "Residents",
                column: "AccountMobile",
                principalTable: "Accounts",
                principalColumn: "Mobile",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
