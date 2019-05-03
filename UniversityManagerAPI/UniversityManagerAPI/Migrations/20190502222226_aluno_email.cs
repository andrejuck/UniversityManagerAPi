using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagerAPI.Migrations
{
    public partial class aluno_email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Alunos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Alunos");
        }
    }
}
