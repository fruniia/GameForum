using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamersParadiseAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedReported : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reported",
                table: "UserThreads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reported",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reported",
                table: "UserThreads");

            migrationBuilder.DropColumn(
                name: "Reported",
                table: "Comments");
        }
    }
}
