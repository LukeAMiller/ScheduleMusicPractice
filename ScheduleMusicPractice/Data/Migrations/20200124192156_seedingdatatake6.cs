using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleMusicPractice.Data.Migrations
{
    public partial class seedingdatatake6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Instrument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LearningMaterials = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProductImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PracticeMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PracticeSession",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    dateTime = table.Column<DateTime>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false),
                    PracticeMethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracticeSession_Instrument_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PracticeSession_PracticeMethod_PracticeMethodId",
                        column: x => x.PracticeMethodId,
                        principalTable: "PracticeMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PracticeSession_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "17cbd856-8539-46a4-a7bd-85acb620639d", "admin@admin.com", true, "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEIuYBvBhfeOa7Ahu5720okqWlNOmQ7rI3jS1Re6Hr5XF2Nl0NHEKA4ZSjdLfI9UACA==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Instrument",
                columns: new[] { "Id", "Description", "LearningMaterials", "Name", "ProductImage" },
                values: new object[,]
                {
                    { 1, null, null, "Piano", null },
                    { 2, null, null, "6-string Guitar", null },
                    { 3, null, null, "Otamatone", null },
                    { 4, null, null, "Kalimba", null },
                    { 5, null, null, "Harmonica", null },
                    { 6, null, null, "Bass Guitar", null },
                    { 7, null, null, "Vocals", null }
                });

            migrationBuilder.InsertData(
                table: "PracticeMethod",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Band" },
                    { 2, "Sheet Music" },
                    { 3, "Tutor" },
                    { 4, "Jamming" },
                    { 5, "Tabs" },
                    { 6, "App" }
                });

            migrationBuilder.InsertData(
                table: "PracticeSession",
                columns: new[] { "Id", "InstrumentId", "PracticeMethodId", "UserId", "dateTime" },
                values: new object[] { 1, 1, 1, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 24, 14, 21, 55, 536, DateTimeKind.Local).AddTicks(8667) });

            migrationBuilder.InsertData(
                table: "PracticeSession",
                columns: new[] { "Id", "InstrumentId", "PracticeMethodId", "UserId", "dateTime" },
                values: new object[] { 2, 2, 2, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 24, 14, 21, 55, 540, DateTimeKind.Local).AddTicks(4981) });

            migrationBuilder.InsertData(
                table: "PracticeSession",
                columns: new[] { "Id", "InstrumentId", "PracticeMethodId", "UserId", "dateTime" },
                values: new object[] { 3, 3, 3, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 24, 14, 21, 55, 540, DateTimeKind.Local).AddTicks(5055) });

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSession_InstrumentId",
                table: "PracticeSession",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSession_PracticeMethodId",
                table: "PracticeSession",
                column: "PracticeMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSession_UserId",
                table: "PracticeSession",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PracticeSession");

            migrationBuilder.DropTable(
                name: "Instrument");

            migrationBuilder.DropTable(
                name: "PracticeMethod");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");
        }
    }
}
