using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coodesh_Pokemon.Migrations
{
    /// <inheritdoc />
    public partial class RenameTypesToPokemonTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Types",
                table: "PokemonCaptures",
                newName: "PokemonTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PokemonTypes",
                table: "PokemonCaptures",
                newName: "Types");
        }
    }
}
