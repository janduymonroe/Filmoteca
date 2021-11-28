using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmoteca.Migrations
{
    public partial class CargaInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "atores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    PaisOrigem = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "diretores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    PaisOrigem = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diretores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "espectadores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_espectadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produtoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "filmes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdDiretor = table.Column<int>(nullable: false),
                    AnoLancamento = table.Column<int>(nullable: false),
                    IdProdutora = table.Column<int>(nullable: false),
                    Imdb = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_filmes_diretores_IdDiretor",
                        column: x => x.IdDiretor,
                        principalTable: "diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_filmes_produtoras_IdProdutora",
                        column: x => x.IdProdutora,
                        principalTable: "produtoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "filmesassistidos",
                columns: table => new
                {
                    IdEspectador = table.Column<int>(nullable: false),
                    IdFilme = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filmesassistidos", x => new { x.IdEspectador, x.IdFilme });
                    table.ForeignKey(
                        name: "FK_filmesassistidos_espectadores_IdEspectador",
                        column: x => x.IdEspectador,
                        principalTable: "espectadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_filmesassistidos_filmes_IdFilme",
                        column: x => x.IdFilme,
                        principalTable: "filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_filmes_IdDiretor",
                table: "filmes",
                column: "IdDiretor");

            migrationBuilder.CreateIndex(
                name: "IX_filmes_IdProdutora",
                table: "filmes",
                column: "IdProdutora");

            migrationBuilder.CreateIndex(
                name: "IX_filmesassistidos_IdFilme",
                table: "filmesassistidos",
                column: "IdFilme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "atores");

            migrationBuilder.DropTable(
                name: "filmesassistidos");

            migrationBuilder.DropTable(
                name: "espectadores");

            migrationBuilder.DropTable(
                name: "filmes");

            migrationBuilder.DropTable(
                name: "diretores");

            migrationBuilder.DropTable(
                name: "produtoras");
        }
    }
}
