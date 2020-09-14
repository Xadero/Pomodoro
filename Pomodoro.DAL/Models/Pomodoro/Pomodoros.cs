using Pomodoro.DAL.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.DAL.Models.Pomodoro
{
    public class Pomodoros
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PomodoroId { get; set; }

        [Required]

        public int PomodoroDuration { get; set; }

        [Required]
        public int BreakDuration { get; set; }

        public string Notes { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [ForeignKey("PomodoroUser")]
        public int? PomodoroUserId { get; set; }
        public virtual PomodoroUser PomodoroUser { get; set; }

        [ForeignKey("PomodoroType")]
        public int? PomodoroTypeId { get; set; }
        public virtual PomodoroType PomodoroType { get; set; }

        [ForeignKey("PomodoroStatus")]
        public int? PomodoroStatusId { get; set; }
        public virtual PomodoroStatus PomodoroStatus { get; set; }
    }
}
