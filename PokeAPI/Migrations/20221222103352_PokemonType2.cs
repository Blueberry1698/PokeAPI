using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeAPI.Migrations
{
    /// <inheritdoc />
    public partial class PokemonType2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Type_TypeID",
                table: "Pokemon");

            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "Pokemon",
                newName: "Type2TypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Pokemon_TypeID",
                table: "Pokemon",
                newName: "IX_Pokemon_Type2TypeID");

            migrationBuilder.AddColumn<int>(
                name: "Type1TypeID",
                table: "Pokemon",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_Type1TypeID",
                table: "Pokemon",
                column: "Type1TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Type_Type1TypeID",
                table: "Pokemon",
                column: "Type1TypeID",
                principalTable: "Type",
                principalColumn: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Type_Type2TypeID",
                table: "Pokemon",
                column: "Type2TypeID",
                principalTable: "Type",
                principalColumn: "TypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Type_Type1TypeID",
                table: "Pokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Type_Type2TypeID",
                table: "Pokemon");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_Type1TypeID",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Type1TypeID",
                table: "Pokemon");

            migrationBuilder.RenameColumn(
                name: "Type2TypeID",
                table: "Pokemon",
                newName: "TypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Pokemon_Type2TypeID",
                table: "Pokemon",
                newName: "IX_Pokemon_TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Type_TypeID",
                table: "Pokemon",
                column: "TypeID",
                principalTable: "Type",
                principalColumn: "TypeID");
        }
    }
}
