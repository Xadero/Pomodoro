using Pomodoro.DAL.Models.Pomodoro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pomodoro.DAL.Interfaces
{
    public interface IPomodoroService
    {
        List<PomodoroType> GetPomodoroTypes(int userId);

        List<Pomodoros> GetPomodoros(int userId);

        PomodoroSettings GetUserSettings(int userId);

        Task<Pomodoros> CreateNewPomodoro(Pomodoros pomodoro);

        Task CompletePomodoro(int pomodoroId);

        Task CancelPomodoro(int pomodoroId);

        Task<PomodoroType> CreateNewType(int userId, string value);

        Task<PomodoroSettings> UpdateSettings(PomodoroSettings settings);
    }
}
