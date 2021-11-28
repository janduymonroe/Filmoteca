using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmoteca.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "filmes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_filmes_FilmeId",
                table: "filmes",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_filmes_filmes_FilmeId",
                table: "filmes",
                column: "FilmeId",
                principalTable: "filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_filmes_filmes_FilmeId",
                table: "filmes");

            migrationBuilder.DropIndex(
                name: "IX_filmes_FilmeId",
                table: "filmes");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "filmes");
        }
    }
}
