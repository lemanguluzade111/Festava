﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festava.Migrations
{
    /// <inheritdoc />
    public partial class CreateAboutsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");
        }
    }
}
