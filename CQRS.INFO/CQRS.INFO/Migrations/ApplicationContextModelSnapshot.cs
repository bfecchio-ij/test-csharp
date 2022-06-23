﻿// <auto-generated />
using System;
using CQRS.INFO.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CQRS.INFO.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CQRS.INFO.Models.Entities.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2000, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john@gmail.com",
                            InsertDate = new DateTime(2022, 6, 23, 18, 30, 39, 871, DateTimeKind.Local).AddTicks(6950),
                            ModifyDate = new DateTime(2022, 6, 23, 18, 30, 39, 871, DateTimeKind.Local).AddTicks(6950),
                            Name = "John",
                            Surname = "Lee"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1990, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "anne@gmail.com",
                            InsertDate = new DateTime(2022, 6, 23, 18, 30, 39, 873, DateTimeKind.Local).AddTicks(4589),
                            ModifyDate = new DateTime(2022, 6, 23, 18, 30, 39, 873, DateTimeKind.Local).AddTicks(4589),
                            Name = "Anne",
                            Surname = "Moraes"
                        });
                });

            modelBuilder.Entity("CQRS.INFO.Models.Entities.CandidateExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Salary")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("CandidatesExperiences");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            BeginDate = new DateTime(2010, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CandidateId = 1,
                            Company = "Apple",
                            Description = "specify and delegate tasks",
                            EndDate = new DateTime(2012, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InsertDate = new DateTime(2022, 6, 23, 18, 30, 39, 878, DateTimeKind.Local).AddTicks(4678),
                            Job = "Scrum master",
                            ModifyDate = new DateTime(2022, 6, 23, 18, 30, 39, 878, DateTimeKind.Local).AddTicks(4678),
                            Salary = 1888.2m
                        },
                        new
                        {
                            Id = 4,
                            BeginDate = new DateTime(2011, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CandidateId = 2,
                            Company = "InfoJobs",
                            Description = "Develop new solutions",
                            EndDate = new DateTime(2012, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InsertDate = new DateTime(2022, 6, 23, 18, 30, 39, 878, DateTimeKind.Local).AddTicks(7958),
                            Job = "Developer",
                            ModifyDate = new DateTime(2022, 6, 23, 18, 30, 39, 878, DateTimeKind.Local).AddTicks(7958),
                            Salary = 2800.2m
                        });
                });

            modelBuilder.Entity("CQRS.INFO.Models.Entities.CandidateExperience", b =>
                {
                    b.HasOne("CQRS.INFO.Models.Entities.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });
#pragma warning restore 612, 618
        }
    }
}
