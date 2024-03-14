using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolRegisterApp.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddSchoolIdToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "People",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "People");
        }
    }
}
