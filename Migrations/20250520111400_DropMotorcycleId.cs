using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPMotoDrive.Migrations
{
    /// <inheritdoc />
    public partial class DropMotorcycleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Motorcycles_MotorcycleId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MotorcycleId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotorcycleId",
                table: "Orders",
                type: "int",
                nullable: true); // или false, ако искаш задължително

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Motorcycles_MotorcycleId",
                table: "Orders",
                column: "MotorcycleId",
                principalTable: "Motorcycles",
                principalColumn: "Id");
        }
    }
}
