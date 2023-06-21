using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeedWackerCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class initalTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployerSetting_Users_UserId",
                table: "EmployerSetting");

            migrationBuilder.DropIndex(
                name: "IX_EmployerSetting_UserId",
                table: "EmployerSetting");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmployerSetting");

            migrationBuilder.AddColumn<string>(
                name: "EmployerSettingId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployerSettingId",
                table: "Users",
                column: "EmployerSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EmployerSetting_EmployerSettingId",
                table: "Users",
                column: "EmployerSettingId",
                principalTable: "EmployerSetting",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_EmployerSetting_EmployerSettingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployerSettingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployerSettingId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EmployerSetting",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployerSetting_UserId",
                table: "EmployerSetting",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployerSetting_Users_UserId",
                table: "EmployerSetting",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
