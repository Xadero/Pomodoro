using System.ComponentModel.DataAnnotations;

namespace Pomodoro.DAL.Models.Pomodoro
{
    public class PomodoroStatus
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
