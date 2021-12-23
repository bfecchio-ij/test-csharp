using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Golnich.RH.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    IdCandidato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Sobrenome = table.Column<string>(maxLength: 150, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    DataCad = table.Column<DateTime>(nullable: false),
                    DataAtu = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.IdCandidato);
                });

            migrationBuilder.CreateTable(
                name: "Experiencias",
                columns: table => new
                {
                    IdExperiencia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCandidato = table.Column<int>(nullable: false),
                    Empresa = table.Column<int>(maxLength: 100, nullable: false),
                    Cargo = table.Column<int>(maxLength: 100, nullable: false),
                    Descricao = table.Column<int>(maxLength: 4000, nullable: false),
                    Salario = table.Column<decimal>(type: "numeric(18, 2)", nullable: false),
                    DataInicio = table.Column<int>(nullable: false),
                    DataSaida = table.Column<int>(nullable: false),
                    DataCad = table.Column<int>(nullable: false),
                    DataAtu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiencias", x => x.IdExperiencia);
                    table.ForeignKey(
                        name: "FK_Experiencias_Candidatos_IdCandidato",
                        column: x => x.IdCandidato,
                        principalTable: "Candidatos",
                        principalColumn: "IdCandidato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiencias_IdCandidato",
                table: "Experiencias",
                column: "IdCandidato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiencias");

            migrationBuilder.DropTable(
                name: "Candidatos");
        }
    }
}
