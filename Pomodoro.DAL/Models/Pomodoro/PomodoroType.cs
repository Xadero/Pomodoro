using Pomodoro.DAL.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.DAL.Models.Pomodoro
{
    public class PomodoroType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        [Required]
        public string Value { get; set; }

        
        [ForeignKey("PomodoroUser")]
        public int? PomodoroUserId { get; set; }
        public virtual PomodoroUser PomodoroUser { get; set; }
    }
}
