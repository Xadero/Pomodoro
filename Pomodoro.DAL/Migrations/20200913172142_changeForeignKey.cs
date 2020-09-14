using Microsoft.EntityFrameworkCore.Migrations;

namespace Pomodoro.DAL.Migrations
{
    public partial class changeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PomodoroUserId",
                table: "PomodoroType",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PomodoroUserId",
                table: "PomodoroType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
