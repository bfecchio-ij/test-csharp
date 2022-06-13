using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test_csharp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidates",
                columns: table => new
                {
                    IdCandidate = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    Surname = table.Column<string>(type: "varchar(150)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidates", x => x.IdCandidate);
                });

            migrationBuilder.CreateTable(
                name: "CandidateExperiencesModel",
                columns: table => new
                {
                    IdCandidateExperience = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCandidates = table.Column<int>(nullable: false),
                    CandidatesModelIdCandidate = table.Column<int>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateExperiencesModel", x => x.IdCandidateExperience);
                    table.ForeignKey(
                        name: "FK_CandidateExperiencesModel_candidates_CandidatesModelIdCandidate",
                        column: x => x.CandidatesModelIdCandidate,
                        principalTable: "candidates",
                        principalColumn: "IdCandidate",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExperiencesModel_CandidatesModelIdCandidate",
                table: "CandidateExperiencesModel",
                column: "CandidatesModelIdCandidate");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_Email",
                table: "candidates",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateExperiencesModel");

            migrationBuilder.DropTable(
                name: "candidates");
        }
    }
}
