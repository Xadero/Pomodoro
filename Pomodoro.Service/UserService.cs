using Pomodoro.DAL;
using Pomodoro.DAL.Interfaces;
using Pomodoro.DAL.Models.Pomodoro;
using Pomodoro.DAL.Models.Users;
using Pomodoro.Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pomodoro.Service
{
    public class UserService : IUserService
    {
        private PomodoroDbContext pomodoroDbContext;

        public UserService(PomodoroDbContext pomodoroDbContext)
        {
            this.pomodoroDbContext = pomodoroDbContext;
        }

        public PomodoroUser GetUserById(int id)
        {
            return pomodoroDbContext.PomodoroUser.Where(x => x.UserId == id).First();
        }

        public List<PomodoroUser> GetAllUsers()
        {
            return pomodoroDbContext.PomodoroUser.ToList();
        }

        public UserStatistics GetUserStatistics(int userId, int rangeType)
        {
            var pomodoros = new List<Pomodoros>();
            switch(rangeType)
            {
                case (int)PomodoroRange.Day:
                    pomodoros = pomodoroDbContext.Pomodoros.Where(x => x.PomodoroUserId == userId && x.StartDate.Date == DateTime.Today.Date).ToList();
                    break;
                case (int)PomodoroRange.Week:
                    var baseDate = DateTime.Today;
                    var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek).Date;
                    var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1).Date;
                    pomodoros = pomodoroDbContext.Pomodoros.Where(x => x.PomodoroUserId == userId && x.StartDate.Date >= thisWeekStart && x.StartDate.Date <= thisWeekEnd).ToList();
                    break;
                case (int)PomodoroRange.Month:
                    var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).Date;
                    pomodoros = pomodoroDbContext.Pomodoros.Where(x => x.PomodoroUserId == userId && x.StartDate.Date >= firstDayOfMonth && x.StartDate.Date <= firstDayOfMonth.AddMonths(1).AddDays(-1)).ToList();
                    break;
            }

            return new UserStatistics()
            {
                Total = pomodoros.Count,
                Completed = pomodoros.Where(x => x.PomodoroStatusId == 2).Count(),
                Canceled = pomodoros.Where(x => x.PomodoroStatusId == 3).Count()
            };
        }
    }
}
