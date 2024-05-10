using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festava.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeactiveColumnToPriceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeactive",
                table: "Prices",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeactive",
                table: "Prices");
        }
    }
}
