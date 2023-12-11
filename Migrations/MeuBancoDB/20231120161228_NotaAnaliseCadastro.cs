using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBancoBackend.Migrations.MeuBancoDB
{
    public partial class NotaAnaliseCadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotalSalario",
                table: "Emprestimo",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentualSalario",
                table: "Emprestimo",
                type: "DECIMAL(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotalSalario",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "PercentualSalario",
                table: "Emprestimo");
        }
    }
}
