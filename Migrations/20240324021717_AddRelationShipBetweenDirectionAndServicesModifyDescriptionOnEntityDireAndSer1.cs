using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonCourriel.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShipBetweenDirectionAndServicesModifyDescriptionOnEntityDireAndSer1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desciption",
                table: "CompagnyDirections",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CompagnyDirections",
                newName: "Desciption");
        }
    }
}
