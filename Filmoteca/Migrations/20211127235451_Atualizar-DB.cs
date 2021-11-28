using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmoteca.Migrations
{
    public partial class AtualizarDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_filmes_produtoras_IdProdutora",
                table: "filmes");

            migrationBuilder.DropTable(
                name: "atores");

            migrationBuilder.DropTable(
                name: "produtoras");

            migrationBuilder.DropIndex(
                name: "IX_filmes_IdProdutora",
                table: "filmes");

            migrationBuilder.DropColumn(
                name: "IdProdutora",
                table: "filmes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProdutora",
                table: "filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "atores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    PaisOrigem = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produtoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtoras", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_filmes_IdProdutora",
                table: "filmes",
                column: "IdProdutora");

            migrationBuilder.AddForeignKey(
                name: "FK_filmes_produtoras_IdProdutora",
                table: "filmes",
                column: "IdProdutora",
                principalTable: "produtoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
