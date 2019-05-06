using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagerAPI.Migrations
{
    public partial class curso_disciplina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_CargasHorarias_CargaHorariaId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_CargaHorariaId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "CargaHorariaId",
                table: "Cursos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Usuarios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "TiposTelefones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Telefones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Cursos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Cursos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "CargasHorarias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    CargaHorariaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_CargasHorarias_CargaHorariaId",
                        column: x => x.CargaHorariaId,
                        principalTable: "CargasHorarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoDisciplina",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoDisciplina", x => new { x.CursoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplina_DisciplinaId",
                table: "CursoDisciplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CargaHorariaId",
                table: "Disciplinas",
                column: "CargaHorariaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoDisciplina");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "TiposTelefones");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "CargasHorarias");

            migrationBuilder.AddColumn<int>(
                name: "CargaHorariaId",
                table: "Cursos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CargaHorariaId",
                table: "Cursos",
                column: "CargaHorariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_CargasHorarias_CargaHorariaId",
                table: "Cursos",
                column: "CargaHorariaId",
                principalTable: "CargasHorarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
