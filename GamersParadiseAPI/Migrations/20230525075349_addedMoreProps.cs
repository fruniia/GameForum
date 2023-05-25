using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamersParadiseAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedMoreProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Comments",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedDate",
                table: "UserThreads",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserThreads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedDate",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "UserThreads");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserThreads");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Comments",
                newName: "Date");
        }
    }
}
