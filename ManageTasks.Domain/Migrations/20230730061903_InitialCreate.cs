using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManageTasks.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Task",
                schema: "dbo",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TaskAction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Task",
                columns: new[] { "TaskId", "Created", "Status", "TaskAction" },
                values: new object[,]
                {
                    { new Guid("24e01e15-3f23-49e0-b177-0b325ec2af9c"), new DateTimeOffset(new DateTime(2023, 7, 17, 19, 27, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 0, "Meditar en la noche" },
                    { new Guid("49cf31ba-32dc-4ded-817c-f9b5c71c968c"), new DateTimeOffset(new DateTime(2023, 7, 28, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, "Pasear a mi Pit Bull" },
                    { new Guid("5d84ed88-8078-4825-b740-02bd71d5346a"), new DateTimeOffset(new DateTime(2023, 5, 11, 15, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 0, "Tocar la guitarra" },
                    { new Guid("a9741f3a-baea-4211-90de-f2fa53c9caa2"), new DateTimeOffset(new DateTime(2023, 6, 8, 10, 42, 10, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 0, "Practicar la calistenia" },
                    { new Guid("ef839c0b-0e57-4bbe-be29-be1c501e82bb"), new DateTimeOffset(new DateTime(2023, 7, 1, 12, 0, 44, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, "Leer \"Menos miedos más Riquezas\"" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task",
                schema: "dbo");
        }
    }
}
