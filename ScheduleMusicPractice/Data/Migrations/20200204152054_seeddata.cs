using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleMusicPractice.Data.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RankingLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankingId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankingLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RankingLevel_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RankingLevel_Ranking_RankingId",
                        column: x => x.RankingId,
                        principalTable: "Ranking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b16fb1c-cd94-47a1-a9d4-d6ff8466d777", "AQAAAAEAACcQAAAAEM4lnPlXuAeL6exUhysDh+3BqdfCUv5INavafXsQtyU3TRcPF9MTKNq+NSR1uVpVWw==" });

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 1,
                column: "dateTime",
                value: new DateTime(2020, 2, 4, 10, 20, 53, 859, DateTimeKind.Local).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 2,
                column: "dateTime",
                value: new DateTime(2020, 2, 4, 10, 20, 53, 864, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 3,
                column: "dateTime",
                value: new DateTime(2020, 2, 4, 10, 20, 53, 864, DateTimeKind.Local).AddTicks(9301));

            migrationBuilder.CreateIndex(
                name: "IX_RankingLevel_LevelId",
                table: "RankingLevel",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_RankingLevel_RankingId",
                table: "RankingLevel",
                column: "RankingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RankingLevel");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "837424ed-97aa-4d2c-bc82-6728d47b46a9", "AQAAAAEAACcQAAAAEEqHVx9bRhM7/Cq7/SDqpfRvUww/tTtk07SLe7CtdGHEdybZm4qH5ioVTRZ/jmPfFA==" });

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
    }
}
