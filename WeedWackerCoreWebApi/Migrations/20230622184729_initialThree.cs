﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeedWackerCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class initialThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCodes",
                table: "PostCodes");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PostCodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PostCodes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCodes",
                table: "PostCodes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCodes",
                table: "PostCodes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostCodes");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PostCodes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCodes",
                table: "PostCodes",
                column: "Code");
        }
    }
}
