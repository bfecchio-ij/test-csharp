using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRS.INFO.Migrations
{
    public partial class info01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidatesExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatesExperiences_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "BirthDate", "Email", "InsertDate", "ModifyDate", "Name", "Surname" },
                values: new object[] { 1, new DateTime(2000, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@gmail.com", new DateTime(2022, 6, 23, 18, 30, 39, 871, DateTimeKind.Local).AddTicks(6950), new DateTime(2022, 6, 23, 18, 30, 39, 871, DateTimeKind.Local).AddTicks(6950), "John", "Lee" });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "BirthDate", "Email", "InsertDate", "ModifyDate", "Name", "Surname" },
                values: new object[] { 2, new DateTime(1990, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "anne@gmail.com", new DateTime(2022, 6, 23, 18, 30, 39, 873, DateTimeKind.Local).AddTicks(4589), new DateTime(2022, 6, 23, 18, 30, 39, 873, DateTimeKind.Local).AddTicks(4589), "Anne", "Moraes" });

            migrationBuilder.InsertData(
                table: "CandidatesExperiences",
                columns: new[] { "Id", "BeginDate", "CandidateId", "Company", "Description", "EndDate", "InsertDate", "Job", "ModifyDate", "Salary" },
                values: new object[] { 3, new DateTime(2010, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Apple", "specify and delegate tasks", new DateTime(2012, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 23, 18, 30, 39, 878, DateTimeKind.Local).AddTicks(4678), "Scrum master", new DateTime(2022, 6, 23, 18, 30, 39, 878, DateTimeKind.Local).AddTicks(4678), 1888.2m });

            migrationBuilder.InsertData(
                table: "CandidatesExperiences",
                columns: new[] { "Id", "BeginDate", "CandidateId", "Company", "Description", "EndDate", "InsertDate", "Job", "ModifyDate", "Salary" },
                values: new object[] { 4, new DateTime(2011, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "InfoJobs", "Develop new solutions", new DateTime(2012, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 23, 18, 30, 39, 878, DateTimeKind.Local).AddTicks(7958), "Developer", new DateTime(2022, 6, 23, 18, 30, 39, 878, DateTimeKind.Local).AddTicks(7958), 2800.2m });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesExperiences_CandidateId",
                table: "CandidatesExperiences",
                column: "CandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatesExperiences");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
