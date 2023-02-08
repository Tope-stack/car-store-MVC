using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsMVC.Migrations
{
    /// <inheritdoc />
    public partial class ThirdUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Honda",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "Toyota",
                table: "Car",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
