using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleMusicPractice.Data.Migrations
{
    public partial class ReviewforSessin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinutesPracticed",
                table: "PracticeSession",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "completed",
                table: "PracticeSession",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ratethisSession",
                table: "PracticeSession",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinutesPracticed",
                table: "PracticeSession");

            migrationBuilder.DropColumn(
                name: "completed",
                table: "PracticeSession");

            migrationBuilder.DropColumn(
                name: "ratethisSession",
                table: "PracticeSession");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a9f25e0b-a26c-4d31-afe8-87a363926c72", "AQAAAAEAACcQAAAAENkvkXF4rcMfumZx3wH5bgJDyIgDBlvIludZ0pl1vtpCBBKm8/CHgTwI5AfBVsNIwQ==" });

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 1,
                column: "dateTime",
                value: new DateTime(2020, 1, 30, 14, 2, 36, 661, DateTimeKind.Local).AddTicks(3547));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 2,
                column: "dateTime",
                value: new DateTime(2020, 1, 30, 14, 2, 36, 666, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 3,
                column: "dateTime",
                value: new DateTime(2020, 1, 30, 14, 2, 36, 666, DateTimeKind.Local).AddTicks(2643));
        }
    }
}
