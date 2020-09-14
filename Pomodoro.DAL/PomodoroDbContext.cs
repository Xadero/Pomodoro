using Microsoft.EntityFrameworkCore;
using Pomodoro.DAL.Models.Pomodoro;
using Pomodoro.DAL.Models.Users;

namespace Pomodoro.DAL
{
    public class PomodoroDbContext : DbContext
    {
        public PomodoroDbContext(DbContextOptions<PomodoroDbContext> options) : base(options) { }

        public DbSet<PomodoroUser> PomodoroUser { get; set; }

        public DbSet<PomodoroStatus> PomodoroStatus { get; set; }

        public DbSet<PomodoroType> PomodoroType { get; set; }

        public DbSet<PomodoroSettings> PomodoroSettings { get; set; }

        public DbSet<Pomodoros> Pomodoros { get; set; }
    }
}
