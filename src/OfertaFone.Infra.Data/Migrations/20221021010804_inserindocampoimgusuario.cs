using Microsoft.EntityFrameworkCore.Migrations;

namespace OfertaFone.Infra.Data.Migrations
{
    public partial class inserindocampoimgusuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Usuario");
        }
    }
}
