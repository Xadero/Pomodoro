using Pomodoro.DAL.Models.Users;
using System.Collections.Generic;

namespace Pomodoro.DAL.Interfaces
{
    public interface IUserService
    {
        public PomodoroUser GetUserById(int userId);

        public List<PomodoroUser> GetAllUsers();

        public UserStatistics GetUserStatistics(int userId, int rangeType);
    }
}
