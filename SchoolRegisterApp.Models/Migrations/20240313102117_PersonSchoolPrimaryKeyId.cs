using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SchoolRegisterApp.Models.Migrations
{
    /// <inheritdoc />
    public partial class PersonSchoolPrimaryKeyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSchools",
                table: "PersonSchools");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PersonSchools",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSchools",
                table: "PersonSchools",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSchools_PersonId",
                table: "PersonSchools",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSchools",
                table: "PersonSchools");

            migrationBuilder.DropIndex(
                name: "IX_PersonSchools_PersonId",
                table: "PersonSchools");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PersonSchools",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSchools",
                table: "PersonSchools",
                columns: new[] { "PersonId", "SchoolId" });
        }
    }
}
