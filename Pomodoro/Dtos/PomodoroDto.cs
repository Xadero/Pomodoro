using System;

namespace Pomodoro.Dtos
{
    public class PomodoroDto
    {
        public int PomodoroId { get; set; }

        public int PomodoroDuration { get; set; }

        public int BreakDuration { get; set; }

        public string Notes { get; set; }
        public DateTime StartDate { get; set; }

        public int? PomodoroUserId { get; set; }

        public int? PomodoroTypeId { get; set; }

        public int? PomodoroStatusId { get; set; }
    }
}
