using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GPApp.Dal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sincronizado = table.Column<bool>(nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 15, nullable: true),
                    Nome = table.Column<string>(maxLength: 80, nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    Custo = table.Column<decimal>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sincronizado = table.Column<bool>(nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Senha = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    Celular = table.Column<string>(maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoEspecificacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sincronizado = table.Column<bool>(nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 40, nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Ordem = table.Column<short>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoEspecificacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoEspecificacao_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoEstoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sincronizado = table.Column<bool>(nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    Lancamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoEstoque_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoImagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sincronizado = table.Column<bool>(nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(nullable: false),
                    Prefixo = table.Column<string>(maxLength: 15, nullable: true),
                    Sufixo = table.Column<string>(maxLength: 4, nullable: true),
                    Dados = table.Column<byte[]>(nullable: true),
                    Ordem = table.Column<short>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoImagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoImagem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEspecificacao_ProdutoId",
                table: "ProdutoEspecificacao",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEstoque_ProdutoId",
                table: "ProdutoEstoque",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoImagem_ProdutoId",
                table: "ProdutoImagem",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoEspecificacao");

            migrationBuilder.DropTable(
                name: "ProdutoEstoque");

            migrationBuilder.DropTable(
                name: "ProdutoImagem");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
