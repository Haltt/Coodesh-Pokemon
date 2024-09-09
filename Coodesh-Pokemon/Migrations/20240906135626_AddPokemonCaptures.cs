using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coodesh_Pokemon.Migrations
{
    /// <inheritdoc />
    public partial class AddPokemonCaptures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonCaptures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonMasterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCaptures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonCaptures_PokemonMasters_PokemonMasterId",
                        column: x => x.PokemonMasterId,
                        principalTable: "PokemonMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCaptures_PokemonMasterId",
                table: "PokemonCaptures",
                column: "PokemonMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonCaptures");
        }
    }
}
