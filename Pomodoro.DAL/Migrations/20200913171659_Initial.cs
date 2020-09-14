using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pomodoro.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PomodoroStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PomodoroStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PomodoroUser",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PomodoroUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "PomodoroSettings",
                columns: table => new
                {
                    SettingsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PomodoroDuration = table.Column<int>(nullable: false),
                    BreakDuration = table.Column<int>(nullable: false),
                    PomodoroUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PomodoroSettings", x => x.SettingsId);
                    table.ForeignKey(
                        name: "FK_PomodoroSettings_PomodoroUser_PomodoroUserId",
                        column: x => x.PomodoroUserId,
                        principalTable: "PomodoroUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PomodoroType",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    PomodoroUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PomodoroType", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_PomodoroType_PomodoroUser_PomodoroUserId",
                        column: x => x.PomodoroUserId,
                        principalTable: "PomodoroUser",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Pomodoros",
                columns: table => new
                {
                    PomodoroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PomodoroDuration = table.Column<int>(nullable: false),
                    BreakDuration = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    PomodoroUserId = table.Column<int>(nullable: false),
                    PomodoroTypeId = table.Column<int>(nullable: false),
                    PomodoroStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pomodoros", x => x.PomodoroId);
                    table.ForeignKey(
                        name: "FK_Pomodoros_PomodoroStatus_PomodoroStatusId",
                        column: x => x.PomodoroStatusId,
                        principalTable: "PomodoroStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pomodoros_PomodoroType_PomodoroTypeId",
                        column: x => x.PomodoroTypeId,
                        principalTable: "PomodoroType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pomodoros_PomodoroUser_PomodoroUserId",
                        column: x => x.PomodoroUserId,
                        principalTable: "PomodoroUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pomodoros_PomodoroStatusId",
                table: "Pomodoros",
                column: "PomodoroStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Pomodoros_PomodoroTypeId",
                table: "Pomodoros",
                column: "PomodoroTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pomodoros_PomodoroUserId",
                table: "Pomodoros",
                column: "PomodoroUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PomodoroSettings_PomodoroUserId",
                table: "PomodoroSettings",
                column: "PomodoroUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PomodoroType_PomodoroUserId",
                table: "PomodoroType",
                column: "PomodoroUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pomodoros");

            migrationBuilder.DropTable(
                name: "PomodoroSettings");

            migrationBuilder.DropTable(
                name: "PomodoroStatus");

            migrationBuilder.DropTable(
                name: "PomodoroType");

            migrationBuilder.DropTable(
                name: "PomodoroUser");
        }
    }
}
