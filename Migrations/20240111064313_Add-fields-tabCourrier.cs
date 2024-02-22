using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonCourriel.API.Migrations
{
    /// <inheritdoc />
    public partial class AddfieldstabCourrier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contenu",
                table: "Courriers",
                newName: "Statut");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Courriers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Courriers");

            migrationBuilder.RenameColumn(
                name: "Statut",
                table: "Courriers",
                newName: "Contenu");
        }
    }
}
