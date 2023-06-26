using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeedWackerCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class editDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Works",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Users",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "EmployerSetting",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "EmployerOffers",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Addresses",
                newName: "ModifiedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Works",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Users",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "EmployerSetting",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "EmployerOffers",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Addresses",
                newName: "Modified");
        }
    }
}
