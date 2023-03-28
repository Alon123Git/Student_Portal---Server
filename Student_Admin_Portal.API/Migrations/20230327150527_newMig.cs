using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Admin_Portal.API.Migrations
{
    /// <inheritdoc />
    public partial class newMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalAdress",
                table: "Adress",
                newName: "PostalAddress");

            migrationBuilder.RenameColumn(
                name: "PhysicalAdress",
                table: "Adress",
                newName: "PhysicalAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalAddress",
                table: "Adress",
                newName: "PostalAdress");

            migrationBuilder.RenameColumn(
                name: "PhysicalAddress",
                table: "Adress",
                newName: "PhysicalAdress");
        }
    }
}
