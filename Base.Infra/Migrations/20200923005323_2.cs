using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Infra.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Assunto_Id",
                table: "LivroAssunto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Livro_Id",
                table: "LivroAssunto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assunto_Id",
                table: "LivroAssunto");

            migrationBuilder.DropColumn(
                name: "Livro_Id",
                table: "LivroAssunto");
        }
    }
}
