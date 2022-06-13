using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test_csharp.Migrations.CandidateExperiencesRepoMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidatesModel",
                columns: table => new
                {
                    IdCandidate = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesModel", x => x.IdCandidate);
                });

            migrationBuilder.CreateTable(
                name: "candidateexperiences",
                columns: table => new
                {
                    IdCandidateExperience = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCandidates = table.Column<int>(nullable: false),
                    CandidatesModelIdCandidate = table.Column<int>(nullable: true),
                    Company = table.Column<string>(type: "varchar(100)", nullable: true),
                    Job = table.Column<string>(type: "varchar(100)", nullable: true),
                    Description = table.Column<string>(type: "varchar(4000)", nullable: true),
                    Salary = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidateexperiences", x => x.IdCandidateExperience);
                    table.ForeignKey(
                        name: "FK_candidateexperiences_CandidatesModel_CandidatesModelIdCandidate",
                        column: x => x.CandidatesModelIdCandidate,
                        principalTable: "CandidatesModel",
                        principalColumn: "IdCandidate",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidateexperiences_CandidatesModelIdCandidate",
                table: "candidateexperiences",
                column: "CandidatesModelIdCandidate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidateexperiences");

            migrationBuilder.DropTable(
                name: "CandidatesModel");
        }
    }
}
