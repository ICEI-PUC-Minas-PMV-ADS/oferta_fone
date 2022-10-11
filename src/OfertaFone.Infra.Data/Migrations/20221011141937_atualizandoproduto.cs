using Microsoft.EntityFrameworkCore.Migrations;

namespace OfertaFone.Infra.Data.Migrations
{
    public partial class atualizandoproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ProdutoEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "ProdutoEntity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "ProdutoEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ProdutoEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "ProdutoEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEntity_UsuarioId",
                table: "ProdutoEntity",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEntity_Usuario_UsuarioId",
                table: "ProdutoEntity",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEntity_Usuario_UsuarioId",
                table: "ProdutoEntity");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoEntity_UsuarioId",
                table: "ProdutoEntity");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "ProdutoEntity");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "ProdutoEntity");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ProdutoEntity");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "ProdutoEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ProdutoEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
