using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleMusicPractice.Data.Migrations
{
    public partial class http : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29322460-111d-41a7-8dd6-b34fcab2eda4", "AQAAAAEAACcQAAAAEIaXirxtync5Kb9xhc9yfWqeHiLR+sMTwpQm/srBJYqPr4Fa88ww4VtLkFdeF+QYRg==" });

            migrationBuilder.UpdateData(
                table: "LearningMaterial",
                keyColumn: "id",
                keyValue: 1,
                column: "Name",
                value: "http://www.flowkey.com");

            migrationBuilder.UpdateData(
                table: "LearningMaterial",
                keyColumn: "id",
                keyValue: 2,
                column: "Name",
                value: "http://www.simplypiano.com");

            migrationBuilder.UpdateData(
                table: "LearningMaterial",
                keyColumn: "id",
                keyValue: 3,
                column: "Name",
                value: "http://www.yousician.com");

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 1,
                column: "dateTime",
                value: new DateTime(2020, 1, 29, 14, 36, 45, 365, DateTimeKind.Local).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 2,
                column: "dateTime",
                value: new DateTime(2020, 1, 29, 14, 36, 45, 371, DateTimeKind.Local).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 3,
                column: "dateTime",
                value: new DateTime(2020, 1, 29, 14, 36, 45, 371, DateTimeKind.Local).AddTicks(1209));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dfbbb45e-13a3-4256-ade1-59f190cea4d0", "AQAAAAEAACcQAAAAEB5OM0syzVqvkRjOiawnpE+1/M65AFkzINy3uM1eud82NTXKtofe0EtS1d/vogBBcw==" });

            migrationBuilder.UpdateData(
                table: "LearningMaterial",
                keyColumn: "id",
                keyValue: 1,
                column: "Name",
                value: "www.flowkey.com");

            migrationBuilder.UpdateData(
                table: "LearningMaterial",
                keyColumn: "id",
                keyValue: 2,
                column: "Name",
                value: "www.simplypiano.com");

            migrationBuilder.UpdateData(
                table: "LearningMaterial",
                keyColumn: "id",
                keyValue: 3,
                column: "Name",
                value: "www.yousician.com");

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 1,
                column: "dateTime",
                value: new DateTime(2020, 1, 29, 13, 35, 28, 658, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 2,
                column: "dateTime",
                value: new DateTime(2020, 1, 29, 13, 35, 28, 662, DateTimeKind.Local).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 3,
                column: "dateTime",
                value: new DateTime(2020, 1, 29, 13, 35, 28, 662, DateTimeKind.Local).AddTicks(990));
        }
    }
}
