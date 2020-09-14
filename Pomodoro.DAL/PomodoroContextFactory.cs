using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pomodoro.DAL
{
    class PomodoroContextFactory : IDesignTimeDbContextFactory<PomodoroDbContext>
    {
        public PomodoroDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PomodoroDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Pomodoro;Trusted_Connection=True;MultipleActiveResultSets=True;");

            return new PomodoroDbContext(optionsBuilder.Options);
        }
    }
}
