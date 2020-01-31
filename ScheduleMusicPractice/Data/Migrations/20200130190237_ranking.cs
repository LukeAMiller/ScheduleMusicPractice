using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleMusicPractice.Data.Migrations
{
    public partial class ranking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    LearningMaterialId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranking_LearningMaterial_LearningMaterialId",
                        column: x => x.LearningMaterialId,
                        principalTable: "LearningMaterial",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ranking_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_LearningMaterialId",
                table: "Ranking",
                column: "LearningMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_UserId",
                table: "Ranking",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29322460-111d-41a7-8dd6-b34fcab2eda4", "AQAAAAEAACcQAAAAEIaXirxtync5Kb9xhc9yfWqeHiLR+sMTwpQm/srBJYqPr4Fa88ww4VtLkFdeF+QYRg==" });

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
    }
}
