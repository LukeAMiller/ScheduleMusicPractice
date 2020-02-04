using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleMusicPractice.Data.Migrations
{
    public partial class levels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "96d51324-f15d-4c49-98b3-09279ff4c5d4", "AQAAAAEAACcQAAAAEOHJn8aHYNDrOEE0TwvLtwuBTk58WxFrS1FFs09ei1uxnHPW7eTNG/rsmARoP2gMfQ==" });

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 1,
                column: "dateTime",
                value: new DateTime(2020, 1, 31, 10, 23, 15, 814, DateTimeKind.Local).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 2,
                column: "dateTime",
                value: new DateTime(2020, 1, 31, 10, 23, 15, 817, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 3,
                column: "dateTime",
                value: new DateTime(2020, 1, 31, 10, 23, 15, 817, DateTimeKind.Local).AddTicks(6668));
        }
    }
}
