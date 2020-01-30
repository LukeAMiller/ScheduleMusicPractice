using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleMusicPractice.Data.Migrations
{
    public partial class learningmaterials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LearningMaterials",
                table: "Instrument");

            migrationBuilder.CreateTable(
                name: "LearningMaterial",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    InstrumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningMaterial", x => x.id);
                    table.ForeignKey(
                        name: "FK_LearningMaterial_Instrument_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dfbbb45e-13a3-4256-ade1-59f190cea4d0", "AQAAAAEAACcQAAAAEB5OM0syzVqvkRjOiawnpE+1/M65AFkzINy3uM1eud82NTXKtofe0EtS1d/vogBBcw==" });

            migrationBuilder.InsertData(
                table: "LearningMaterial",
                columns: new[] { "id", "InstrumentId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "www.flowkey.com" },
                    { 2, 1, "www.simplypiano.com" },
                    { 3, 2, "www.yousician.com" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterial_InstrumentId",
                table: "LearningMaterial",
                column: "InstrumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningMaterial");

            migrationBuilder.AddColumn<string>(
                name: "LearningMaterials",
                table: "Instrument",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17cbd856-8539-46a4-a7bd-85acb620639d", "AQAAAAEAACcQAAAAEIuYBvBhfeOa7Ahu5720okqWlNOmQ7rI3jS1Re6Hr5XF2Nl0NHEKA4ZSjdLfI9UACA==" });

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 1,
                column: "dateTime",
                value: new DateTime(2020, 1, 24, 14, 21, 55, 536, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 2,
                column: "dateTime",
                value: new DateTime(2020, 1, 24, 14, 21, 55, 540, DateTimeKind.Local).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "PracticeSession",
                keyColumn: "Id",
                keyValue: 3,
                column: "dateTime",
                value: new DateTime(2020, 1, 24, 14, 21, 55, 540, DateTimeKind.Local).AddTicks(5055));
        }
    }
}
