using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festava.Migrations
{
    /// <inheritdoc />
    public partial class AddImageTitleColumnToAboutsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageText",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageTitle",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageText",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "ImageTitle",
                table: "Abouts");
        }
    }
}
