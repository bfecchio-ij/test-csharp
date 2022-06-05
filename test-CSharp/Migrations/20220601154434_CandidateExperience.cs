using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_CSharp.Migrations
{
    public partial class CandidateExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateExperiences",
                columns: table => new
                {
                    IdCandidateExperience = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCandidate = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Job = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateExperiences", x => x.IdCandidateExperience);
                    table.ForeignKey(
                        name: "FK_CandidateExperiences_Candidates_IdCandidate",
                        column: x => x.IdCandidate,
                        principalTable: "Candidates",
                        principalColumn: "IdCandidate",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExperiences_IdCandidate",
                table: "CandidateExperiences",
                column: "IdCandidate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateExperiences");
        }
    }
}
