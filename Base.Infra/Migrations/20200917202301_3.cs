using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Infra.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "livro");

            migrationBuilder.AddColumn<string>(
                name: "AnoPublicacao",
                table: "livro",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Edicao",
                table: "livro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Editora",
                table: "livro",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "livro",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "assunto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assunto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "autor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assunto");

            migrationBuilder.DropTable(
                name: "autor");

            migrationBuilder.DropColumn(
                name: "AnoPublicacao",
                table: "livro");

            migrationBuilder.DropColumn(
                name: "Edicao",
                table: "livro");

            migrationBuilder.DropColumn(
                name: "Editora",
                table: "livro");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "livro");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "livro",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
