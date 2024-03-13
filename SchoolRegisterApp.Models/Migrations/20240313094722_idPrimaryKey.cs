using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SchoolRegisterApp.Models.Migrations
{
    /// <inheritdoc />
    public partial class idPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonHistories",
                table: "PersonHistories");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PersonHistories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "People",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonHistories",
                table: "PersonHistories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHistories_UserId",
                table: "PersonHistories",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonHistories",
                table: "PersonHistories");

            migrationBuilder.DropIndex(
                name: "IX_PersonHistories_UserId",
                table: "PersonHistories");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PersonHistories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "People",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonHistories",
                table: "PersonHistories",
                columns: new[] { "UserId", "PersonId" });
        }
    }
}
