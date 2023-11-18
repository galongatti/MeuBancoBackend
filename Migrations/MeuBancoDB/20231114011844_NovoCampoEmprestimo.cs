using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBancoBackend.Migrations.MeuBancoDB
{
    public partial class NovoCampoEmprestimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotaSERASA",
                table: "Emprestimo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScoreSERASA",
                table: "Emprestimo",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaSERASA",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "ScoreSERASA",
                table: "Emprestimo");
        }
    }
}
