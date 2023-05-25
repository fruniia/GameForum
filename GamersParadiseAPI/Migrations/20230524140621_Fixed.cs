using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamersParadiseAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "Comments",
                newName: "UserThreadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserThreadId",
                table: "Comments",
                newName: "SubCategoryId");
        }
    }
}
