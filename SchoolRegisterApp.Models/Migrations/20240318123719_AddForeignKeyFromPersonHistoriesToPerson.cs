using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolRegisterApp.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyFromPersonHistoriesToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_People_SchoolId",
                table: "People",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Schools_SchoolId",
                table: "People",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Schools_SchoolId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_SchoolId",
                table: "People");
        }
    }
}
