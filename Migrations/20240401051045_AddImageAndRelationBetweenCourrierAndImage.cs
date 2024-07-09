using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonCourriel.API.Migrations
{
    /// <inheritdoc />
    public partial class AddImageAndRelationBetweenCourrierAndImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourrierImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NameImg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourrierId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourrierImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourrierImages_Courriers_CourrierId",
                        column: x => x.CourrierId,
                        principalTable: "Courriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CourrierImages_CourrierId",
                table: "CourrierImages",
                column: "CourrierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourrierImages");
        }
    }
}
