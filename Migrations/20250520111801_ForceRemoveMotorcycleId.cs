using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPMotoDrive.Migrations
{
    /// <inheritdoc />
    public partial class ForceRemoveMotorcycleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DECLARE @constraintName NVARCHAR(200);
          SELECT @constraintName = Name
          FROM sys.foreign_keys
          WHERE parent_object_id = OBJECT_ID('Orders') AND referenced_object_id = OBJECT_ID('Motorcycles');
          IF @constraintName IS NOT NULL
              EXEC('ALTER TABLE Orders DROP CONSTRAINT ' + @constraintName);");

            migrationBuilder.DropColumn(
                name: "MotorcycleId",
                table: "Orders");
        }

    }
}
