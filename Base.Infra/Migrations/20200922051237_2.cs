using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Infra.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "livro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(maxLength: 40, nullable: false),
                    Editora = table.Column<string>(maxLength: 40, nullable: false),
                    Edicao = table.Column<int>(nullable: false),
                    AnoPublicacao = table.Column<string>(maxLength: 40, nullable: false),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "assunto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    LivroId = table.Column<int>(nullable: true),
                    Livro_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assunto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_assunto_livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "autor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    LivroId = table.Column<int>(nullable: true),
                    Livro_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_autor_livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LivroAssunto",
                columns: table => new
                {
                    Livro_Id = table.Column<int>(nullable: false),
                    Assunto_Id = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAssunto", x => new { x.Livro_Id, x.Assunto_Id });
                    table.ForeignKey(
                        name: "FK_LivroAssunto_assunto_Id",
                        column: x => x.Id,
                        principalTable: "assunto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAssunto_livro_Id",
                        column: x => x.Id,
                        principalTable: "livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                columns: table => new
                {
                    Livro_Id = table.Column<int>(nullable: false),
                    Autor_Id = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAutor", x => new { x.Livro_Id, x.Autor_Id });
                    table.ForeignKey(
                        name: "FK_LivroAutor_autor_Id",
                        column: x => x.Id,
                        principalTable: "autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAutor_livro_Id",
                        column: x => x.Id,
                        principalTable: "livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assunto_LivroId",
                table: "assunto",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_autor_LivroId",
                table: "autor",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_Id",
                table: "LivroAssunto",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_Id",
                table: "LivroAutor",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAssunto");

            migrationBuilder.DropTable(
                name: "LivroAutor");

            migrationBuilder.DropTable(
                name: "assunto");

            migrationBuilder.DropTable(
                name: "autor");

            migrationBuilder.DropTable(
                name: "livro");
        }
    }
}
