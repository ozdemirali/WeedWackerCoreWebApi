using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeedWackerCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addColumnOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "EmployerOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "EmployerOffers");
        }
    }
}
