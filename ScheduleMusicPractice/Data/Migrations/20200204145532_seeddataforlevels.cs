using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleMusicPractice.Data.Migrations
{
    public partial class seeddataforlevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "837424ed-97aa-4d2c-bc82-6728d47b46a9", "AQAAAAEAACcQAAAAEEqHVx9bRhM7/Cq7/SDqpfRvUww/tTtk07SLe7CtdGHEdybZm4qH5ioVTRZ/jmPfFA==" });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Beginner" },
                    { 2, "Intermediate" },
                    { 3, "Advanced" },
                    { 4, "Pro" }
                });

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 1,
                column: "dateTime",
                value: new DateTime(2020, 2, 4, 9, 55, 31, 788, DateTimeKind.Local).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 2,
                column: "dateTime",
                value: new DateTime(2020, 2, 4, 9, 55, 31, 794, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 3,
                column: "dateTime",
                value: new DateTime(2020, 2, 4, 9, 55, 31, 794, DateTimeKind.Local).AddTicks(5619));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "461c88aa-68f4-4c75-9d2a-2be856533228", "AQAAAAEAACcQAAAAEMz9Wz3zMxPBvkKvbyW7Ajh1LCjXIXkYHvWpD8V5pIHNiTWpSbAKbVWYJuwypkCY+g==" });

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 1,
                column: "dateTime",
                value: new DateTime(2020, 2, 4, 9, 45, 37, 110, DateTimeKind.Local).AddTicks(2901));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 2,
                column: "dateTime",
                value: new DateTime(2020, 2, 4, 9, 45, 37, 113, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 3,
                column: "dateTime",
                value: new DateTime(2020, 2, 4, 9, 45, 37, 113, DateTimeKind.Local).AddTicks(9262));
        }
    }
}
