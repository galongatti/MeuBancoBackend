using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBancoBackend.Migrations.MeuBancoDB
{
    public partial class NotaAnaliseCadastro2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotalSalario",
                table: "Emprestimo",
                newName: "NotaSalario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotaSalario",
                table: "Emprestimo",
                newName: "NotalSalario");
        }
    }
}
