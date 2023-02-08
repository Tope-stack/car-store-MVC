using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsMVC.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Car",
                newName: "Toyota");

            migrationBuilder.AddColumn<int>(
                name: "Honda",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Honda",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "Toyota",
                table: "Car",
                newName: "Name");
        }
    }
}
