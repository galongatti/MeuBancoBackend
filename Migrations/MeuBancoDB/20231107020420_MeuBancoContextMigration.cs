using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBancoBackend.Migrations.MeuBancoDB
{
    public partial class MeuBancoContextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    IdPessoa = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiroNome = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Sobrenome = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "DATE", nullable: true),
                    CPF = table.Column<string>(type: "VARCHAR(14)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RendaBruta = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.IdPessoa);
                    table.ForeignKey(
                        name: "FK_PESSOA_USUARIO",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    IdEmprestimo = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSolicitacao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ValorSolicitado = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: true),
                    ValorAprovado = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: true),
                    IdPessoa = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.IdEmprestimo);
                    table.ForeignKey(
                        name: "FK_EMPRESTIMO_PESSOA",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdPessoa",
                table: "Emprestimo",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_IdUsuario",
                table: "Pessoa",
                column: "IdUsuario",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
