﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Infra.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "LivroAssunto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LivroId = table.Column<int>(nullable: true),
                    AssuntoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAssunto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivroAssunto_assunto_AssuntoId",
                        column: x => x.AssuntoId,
                        principalTable: "assunto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LivroAssunto_livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Livro_Id = table.Column<int>(nullable: false),
                    Autor_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivroAutor_autor_Autor_Id",
                        column: x => x.Autor_Id,
                        principalTable: "autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAutor_livro_Livro_Id",
                        column: x => x.Livro_Id,
                        principalTable: "livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_AssuntoId",
                table: "LivroAssunto",
                column: "AssuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_LivroId",
                table: "LivroAssunto",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_Autor_Id",
                table: "LivroAutor",
                column: "Autor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_Livro_Id",
                table: "LivroAutor",
                column: "Livro_Id");
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
