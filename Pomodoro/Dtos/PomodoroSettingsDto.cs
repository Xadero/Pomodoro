namespace Pomodoro.Dtos
{
    public class PomodoroSettingsDto
    {
        public int SettingsId { get; set; }

        public int PomodoroDuration { get; set; }

        public int BreakDuration { get; set; }

        public int? PomodoroUserId { get; set; }
    }
}
