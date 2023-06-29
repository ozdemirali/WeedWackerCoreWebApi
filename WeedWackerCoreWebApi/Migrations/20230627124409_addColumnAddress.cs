using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeedWackerCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addColumnAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Addresses");
        }
    }
}
