using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolRegisterApp.Models.Migrations
{
    /// <inheritdoc />
    public partial class PersonSchools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personSchools_People_PersonId",
                table: "personSchools");

            migrationBuilder.DropForeignKey(
                name: "FK_personSchools_Schools_SchoolId",
                table: "personSchools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_personSchools",
                table: "personSchools");

            migrationBuilder.RenameTable(
                name: "personSchools",
                newName: "PersonSchools");

            migrationBuilder.RenameIndex(
                name: "IX_personSchools_SchoolId",
                table: "PersonSchools",
                newName: "IX_PersonSchools_SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSchools",
                table: "PersonSchools",
                columns: new[] { "PersonId", "SchoolId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSchools_People_PersonId",
                table: "PersonSchools",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSchools_Schools_SchoolId",
                table: "PersonSchools",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonSchools_People_PersonId",
                table: "PersonSchools");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSchools_Schools_SchoolId",
                table: "PersonSchools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSchools",
                table: "PersonSchools");

            migrationBuilder.RenameTable(
                name: "PersonSchools",
                newName: "personSchools");

            migrationBuilder.RenameIndex(
                name: "IX_PersonSchools_SchoolId",
                table: "personSchools",
                newName: "IX_personSchools_SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_personSchools",
                table: "personSchools",
                columns: new[] { "PersonId", "SchoolId" });

            migrationBuilder.AddForeignKey(
                name: "FK_personSchools_People_PersonId",
                table: "personSchools",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personSchools_Schools_SchoolId",
                table: "personSchools",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
