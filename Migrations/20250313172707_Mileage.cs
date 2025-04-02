﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPMotoDrive.Migrations
{
    /// <inheritdoc />
    public partial class Mileage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Mileage",
                table: "Motorcycles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Motorcycles");
        }
    }
}
