using Pomodoro.DAL;
using Pomodoro.DAL.Interfaces;

namespace Pomodoro.Service
{
    public class DictionaryService : IDictionaryService
    {
        private readonly PomodoroDbContext pomodoroDbContext;

        public DictionaryService(PomodoroDbContext pomodoroDbContext)
        {
            this.pomodoroDbContext = pomodoroDbContext;
        }
        public T Get<T>(int id) where T : class
        {
            return pomodoroDbContext.Set<T>().Find(id);
        }
    }
}
