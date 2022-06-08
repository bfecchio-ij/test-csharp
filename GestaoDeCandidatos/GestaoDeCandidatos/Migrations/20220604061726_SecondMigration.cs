using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeCandidatos.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidateexperiences_candidates_ExperiencesIdCandidate",
                table: "candidateexperiences");

            migrationBuilder.DropIndex(
                name: "IX_candidateexperiences_ExperiencesIdCandidate",
                table: "candidateexperiences");

            migrationBuilder.DropColumn(
                name: "ExperiencesIdCandidate",
                table: "candidateexperiences");

            migrationBuilder.CreateIndex(
                name: "IX_candidateexperiences_IdCandidate",
                table: "candidateexperiences",
                column: "IdCandidate");

            migrationBuilder.AddForeignKey(
                name: "FK_candidateexperiences_candidates_IdCandidate",
                table: "candidateexperiences",
                column: "IdCandidate",
                principalTable: "candidates",
                principalColumn: "IdCandidate",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidateexperiences_candidates_IdCandidate",
                table: "candidateexperiences");

            migrationBuilder.DropIndex(
                name: "IX_candidateexperiences_IdCandidate",
                table: "candidateexperiences");

            migrationBuilder.AddColumn<int>(
                name: "ExperiencesIdCandidate",
                table: "candidateexperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_candidateexperiences_ExperiencesIdCandidate",
                table: "candidateexperiences",
                column: "ExperiencesIdCandidate");

            migrationBuilder.AddForeignKey(
                name: "FK_candidateexperiences_candidates_ExperiencesIdCandidate",
                table: "candidateexperiences",
                column: "ExperiencesIdCandidate",
                principalTable: "candidates",
                principalColumn: "IdCandidate",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
