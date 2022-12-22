using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeAPI.Migrations
{
    /// <inheritdoc />
    public partial class PokemonType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Pokemon",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_TypeID",
                table: "Pokemon",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Type_TypeID",
                table: "Pokemon",
                column: "TypeID",
                principalTable: "Type",
                principalColumn: "TypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Type_TypeID",
                table: "Pokemon");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_TypeID",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Pokemon");
        }
    }
}
