using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festava.Migrations
{
    /// <inheritdoc />
    public partial class AddButtonColumnToTitlesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Button",
                table: "Titles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Button",
                table: "Titles");
        }
    }
}
