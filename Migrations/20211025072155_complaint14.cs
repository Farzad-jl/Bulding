using Microsoft.EntityFrameworkCore.Migrations;

namespace BacendBulding.Migrations
{
    public partial class complaint14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Manages_AccountMobile",
                table: "Buildings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Residents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AccountMobile",
                table: "Buildings",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_BuildingId",
                table: "Residents",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_AccountMobile",
                table: "Buildings",
                column: "AccountMobile",
                unique: true,
                filter: "[AccountMobile] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Manages_AccountMobile",
                table: "Buildings",
                column: "AccountMobile",
                principalTable: "Manages",
                principalColumn: "AccountMobile",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Buildings_BuildingId",
                table: "Residents",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Manages_AccountMobile",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Buildings_BuildingId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_BuildingId",
                table: "Residents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_AccountMobile",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Buildings");

            migrationBuilder.AlterColumn<string>(
                name: "AccountMobile",
                table: "Buildings",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "AccountMobile");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Manages_AccountMobile",
                table: "Buildings",
                column: "AccountMobile",
                principalTable: "Manages",
                principalColumn: "AccountMobile",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
