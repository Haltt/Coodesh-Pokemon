using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coodesh_Pokemon.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToPokemonCapture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PokemonName",
                table: "PokemonCaptures",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PokemonSprite",
                table: "PokemonCaptures",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Types",
                table: "PokemonCaptures",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PokemonName",
                table: "PokemonCaptures");

            migrationBuilder.DropColumn(
                name: "PokemonSprite",
                table: "PokemonCaptures");

            migrationBuilder.DropColumn(
                name: "Types",
                table: "PokemonCaptures");
        }
    }
}
