using AutoMapper;
using Pomodoro.DAL.Models.Pomodoro;
using Pomodoro.DAL.Models.Users;
using Pomodoro.Dtos;

namespace Pomodoro.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<PomodoroUserDto, PomodoroUser>();
            CreateMap<PomodoroUser, PomodoroUserDto>();

            CreateMap<UserStatistics, UserStatisticsDto>();
        }
    }
}
