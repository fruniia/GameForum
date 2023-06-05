using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamersParadiseAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "UserThreads",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "UserThreads");
        }
    }
}
