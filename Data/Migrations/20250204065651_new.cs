using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPMotoDrive.Data.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Models_ModelId",
                table: "Motorcycles");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Models_ModelId",
                table: "Motorcycles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Models_ModelId",
                table: "Motorcycles");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Models_ModelId",
                table: "Motorcycles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
