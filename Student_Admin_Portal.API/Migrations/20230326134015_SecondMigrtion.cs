using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Admin_Portal.API.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigrtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Moblie",
                table: "Student",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "FiratName",
                table: "Student",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "Student",
                newName: "Moblie");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Student",
                newName: "FiratName");
        }
    }
}
