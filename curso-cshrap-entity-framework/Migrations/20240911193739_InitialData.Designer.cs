﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projectef;

#nullable disable

namespace curso_cshrap_ef.Migrations
{
    [DbContext(typeof(TasksContext))]
    [Migration("20240911193739_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projectef.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c369"),
                            Description = "To do tasks",
                            Name = "Pending Tasks",
                            Weight = 10
                        },
                        new
                        {
                            CategoryId = new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c370"),
                            Description = "Already done tasks",
                            Name = "Done Tasks",
                            Weight = 30
                        });
                });

            modelBuilder.Entity("projectef.Models.ProjectTask", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("TaskPriority")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProjectTask", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c400"),
                            CategoryId = new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c369"),
                            CreationDate = new DateTime(2024, 9, 11, 15, 37, 39, 251, DateTimeKind.Local).AddTicks(4374),
                            Description = "Custom Description",
                            TaskPriority = 1,
                            Title = "Cook dinner"
                        },
                        new
                        {
                            TaskId = new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c401"),
                            CategoryId = new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c370"),
                            CreationDate = new DateTime(2024, 9, 11, 15, 37, 39, 251, DateTimeKind.Local).AddTicks(4387),
                            Description = "Custom Description",
                            TaskPriority = 2,
                            Title = "Feed the cat"
                        });
                });

            modelBuilder.Entity("projectef.Models.ProjectTask", b =>
                {
                    b.HasOne("projectef.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("projectef.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
