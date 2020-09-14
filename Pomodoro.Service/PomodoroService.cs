using Pomodoro.DAL;
using Pomodoro.DAL.Interfaces;
using Pomodoro.DAL.Models.Pomodoro;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Pomodoro.Service
{
    public class PomodoroService : IPomodoroService
    {
        private readonly PomodoroDbContext pomodoroDbContext;

        public PomodoroService (PomodoroDbContext pomodoroDbContext)
        {
            this.pomodoroDbContext = pomodoroDbContext;
        }

        public List<PomodoroType> GetPomodoroTypes(int userId)
        {
            return pomodoroDbContext.PomodoroType.Where(x=> x.PomodoroUser.UserId == userId).Include(x => x.PomodoroUser).ToList();
        }

        public List<Pomodoros> GetPomodoros(int userId)
        {
            return pomodoroDbContext.Pomodoros.Where(x => x.PomodoroUser.UserId == userId).Include(x => x.PomodoroStatus).Include(x => x.PomodoroType).ToList();
        }

        public PomodoroSettings GetUserSettings(int userId)
        {
            return pomodoroDbContext.PomodoroSettings.Where(x => x.PomodoroUser.UserId == userId).Include(x => x.PomodoroUser).First();
        }

        public async Task<Pomodoros> CreateNewPomodoro(Pomodoros pomodoro)
        {
            pomodoro.PomodoroStatusId = (int)Enums.PomodoroStatus.InProgress;
            pomodoro.StartDate = DateTime.Now;
            await pomodoroDbContext.Pomodoros.AddAsync(pomodoro);
            await pomodoroDbContext.SaveChangesAsync();

            return pomodoro;
        }

        public async Task CompletePomodoro(int pomodoroId)
        {
            pomodoroDbContext.Pomodoros.Where(x => x.PomodoroId == pomodoroId).FirstOrDefault().PomodoroStatusId = (int)Enums.PomodoroStatus.Completed;
            await pomodoroDbContext.SaveChangesAsync();
        }

        public async Task CancelPomodoro(int pomodoroId)
        {
            pomodoroDbContext.Pomodoros.Where(x => x.PomodoroId == pomodoroId).FirstOrDefault().PomodoroStatusId = (int)Enums.PomodoroStatus.Canceled;
            await pomodoroDbContext.SaveChangesAsync();
        }

        public async Task<PomodoroType> CreateNewType (int userId, string value)
        {
            var pomodoroType = new PomodoroType()
            {
                PomodoroUserId = userId,
                Value = value
            };
            pomodoroDbContext.PomodoroType.Add(pomodoroType);
            await pomodoroDbContext.SaveChangesAsync();

            return pomodoroType;
        }

        public async Task<PomodoroSettings> UpdateSettings(PomodoroSettings settings)
        {
            var newSettings = pomodoroDbContext.PomodoroSettings.Where(x => x.PomodoroUserId == settings.PomodoroUserId).FirstOrDefault();
            newSettings.BreakDuration = settings.BreakDuration;
            newSettings.PomodoroDuration = settings.PomodoroDuration;
            await pomodoroDbContext.SaveChangesAsync();

            return newSettings;
        }
    }
}
