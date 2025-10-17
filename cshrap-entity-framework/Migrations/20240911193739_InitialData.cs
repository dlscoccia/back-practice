using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace curso_cshrap_ef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c369"), "To do tasks", "Pending Tasks", 10 },
                    { new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c370"), "Already done tasks", "Done Tasks", 30 }
                });

            migrationBuilder.InsertData(
                table: "ProjectTask",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "TaskPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c400"), new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c369"), new DateTime(2024, 9, 11, 15, 37, 39, 251, DateTimeKind.Local).AddTicks(4374), "Custom Description", 1, "Cook dinner" },
                    { new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c401"), new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c370"), new DateTime(2024, 9, 11, 15, 37, 39, 251, DateTimeKind.Local).AddTicks(4387), "Custom Description", 2, "Feed the cat" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectTask",
                keyColumn: "TaskId",
                keyValue: new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c400"));

            migrationBuilder.DeleteData(
                table: "ProjectTask",
                keyColumn: "TaskId",
                keyValue: new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c401"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c369"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("d7af7863-3c92-41b0-9c09-9ccc2e60c370"));
        }
    }
}
