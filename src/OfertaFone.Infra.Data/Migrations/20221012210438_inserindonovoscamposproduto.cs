using Microsoft.EntityFrameworkCore.Migrations;

namespace OfertaFone.Infra.Data.Migrations
{
    public partial class inserindonovoscamposproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Camera",
                table: "ProdutoEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detalhes",
                table: "ProdutoEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "ProdutoEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memoria",
                table: "ProdutoEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "ProdutoEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Processador",
                table: "ProdutoEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RAM",
                table: "ProdutoEntity",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Camera",
                table: "ProdutoEntity");

            migrationBuilder.DropColumn(
                name: "Detalhes",
                table: "ProdutoEntity");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "ProdutoEntity");

            migrationBuilder.DropColumn(
                name: "Memoria",
                table: "ProdutoEntity");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "ProdutoEntity");

            migrationBuilder.DropColumn(
                name: "Processador",
                table: "ProdutoEntity");

            migrationBuilder.DropColumn(
                name: "RAM",
                table: "ProdutoEntity");
        }
    }
}
