using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeedWackerCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addColumnWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Works");
        }
    }
}
