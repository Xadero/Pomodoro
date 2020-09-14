using Pomodoro.DAL.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.DAL.Models.Pomodoro
{
    public class PomodoroSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SettingsId { get; set; }

        [Required]
        public int PomodoroDuration { get; set; }
        
        [Required]
        public int BreakDuration { get; set; }

        [ForeignKey("PomodoroUser")]
        public int? PomodoroUserId { get; set; }
        public virtual PomodoroUser PomodoroUser { get; set; }
    }
}
