using Microsoft.EntityFrameworkCore.Migrations;

namespace Pomodoro.DAL.Migrations
{
    public partial class changeForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoros_PomodoroStatus_PomodoroStatusId",
                table: "Pomodoros");

            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoros_PomodoroType_PomodoroTypeId",
                table: "Pomodoros");

            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoros_PomodoroUser_PomodoroUserId",
                table: "Pomodoros");

            migrationBuilder.DropForeignKey(
                name: "FK_PomodoroSettings_PomodoroUser_PomodoroUserId",
                table: "PomodoroSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_PomodoroType_PomodoroUser_PomodoroUserId",
                table: "PomodoroType");

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroUserId",
                table: "PomodoroSettings",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroUserId",
                table: "Pomodoros",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroTypeId",
                table: "Pomodoros",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroStatusId",
                table: "Pomodoros",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoros_PomodoroStatus_PomodoroStatusId",
                table: "Pomodoros",
                column: "PomodoroStatusId",
                principalTable: "PomodoroStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoros_PomodoroType_PomodoroTypeId",
                table: "Pomodoros",
                column: "PomodoroTypeId",
                principalTable: "PomodoroType",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoros_PomodoroUser_PomodoroUserId",
                table: "Pomodoros",
                column: "PomodoroUserId",
                principalTable: "PomodoroUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PomodoroSettings_PomodoroUser_PomodoroUserId",
                table: "PomodoroSettings",
                column: "PomodoroUserId",
                principalTable: "PomodoroUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PomodoroType_PomodoroUser_PomodoroUserId",
                table: "PomodoroType",
                column: "PomodoroUserId",
                principalTable: "PomodoroUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoros_PomodoroStatus_PomodoroStatusId",
                table: "Pomodoros");

            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoros_PomodoroType_PomodoroTypeId",
                table: "Pomodoros");

            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoros_PomodoroUser_PomodoroUserId",
                table: "Pomodoros");

            migrationBuilder.DropForeignKey(
                name: "FK_PomodoroSettings_PomodoroUser_PomodoroUserId",
                table: "PomodoroSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_PomodoroType_PomodoroUser_PomodoroUserId",
                table: "PomodoroType");

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroUserId",
                table: "PomodoroSettings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroUserId",
                table: "Pomodoros",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroTypeId",
                table: "Pomodoros",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroStatusId",
                table: "Pomodoros",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoros_PomodoroStatus_PomodoroStatusId",
                table: "Pomodoros",
                column: "PomodoroStatusId",
                principalTable: "PomodoroStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoros_PomodoroType_PomodoroTypeId",
                table: "Pomodoros",
                column: "PomodoroTypeId",
                principalTable: "PomodoroType",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoros_PomodoroUser_PomodoroUserId",
                table: "Pomodoros",
                column: "PomodoroUserId",
                principalTable: "PomodoroUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PomodoroSettings_PomodoroUser_PomodoroUserId",
                table: "PomodoroSettings",
                column: "PomodoroUserId",
                principalTable: "PomodoroUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PomodoroType_PomodoroUser_PomodoroUserId",
                table: "PomodoroType",
                column: "PomodoroUserId",
                principalTable: "PomodoroUser",
                principalColumn: "UserId");
        }
    }
}
