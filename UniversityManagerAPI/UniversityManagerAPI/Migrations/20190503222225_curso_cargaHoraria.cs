using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagerAPI.Migrations
{
    public partial class curso_cargaHoraria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargasHorarias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuantidadeHoras = table.Column<int>(nullable: false),
                    CustoBase = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargasHorarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    CargaHorariaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_CargasHorarias_CargaHorariaId",
                        column: x => x.CargaHorariaId,
                        principalTable: "CargasHorarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CargasHorarias",
                columns: new[] { "Id", "CustoBase", "QuantidadeHoras" },
                values: new object[,]
                {
                    { 1, 200.0, 20 },
                    { 2, 350.0, 40 },
                    { 3, 500.0, 60 },
                    { 4, 650.0, 80 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CargaHorariaId",
                table: "Cursos",
                column: "CargaHorariaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "CargasHorarias");
        }
    }
}
