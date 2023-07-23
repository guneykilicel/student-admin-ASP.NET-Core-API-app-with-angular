using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.API.Migrations
{
    /// <inheritdoc />
    public partial class Initialll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalAddress",
                table: "Address",
                newName: "PostalAdress");

            migrationBuilder.RenameColumn(
                name: "PhysicalAddress",
                table: "Address",
                newName: "PhysicalAdress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalAdress",
                table: "Address",
                newName: "PostalAddress");

            migrationBuilder.RenameColumn(
                name: "PhysicalAdress",
                table: "Address",
                newName: "PhysicalAddress");
        }
    }
}
