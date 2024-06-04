using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Fone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentoProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentoProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    NomeUsuario = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasAReceber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true),
                    Valor = table.Column<float>(type: "REAL", nullable: false),
                    ValorRecebido = table.Column<float>(type: "REAL", nullable: false),
                    ValorAReceber = table.Column<float>(type: "REAL", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasAReceber_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalDosProdutos = table.Column<float>(type: "REAL", nullable: false),
                    ValorDesconto = table.Column<float>(type: "REAL", nullable: false),
                    ValorAcrescimo = table.Column<float>(type: "REAL", nullable: false),
                    ValorTotal = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GrupoProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    DepartamentoProdutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoProduto_DepartamentoProduto_DepartamentoProdutoId",
                        column: x => x.DepartamentoProdutoId,
                        principalTable: "DepartamentoProduto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FornecedorId = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalDosProdutos = table.Column<float>(type: "REAL", nullable: false),
                    ValorDesconto = table.Column<float>(type: "REAL", nullable: false),
                    ValorAcrescimo = table.Column<float>(type: "REAL", nullable: false),
                    ValorFrete = table.Column<float>(type: "REAL", nullable: false),
                    ValorTotal = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compra_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContasAPagar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FornecedorId = table.Column<int>(type: "INTEGER", nullable: true),
                    Valor = table.Column<float>(type: "REAL", nullable: false),
                    ValorPago = table.Column<float>(type: "REAL", nullable: false),
                    ValorAPagar = table.Column<float>(type: "REAL", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAPagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasAPagar_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GrupoUsuarioPermissao",
                columns: table => new
                {
                    GrupoUsuarioListId = table.Column<int>(type: "INTEGER", nullable: false),
                    PermissaoListMyPropertyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUsuarioPermissao", x => new { x.GrupoUsuarioListId, x.PermissaoListMyPropertyId });
                    table.ForeignKey(
                        name: "FK_GrupoUsuarioPermissao_GrupoUsuario_GrupoUsuarioListId",
                        column: x => x.GrupoUsuarioListId,
                        principalTable: "GrupoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoUsuarioPermissao_Permissao_PermissaoListMyPropertyId",
                        column: x => x.PermissaoListMyPropertyId,
                        principalTable: "Permissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupoUsuarioUsuario",
                columns: table => new
                {
                    GrupoUsuarioListId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioListId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUsuarioUsuario", x => new { x.GrupoUsuarioListId, x.UsuarioListId });
                    table.ForeignKey(
                        name: "FK_GrupoUsuarioUsuario_GrupoUsuario_GrupoUsuarioListId",
                        column: x => x.GrupoUsuarioListId,
                        principalTable: "GrupoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoUsuarioUsuario_Usuario_UsuarioListId",
                        column: x => x.UsuarioListId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemContasAPagar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContasAReceberId = table.Column<int>(type: "INTEGER", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "INTEGER", nullable: true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemContasAPagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemContasAPagar_ContasAReceber_ContasAReceberId",
                        column: x => x.ContasAReceberId,
                        principalTable: "ContasAReceber",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemContasAPagar_FormaPagamento_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemContasAPagar_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubGrupoProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    GrupoProdutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGrupoProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGrupoProduto_GrupoProduto_GrupoProdutoId",
                        column: x => x.GrupoProdutoId,
                        principalTable: "GrupoProduto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemContasAReceber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContasAReceberId = table.Column<int>(type: "INTEGER", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "INTEGER", nullable: true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: true),
                    ContasAPagarId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemContasAReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemContasAReceber_ContasAPagar_ContasAPagarId",
                        column: x => x.ContasAPagarId,
                        principalTable: "ContasAPagar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemContasAReceber_ContasAReceber_ContasAReceberId",
                        column: x => x.ContasAReceberId,
                        principalTable: "ContasAReceber",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemContasAReceber_FormaPagamento_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemContasAReceber_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Preco = table.Column<float>(type: "REAL", nullable: false),
                    Estoque = table.Column<float>(type: "REAL", nullable: false),
                    MarcaId = table.Column<int>(type: "INTEGER", nullable: true),
                    CategoriaProdutoId = table.Column<int>(type: "INTEGER", nullable: true),
                    SubGrupoProdutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_CategoriaProduto_CategoriaProdutoId",
                        column: x => x.CategoriaProdutoId,
                        principalTable: "CategoriaProduto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produto_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produto_SubGrupoProduto_SubGrupoProdutoId",
                        column: x => x.SubGrupoProdutoId,
                        principalTable: "SubGrupoProduto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FixaKardex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: true),
                    VendaId = table.Column<int>(type: "INTEGER", nullable: true),
                    CompraId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantidade = table.Column<double>(type: "REAL", nullable: false),
                    EstoqueAnterior = table.Column<double>(type: "REAL", nullable: false),
                    EstoqueAtual = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixaKardex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixaKardex_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FixaKardex_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FixaKardex_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompraId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantidade = table.Column<float>(type: "REAL", nullable: false),
                    ValorDesconto = table.Column<float>(type: "REAL", nullable: false),
                    ValorAcrescimo = table.Column<float>(type: "REAL", nullable: false),
                    ValorFrete = table.Column<float>(type: "REAL", nullable: false),
                    ValorTotal = table.Column<float>(type: "REAL", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCompra_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemCompra_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemVenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VendaId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantidade = table.Column<float>(type: "REAL", nullable: false),
                    ValorDesconto = table.Column<float>(type: "REAL", nullable: false),
                    ValorAcrescimo = table.Column<float>(type: "REAL", nullable: false),
                    ValorTotal = table.Column<float>(type: "REAL", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemVenda_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CategoriaProduto",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Novo" },
                    { 2, "Usado" }
                });

            migrationBuilder.InsertData(
                table: "GrupoUsuario",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Operador de caixa" },
                    { 3, "Estoquista" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "Nome", "NomeUsuario", "Senha" },
                values: new object[,]
                {
                    { 1, true, "Administrador", "admin", "123456" },
                    { 2, true, "Vendedor", "vendedor", "123456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_FornecedorId",
                table: "Compra",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAPagar_FornecedorId",
                table: "ContasAPagar",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_ClienteId",
                table: "ContasAReceber",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_FixaKardex_CompraId",
                table: "FixaKardex",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_FixaKardex_ProdutoId",
                table: "FixaKardex",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_FixaKardex_VendaId",
                table: "FixaKardex",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoProduto_DepartamentoProdutoId",
                table: "GrupoProduto",
                column: "DepartamentoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoUsuarioPermissao_PermissaoListMyPropertyId",
                table: "GrupoUsuarioPermissao",
                column: "PermissaoListMyPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoUsuarioUsuario_UsuarioListId",
                table: "GrupoUsuarioUsuario",
                column: "UsuarioListId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompra_CompraId",
                table: "ItemCompra",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompra_ProdutoId",
                table: "ItemCompra",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemContasAPagar_ContasAReceberId",
                table: "ItemContasAPagar",
                column: "ContasAReceberId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemContasAPagar_FormaPagamentoId",
                table: "ItemContasAPagar",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemContasAPagar_UsuarioId",
                table: "ItemContasAPagar",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemContasAReceber_ContasAPagarId",
                table: "ItemContasAReceber",
                column: "ContasAPagarId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemContasAReceber_ContasAReceberId",
                table: "ItemContasAReceber",
                column: "ContasAReceberId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemContasAReceber_FormaPagamentoId",
                table: "ItemContasAReceber",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemContasAReceber_UsuarioId",
                table: "ItemContasAReceber",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "ItemVenda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_VendaId",
                table: "ItemVenda",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaProdutoId",
                table: "Produto",
                column: "CategoriaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_MarcaId",
                table: "Produto",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_SubGrupoProdutoId",
                table: "Produto",
                column: "SubGrupoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGrupoProduto_GrupoProdutoId",
                table: "SubGrupoProduto",
                column: "GrupoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteId",
                table: "Venda",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FixaKardex");

            migrationBuilder.DropTable(
                name: "GrupoUsuarioPermissao");

            migrationBuilder.DropTable(
                name: "GrupoUsuarioUsuario");

            migrationBuilder.DropTable(
                name: "ItemCompra");

            migrationBuilder.DropTable(
                name: "ItemContasAPagar");

            migrationBuilder.DropTable(
                name: "ItemContasAReceber");

            migrationBuilder.DropTable(
                name: "ItemVenda");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "GrupoUsuario");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "ContasAPagar");

            migrationBuilder.DropTable(
                name: "ContasAReceber");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "CategoriaProduto");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "SubGrupoProduto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "GrupoProduto");

            migrationBuilder.DropTable(
                name: "DepartamentoProduto");
        }
    }
}
