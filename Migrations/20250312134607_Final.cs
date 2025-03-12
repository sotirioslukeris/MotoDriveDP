using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPMotoDrive.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryOfManuf",
                table: "Models",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearOfManuf",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryOfManuf",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "YearOfManuf",
                table: "Models");
        }
    }
}
