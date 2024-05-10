using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Pages",
                newName: "Pathname");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Languages",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pathname",
                table: "Pages",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Languages",
                newName: "Title");
        }
    }
}
